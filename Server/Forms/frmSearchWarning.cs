using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using xServer.Core.Packets.ServerPackets;

namespace xServer.Forms
{
    public enum WarningChoice
    {
        Cancel,
        Search
    }

    public partial class FrmSearchWarning : Form
    {
        public WarningChoice Choice { get; set; }

        public int Timeout { get; set; }

        public TimeoutType Type { get; set; }

        public FrmSearchWarning()
        {
            InitializeComponent();
            Choice = WarningChoice.Cancel;
            Timeout = -1;
            Type = TimeoutType.Milliseconds;
        }

        private void frmSearchWarning_Load(object sender, EventArgs e)
        {
            cbTime.SelectedIndex = 1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Choice = WarningChoice.Search;
            this.Timeout = (int)numTimeoutVal.Value;
            this.Type = (TimeoutType) cbTime.SelectedIndex;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
