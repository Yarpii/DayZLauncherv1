namespace DayZLauncher
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblUptime = new System.Windows.Forms.Label();
            this.lblMemoryUsage = new System.Windows.Forms.Label();
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOpenServerFolder = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLaunchParameters = new System.Windows.Forms.TextBox();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabMods = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnRefreshMods = new System.Windows.Forms.Button();
            this.lblModCount = new System.Windows.Forms.Label();
            this.lstAvailableMods = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnOpenModsFolder = new System.Windows.Forms.Button();
            this.btnClearMods = new System.Windows.Forms.Button();
            this.btnAddAllMods = new System.Windows.Forms.Button();
            this.lblSelectedModCount = new System.Windows.Forms.Label();
            this.btnRemoveMod = new System.Windows.Forms.Button();
            this.btnAddMod = new System.Windows.Forms.Button();
            this.lstSelectedMods = new System.Windows.Forms.ListBox();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtExecutable = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrowseMods = new System.Windows.Forms.Button();
            this.btnBrowseServer = new System.Windows.Forms.Button();
            this.txtModsFolder = new System.Windows.Forms.TextBox();
            this.txtServerPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.btnSaveLog = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabMods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabLog.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabMain);
            this.tabControl.Controls.Add(this.tabMods);
            this.tabControl.Controls.Add(this.tabSettings);
            this.tabControl.Controls.Add(this.tabLog);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(760, 487);
            this.tabControl.TabIndex = 0;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.groupBox3);
            this.tabMain.Controls.Add(this.groupBox2);
            this.tabMain.Controls.Add(this.pictureBox1);
            this.tabMain.Location = new System.Drawing.Point(4, 25);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(752, 458);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lblUptime);
            this.groupBox3.Controls.Add(this.lblMemoryUsage);
            this.groupBox3.Controls.Add(this.lblServerStatus);
            this.groupBox3.Location = new System.Drawing.Point(6, 135);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(740, 100);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Server Status";
            // 
            // lblUptime
            // 
            this.lblUptime.AutoSize = true;
            this.lblUptime.Location = new System.Drawing.Point(16, 70);
            this.lblUptime.Name = "lblUptime";
            this.lblUptime.Size = new System.Drawing.Size(115, 17);
            this.lblUptime.TabIndex = 2;
            this.lblUptime.Text = "Uptime: 00:00:00";
            // 
            // lblMemoryUsage
            // 
            this.lblMemoryUsage.AutoSize = true;
            this.lblMemoryUsage.Location = new System.Drawing.Point(16, 45);
            this.lblMemoryUsage.Name = "lblMemoryUsage";
            this.lblMemoryUsage.Size = new System.Drawing.Size(95, 17);
            this.lblMemoryUsage.TabIndex = 1;
            this.lblMemoryUsage.Text = "Memory: N/A";
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.AutoSize = true;
            this.lblServerStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerStatus.ForeColor = System.Drawing.Color.Red;
            this.lblServerStatus.Location = new System.Drawing.Point(15, 20);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(193, 20);
            this.lblServerStatus.TabIndex = 0;
            this.lblServerStatus.Text = "Server Status: OFFLINE";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnOpenServerFolder);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtLaunchParameters);
            this.groupBox2.Controls.Add(this.btnStopServer);
            this.groupBox2.Controls.Add(this.btnStartServer);
            this.groupBox2.Location = new System.Drawing.Point(6, 241);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(740, 211);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server Controls";
            // 
            // btnOpenServerFolder
            // 
            this.btnOpenServerFolder.Location = new System.Drawing.Point(15, 157);
            this.btnOpenServerFolder.Name = "btnOpenServerFolder";
            this.btnOpenServerFolder.Size = new System.Drawing.Size(180, 36);
            this.btnOpenServerFolder.TabIndex = 4;
            this.btnOpenServerFolder.Text = "Open Server Folder";
            this.btnOpenServerFolder.UseVisualStyleBackColor = true;
            this.btnOpenServerFolder.Click += new System.EventHandler(this.btnOpenServerFolder_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Additional launch options:";
            // 
            // txtLaunchParameters
            // 
            this.txtLaunchParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLaunchParameters.Location = new System.Drawing.Point(15, 110);
            this.txtLaunchParameters.Name = "txtLaunchParameters";
            this.txtLaunchParameters.Size = new System.Drawing.Size(710, 22);
            this.txtLaunchParameters.TabIndex = 2;
            this.txtLaunchParameters.Text = "-config=serverDZ.cfg -profiles=ServerProfiles";
            // 
            // btnStopServer
            // 
            this.btnStopServer.Enabled = false;
            this.btnStopServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopServer.Location = new System.Drawing.Point(235, 30);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(180, 45);
            this.btnStopServer.TabIndex = 1;
            this.btnStopServer.Text = "Stop Server";
            this.btnStopServer.UseVisualStyleBackColor = true;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // btnStartServer
            // 
            this.btnStartServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartServer.Location = new System.Drawing.Point(15, 30);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(180, 45);
            this.btnStartServer.TabIndex = 0;
            this.btnStartServer.Text = "Start DayZ Server";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(740, 123);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabMods
            // 
            this.tabMods.Controls.Add(this.splitContainer1);
            this.tabMods.Location = new System.Drawing.Point(4, 25);
            this.tabMods.Name = "tabMods";
            this.tabMods.Padding = new System.Windows.Forms.Padding(3);
            this.tabMods.Size = new System.Drawing.Size(752, 458);
            this.tabMods.TabIndex = 1;
            this.tabMods.Text = "Mods";
            this.tabMods.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox5);
            this.splitContainer1.Size = new System.Drawing.Size(746, 452);
            this.splitContainer1.SplitterDistance = 373;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnRefreshMods);
            this.groupBox4.Controls.Add(this.lblModCount);
            this.groupBox4.Controls.Add(this.lstAvailableMods);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(373, 452);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Available Mods";
            // 
            // btnRefreshMods
            // 
            this.btnRefreshMods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefreshMods.Location = new System.Drawing.Point(6, 423);
            this.btnRefreshMods.Name = "btnRefreshMods";
            this.btnRefreshMods.Size = new System.Drawing.Size(110, 23);
            this.btnRefreshMods.TabIndex = 2;
            this.btnRefreshMods.Text = "Refresh Mods";
            this.btnRefreshMods.UseVisualStyleBackColor = true;
            this.btnRefreshMods.Click += new System.EventHandler(this.btnRefreshMods_Click);
            // 
            // lblModCount
            // 
            this.lblModCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModCount.AutoSize = true;
            this.lblModCount.Location = new System.Drawing.Point(250, 426);
            this.lblModCount.Name = "lblModCount";
            this.lblModCount.Size = new System.Drawing.Size(117, 17);
            this.lblModCount.TabIndex = 1;
            this.lblModCount.Text = "Available Mods: 0";
            // 
            // lstAvailableMods
            // 
            this.lstAvailableMods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAvailableMods.FormattingEnabled = true;
            this.lstAvailableMods.ItemHeight = 16;
            this.lstAvailableMods.Location = new System.Drawing.Point(6, 21);
            this.lstAvailableMods.Name = "lstAvailableMods";
            this.lstAvailableMods.Size = new System.Drawing.Size(361, 388);
            this.lstAvailableMods.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnOpenModsFolder);
            this.groupBox5.Controls.Add(this.btnClearMods);
            this.groupBox5.Controls.Add(this.btnAddAllMods);
            this.groupBox5.Controls.Add(this.lblSelectedModCount);
            this.groupBox5.Controls.Add(this.btnRemoveMod);
            this.groupBox5.Controls.Add(this.btnAddMod);
            this.groupBox5.Controls.Add(this.lstSelectedMods);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(369, 452);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Selected Mods";
            // 
            // btnOpenModsFolder
            // 
            this.btnOpenModsFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenModsFolder.Location = new System.Drawing.Point(6, 423);
            this.btnOpenModsFolder.Name = "btnOpenModsFolder";
            this.btnOpenModsFolder.Size = new System.Drawing.Size(122, 23);
            this.btnOpenModsFolder.TabIndex = 6;
            this.btnOpenModsFolder.Text = "Open Mods Folder";
            this.btnOpenModsFolder.UseVisualStyleBackColor = true;
            this.btnOpenModsFolder.Click += new System.EventHandler(this.btnOpenModsFolder_Click);
            // 
            // btnClearMods
            // 
            this.btnClearMods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearMods.Location = new System.Drawing.Point(263, 80);
            this.btnClearMods.Name = "btnClearMods";
            this.btnClearMods.Size = new System.Drawing.Size(100, 23);
            this.btnClearMods.TabIndex = 5;
            this.btnClearMods.Text = "Clear All";
            this.btnClearMods.UseVisualStyleBackColor = true;
            this.btnClearMods.Click += new System.EventHandler(this.btnClearMods_Click);
            // 
            // btnAddAllMods
            // 
            this.btnAddAllMods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAllMods.Location = new System.Drawing.Point(263, 51);
            this.btnAddAllMods.Name = "btnAddAllMods";
            this.btnAddAllMods.Size = new System.Drawing.Size(100, 23);
            this.btnAddAllMods.TabIndex = 4;
            this.btnAddAllMods.Text = "Select All";
            this.btnAddAllMods.UseVisualStyleBackColor = true;
            this.btnAddAllMods.Click += new System.EventHandler(this.btnAddAllMods_Click);
            // 
            // lblSelectedModCount
            // 
            this.lblSelectedModCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedModCount.AutoSize = true;
            this.lblSelectedModCount.Location = new System.Drawing.Point(249, 426);
            this.lblSelectedModCount.Name = "lblSelectedModCount";
            this.lblSelectedModCount.Size = new System.Drawing.Size(114, 17);
            this.lblSelectedModCount.TabIndex = 3;
            this.lblSelectedModCount.Text = "Selected Mods: 0";
            // 
            // btnRemoveMod
            // 
            this.btnRemoveMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveMod.Location = new System.Drawing.Point(263, 120);
            this.btnRemoveMod.Name = "btnRemoveMod";
            this.btnRemoveMod.Size = new System.Drawing.Size(100, 23);
            this.btnRemoveMod.TabIndex = 2;
            this.btnRemoveMod.Text = "< Remove";
            this.btnRemoveMod.UseVisualStyleBackColor = true;
            this.btnRemoveMod.Click += new System.EventHandler(this.btnRemoveMod_Click);
            // 
            // btnAddMod
            // 
            this.btnAddMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddMod.Location = new System.Drawing.Point(263, 22);
            this.btnAddMod.Name = "btnAddMod";
            this.btnAddMod.Size = new System.Drawing.Size(100, 23);
            this.btnAddMod.TabIndex = 1;
            this.btnAddMod.Text = "Add >";
            this.btnAddMod.UseVisualStyleBackColor = true;
            this.btnAddMod.Click += new System.EventHandler(this.btnAddMod_Click);
            // 
            // lstSelectedMods
            // 
            this.lstSelectedMods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSelectedMods.FormattingEnabled = true;
            this.lstSelectedMods.ItemHeight = 16;
            this.lstSelectedMods.Location = new System.Drawing.Point(6, 21);
            this.lstSelectedMods.Name = "lstSelectedMods";
            this.lstSelectedMods.Size = new System.Drawing.Size(251, 388);
            this.lstSelectedMods.TabIndex = 0;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.groupBox1);
            this.tabSettings.Controls.Add(this.btnSaveSettings);
            this.tabSettings.Location = new System.Drawing.Point(4, 25);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Size = new System.Drawing.Size(752, 458);
            this.tabSettings.TabIndex = 2;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtExecutable);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnBrowseMods);
            this.groupBox1.Controls.Add(this.btnBrowseServer);
            this.groupBox1.Controls.Add(this.txtModsFolder);
            this.groupBox1.Controls.Add(this.txtServerPath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(736, 155);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server Location";
            // 
            // txtExecutable
            // 
            this.txtExecutable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExecutable.Location = new System.Drawing.Point(140, 102);
            this.txtExecutable.Name = "txtExecutable";
            this.txtExecutable.Size = new System.Drawing.Size(590, 22);
            this.txtExecutable.TabIndex = 7;
            this.txtExecutable.Text = "DayZServer_x64.exe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Server Executable:";
            // 
            // btnBrowseMods
            // 
            this.btnBrowseMods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseMods.Location = new System.Drawing.Point(658, 67);
            this.btnBrowseMods.Name = "btnBrowseMods";
            this.btnBrowseMods.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseMods.TabIndex = 5;
            this.btnBrowseMods.Text = "Browse...";
            this.btnBrowseMods.UseVisualStyleBackColor = true;
            this.btnBrowseMods.Click += new System.EventHandler(this.btnBrowseMods_Click);
            // 
            // btnBrowseServer
            // 
            this.btnBrowseServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseServer.Location = new System.Drawing.Point(658, 34);
            this.btnBrowseServer.Name = "btnBrowseServer";
            this.btnBrowseServer.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseServer.TabIndex = 4;
            this.btnBrowseServer.Text = "Browse...";
            this.btnBrowseServer.UseVisualStyleBackColor = true;
            this.btnBrowseServer.Click += new System.EventHandler(this.btnBrowseServer_Click);
            // 
            // txtModsFolder
            // 
            this.txtModsFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtModsFolder.Location = new System.Drawing.Point(140, 67);
            this.txtModsFolder.Name = "txtModsFolder";
            this.txtModsFolder.Size = new System.Drawing.Size(512, 22);
            this.txtModsFolder.TabIndex = 3;
            // 
            // txtServerPath
            // 
            this.txtServerPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerPath.Location = new System.Drawing.Point(140, 34);
            this.txtServerPath.Name = "txtServerPath";
            this.txtServerPath.Size = new System.Drawing.Size(512, 22);
            this.txtServerPath.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mods Folder:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Path:";
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveSettings.Location = new System.Drawing.Point(609, 398);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(135, 42);
            this.btnSaveSettings.TabIndex = 2;
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // tabLog
            // 
            this.tabLog.Controls.Add(this.btnSaveLog);
            this.tabLog.Controls.Add(this.btnClearLog);
            this.tabLog.Controls.Add(this.txtLog);
            this.tabLog.Location = new System.Drawing.Point(4, 25);
            this.tabLog.Name = "tabLog";
            this.tabLog.Size = new System.Drawing.Size(752, 458);
            this.tabLog.TabIndex = 3;
            this.tabLog.Text = "Log";
            this.tabLog.UseVisualStyleBackColor = true;
            // 
            // btnSaveLog
            // 
            this.btnSaveLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveLog.Location = new System.Drawing.Point(669, 427);
            this.btnSaveLog.Name = "btnSaveLog";
            this.btnSaveLog.Size = new System.Drawing.Size(75, 28);
            this.btnSaveLog.TabIndex = 2;
            this.btnSaveLog.Text = "Save Log";
            this.btnSaveLog.UseVisualStyleBackColor = true;
            this.btnSaveLog.Click += new System.EventHandler(this.btnSaveLog_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClearLog.Location = new System.Drawing.Point(8, 427);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(75, 28);
            this.btnClearLog.TabIndex = 1;
            this.btnClearLog.Text = "Clear";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.BackColor = System.Drawing.Color.Black;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.ForeColor = System.Drawing.Color.LightGreen;
            this.txtLog.Location = new System.Drawing.Point(8, 8);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(736, 413);
            this.txtLog.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
           this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 504);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(782, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(171, 20);
            this.toolStripStatusLabel1.Text = "DayZ Server Launcher v1.0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 530);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 575);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DayZ Server Launcher";
            this.tabControl.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabMods.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabLog.ResumeLayout(false);
            this.tabLog.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();




            // Add this after the existing ServerPath, ModsFolder, Executable controls
            // in the Settings tab but within the same groupBox1

            this.label4 = new System.Windows.Forms.Label();
            this.txtConfigFile = new System.Windows.Forms.TextBox();
            this.btnBrowseConfig = new System.Windows.Forms.Button();

            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Config File:";

            this.txtConfigFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfigFile.Location = new System.Drawing.Point(140, 135);
            this.txtConfigFile.Name = "txtConfigFile";
            this.txtConfigFile.Size = new System.Drawing.Size(512, 22);
            this.txtConfigFile.TabIndex = 9;
            this.txtConfigFile.Text = "serverDZ.cfg";

            this.btnBrowseConfig = new System.Windows.Forms.Button();
            this.btnBrowseConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseConfig.Location = new System.Drawing.Point(658, 135);
            this.btnBrowseConfig.Name = "btnBrowseConfig";
            this.btnBrowseConfig.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseConfig.TabIndex = 10;
            this.btnBrowseConfig.Text = "Browse...";
            this.btnBrowseConfig.UseVisualStyleBackColor = true;
            this.btnBrowseConfig.Click += new System.EventHandler(this.btnBrowseConfig_Click);

            this.label5 = new System.Windows.Forms.Label();
            this.txtBattlEyePath = new System.Windows.Forms.TextBox();
            this.btnBrowseBattlEye = new System.Windows.Forms.Button();

            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "BattlEye Path:";

            this.txtBattlEyePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBattlEyePath.Location = new System.Drawing.Point(140, 170);
            this.txtBattlEyePath.Name = "txtBattlEyePath";
            this.txtBattlEyePath.Size = new System.Drawing.Size(512, 22);
            this.txtBattlEyePath.TabIndex = 12;

            this.btnBrowseBattlEye = new System.Windows.Forms.Button();
            this.btnBrowseBattlEye.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseBattlEye.Location = new System.Drawing.Point(658, 170);
            this.btnBrowseBattlEye.Name = "btnBrowseBattlEye";
            this.btnBrowseBattlEye.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseBattlEye.TabIndex = 13;
            this.btnBrowseBattlEye.Text = "Browse...";
            this.btnBrowseBattlEye.UseVisualStyleBackColor = true;
            this.btnBrowseBattlEye.Click += new System.EventHandler(this.btnBrowseBattlEye_Click);

            // Add controls to groupBox1
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtConfigFile);
            this.groupBox1.Controls.Add(this.btnBrowseConfig);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtBattlEyePath);
            this.groupBox1.Controls.Add(this.btnBrowseBattlEye);

            // Expand groupBox1 height to accommodate new controls
            this.groupBox1.Size = new System.Drawing.Size(736, 210);

            // Add a new group box for resource settings
            this.groupBoxResources = new System.Windows.Forms.GroupBox();
            this.groupBoxResources.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxResources.Location = new System.Drawing.Point(8, 230);
            this.groupBoxResources.Name = "groupBoxResources";
            this.groupBoxResources.Size = new System.Drawing.Size(736, 150);
            this.groupBoxResources.TabIndex = 4;
            this.groupBoxResources.TabStop = false;
            this.groupBoxResources.Text = "Resource Allocation";

            this.chkCustomResources = new System.Windows.Forms.CheckBox();
            this.chkCustomResources.AutoSize = true;
            this.chkCustomResources.Location = new System.Drawing.Point(20, 30);
            this.chkCustomResources.Name = "chkCustomResources";
            this.chkCustomResources.Size = new System.Drawing.Size(212, 21);
            this.chkCustomResources.TabIndex = 0;
            this.chkCustomResources.Text = "Use custom resource settings";
            this.chkCustomResources.UseVisualStyleBackColor = true;
            this.chkCustomResources.CheckedChanged += new System.EventHandler(this.chkCustomResources_CheckedChanged);

            this.label6 = new System.Windows.Forms.Label();
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Maximum Memory:";

            this.numMaxMemory = new System.Windows.Forms.NumericUpDown();
            this.numMaxMemory.Location = new System.Drawing.Point(160, 68);
            this.numMaxMemory.Maximum = new decimal(new int[] { 65536, 0, 0, 0 });
            this.numMaxMemory.Minimum = new decimal(new int[] { 1024, 0, 0, 0 });
            this.numMaxMemory.Name = "numMaxMemory";
            this.numMaxMemory.Size = new System.Drawing.Size(120, 22);
            this.numMaxMemory.TabIndex = 2;
            this.numMaxMemory.Value = new decimal(new int[] { 8192, 0, 0, 0 });
            this.numMaxMemory.Enabled = false;

            this.label7 = new System.Windows.Forms.Label();
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(290, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "MB";

            this.label8 = new System.Windows.Forms.Label();
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "CPU Count:";

            this.numCpuCount = new System.Windows.Forms.NumericUpDown();
            this.numCpuCount.Location = new System.Drawing.Point(160, 108);
            this.numCpuCount.Maximum = new decimal(new int[] { 64, 0, 0, 0 });
            this.numCpuCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numCpuCount.Name = "numCpuCount";
            this.numCpuCount.Size = new System.Drawing.Size(120, 22);
            this.numCpuCount.TabIndex = 5;
            this.numCpuCount.Value = new decimal(new int[] { 4, 0, 0, 0 });
            this.numCpuCount.Enabled = false;

            // Add controls to groupBoxResources
            this.groupBoxResources.Controls.Add(this.chkCustomResources);
            this.groupBoxResources.Controls.Add(this.label6);
            this.groupBoxResources.Controls.Add(this.numMaxMemory);
            this.groupBoxResources.Controls.Add(this.label7);
            this.groupBoxResources.Controls.Add(this.label8);
            this.groupBoxResources.Controls.Add(this.numCpuCount);

            // Add groupBoxResources to the Settings tab
            this.tabSettings.Controls.Add(this.groupBoxResources);


        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabMods;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.TabPage tabLog;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBrowseMods;
        private System.Windows.Forms.Button btnBrowseServer;
        private System.Windows.Forms.TextBox txtModsFolder;
        private System.Windows.Forms.TextBox txtServerPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtExecutable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lstAvailableMods;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListBox lstSelectedMods;
        private System.Windows.Forms.Label lblModCount;
        private System.Windows.Forms.Button btnRefreshMods;
        private System.Windows.Forms.Button btnRemoveMod;
        private System.Windows.Forms.Button btnAddMod;
        private System.Windows.Forms.Label lblSelectedModCount;
        private System.Windows.Forms.Button btnClearMods;
        private System.Windows.Forms.Button btnAddAllMods;
        private System.Windows.Forms.Button btnOpenModsFolder;
        private System.Windows.Forms.Button btnOpenServerFolder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLaunchParameters;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button btnSaveLog;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblServerStatus;
        private System.Windows.Forms.Label lblUptime;
        private System.Windows.Forms.Label lblMemoryUsage;

        // At the top of your MainForm class, where other private fields are declared
        private System.Windows.Forms.TextBox txtConfigFile;
        private System.Windows.Forms.TextBox txtBattlEyePath;
        private System.Windows.Forms.CheckBox chkCustomResources;
        private System.Windows.Forms.NumericUpDown numMaxMemory;
        private System.Windows.Forms.NumericUpDown numCpuCount;
        private System.Windows.Forms.Button btnBrowseBattlEye;
        private System.Windows.Forms.Button btnBrowseConfig;
        private System.Windows.Forms.Label label4;
   
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBoxResources;

    }
}