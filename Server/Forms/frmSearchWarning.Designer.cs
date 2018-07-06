namespace xServer.Forms
{
    partial class FrmSearchWarning
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtWarning = new System.Windows.Forms.TextBox();
            this.numTimeoutVal = new System.Windows.Forms.NumericUpDown();
            this.lblTimeout = new System.Windows.Forms.Label();
            this.cbTime = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeoutVal)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtWarning
            // 
            this.txtWarning.Location = new System.Drawing.Point(11, 19);
            this.txtWarning.Multiline = true;
            this.txtWarning.Name = "txtWarning";
            this.txtWarning.ReadOnly = true;
            this.txtWarning.Size = new System.Drawing.Size(296, 64);
            this.txtWarning.TabIndex = 0;
            this.txtWarning.Text = "Using search pattern \"*.*\" recursively may make the application unresponsive duri" +
    "ng the search. Please consider narrowing down the search pattern or set an appro" +
    "priate search timeout.";
            this.txtWarning.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numTimeoutVal
            // 
            this.numTimeoutVal.Location = new System.Drawing.Point(98, 89);
            this.numTimeoutVal.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numTimeoutVal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTimeoutVal.Name = "numTimeoutVal";
            this.numTimeoutVal.Size = new System.Drawing.Size(100, 20);
            this.numTimeoutVal.TabIndex = 1;
            this.numTimeoutVal.Value = new decimal(new int[] {
            180,
            0,
            0,
            0});
            // 
            // lblTimeout
            // 
            this.lblTimeout.AutoSize = true;
            this.lblTimeout.Location = new System.Drawing.Point(11, 91);
            this.lblTimeout.Name = "lblTimeout";
            this.lblTimeout.Size = new System.Drawing.Size(81, 13);
            this.lblTimeout.TabIndex = 2;
            this.lblTimeout.Text = "Search timeout:";
            // 
            // cbTime
            // 
            this.cbTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTime.FormattingEnabled = true;
            this.cbTime.Items.AddRange(new object[] {
            "Millisecond(s)",
            "Second(s)",
            "Minute(s)"});
            this.cbTime.Location = new System.Drawing.Point(207, 88);
            this.cbTime.Name = "cbTime";
            this.cbTime.Size = new System.Drawing.Size(100, 21);
            this.cbTime.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(250, 128);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(169, 128);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtWarning);
            this.groupBox1.Controls.Add(this.numTimeoutVal);
            this.groupBox1.Controls.Add(this.lblTimeout);
            this.groupBox1.Controls.Add(this.cbTime);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 119);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // frmSearchWarning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 158);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearchWarning";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Warning";
            this.Load += new System.EventHandler(this.frmSearchWarning_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numTimeoutVal)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtWarning;
        private System.Windows.Forms.NumericUpDown numTimeoutVal;
        private System.Windows.Forms.Label lblTimeout;
        private System.Windows.Forms.ComboBox cbTime;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}