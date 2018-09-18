using xServer.Controls;

namespace xServer.Forms
{
    partial class FrmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uninstallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startupManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteShellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reverseProxyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registryEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elevateClientPermissionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxtLine = new System.Windows.Forms.ToolStripSeparator();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shutdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.standbyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.surveillanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteDesktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteWebcamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.passwordRecoveryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyloggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miscellaneousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteExecuteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visitWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMessageboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupByToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operatingSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.unGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imgFlags = new System.Windows.Forms.ImageList(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.listenToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lstClients = new xServer.Controls.AeroListView();
            this.hIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hTag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hUserPC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hUserStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hCountry = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hOS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hAccountType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.builderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionToolStripMenuItem,
            this.systemToolStripMenuItem,
            this.surveillanceToolStripMenuItem,
            this.miscellaneousToolStripMenuItem,
            this.lineToolStripMenuItem,
            this.selectAllToolStripMenuItem,
            this.groupByToolStripMenuItem});
            this.contextMenuStrip.Name = "ctxtMenu";
            this.contextMenuStrip.Size = new System.Drawing.Size(153, 164);
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.reconnectToolStripMenuItem,
            this.disconnectToolStripMenuItem,
            this.uninstallToolStripMenuItem});
            this.connectionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("connectionToolStripMenuItem.Image")));
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.connectionToolStripMenuItem.Text = "Connection";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("updateToolStripMenuItem.Image")));
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // reconnectToolStripMenuItem
            // 
            this.reconnectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reconnectToolStripMenuItem.Image")));
            this.reconnectToolStripMenuItem.Name = "reconnectToolStripMenuItem";
            this.reconnectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.reconnectToolStripMenuItem.Text = "Reconnect";
            this.reconnectToolStripMenuItem.Click += new System.EventHandler(this.reconnectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("disconnectToolStripMenuItem.Image")));
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // uninstallToolStripMenuItem
            // 
            this.uninstallToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("uninstallToolStripMenuItem.Image")));
            this.uninstallToolStripMenuItem.Name = "uninstallToolStripMenuItem";
            this.uninstallToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.uninstallToolStripMenuItem.Text = "Uninstall";
            this.uninstallToolStripMenuItem.Click += new System.EventHandler(this.uninstallToolStripMenuItem_Click);
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemInformationToolStripMenuItem,
            this.fileManagerToolStripMenuItem,
            this.startupManagerToolStripMenuItem,
            this.taskManagerToolStripMenuItem,
            this.remoteShellToolStripMenuItem,
            this.connectionsToolStripMenuItem,
            this.reverseProxyToolStripMenuItem,
            this.registryEditorToolStripMenuItem,
            this.elevateClientPermissionsToolStripMenuItem,
            this.ctxtLine,
            this.actionsToolStripMenuItem});
            this.systemToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("systemToolStripMenuItem.Image")));
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.systemToolStripMenuItem.Text = "System";
            // 
            // systemInformationToolStripMenuItem
            // 
            this.systemInformationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("systemInformationToolStripMenuItem.Image")));
            this.systemInformationToolStripMenuItem.Name = "systemInformationToolStripMenuItem";
            this.systemInformationToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.systemInformationToolStripMenuItem.Text = "System Information";
            this.systemInformationToolStripMenuItem.Click += new System.EventHandler(this.systemInformationToolStripMenuItem_Click);
            // 
            // fileManagerToolStripMenuItem
            // 
            this.fileManagerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fileManagerToolStripMenuItem.Image")));
            this.fileManagerToolStripMenuItem.Name = "fileManagerToolStripMenuItem";
            this.fileManagerToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.fileManagerToolStripMenuItem.Text = "File Manager";
            this.fileManagerToolStripMenuItem.Click += new System.EventHandler(this.fileManagerToolStripMenuItem_Click);
            // 
            // startupManagerToolStripMenuItem
            // 
            this.startupManagerToolStripMenuItem.Image = global::xServer.Properties.Resources.startup_programs;
            this.startupManagerToolStripMenuItem.Name = "startupManagerToolStripMenuItem";
            this.startupManagerToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.startupManagerToolStripMenuItem.Text = "Startup Manager";
            this.startupManagerToolStripMenuItem.Click += new System.EventHandler(this.startupManagerToolStripMenuItem_Click);
            // 
            // taskManagerToolStripMenuItem
            // 
            this.taskManagerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("taskManagerToolStripMenuItem.Image")));
            this.taskManagerToolStripMenuItem.Name = "taskManagerToolStripMenuItem";
            this.taskManagerToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.taskManagerToolStripMenuItem.Text = "Task Manager";
            this.taskManagerToolStripMenuItem.Click += new System.EventHandler(this.taskManagerToolStripMenuItem_Click);
            // 
            // remoteShellToolStripMenuItem
            // 
            this.remoteShellToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("remoteShellToolStripMenuItem.Image")));
            this.remoteShellToolStripMenuItem.Name = "remoteShellToolStripMenuItem";
            this.remoteShellToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.remoteShellToolStripMenuItem.Text = "Remote Shell";
            this.remoteShellToolStripMenuItem.Click += new System.EventHandler(this.remoteShellToolStripMenuItem_Click);
            // 
            // connectionsToolStripMenuItem
            // 
            this.connectionsToolStripMenuItem.Image = global::xServer.Properties.Resources.transmit_blue;
            this.connectionsToolStripMenuItem.Name = "connectionsToolStripMenuItem";
            this.connectionsToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.connectionsToolStripMenuItem.Text = "TCP Connections";
            this.connectionsToolStripMenuItem.Click += new System.EventHandler(this.connectionsToolStripMenuItem_Click);
            // 
            // reverseProxyToolStripMenuItem
            // 
            this.reverseProxyToolStripMenuItem.Image = global::xServer.Properties.Resources.server_link;
            this.reverseProxyToolStripMenuItem.Name = "reverseProxyToolStripMenuItem";
            this.reverseProxyToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.reverseProxyToolStripMenuItem.Text = "Reverse Proxy";
            this.reverseProxyToolStripMenuItem.Click += new System.EventHandler(this.reverseProxyToolStripMenuItem_Click);
            // 
            // registryEditorToolStripMenuItem
            // 
            this.registryEditorToolStripMenuItem.Image = global::xServer.Properties.Resources.registry;
            this.registryEditorToolStripMenuItem.Name = "registryEditorToolStripMenuItem";
            this.registryEditorToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.registryEditorToolStripMenuItem.Text = "Registry Editor";
            this.registryEditorToolStripMenuItem.Click += new System.EventHandler(this.registryEditorToolStripMenuItem_Click);
            // 
            // elevateClientPermissionsToolStripMenuItem
            // 
            this.elevateClientPermissionsToolStripMenuItem.Image = global::xServer.Properties.Resources.uac_shield;
            this.elevateClientPermissionsToolStripMenuItem.Name = "elevateClientPermissionsToolStripMenuItem";
            this.elevateClientPermissionsToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.elevateClientPermissionsToolStripMenuItem.Text = "Elevate Client Permissions";
            this.elevateClientPermissionsToolStripMenuItem.Click += new System.EventHandler(this.elevateClientPermissionsToolStripMenuItem_Click);
            // 
            // ctxtLine
            // 
            this.ctxtLine.Name = "ctxtLine";
            this.ctxtLine.Size = new System.Drawing.Size(208, 6);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shutdownToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.standbyToolStripMenuItem});
            this.actionsToolStripMenuItem.Image = global::xServer.Properties.Resources.actions;
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // shutdownToolStripMenuItem
            // 
            this.shutdownToolStripMenuItem.Image = global::xServer.Properties.Resources.shutdown;
            this.shutdownToolStripMenuItem.Name = "shutdownToolStripMenuItem";
            this.shutdownToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.shutdownToolStripMenuItem.Text = "Shutdown";
            this.shutdownToolStripMenuItem.Click += new System.EventHandler(this.shutdownToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Image = global::xServer.Properties.Resources.restart;
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // standbyToolStripMenuItem
            // 
            this.standbyToolStripMenuItem.Image = global::xServer.Properties.Resources.standby;
            this.standbyToolStripMenuItem.Name = "standbyToolStripMenuItem";
            this.standbyToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.standbyToolStripMenuItem.Text = "Standby";
            this.standbyToolStripMenuItem.Click += new System.EventHandler(this.standbyToolStripMenuItem_Click);
            // 
            // surveillanceToolStripMenuItem
            // 
            this.surveillanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.remoteDesktopToolStripMenuItem,
            this.remoteWebcamToolStripMenuItem,
            this.passwordRecoveryToolStripMenuItem,
            this.keyloggerToolStripMenuItem});
            this.surveillanceToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("surveillanceToolStripMenuItem.Image")));
            this.surveillanceToolStripMenuItem.Name = "surveillanceToolStripMenuItem";
            this.surveillanceToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.surveillanceToolStripMenuItem.Text = "Surveillance";
            // 
            // remoteDesktopToolStripMenuItem
            // 
            this.remoteDesktopToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("remoteDesktopToolStripMenuItem.Image")));
            this.remoteDesktopToolStripMenuItem.Name = "remoteDesktopToolStripMenuItem";
            this.remoteDesktopToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.remoteDesktopToolStripMenuItem.Text = "Remote Desktop";
            this.remoteDesktopToolStripMenuItem.Click += new System.EventHandler(this.remoteDesktopToolStripMenuItem_Click);
            // 
            // remoteWebcamToolStripMenuItem
            // 
            this.remoteWebcamToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("remoteWebcamToolStripMenuItem.Image")));
            this.remoteWebcamToolStripMenuItem.Name = "remoteWebcamToolStripMenuItem";
            this.remoteWebcamToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.remoteWebcamToolStripMenuItem.Text = "Remote Webcam";
            this.remoteWebcamToolStripMenuItem.Click += new System.EventHandler(this.remoteWebcamToolStripMenuItem_Click);
            // 
            // passwordRecoveryToolStripMenuItem
            // 
            this.passwordRecoveryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("passwordRecoveryToolStripMenuItem.Image")));
            this.passwordRecoveryToolStripMenuItem.Name = "passwordRecoveryToolStripMenuItem";
            this.passwordRecoveryToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.passwordRecoveryToolStripMenuItem.Text = "Password Recovery";
            this.passwordRecoveryToolStripMenuItem.Click += new System.EventHandler(this.passwordRecoveryToolStripMenuItem_Click);
            // 
            // keyloggerToolStripMenuItem
            // 
            this.keyloggerToolStripMenuItem.Image = global::xServer.Properties.Resources.logger;
            this.keyloggerToolStripMenuItem.Name = "keyloggerToolStripMenuItem";
            this.keyloggerToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.keyloggerToolStripMenuItem.Text = "Keylogger";
            this.keyloggerToolStripMenuItem.Click += new System.EventHandler(this.keyloggerToolStripMenuItem_Click);
            // 
            // miscellaneousToolStripMenuItem
            // 
            this.miscellaneousToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.remoteExecuteToolStripMenuItem,
            this.visitWebsiteToolStripMenuItem,
            this.showMessageboxToolStripMenuItem});
            this.miscellaneousToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("miscellaneousToolStripMenuItem.Image")));
            this.miscellaneousToolStripMenuItem.Name = "miscellaneousToolStripMenuItem";
            this.miscellaneousToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.miscellaneousToolStripMenuItem.Text = "Miscellaneous";
            // 
            // remoteExecuteToolStripMenuItem
            // 
            this.remoteExecuteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localFileToolStripMenuItem,
            this.webFileToolStripMenuItem});
            this.remoteExecuteToolStripMenuItem.Image = global::xServer.Properties.Resources.lightning;
            this.remoteExecuteToolStripMenuItem.Name = "remoteExecuteToolStripMenuItem";
            this.remoteExecuteToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.remoteExecuteToolStripMenuItem.Text = "Remote Execute";
            // 
            // localFileToolStripMenuItem
            // 
            this.localFileToolStripMenuItem.Image = global::xServer.Properties.Resources.drive_go;
            this.localFileToolStripMenuItem.Name = "localFileToolStripMenuItem";
            this.localFileToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.localFileToolStripMenuItem.Text = "Local File...";
            this.localFileToolStripMenuItem.Click += new System.EventHandler(this.localFileToolStripMenuItem_Click);
            // 
            // webFileToolStripMenuItem
            // 
            this.webFileToolStripMenuItem.Image = global::xServer.Properties.Resources.world_go;
            this.webFileToolStripMenuItem.Name = "webFileToolStripMenuItem";
            this.webFileToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.webFileToolStripMenuItem.Text = "Web File...";
            this.webFileToolStripMenuItem.Click += new System.EventHandler(this.webFileToolStripMenuItem_Click);
            // 
            // visitWebsiteToolStripMenuItem
            // 
            this.visitWebsiteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("visitWebsiteToolStripMenuItem.Image")));
            this.visitWebsiteToolStripMenuItem.Name = "visitWebsiteToolStripMenuItem";
            this.visitWebsiteToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.visitWebsiteToolStripMenuItem.Text = "Visit Website";
            this.visitWebsiteToolStripMenuItem.Click += new System.EventHandler(this.visitWebsiteToolStripMenuItem_Click);
            // 
            // showMessageboxToolStripMenuItem
            // 
            this.showMessageboxToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showMessageboxToolStripMenuItem.Image")));
            this.showMessageboxToolStripMenuItem.Name = "showMessageboxToolStripMenuItem";
            this.showMessageboxToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.showMessageboxToolStripMenuItem.Text = "Show Messagebox";
            this.showMessageboxToolStripMenuItem.Click += new System.EventHandler(this.showMessageboxToolStripMenuItem_Click);
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(149, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // groupByToolStripMenuItem
            // 
            this.groupByToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tagToolStripMenuItem,
            this.countryToolStripMenuItem,
            this.operatingSystemToolStripMenuItem,
            this.accountTypeToolStripMenuItem,
            this.userStatusToolStripMenuItem,
            this.toolStripSeparator1,
            this.unGroupToolStripMenuItem});
            this.groupByToolStripMenuItem.Name = "groupByToolStripMenuItem";
            this.groupByToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.groupByToolStripMenuItem.Text = "Group By";
            // 
            // tagToolStripMenuItem
            // 
            this.tagToolStripMenuItem.Name = "tagToolStripMenuItem";
            this.tagToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.tagToolStripMenuItem.Text = "Tag";
            this.tagToolStripMenuItem.Click += new System.EventHandler(this.tagToolStripMenuItem_Click);
            // 
            // countryToolStripMenuItem
            // 
            this.countryToolStripMenuItem.Name = "countryToolStripMenuItem";
            this.countryToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.countryToolStripMenuItem.Text = "Country";
            this.countryToolStripMenuItem.Click += new System.EventHandler(this.countryToolStripMenuItem_Click);
            // 
            // operatingSystemToolStripMenuItem
            // 
            this.operatingSystemToolStripMenuItem.Name = "operatingSystemToolStripMenuItem";
            this.operatingSystemToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.operatingSystemToolStripMenuItem.Text = "Operating System";
            this.operatingSystemToolStripMenuItem.Click += new System.EventHandler(this.operatingSystemToolStripMenuItem_Click);
            // 
            // accountTypeToolStripMenuItem
            // 
            this.accountTypeToolStripMenuItem.Name = "accountTypeToolStripMenuItem";
            this.accountTypeToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.accountTypeToolStripMenuItem.Text = "Account Type";
            this.accountTypeToolStripMenuItem.Click += new System.EventHandler(this.accountTypeToolStripMenuItem_Click);
            // 
            // userStatusToolStripMenuItem
            // 
            this.userStatusToolStripMenuItem.Name = "userStatusToolStripMenuItem";
            this.userStatusToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.userStatusToolStripMenuItem.Text = "User Status";
            this.userStatusToolStripMenuItem.Click += new System.EventHandler(this.userStatusToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // unGroupToolStripMenuItem
            // 
            this.unGroupToolStripMenuItem.Name = "unGroupToolStripMenuItem";
            this.unGroupToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.unGroupToolStripMenuItem.Text = "Un-Group";
            this.unGroupToolStripMenuItem.Click += new System.EventHandler(this.unGroupToolStripMenuItem_Click);
            // 
            // imgFlags
            // 
            this.imgFlags.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgFlags.ImageStream")));
            this.imgFlags.TransparentColor = System.Drawing.Color.Transparent;
            this.imgFlags.Images.SetKeyName(0, "ad.png");
            this.imgFlags.Images.SetKeyName(1, "ae.png");
            this.imgFlags.Images.SetKeyName(2, "af.png");
            this.imgFlags.Images.SetKeyName(3, "ag.png");
            this.imgFlags.Images.SetKeyName(4, "ai.png");
            this.imgFlags.Images.SetKeyName(5, "al.png");
            this.imgFlags.Images.SetKeyName(6, "am.png");
            this.imgFlags.Images.SetKeyName(7, "an.png");
            this.imgFlags.Images.SetKeyName(8, "ao.png");
            this.imgFlags.Images.SetKeyName(9, "ar.png");
            this.imgFlags.Images.SetKeyName(10, "as.png");
            this.imgFlags.Images.SetKeyName(11, "at.png");
            this.imgFlags.Images.SetKeyName(12, "au.png");
            this.imgFlags.Images.SetKeyName(13, "aw.png");
            this.imgFlags.Images.SetKeyName(14, "ax.png");
            this.imgFlags.Images.SetKeyName(15, "az.png");
            this.imgFlags.Images.SetKeyName(16, "ba.png");
            this.imgFlags.Images.SetKeyName(17, "bb.png");
            this.imgFlags.Images.SetKeyName(18, "bd.png");
            this.imgFlags.Images.SetKeyName(19, "be.png");
            this.imgFlags.Images.SetKeyName(20, "bf.png");
            this.imgFlags.Images.SetKeyName(21, "bg.png");
            this.imgFlags.Images.SetKeyName(22, "bh.png");
            this.imgFlags.Images.SetKeyName(23, "bi.png");
            this.imgFlags.Images.SetKeyName(24, "bj.png");
            this.imgFlags.Images.SetKeyName(25, "bm.png");
            this.imgFlags.Images.SetKeyName(26, "bn.png");
            this.imgFlags.Images.SetKeyName(27, "bo.png");
            this.imgFlags.Images.SetKeyName(28, "br.png");
            this.imgFlags.Images.SetKeyName(29, "bs.png");
            this.imgFlags.Images.SetKeyName(30, "bt.png");
            this.imgFlags.Images.SetKeyName(31, "bv.png");
            this.imgFlags.Images.SetKeyName(32, "bw.png");
            this.imgFlags.Images.SetKeyName(33, "by.png");
            this.imgFlags.Images.SetKeyName(34, "bz.png");
            this.imgFlags.Images.SetKeyName(35, "ca.png");
            this.imgFlags.Images.SetKeyName(36, "catalonia.png");
            this.imgFlags.Images.SetKeyName(37, "cc.png");
            this.imgFlags.Images.SetKeyName(38, "cd.png");
            this.imgFlags.Images.SetKeyName(39, "cf.png");
            this.imgFlags.Images.SetKeyName(40, "cg.png");
            this.imgFlags.Images.SetKeyName(41, "ch.png");
            this.imgFlags.Images.SetKeyName(42, "ci.png");
            this.imgFlags.Images.SetKeyName(43, "ck.png");
            this.imgFlags.Images.SetKeyName(44, "cl.png");
            this.imgFlags.Images.SetKeyName(45, "cm.png");
            this.imgFlags.Images.SetKeyName(46, "cn.png");
            this.imgFlags.Images.SetKeyName(47, "co.png");
            this.imgFlags.Images.SetKeyName(48, "cr.png");
            this.imgFlags.Images.SetKeyName(49, "cs.png");
            this.imgFlags.Images.SetKeyName(50, "cu.png");
            this.imgFlags.Images.SetKeyName(51, "cv.png");
            this.imgFlags.Images.SetKeyName(52, "cx.png");
            this.imgFlags.Images.SetKeyName(53, "cy.png");
            this.imgFlags.Images.SetKeyName(54, "cz.png");
            this.imgFlags.Images.SetKeyName(55, "de.png");
            this.imgFlags.Images.SetKeyName(56, "dj.png");
            this.imgFlags.Images.SetKeyName(57, "dk.png");
            this.imgFlags.Images.SetKeyName(58, "dm.png");
            this.imgFlags.Images.SetKeyName(59, "do.png");
            this.imgFlags.Images.SetKeyName(60, "dz.png");
            this.imgFlags.Images.SetKeyName(61, "ec.png");
            this.imgFlags.Images.SetKeyName(62, "ee.png");
            this.imgFlags.Images.SetKeyName(63, "eg.png");
            this.imgFlags.Images.SetKeyName(64, "eh.png");
            this.imgFlags.Images.SetKeyName(65, "england.png");
            this.imgFlags.Images.SetKeyName(66, "er.png");
            this.imgFlags.Images.SetKeyName(67, "es.png");
            this.imgFlags.Images.SetKeyName(68, "et.png");
            this.imgFlags.Images.SetKeyName(69, "europeanunion.png");
            this.imgFlags.Images.SetKeyName(70, "fam.png");
            this.imgFlags.Images.SetKeyName(71, "fi.png");
            this.imgFlags.Images.SetKeyName(72, "fj.png");
            this.imgFlags.Images.SetKeyName(73, "fk.png");
            this.imgFlags.Images.SetKeyName(74, "fm.png");
            this.imgFlags.Images.SetKeyName(75, "fo.png");
            this.imgFlags.Images.SetKeyName(76, "fr.png");
            this.imgFlags.Images.SetKeyName(77, "ga.png");
            this.imgFlags.Images.SetKeyName(78, "gb.png");
            this.imgFlags.Images.SetKeyName(79, "gd.png");
            this.imgFlags.Images.SetKeyName(80, "ge.png");
            this.imgFlags.Images.SetKeyName(81, "gf.png");
            this.imgFlags.Images.SetKeyName(82, "gh.png");
            this.imgFlags.Images.SetKeyName(83, "gi.png");
            this.imgFlags.Images.SetKeyName(84, "gl.png");
            this.imgFlags.Images.SetKeyName(85, "gm.png");
            this.imgFlags.Images.SetKeyName(86, "gn.png");
            this.imgFlags.Images.SetKeyName(87, "gp.png");
            this.imgFlags.Images.SetKeyName(88, "gq.png");
            this.imgFlags.Images.SetKeyName(89, "gr.png");
            this.imgFlags.Images.SetKeyName(90, "gs.png");
            this.imgFlags.Images.SetKeyName(91, "gt.png");
            this.imgFlags.Images.SetKeyName(92, "gu.png");
            this.imgFlags.Images.SetKeyName(93, "gw.png");
            this.imgFlags.Images.SetKeyName(94, "gy.png");
            this.imgFlags.Images.SetKeyName(95, "hk.png");
            this.imgFlags.Images.SetKeyName(96, "hm.png");
            this.imgFlags.Images.SetKeyName(97, "hn.png");
            this.imgFlags.Images.SetKeyName(98, "hr.png");
            this.imgFlags.Images.SetKeyName(99, "ht.png");
            this.imgFlags.Images.SetKeyName(100, "hu.png");
            this.imgFlags.Images.SetKeyName(101, "id.png");
            this.imgFlags.Images.SetKeyName(102, "ie.png");
            this.imgFlags.Images.SetKeyName(103, "il.png");
            this.imgFlags.Images.SetKeyName(104, "in.png");
            this.imgFlags.Images.SetKeyName(105, "io.png");
            this.imgFlags.Images.SetKeyName(106, "iq.png");
            this.imgFlags.Images.SetKeyName(107, "ir.png");
            this.imgFlags.Images.SetKeyName(108, "is.png");
            this.imgFlags.Images.SetKeyName(109, "it.png");
            this.imgFlags.Images.SetKeyName(110, "jm.png");
            this.imgFlags.Images.SetKeyName(111, "jo.png");
            this.imgFlags.Images.SetKeyName(112, "jp.png");
            this.imgFlags.Images.SetKeyName(113, "ke.png");
            this.imgFlags.Images.SetKeyName(114, "kg.png");
            this.imgFlags.Images.SetKeyName(115, "kh.png");
            this.imgFlags.Images.SetKeyName(116, "ki.png");
            this.imgFlags.Images.SetKeyName(117, "km.png");
            this.imgFlags.Images.SetKeyName(118, "kn.png");
            this.imgFlags.Images.SetKeyName(119, "kp.png");
            this.imgFlags.Images.SetKeyName(120, "kr.png");
            this.imgFlags.Images.SetKeyName(121, "kw.png");
            this.imgFlags.Images.SetKeyName(122, "ky.png");
            this.imgFlags.Images.SetKeyName(123, "kz.png");
            this.imgFlags.Images.SetKeyName(124, "la.png");
            this.imgFlags.Images.SetKeyName(125, "lb.png");
            this.imgFlags.Images.SetKeyName(126, "lc.png");
            this.imgFlags.Images.SetKeyName(127, "li.png");
            this.imgFlags.Images.SetKeyName(128, "lk.png");
            this.imgFlags.Images.SetKeyName(129, "lr.png");
            this.imgFlags.Images.SetKeyName(130, "ls.png");
            this.imgFlags.Images.SetKeyName(131, "lt.png");
            this.imgFlags.Images.SetKeyName(132, "lu.png");
            this.imgFlags.Images.SetKeyName(133, "lv.png");
            this.imgFlags.Images.SetKeyName(134, "ly.png");
            this.imgFlags.Images.SetKeyName(135, "ma.png");
            this.imgFlags.Images.SetKeyName(136, "mc.png");
            this.imgFlags.Images.SetKeyName(137, "md.png");
            this.imgFlags.Images.SetKeyName(138, "me.png");
            this.imgFlags.Images.SetKeyName(139, "mg.png");
            this.imgFlags.Images.SetKeyName(140, "mh.png");
            this.imgFlags.Images.SetKeyName(141, "mk.png");
            this.imgFlags.Images.SetKeyName(142, "ml.png");
            this.imgFlags.Images.SetKeyName(143, "mm.png");
            this.imgFlags.Images.SetKeyName(144, "mn.png");
            this.imgFlags.Images.SetKeyName(145, "mo.png");
            this.imgFlags.Images.SetKeyName(146, "mp.png");
            this.imgFlags.Images.SetKeyName(147, "mq.png");
            this.imgFlags.Images.SetKeyName(148, "mr.png");
            this.imgFlags.Images.SetKeyName(149, "ms.png");
            this.imgFlags.Images.SetKeyName(150, "mt.png");
            this.imgFlags.Images.SetKeyName(151, "mu.png");
            this.imgFlags.Images.SetKeyName(152, "mv.png");
            this.imgFlags.Images.SetKeyName(153, "mw.png");
            this.imgFlags.Images.SetKeyName(154, "mx.png");
            this.imgFlags.Images.SetKeyName(155, "my.png");
            this.imgFlags.Images.SetKeyName(156, "mz.png");
            this.imgFlags.Images.SetKeyName(157, "na.png");
            this.imgFlags.Images.SetKeyName(158, "nc.png");
            this.imgFlags.Images.SetKeyName(159, "ne.png");
            this.imgFlags.Images.SetKeyName(160, "nf.png");
            this.imgFlags.Images.SetKeyName(161, "ng.png");
            this.imgFlags.Images.SetKeyName(162, "ni.png");
            this.imgFlags.Images.SetKeyName(163, "nl.png");
            this.imgFlags.Images.SetKeyName(164, "no.png");
            this.imgFlags.Images.SetKeyName(165, "np.png");
            this.imgFlags.Images.SetKeyName(166, "nr.png");
            this.imgFlags.Images.SetKeyName(167, "nu.png");
            this.imgFlags.Images.SetKeyName(168, "nz.png");
            this.imgFlags.Images.SetKeyName(169, "om.png");
            this.imgFlags.Images.SetKeyName(170, "pa.png");
            this.imgFlags.Images.SetKeyName(171, "pe.png");
            this.imgFlags.Images.SetKeyName(172, "pf.png");
            this.imgFlags.Images.SetKeyName(173, "pg.png");
            this.imgFlags.Images.SetKeyName(174, "ph.png");
            this.imgFlags.Images.SetKeyName(175, "pk.png");
            this.imgFlags.Images.SetKeyName(176, "pl.png");
            this.imgFlags.Images.SetKeyName(177, "pm.png");
            this.imgFlags.Images.SetKeyName(178, "pn.png");
            this.imgFlags.Images.SetKeyName(179, "pr.png");
            this.imgFlags.Images.SetKeyName(180, "ps.png");
            this.imgFlags.Images.SetKeyName(181, "pt.png");
            this.imgFlags.Images.SetKeyName(182, "pw.png");
            this.imgFlags.Images.SetKeyName(183, "py.png");
            this.imgFlags.Images.SetKeyName(184, "qa.png");
            this.imgFlags.Images.SetKeyName(185, "re.png");
            this.imgFlags.Images.SetKeyName(186, "ro.png");
            this.imgFlags.Images.SetKeyName(187, "rs.png");
            this.imgFlags.Images.SetKeyName(188, "ru.png");
            this.imgFlags.Images.SetKeyName(189, "rw.png");
            this.imgFlags.Images.SetKeyName(190, "sa.png");
            this.imgFlags.Images.SetKeyName(191, "sb.png");
            this.imgFlags.Images.SetKeyName(192, "sc.png");
            this.imgFlags.Images.SetKeyName(193, "scotland.png");
            this.imgFlags.Images.SetKeyName(194, "sd.png");
            this.imgFlags.Images.SetKeyName(195, "se.png");
            this.imgFlags.Images.SetKeyName(196, "sg.png");
            this.imgFlags.Images.SetKeyName(197, "sh.png");
            this.imgFlags.Images.SetKeyName(198, "si.png");
            this.imgFlags.Images.SetKeyName(199, "sj.png");
            this.imgFlags.Images.SetKeyName(200, "sk.png");
            this.imgFlags.Images.SetKeyName(201, "sl.png");
            this.imgFlags.Images.SetKeyName(202, "sm.png");
            this.imgFlags.Images.SetKeyName(203, "sn.png");
            this.imgFlags.Images.SetKeyName(204, "so.png");
            this.imgFlags.Images.SetKeyName(205, "sr.png");
            this.imgFlags.Images.SetKeyName(206, "st.png");
            this.imgFlags.Images.SetKeyName(207, "sv.png");
            this.imgFlags.Images.SetKeyName(208, "sy.png");
            this.imgFlags.Images.SetKeyName(209, "sz.png");
            this.imgFlags.Images.SetKeyName(210, "tc.png");
            this.imgFlags.Images.SetKeyName(211, "td.png");
            this.imgFlags.Images.SetKeyName(212, "tf.png");
            this.imgFlags.Images.SetKeyName(213, "tg.png");
            this.imgFlags.Images.SetKeyName(214, "th.png");
            this.imgFlags.Images.SetKeyName(215, "tj.png");
            this.imgFlags.Images.SetKeyName(216, "tk.png");
            this.imgFlags.Images.SetKeyName(217, "tl.png");
            this.imgFlags.Images.SetKeyName(218, "tm.png");
            this.imgFlags.Images.SetKeyName(219, "tn.png");
            this.imgFlags.Images.SetKeyName(220, "to.png");
            this.imgFlags.Images.SetKeyName(221, "tr.png");
            this.imgFlags.Images.SetKeyName(222, "tt.png");
            this.imgFlags.Images.SetKeyName(223, "tv.png");
            this.imgFlags.Images.SetKeyName(224, "tw.png");
            this.imgFlags.Images.SetKeyName(225, "tz.png");
            this.imgFlags.Images.SetKeyName(226, "ua.png");
            this.imgFlags.Images.SetKeyName(227, "ug.png");
            this.imgFlags.Images.SetKeyName(228, "um.png");
            this.imgFlags.Images.SetKeyName(229, "us.png");
            this.imgFlags.Images.SetKeyName(230, "uy.png");
            this.imgFlags.Images.SetKeyName(231, "uz.png");
            this.imgFlags.Images.SetKeyName(232, "va.png");
            this.imgFlags.Images.SetKeyName(233, "vc.png");
            this.imgFlags.Images.SetKeyName(234, "ve.png");
            this.imgFlags.Images.SetKeyName(235, "vg.png");
            this.imgFlags.Images.SetKeyName(236, "vi.png");
            this.imgFlags.Images.SetKeyName(237, "vn.png");
            this.imgFlags.Images.SetKeyName(238, "vu.png");
            this.imgFlags.Images.SetKeyName(239, "wales.png");
            this.imgFlags.Images.SetKeyName(240, "wf.png");
            this.imgFlags.Images.SetKeyName(241, "ws.png");
            this.imgFlags.Images.SetKeyName(242, "ye.png");
            this.imgFlags.Images.SetKeyName(243, "yt.png");
            this.imgFlags.Images.SetKeyName(244, "za.png");
            this.imgFlags.Images.SetKeyName(245, "zm.png");
            this.imgFlags.Images.SetKeyName(246, "zw.png");
            this.imgFlags.Images.SetKeyName(247, "xy.png");
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Quasar";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.statusStrip, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.lstClients, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.menuStrip, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1022, 458);
            this.tableLayoutPanel.TabIndex = 6;
            // 
            // statusStrip
            // 
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listenToolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 436);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1022, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // listenToolStripStatusLabel
            // 
            this.listenToolStripStatusLabel.Name = "listenToolStripStatusLabel";
            this.listenToolStripStatusLabel.Size = new System.Drawing.Size(87, 17);
            this.listenToolStripStatusLabel.Text = "Listening: False";
            // 
            // lstClients
            // 
            this.lstClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hIP,
            this.hTag,
            this.hUserPC,
            this.hVersion,
            this.hStatus,
            this.hUserStatus,
            this.hCountry,
            this.hOS,
            this.hAccountType});
            this.lstClients.ContextMenuStrip = this.contextMenuStrip;
            this.lstClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstClients.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstClients.FullRowSelect = true;
            this.lstClients.Location = new System.Drawing.Point(3, 28);
            this.lstClients.Name = "lstClients";
            this.lstClients.ShowItemToolTips = true;
            this.lstClients.Size = new System.Drawing.Size(1016, 405);
            this.lstClients.SmallImageList = this.imgFlags;
            this.lstClients.TabIndex = 1;
            this.lstClients.UseCompatibleStateImageBehavior = false;
            this.lstClients.View = System.Windows.Forms.View.Details;
            this.lstClients.SelectedIndexChanged += new System.EventHandler(this.lstClients_SelectedIndexChanged);
            // 
            // hIP
            // 
            this.hIP.Text = "IP Address";
            this.hIP.Width = 112;
            // 
            // hTag
            // 
            this.hTag.Text = "Tag";
            // 
            // hUserPC
            // 
            this.hUserPC.Text = "User@PC";
            this.hUserPC.Width = 175;
            // 
            // hVersion
            // 
            this.hVersion.Text = "Version";
            this.hVersion.Width = 66;
            // 
            // hStatus
            // 
            this.hStatus.Text = "Status";
            this.hStatus.Width = 78;
            // 
            // hUserStatus
            // 
            this.hUserStatus.Text = "User Status";
            this.hUserStatus.Width = 72;
            // 
            // hCountry
            // 
            this.hCountry.Text = "Country";
            this.hCountry.Width = 117;
            // 
            // hOS
            // 
            this.hOS.Text = "Operating System";
            this.hOS.Width = 222;
            // 
            // hAccountType
            // 
            this.hAccountType.Text = "Account Type";
            this.hAccountType.Width = 100;
            // 
            // menuStrip
            // 
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fIleToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.builderToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(216, 25);
            this.menuStrip.TabIndex = 2;
            // 
            // fIleToolStripMenuItem
            // 
            this.fIleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fIleToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fIleToolStripMenuItem.Name = "fIleToolStripMenuItem";
            this.fIleToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fIleToolStripMenuItem.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // builderToolStripMenuItem
            // 
            this.builderToolStripMenuItem.Name = "builderToolStripMenuItem";
            this.builderToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.builderToolStripMenuItem.Text = "Builder";
            this.builderToolStripMenuItem.Click += new System.EventHandler(this.builderToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1022, 458);
            this.Controls.Add(this.tableLayoutPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(680, 415);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quasar - Connected: 0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader hIP;
        private System.Windows.Forms.ColumnHeader hVersion;
        private System.Windows.Forms.ColumnHeader hCountry;
        private System.Windows.Forms.ColumnHeader hOS;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader hTag;
        private System.Windows.Forms.ImageList imgFlags;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader hStatus;
        private System.Windows.Forms.ToolStripMenuItem uninstallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem surveillanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remoteDesktopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taskManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileManagerToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader hAccountType;
        private System.Windows.Forms.ToolStripMenuItem systemInformationToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader hUserStatus;
        private System.Windows.Forms.ToolStripMenuItem miscellaneousToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visitWebsiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem passwordRecoveryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMessageboxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remoteShellToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ctxtLine;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shutdownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem standbyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startupManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remoteExecuteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem webFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyloggerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reverseProxyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registryEditorToolStripMenuItem;
        private AeroListView lstClients;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ColumnHeader hUserPC;
        private System.Windows.Forms.ToolStripSeparator lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fIleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem builderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel listenToolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem elevateClientPermissionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remoteWebcamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupByToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem countryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operatingSystemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem unGroupToolStripMenuItem;
    }
}

