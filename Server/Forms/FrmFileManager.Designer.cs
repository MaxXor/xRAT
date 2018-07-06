using xServer.Controls;

namespace xServer.Forms
{
    partial class FrmFileManager
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFileManager));
            this.contextMenuStripDirectory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.executeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.line2ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.addToStartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.line3ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDirectoryInShellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imgListDirectory = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.stripLblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.stripProgressSearch = new System.Windows.Forms.ToolStripProgressBar();
            this.stripLblFilesFound = new System.Windows.Forms.ToolStripStatusLabel();
            this.stripBtnCancel = new System.Windows.Forms.ToolStripSplitButton();
            this.contextMenuStripTransfers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imgListTransfers = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStripSearch = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.clearSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTipSearchPattern = new System.Windows.Forms.ToolTip(this.components);
            this.TabControlFileManager = new xServer.Controls.DotNetBarTabControl();
            this.tabFileExplorer = new System.Windows.Forms.TabPage();
            this.lstDirectory = new xServer.Controls.AeroListView();
            this.hName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hLastModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hCreationDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCancelSearch = new System.Windows.Forms.Button();
            this.btnSearchMode = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbRecursive = new System.Windows.Forms.CheckBox();
            this.txtSearchDirectory = new System.Windows.Forms.TextBox();
            this.lblSearchPath = new System.Windows.Forms.Label();
            this.lblSearchString = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblPath = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblDrive = new System.Windows.Forms.Label();
            this.cmbDrives = new System.Windows.Forms.ComboBox();
            this.tabTransfers = new System.Windows.Forms.TabPage();
            this.btnOpenDLFolder = new System.Windows.Forms.Button();
            this.lstTransfers = new xServer.Controls.AeroListView();
            this.hID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hTransferType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hFilename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabSearchResults = new System.Windows.Forms.TabPage();
            this.lstSearchResults = new xServer.Controls.AeroListView();
            this.hsName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hsSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hsModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hsCreated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripDirectory.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.contextMenuStripTransfers.SuspendLayout();
            this.contextMenuStripSearch.SuspendLayout();
            this.TabControlFileManager.SuspendLayout();
            this.tabFileExplorer.SuspendLayout();
            this.tabTransfers.SuspendLayout();
            this.tabSearchResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripDirectory
            // 
            this.contextMenuStripDirectory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadToolStripMenuItem,
            this.uploadToolStripMenuItem,
            this.lineToolStripMenuItem,
            this.executeToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.line2ToolStripMenuItem,
            this.addToStartupToolStripMenuItem,
            this.line3ToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.openDirectoryInShellToolStripMenuItem});
            this.contextMenuStripDirectory.Name = "ctxtMenu";
            this.contextMenuStripDirectory.Size = new System.Drawing.Size(240, 198);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadToolStripMenuItem.Image = global::xServer.Properties.Resources.download;
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.downloadToolStripMenuItem.Text = "Download";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // uploadToolStripMenuItem
            // 
            this.uploadToolStripMenuItem.Image = global::xServer.Properties.Resources.upload;
            this.uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            this.uploadToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.uploadToolStripMenuItem.Text = "Upload";
            this.uploadToolStripMenuItem.Click += new System.EventHandler(this.uploadToolStripMenuItem_Click);
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(236, 6);
            // 
            // executeToolStripMenuItem
            // 
            this.executeToolStripMenuItem.Image = global::xServer.Properties.Resources.run;
            this.executeToolStripMenuItem.Name = "executeToolStripMenuItem";
            this.executeToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.executeToolStripMenuItem.Text = "Execute";
            this.executeToolStripMenuItem.Click += new System.EventHandler(this.executeToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Image = global::xServer.Properties.Resources.textfield_rename;
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::xServer.Properties.Resources.delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // line2ToolStripMenuItem
            // 
            this.line2ToolStripMenuItem.Name = "line2ToolStripMenuItem";
            this.line2ToolStripMenuItem.Size = new System.Drawing.Size(236, 6);
            // 
            // addToStartupToolStripMenuItem
            // 
            this.addToStartupToolStripMenuItem.Image = global::xServer.Properties.Resources.application_add;
            this.addToStartupToolStripMenuItem.Name = "addToStartupToolStripMenuItem";
            this.addToStartupToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.addToStartupToolStripMenuItem.Text = "Add to Startup";
            this.addToStartupToolStripMenuItem.Click += new System.EventHandler(this.addToStartupToolStripMenuItem_Click);
            // 
            // line3ToolStripMenuItem
            // 
            this.line3ToolStripMenuItem.Name = "line3ToolStripMenuItem";
            this.line3ToolStripMenuItem.Size = new System.Drawing.Size(236, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = global::xServer.Properties.Resources.refresh;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // openDirectoryInShellToolStripMenuItem
            // 
            this.openDirectoryInShellToolStripMenuItem.Name = "openDirectoryInShellToolStripMenuItem";
            this.openDirectoryInShellToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.openDirectoryInShellToolStripMenuItem.Text = "Open Directory in Remote Shell";
            this.openDirectoryInShellToolStripMenuItem.Click += new System.EventHandler(this.openDirectoryToolStripMenuItem_Click);
            // 
            // imgListDirectory
            // 
            this.imgListDirectory.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListDirectory.ImageStream")));
            this.imgListDirectory.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListDirectory.Images.SetKeyName(0, "back.png");
            this.imgListDirectory.Images.SetKeyName(1, "folder.png");
            this.imgListDirectory.Images.SetKeyName(2, "file.png");
            this.imgListDirectory.Images.SetKeyName(3, "application.png");
            this.imgListDirectory.Images.SetKeyName(4, "text.png");
            this.imgListDirectory.Images.SetKeyName(5, "archive.png");
            this.imgListDirectory.Images.SetKeyName(6, "word.png");
            this.imgListDirectory.Images.SetKeyName(7, "pdf.png");
            this.imgListDirectory.Images.SetKeyName(8, "image.png");
            this.imgListDirectory.Images.SetKeyName(9, "movie.png");
            this.imgListDirectory.Images.SetKeyName(10, "music.png");
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripLblStatus,
            this.stripProgressSearch,
            this.stripLblFilesFound,
            this.stripBtnCancel});
            this.statusStrip.Location = new System.Drawing.Point(0, 456);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(858, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // stripLblStatus
            // 
            this.stripLblStatus.Name = "stripLblStatus";
            this.stripLblStatus.Size = new System.Drawing.Size(131, 17);
            this.stripLblStatus.Text = "Status: Loading drives...";
            // 
            // stripProgressSearch
            // 
            this.stripProgressSearch.Name = "stripProgressSearch";
            this.stripProgressSearch.Size = new System.Drawing.Size(100, 16);
            this.stripProgressSearch.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.stripProgressSearch.Visible = false;
            // 
            // stripLblFilesFound
            // 
            this.stripLblFilesFound.Name = "stripLblFilesFound";
            this.stripLblFilesFound.Size = new System.Drawing.Size(13, 17);
            this.stripLblFilesFound.Text = "0";
            this.stripLblFilesFound.Visible = false;
            // 
            // stripBtnCancel
            // 
            this.stripBtnCancel.Image = global::xServer.Properties.Resources.cancel;
            this.stripBtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stripBtnCancel.Name = "stripBtnCancel";
            this.stripBtnCancel.Size = new System.Drawing.Size(75, 20);
            this.stripBtnCancel.Text = "Cancel";
            this.stripBtnCancel.Visible = false;
            this.stripBtnCancel.ButtonClick += new System.EventHandler(this.stripBtnCancel_ButtonClick);
            // 
            // contextMenuStripTransfers
            // 
            this.contextMenuStripTransfers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelToolStripMenuItem,
            this.toolStripMenuItem1,
            this.clearToolStripMenuItem});
            this.contextMenuStripTransfers.Name = "ctxtMenu2";
            this.contextMenuStripTransfers.Size = new System.Drawing.Size(150, 54);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Image = global::xServer.Properties.Resources.cancel;
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.cancelToolStripMenuItem.Text = "Cancel";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(146, 6);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Image = global::xServer.Properties.Resources.broom;
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.clearToolStripMenuItem.Text = "Clear transfers";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // imgListTransfers
            // 
            this.imgListTransfers.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListTransfers.ImageStream")));
            this.imgListTransfers.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListTransfers.Images.SetKeyName(0, "cancel.png");
            this.imgListTransfers.Images.SetKeyName(1, "done.png");
            // 
            // contextMenuStripSearch
            // 
            this.contextMenuStripSearch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.downloadToolStripMenuItem1,
            this.toolStripSeparator1,
            this.clearSearchToolStripMenuItem});
            this.contextMenuStripSearch.Name = "ctxtMenu2";
            this.contextMenuStripSearch.Size = new System.Drawing.Size(181, 76);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::xServer.Properties.Resources.drive_go;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open in file explorer";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // downloadToolStripMenuItem1
            // 
            this.downloadToolStripMenuItem1.Image = global::xServer.Properties.Resources.download;
            this.downloadToolStripMenuItem1.Name = "downloadToolStripMenuItem1";
            this.downloadToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.downloadToolStripMenuItem1.Text = "Download";
            this.downloadToolStripMenuItem1.Click += new System.EventHandler(this.downloadToolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // clearSearchToolStripMenuItem
            // 
            this.clearSearchToolStripMenuItem.Image = global::xServer.Properties.Resources.broom;
            this.clearSearchToolStripMenuItem.Name = "clearSearchToolStripMenuItem";
            this.clearSearchToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearSearchToolStripMenuItem.Text = "Clear search results";
            this.clearSearchToolStripMenuItem.Click += new System.EventHandler(this.clearSearchToolStripMenuItem_Click);
            // 
            // toolTipSearchPattern
            // 
            this.toolTipSearchPattern.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipSearchPattern.ToolTipTitle = "Search pattern";
            // 
            // TabControlFileManager
            // 
            this.TabControlFileManager.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.TabControlFileManager.Controls.Add(this.tabFileExplorer);
            this.TabControlFileManager.Controls.Add(this.tabTransfers);
            this.TabControlFileManager.Controls.Add(this.tabSearchResults);
            this.TabControlFileManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlFileManager.ItemSize = new System.Drawing.Size(44, 136);
            this.TabControlFileManager.Location = new System.Drawing.Point(0, 0);
            this.TabControlFileManager.Multiline = true;
            this.TabControlFileManager.Name = "TabControlFileManager";
            this.TabControlFileManager.SelectedIndex = 0;
            this.TabControlFileManager.Size = new System.Drawing.Size(858, 456);
            this.TabControlFileManager.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabControlFileManager.TabIndex = 5;
            this.TabControlFileManager.SelectedIndexChanged += new System.EventHandler(this.TabControlFileManager_SelectedIndexChanged);
            // 
            // tabFileExplorer
            // 
            this.tabFileExplorer.BackColor = System.Drawing.SystemColors.Control;
            this.tabFileExplorer.Controls.Add(this.lstDirectory);
            this.tabFileExplorer.Controls.Add(this.btnCancelSearch);
            this.tabFileExplorer.Controls.Add(this.btnSearchMode);
            this.tabFileExplorer.Controls.Add(this.btnSearch);
            this.tabFileExplorer.Controls.Add(this.cbRecursive);
            this.tabFileExplorer.Controls.Add(this.txtSearchDirectory);
            this.tabFileExplorer.Controls.Add(this.lblSearchPath);
            this.tabFileExplorer.Controls.Add(this.lblSearchString);
            this.tabFileExplorer.Controls.Add(this.txtSearch);
            this.tabFileExplorer.Controls.Add(this.btnRefresh);
            this.tabFileExplorer.Controls.Add(this.lblPath);
            this.tabFileExplorer.Controls.Add(this.txtPath);
            this.tabFileExplorer.Controls.Add(this.lblDrive);
            this.tabFileExplorer.Controls.Add(this.cmbDrives);
            this.tabFileExplorer.Location = new System.Drawing.Point(140, 4);
            this.tabFileExplorer.Name = "tabFileExplorer";
            this.tabFileExplorer.Padding = new System.Windows.Forms.Padding(3);
            this.tabFileExplorer.Size = new System.Drawing.Size(714, 448);
            this.tabFileExplorer.TabIndex = 0;
            this.tabFileExplorer.Text = "File Explorer";
            // 
            // lstDirectory
            // 
            this.lstDirectory.AllowDrop = true;
            this.lstDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDirectory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hName,
            this.hSize,
            this.hType,
            this.hLastModified,
            this.hCreationDate});
            this.lstDirectory.ContextMenuStrip = this.contextMenuStripDirectory;
            this.lstDirectory.FullRowSelect = true;
            this.lstDirectory.GridLines = true;
            this.lstDirectory.Location = new System.Drawing.Point(8, 36);
            this.lstDirectory.Name = "lstDirectory";
            this.lstDirectory.Size = new System.Drawing.Size(700, 405);
            this.lstDirectory.SmallImageList = this.imgListDirectory;
            this.lstDirectory.TabIndex = 2;
            this.lstDirectory.UseCompatibleStateImageBehavior = false;
            this.lstDirectory.View = System.Windows.Forms.View.Details;
            this.lstDirectory.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstDirectory_DragDrop);
            this.lstDirectory.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstDirectory_DragEnter);
            this.lstDirectory.DoubleClick += new System.EventHandler(this.lstDirectory_DoubleClick);
            // 
            // hName
            // 
            this.hName.Text = "Name";
            this.hName.Width = 321;
            // 
            // hSize
            // 
            this.hSize.Text = "Size";
            this.hSize.Width = 125;
            // 
            // hType
            // 
            this.hType.Text = "Type";
            this.hType.Width = 168;
            // 
            // hLastModified
            // 
            this.hLastModified.Text = "Modified";
            this.hLastModified.Width = 76;
            // 
            // hCreationDate
            // 
            this.hCreationDate.Text = "Created";
            // 
            // btnCancelSearch
            // 
            this.btnCancelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelSearch.Image = global::xServer.Properties.Resources.cancel;
            this.btnCancelSearch.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelSearch.Location = new System.Drawing.Point(682, 38);
            this.btnCancelSearch.Name = "btnCancelSearch";
            this.btnCancelSearch.Size = new System.Drawing.Size(22, 22);
            this.btnCancelSearch.TabIndex = 14;
            this.btnCancelSearch.UseVisualStyleBackColor = true;
            this.btnCancelSearch.Click += new System.EventHandler(this.btnCancelSearch_Click);
            // 
            // btnSearchMode
            // 
            this.btnSearchMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearchMode.Image = global::xServer.Properties.Resources.drive_magnify;
            this.btnSearchMode.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearchMode.Location = new System.Drawing.Point(682, 8);
            this.btnSearchMode.Name = "btnSearchMode";
            this.btnSearchMode.Size = new System.Drawing.Size(22, 22);
            this.btnSearchMode.TabIndex = 13;
            this.btnSearchMode.UseVisualStyleBackColor = true;
            this.btnSearchMode.Click += new System.EventHandler(this.btnSearchMode_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Image = global::xServer.Properties.Resources.drive_magnify;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearch.Location = new System.Drawing.Point(661, 38);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(22, 22);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbRecursive
            // 
            this.cbRecursive.AutoSize = true;
            this.cbRecursive.Location = new System.Drawing.Point(280, 41);
            this.cbRecursive.Name = "cbRecursive";
            this.cbRecursive.Size = new System.Drawing.Size(74, 17);
            this.cbRecursive.TabIndex = 11;
            this.cbRecursive.Text = "Recursive";
            this.cbRecursive.UseVisualStyleBackColor = true;
            // 
            // txtSearchDirectory
            // 
            this.txtSearchDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchDirectory.Location = new System.Drawing.Point(436, 38);
            this.txtSearchDirectory.Name = "txtSearchDirectory";
            this.txtSearchDirectory.Size = new System.Drawing.Size(226, 22);
            this.txtSearchDirectory.TabIndex = 10;
            this.txtSearchDirectory.Text = "\\";
            // 
            // lblSearchPath
            // 
            this.lblSearchPath.AutoSize = true;
            this.lblSearchPath.Location = new System.Drawing.Point(360, 42);
            this.lblSearchPath.Name = "lblSearchPath";
            this.lblSearchPath.Size = new System.Drawing.Size(70, 13);
            this.lblSearchPath.TabIndex = 9;
            this.lblSearchPath.Text = "Search Path:";
            // 
            // lblSearchString
            // 
            this.lblSearchString.AutoSize = true;
            this.lblSearchString.Location = new System.Drawing.Point(7, 42);
            this.lblSearchString.Name = "lblSearchString";
            this.lblSearchString.Size = new System.Drawing.Size(77, 13);
            this.lblSearchString.TabIndex = 8;
            this.lblSearchString.Text = "Search string:";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(87, 38);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(175, 22);
            this.txtSearch.TabIndex = 7;
            this.txtSearch.Text = "*.*";
            this.toolTipSearchPattern.SetToolTip(this.txtSearch, "To use multiple patterns, separate them with \",\".");
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = global::xServer.Properties.Resources.refresh;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRefresh.Location = new System.Drawing.Point(661, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(22, 22);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(279, 12);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(75, 13);
            this.lblPath.TabIndex = 4;
            this.lblPath.Text = "Remote Path:";
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPath.Location = new System.Drawing.Point(360, 8);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(302, 22);
            this.txtPath.TabIndex = 3;
            this.txtPath.Text = "\\";
            // 
            // lblDrive
            // 
            this.lblDrive.AutoSize = true;
            this.lblDrive.Location = new System.Drawing.Point(8, 12);
            this.lblDrive.Name = "lblDrive";
            this.lblDrive.Size = new System.Drawing.Size(36, 13);
            this.lblDrive.TabIndex = 0;
            this.lblDrive.Text = "Drive:";
            // 
            // cmbDrives
            // 
            this.cmbDrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDrives.FormattingEnabled = true;
            this.cmbDrives.Location = new System.Drawing.Point(50, 8);
            this.cmbDrives.Name = "cmbDrives";
            this.cmbDrives.Size = new System.Drawing.Size(212, 21);
            this.cmbDrives.TabIndex = 1;
            this.cmbDrives.SelectedIndexChanged += new System.EventHandler(this.cmbDrives_SelectedIndexChanged);
            // 
            // tabTransfers
            // 
            this.tabTransfers.BackColor = System.Drawing.SystemColors.Control;
            this.tabTransfers.Controls.Add(this.btnOpenDLFolder);
            this.tabTransfers.Controls.Add(this.lstTransfers);
            this.tabTransfers.Location = new System.Drawing.Point(140, 4);
            this.tabTransfers.Name = "tabTransfers";
            this.tabTransfers.Padding = new System.Windows.Forms.Padding(3);
            this.tabTransfers.Size = new System.Drawing.Size(714, 448);
            this.tabTransfers.TabIndex = 1;
            this.tabTransfers.Text = "Transfers";
            // 
            // btnOpenDLFolder
            // 
            this.btnOpenDLFolder.Location = new System.Drawing.Point(8, 8);
            this.btnOpenDLFolder.Name = "btnOpenDLFolder";
            this.btnOpenDLFolder.Size = new System.Drawing.Size(145, 21);
            this.btnOpenDLFolder.TabIndex = 0;
            this.btnOpenDLFolder.Text = "&Open Download Folder";
            this.btnOpenDLFolder.UseVisualStyleBackColor = true;
            this.btnOpenDLFolder.Click += new System.EventHandler(this.btnOpenDLFolder_Click);
            // 
            // lstTransfers
            // 
            this.lstTransfers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTransfers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hID,
            this.hTransferType,
            this.hStatus,
            this.hFilename});
            this.lstTransfers.ContextMenuStrip = this.contextMenuStripTransfers;
            this.lstTransfers.FullRowSelect = true;
            this.lstTransfers.GridLines = true;
            this.lstTransfers.Location = new System.Drawing.Point(8, 35);
            this.lstTransfers.Name = "lstTransfers";
            this.lstTransfers.Size = new System.Drawing.Size(698, 407);
            this.lstTransfers.SmallImageList = this.imgListTransfers;
            this.lstTransfers.TabIndex = 1;
            this.lstTransfers.UseCompatibleStateImageBehavior = false;
            this.lstTransfers.View = System.Windows.Forms.View.Details;
            // 
            // hID
            // 
            this.hID.Text = "ID";
            this.hID.Width = 128;
            // 
            // hTransferType
            // 
            this.hTransferType.Text = "Transfer Type";
            this.hTransferType.Width = 93;
            // 
            // hStatus
            // 
            this.hStatus.Text = "Status";
            this.hStatus.Width = 173;
            // 
            // hFilename
            // 
            this.hFilename.Text = "Filename";
            this.hFilename.Width = 289;
            // 
            // tabSearchResults
            // 
            this.tabSearchResults.BackColor = System.Drawing.SystemColors.Control;
            this.tabSearchResults.Controls.Add(this.lstSearchResults);
            this.tabSearchResults.Location = new System.Drawing.Point(140, 4);
            this.tabSearchResults.Name = "tabSearchResults";
            this.tabSearchResults.Padding = new System.Windows.Forms.Padding(3);
            this.tabSearchResults.Size = new System.Drawing.Size(714, 448);
            this.tabSearchResults.TabIndex = 3;
            this.tabSearchResults.Text = "Search results";
            // 
            // lstSearchResults
            // 
            this.lstSearchResults.AllowDrop = true;
            this.lstSearchResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSearchResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hsName,
            this.hsSize,
            this.hsModified,
            this.hsCreated});
            this.lstSearchResults.ContextMenuStrip = this.contextMenuStripSearch;
            this.lstSearchResults.FullRowSelect = true;
            this.lstSearchResults.GridLines = true;
            this.lstSearchResults.Location = new System.Drawing.Point(8, 8);
            this.lstSearchResults.MultiSelect = false;
            this.lstSearchResults.Name = "lstSearchResults";
            this.lstSearchResults.Size = new System.Drawing.Size(700, 433);
            this.lstSearchResults.SmallImageList = this.imgListDirectory;
            this.lstSearchResults.TabIndex = 2;
            this.lstSearchResults.UseCompatibleStateImageBehavior = false;
            this.lstSearchResults.View = System.Windows.Forms.View.Details;
            this.lstSearchResults.DoubleClick += new System.EventHandler(this.lstSearchResults_DoubleClick);
            // 
            // hsName
            // 
            this.hsName.Text = "Name";
            this.hsName.Width = 321;
            // 
            // hsSize
            // 
            this.hsSize.Text = "Size";
            this.hsSize.Width = 125;
            // 
            // hsModified
            // 
            this.hsModified.Text = "Modified";
            this.hsModified.Width = 138;
            // 
            // hsCreated
            // 
            this.hsCreated.Text = "Created";
            this.hsCreated.Width = 112;
            // 
            // FrmFileManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(858, 478);
            this.Controls.Add(this.TabControlFileManager);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(663, 377);
            this.Name = "FrmFileManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Manager []";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmFileManager_FormClosing);
            this.Load += new System.EventHandler(this.FrmFileManager_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmFileManager_KeyDown);
            this.contextMenuStripDirectory.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.contextMenuStripTransfers.ResumeLayout(false);
            this.contextMenuStripSearch.ResumeLayout(false);
            this.TabControlFileManager.ResumeLayout(false);
            this.tabFileExplorer.ResumeLayout(false);
            this.tabFileExplorer.PerformLayout();
            this.tabTransfers.ResumeLayout(false);
            this.tabSearchResults.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imgListDirectory;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDirectory;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ImageList imgListTransfers;
        private System.Windows.Forms.ToolStripMenuItem executeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator line3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator line2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToStartupToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTransfers;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDirectoryInShellToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel stripLblStatus;
        private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.TabPage tabSearchResults;
        private System.Windows.Forms.TabPage tabTransfers;
        private System.Windows.Forms.Button btnOpenDLFolder;
        private AeroListView lstTransfers;
        private System.Windows.Forms.ColumnHeader hID;
        private System.Windows.Forms.ColumnHeader hTransferType;
        private System.Windows.Forms.ColumnHeader hStatus;
        private System.Windows.Forms.ColumnHeader hFilename;
        private System.Windows.Forms.TabPage tabFileExplorer;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtPath;
        private AeroListView lstDirectory;
        private System.Windows.Forms.ColumnHeader hName;
        private System.Windows.Forms.ColumnHeader hSize;
        private System.Windows.Forms.ColumnHeader hType;
        private System.Windows.Forms.ColumnHeader hLastModified;
        private System.Windows.Forms.ColumnHeader hCreationDate;
        private System.Windows.Forms.Label lblDrive;
        private System.Windows.Forms.ComboBox cmbDrives;
        private DotNetBarTabControl TabControlFileManager;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox cbRecursive;
        private System.Windows.Forms.TextBox txtSearchDirectory;
        private System.Windows.Forms.Label lblSearchPath;
        private System.Windows.Forms.Label lblSearchString;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSearch;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem clearSearchToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTipSearchPattern;
        private System.Windows.Forms.Button btnSearchMode;
        private System.Windows.Forms.Button btnCancelSearch;
        private System.Windows.Forms.ToolStripProgressBar stripProgressSearch;
        private System.Windows.Forms.ToolStripStatusLabel stripLblFilesFound;
        private System.Windows.Forms.ToolStripSplitButton stripBtnCancel;
        private AeroListView lstSearchResults;
        private System.Windows.Forms.ColumnHeader hsName;
        private System.Windows.Forms.ColumnHeader hsSize;
        private System.Windows.Forms.ColumnHeader hsModified;
        private System.Windows.Forms.ColumnHeader hsCreated;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem1;
    }
}