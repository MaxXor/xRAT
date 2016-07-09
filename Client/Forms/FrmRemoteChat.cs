using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using xClient.Core.Helper;
using xClient.Core.Networking;
using xClient.Core.Utilities;

namespace xClient.Forms
{
    public partial class FrmRemoteChat : Form
    {
        private Client _connectedClient;
        public bool Active;

        public FrmRemoteChat(Client client)
        {
            this._connectedClient = client;
            InitializeComponent();
            Active = true;

        }

        public void AddMessage(string sender, string message)
        {
            txtMessages.AppendText(string.Format("{0} {1}: {2}{3}", DateTime.Now.ToString("HH:mm:ss"), sender, message, Environment.NewLine));
            ForceFocus();
        }

        private void FrmRemoteChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(Active)
                e.Cancel = true;
        }

        /// <summary>
        /// Method used for hiding the form from task manager
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x80;
                return cp;
            }
        }

        private void FrmRemoteChat_Shown(object sender, EventArgs e)
        {
            ForceFocus();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if(txtMessage.Text.Trim() != "")
            {
                new xClient.Core.Packets.ServerPackets.DoChatMessage(txtMessage.Text.Trim()).Execute(_connectedClient);
                AddMessage("Me", txtMessage.Text.Trim());
                txtMessage.Text = "";
                txtMessage.Focus();
            }
        }

        public void ForceFocus()
        {
            var fThread = NativeMethods.GetWindowThreadProcessId(NativeMethods.GetForegroundWindow(), IntPtr.Zero);
            var cThread = NativeMethods.GetCurrentThreadId();
            if (fThread != cThread)
            {
                NativeMethods.AttachThreadInput(fThread, cThread, true);
                NativeMethods.BringWindowToTop(Handle);
                NativeMethods.AttachThreadInput(fThread, cThread, false);
            }
            else NativeMethods.BringWindowToTop(Handle);
            txtMessage.Focus();
        }
    }
}
