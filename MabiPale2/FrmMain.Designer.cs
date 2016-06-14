namespace MabiPale2
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
			System.Windows.Forms.MenuItem menuItem1;
			this.SplitContainerPackets = new System.Windows.Forms.SplitContainer();
			this.LstPackets = new MabiPale2.Shared.ListViewNF();
			this.ColOp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColOpName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.TxtPacket = new System.Windows.Forms.TextBox();
			this.ToolBar = new System.Windows.Forms.ToolStrip();
			this.BtnOpen = new System.Windows.Forms.ToolStripButton();
			this.BtnSave = new System.Windows.Forms.ToolStripButton();
			this.BtnClear = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.BtnConnect = new System.Windows.Forms.ToolStripButton();
			this.BtnDisconnect = new System.Windows.Forms.ToolStripButton();
			this.BtnConnectTo = new System.Windows.Forms.ToolStripButton();
			this.BtnSettings = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.LblPacketCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.LblCurrentFileName = new System.Windows.Forms.ToolStripStatusLabel();
			this.LblPacketProvider = new System.Windows.Forms.ToolStripStatusLabel();
			this.MainMenu = new System.Windows.Forms.MainMenu(this.components);
			this.MenuFile = new System.Windows.Forms.MenuItem();
			this.BtnMenuOpen = new System.Windows.Forms.MenuItem();
			this.BtnMenuSaveAs = new System.Windows.Forms.MenuItem();
			this.MenuFileExitSpacer = new System.Windows.Forms.MenuItem();
			this.BtnMenuExit = new System.Windows.Forms.MenuItem();
			this.MenuEdit = new System.Windows.Forms.MenuItem();
			this.BtnMenuEditFilter = new System.Windows.Forms.MenuItem();
			this.BtnMenuEditFind = new System.Windows.Forms.MenuItem();
			this.MenuPlugins = new System.Windows.Forms.MenuItem();
			this.MenuHelp = new System.Windows.Forms.MenuItem();
			this.BtnMenuAbout = new System.Windows.Forms.MenuItem();
			this.OpenLogDialog = new System.Windows.Forms.OpenFileDialog();
			this.SaveLogDialog = new System.Windows.Forms.SaveFileDialog();
			this.CtxPacketList = new System.Windows.Forms.ContextMenu();
			this.BtnMenuPacketsCopyOp = new System.Windows.Forms.MenuItem();
			this.BtnMenuPacketsCopyId = new System.Windows.Forms.MenuItem();
			this.BtnMenuPacketsCopyHex = new System.Windows.Forms.MenuItem();
			this.BtnMenuPacketsCopyAuraWrite = new System.Windows.Forms.MenuItem();
			this.BtnMenuPacketsCopyAuraRead = new System.Windows.Forms.MenuItem();
			this.BtnMenuPacketsFilter = new System.Windows.Forms.MenuItem();
			this.BtnMenuEditFindPrev = new System.Windows.Forms.MenuItem();
			this.BtnMenuEditFindNext = new System.Windows.Forms.MenuItem();
			menuItem1 = new System.Windows.Forms.MenuItem();
			((System.ComponentModel.ISupportInitialize)(this.SplitContainerPackets)).BeginInit();
			this.SplitContainerPackets.Panel1.SuspendLayout();
			this.SplitContainerPackets.Panel2.SuspendLayout();
			this.SplitContainerPackets.SuspendLayout();
			this.ToolBar.SuspendLayout();
			this.StatusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// SplitContainerPackets
			// 
			this.SplitContainerPackets.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SplitContainerPackets.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.SplitContainerPackets.IsSplitterFixed = true;
			this.SplitContainerPackets.Location = new System.Drawing.Point(0, 25);
			this.SplitContainerPackets.Name = "SplitContainerPackets";
			// 
			// SplitContainerPackets.Panel1
			// 
			this.SplitContainerPackets.Panel1.Controls.Add(this.LstPackets);
			// 
			// SplitContainerPackets.Panel2
			// 
			this.SplitContainerPackets.Panel2.Controls.Add(this.TxtPacket);
			this.SplitContainerPackets.Size = new System.Drawing.Size(984, 492);
			this.SplitContainerPackets.SplitterDistance = 468;
			this.SplitContainerPackets.TabIndex = 0;
			// 
			// LstPackets
			// 
			this.LstPackets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColOp,
            this.ColId,
            this.ColOpName,
            this.ColTime});
			this.LstPackets.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LstPackets.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LstPackets.FullRowSelect = true;
			this.LstPackets.GridLines = true;
			this.LstPackets.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.LstPackets.HideSelection = false;
			this.LstPackets.Location = new System.Drawing.Point(0, 0);
			this.LstPackets.Name = "LstPackets";
			this.LstPackets.Size = new System.Drawing.Size(468, 492);
			this.LstPackets.TabIndex = 1;
			this.LstPackets.UseCompatibleStateImageBehavior = false;
			this.LstPackets.View = System.Windows.Forms.View.Details;
			this.LstPackets.SelectedIndexChanged += new System.EventHandler(this.LstPackets_SelectedIndexChanged);
			this.LstPackets.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LstPackets_KeyUp);
			// 
			// ColOp
			// 
			this.ColOp.Text = "Op";
			this.ColOp.Width = 78;
			// 
			// ColId
			// 
			this.ColId.Text = "Id";
			this.ColId.Width = 125;
			// 
			// ColOpName
			// 
			this.ColOpName.Text = "";
			this.ColOpName.Width = 135;
			// 
			// ColTime
			// 
			this.ColTime.Text = "Time";
			this.ColTime.Width = 99;
			// 
			// TxtPacket
			// 
			this.TxtPacket.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TxtPacket.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtPacket.Location = new System.Drawing.Point(0, 0);
			this.TxtPacket.Multiline = true;
			this.TxtPacket.Name = "TxtPacket";
			this.TxtPacket.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TxtPacket.Size = new System.Drawing.Size(512, 492);
			this.TxtPacket.TabIndex = 0;
			this.TxtPacket.WordWrap = false;
			// 
			// ToolBar
			// 
			this.ToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnOpen,
            this.BtnSave,
            this.BtnClear,
            this.toolStripSeparator1,
            this.BtnConnect,
            this.BtnDisconnect,
            this.BtnConnectTo,
            this.BtnSettings,
            this.toolStripSeparator2});
			this.ToolBar.Location = new System.Drawing.Point(0, 0);
			this.ToolBar.Name = "ToolBar";
			this.ToolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.ToolBar.Size = new System.Drawing.Size(984, 25);
			this.ToolBar.TabIndex = 1;
			this.ToolBar.Text = "toolStrip1";
			// 
			// BtnOpen
			// 
			this.BtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.BtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("BtnOpen.Image")));
			this.BtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BtnOpen.Name = "BtnOpen";
			this.BtnOpen.Size = new System.Drawing.Size(23, 22);
			this.BtnOpen.Text = "Open...";
			this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
			// 
			// BtnSave
			// 
			this.BtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.BtnSave.Image = ((System.Drawing.Image)(resources.GetObject("BtnSave.Image")));
			this.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BtnSave.Name = "BtnSave";
			this.BtnSave.Size = new System.Drawing.Size(23, 22);
			this.BtnSave.Text = "Save as...";
			this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
			// 
			// BtnClear
			// 
			this.BtnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.BtnClear.Image = ((System.Drawing.Image)(resources.GetObject("BtnClear.Image")));
			this.BtnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BtnClear.Name = "BtnClear";
			this.BtnClear.Size = new System.Drawing.Size(23, 22);
			this.BtnClear.Text = "Clear";
			this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// BtnConnect
			// 
			this.BtnConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.BtnConnect.Image = ((System.Drawing.Image)(resources.GetObject("BtnConnect.Image")));
			this.BtnConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BtnConnect.Name = "BtnConnect";
			this.BtnConnect.Size = new System.Drawing.Size(23, 22);
			this.BtnConnect.Text = "Connect";
			this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
			// 
			// BtnDisconnect
			// 
			this.BtnDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.BtnDisconnect.Enabled = false;
			this.BtnDisconnect.Image = ((System.Drawing.Image)(resources.GetObject("BtnDisconnect.Image")));
			this.BtnDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BtnDisconnect.Name = "BtnDisconnect";
			this.BtnDisconnect.Size = new System.Drawing.Size(23, 22);
			this.BtnDisconnect.Text = "Disconnect";
			this.BtnDisconnect.Click += new System.EventHandler(this.BtnDisconnect_Click);
			// 
			// BtnConnectTo
			// 
			this.BtnConnectTo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.BtnConnectTo.Image = ((System.Drawing.Image)(resources.GetObject("BtnConnectTo.Image")));
			this.BtnConnectTo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BtnConnectTo.Name = "BtnConnectTo";
			this.BtnConnectTo.Size = new System.Drawing.Size(23, 22);
			this.BtnConnectTo.Text = "Connect to...";
			this.BtnConnectTo.Click += new System.EventHandler(this.BtnConnectTo_Click);
			// 
			// BtnSettings
			// 
			this.BtnSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.BtnSettings.Image = ((System.Drawing.Image)(resources.GetObject("BtnSettings.Image")));
			this.BtnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BtnSettings.Name = "BtnSettings";
			this.BtnSettings.Size = new System.Drawing.Size(23, 22);
			this.BtnSettings.Text = "Settings";
			this.BtnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// StatusStrip
			// 
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LblPacketCount,
            this.LblCurrentFileName,
            this.LblPacketProvider});
			this.StatusStrip.Location = new System.Drawing.Point(0, 517);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(984, 24);
			this.StatusStrip.TabIndex = 2;
			this.StatusStrip.Text = "statusStrip1";
			// 
			// LblPacketCount
			// 
			this.LblPacketCount.AutoSize = false;
			this.LblPacketCount.Name = "LblPacketCount";
			this.LblPacketCount.Padding = new System.Windows.Forms.Padding(0, 0, 25, 0);
			this.LblPacketCount.Size = new System.Drawing.Size(79, 19);
			this.LblPacketCount.Text = "Packets: 0";
			this.LblPacketCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblCurrentFileName
			// 
			this.LblCurrentFileName.AutoSize = false;
			this.LblCurrentFileName.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
			this.LblCurrentFileName.Name = "LblCurrentFileName";
			this.LblCurrentFileName.Size = new System.Drawing.Size(390, 19);
			this.LblCurrentFileName.Text = "Current File";
			this.LblCurrentFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblPacketProvider
			// 
			this.LblPacketProvider.Name = "LblPacketProvider";
			this.LblPacketProvider.Size = new System.Drawing.Size(89, 19);
			this.LblPacketProvider.Text = "Packet Provider";
			// 
			// MainMenu
			// 
			this.MainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuFile,
            this.MenuEdit,
            this.MenuPlugins,
            this.MenuHelp});
			// 
			// MenuFile
			// 
			this.MenuFile.Index = 0;
			this.MenuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.BtnMenuOpen,
            this.BtnMenuSaveAs,
            this.MenuFileExitSpacer,
            this.BtnMenuExit});
			this.MenuFile.Text = "&File";
			// 
			// BtnMenuOpen
			// 
			this.BtnMenuOpen.Index = 0;
			this.BtnMenuOpen.Text = "&Open...";
			this.BtnMenuOpen.Click += new System.EventHandler(this.BtnOpen_Click);
			// 
			// BtnMenuSaveAs
			// 
			this.BtnMenuSaveAs.Index = 1;
			this.BtnMenuSaveAs.Text = "&Save as...";
			this.BtnMenuSaveAs.Click += new System.EventHandler(this.BtnSave_Click);
			// 
			// MenuFileExitSpacer
			// 
			this.MenuFileExitSpacer.Index = 2;
			this.MenuFileExitSpacer.Text = "-";
			// 
			// BtnMenuExit
			// 
			this.BtnMenuExit.Index = 3;
			this.BtnMenuExit.Text = "E&xit";
			this.BtnMenuExit.Click += new System.EventHandler(this.BtnMenuExit_Click);
			// 
			// MenuEdit
			// 
			this.MenuEdit.Index = 1;
			this.MenuEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.BtnMenuEditFilter,
            menuItem1,
            this.BtnMenuEditFind,
            this.BtnMenuEditFindPrev,
            this.BtnMenuEditFindNext});
			this.MenuEdit.Text = "&Edit";
			// 
			// BtnMenuEditFilter
			// 
			this.BtnMenuEditFilter.Index = 0;
			this.BtnMenuEditFilter.Text = "Apply filters to list";
			this.BtnMenuEditFilter.Click += new System.EventHandler(this.BtnMenuEditFilter_Click);
			// 
			// BtnMenuEditFind
			// 
			this.BtnMenuEditFind.Index = 2;
			this.BtnMenuEditFind.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
			this.BtnMenuEditFind.Text = "Find...";
			this.BtnMenuEditFind.Click += new System.EventHandler(this.BtnMenuEditFind_Click);
			// 
			// MenuPlugins
			// 
			this.MenuPlugins.Index = 2;
			this.MenuPlugins.Text = "&Plugins";
			// 
			// MenuHelp
			// 
			this.MenuHelp.Index = 3;
			this.MenuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.BtnMenuAbout});
			this.MenuHelp.Text = "?";
			// 
			// BtnMenuAbout
			// 
			this.BtnMenuAbout.Index = 0;
			this.BtnMenuAbout.Text = "&About";
			this.BtnMenuAbout.Click += new System.EventHandler(this.BtnMenuAbout_Click);
			// 
			// OpenLogDialog
			// 
			this.OpenLogDialog.Filter = "Text Files|*.txt|All Files|*.*";
			// 
			// SaveLogDialog
			// 
			this.SaveLogDialog.DefaultExt = "txt";
			this.SaveLogDialog.Filter = "Text Files|*.txt|All Files|*.*";
			// 
			// CtxPacketList
			// 
			this.CtxPacketList.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.BtnMenuPacketsCopyOp,
            this.BtnMenuPacketsCopyId,
            this.BtnMenuPacketsCopyHex,
            this.BtnMenuPacketsCopyAuraWrite,
            this.BtnMenuPacketsCopyAuraRead,
            this.BtnMenuPacketsFilter});
			this.CtxPacketList.Popup += new System.EventHandler(this.CtxPacketList_Popup);
			this.CtxPacketList.Collapse += new System.EventHandler(this.CtxPacketList_Collapse);
			// 
			// BtnMenuPacketsCopyOp
			// 
			this.BtnMenuPacketsCopyOp.Index = 0;
			this.BtnMenuPacketsCopyOp.Text = "Copy Op";
			this.BtnMenuPacketsCopyOp.Click += new System.EventHandler(this.BtnMenuPacketsCopyOp_Click);
			// 
			// BtnMenuPacketsCopyId
			// 
			this.BtnMenuPacketsCopyId.Index = 1;
			this.BtnMenuPacketsCopyId.Text = "Copy Id";
			this.BtnMenuPacketsCopyId.Click += new System.EventHandler(this.BtnMenuPacketsCopyId_Click);
			// 
			// BtnMenuPacketsCopyHex
			// 
			this.BtnMenuPacketsCopyHex.Index = 2;
			this.BtnMenuPacketsCopyHex.Text = "Copy packet (Hex)";
			this.BtnMenuPacketsCopyHex.Click += new System.EventHandler(this.BtnMenuPacketsCopyHex_Click);
			// 
			// BtnMenuPacketsCopyAuraWrite
			// 
			this.BtnMenuPacketsCopyAuraWrite.Index = 3;
			this.BtnMenuPacketsCopyAuraWrite.Text = "Copy packet (Aura write)";
			this.BtnMenuPacketsCopyAuraWrite.Click += new System.EventHandler(this.BtnMenuPacketsCopyAuraWrite_Click);
			// 
			// BtnMenuPacketsCopyAuraRead
			// 
			this.BtnMenuPacketsCopyAuraRead.Index = 4;
			this.BtnMenuPacketsCopyAuraRead.Text = "Copy packet (Aura read)";
			this.BtnMenuPacketsCopyAuraRead.Click += new System.EventHandler(this.BtnMenuPacketsCopyAuraRead_Click);
			// 
			// BtnMenuPacketsFilter
			// 
			this.BtnMenuPacketsFilter.Index = 5;
			this.BtnMenuPacketsFilter.Text = "Add to filter";
			this.BtnMenuPacketsFilter.Click += new System.EventHandler(this.BtnMenuPacketsFilter_Click);
			// 
			// menuItem1
			// 
			menuItem1.Index = 1;
			menuItem1.Text = "-";
			// 
			// BtnMenuEditFindPrev
			// 
			this.BtnMenuEditFindPrev.Index = 3;
			this.BtnMenuEditFindPrev.Shortcut = System.Windows.Forms.Shortcut.ShiftF3;
			this.BtnMenuEditFindPrev.Text = "Find Previous";
			this.BtnMenuEditFindPrev.Click += new System.EventHandler(this.BtnMenuEditFindPrev_Click);
			// 
			// BtnMenuEditFindNext
			// 
			this.BtnMenuEditFindNext.Index = 4;
			this.BtnMenuEditFindNext.Shortcut = System.Windows.Forms.Shortcut.F3;
			this.BtnMenuEditFindNext.Text = "Find Next";
			this.BtnMenuEditFindNext.Click += new System.EventHandler(this.BtnMenuEditFindNext_Click);
			// 
			// FrmMain
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 541);
			this.Controls.Add(this.SplitContainerPackets);
			this.Controls.Add(this.ToolBar);
			this.Controls.Add(this.StatusStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.MainMenu;
			this.Name = "FrmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MabiPale2";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
			this.Load += new System.EventHandler(this.FrmMain_Load);
			this.Shown += new System.EventHandler(this.FrmMain_Shown);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FrmMain_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FrmMain_DragEnter);
			this.SplitContainerPackets.Panel1.ResumeLayout(false);
			this.SplitContainerPackets.Panel2.ResumeLayout(false);
			this.SplitContainerPackets.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.SplitContainerPackets)).EndInit();
			this.SplitContainerPackets.ResumeLayout(false);
			this.ToolBar.ResumeLayout(false);
			this.ToolBar.PerformLayout();
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.SplitContainer SplitContainerPackets;
		private System.Windows.Forms.StatusStrip StatusStrip;
		private MabiPale2.Shared.ListViewNF LstPackets;
		private System.Windows.Forms.ColumnHeader ColOp;
		private System.Windows.Forms.ColumnHeader ColId;
		private System.Windows.Forms.ColumnHeader ColOpName;
		private System.Windows.Forms.ColumnHeader ColTime;
		private System.Windows.Forms.TextBox TxtPacket;
		private System.Windows.Forms.ToolStripButton BtnConnect;
		private System.Windows.Forms.ToolStripButton BtnDisconnect;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton BtnOpen;
		private System.Windows.Forms.ToolStripButton BtnSave;
		private System.Windows.Forms.MainMenu MainMenu;
		private System.Windows.Forms.MenuItem MenuFile;
		private System.Windows.Forms.MenuItem BtnMenuExit;
		private System.Windows.Forms.MenuItem MenuHelp;
		private System.Windows.Forms.MenuItem BtnMenuAbout;
		private System.Windows.Forms.OpenFileDialog OpenLogDialog;
		private System.Windows.Forms.ToolStripButton BtnSettings;
		private System.Windows.Forms.ToolStripButton BtnClear;
		private System.Windows.Forms.ToolStripStatusLabel LblPacketCount;
		private System.Windows.Forms.ToolStripStatusLabel LblCurrentFileName;
		private System.Windows.Forms.SaveFileDialog SaveLogDialog;
		public System.Windows.Forms.ToolStrip ToolBar;
		public System.Windows.Forms.MenuItem MenuPlugins;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.MenuItem BtnMenuOpen;
		private System.Windows.Forms.MenuItem BtnMenuSaveAs;
		private System.Windows.Forms.ContextMenu CtxPacketList;
		private System.Windows.Forms.MenuItem BtnMenuPacketsCopyOp;
		private System.Windows.Forms.MenuItem BtnMenuPacketsCopyHex;
		private System.Windows.Forms.MenuItem BtnMenuPacketsFilter;
		private System.Windows.Forms.MenuItem BtnMenuPacketsCopyId;
		private System.Windows.Forms.MenuItem BtnMenuPacketsCopyAuraWrite;
		private System.Windows.Forms.MenuItem BtnMenuPacketsCopyAuraRead;
		private System.Windows.Forms.MenuItem MenuEdit;
		private System.Windows.Forms.MenuItem BtnMenuEditFilter;
		private System.Windows.Forms.MenuItem MenuFileExitSpacer;
		private System.Windows.Forms.ToolStripStatusLabel LblPacketProvider;
		private System.Windows.Forms.ToolStripButton BtnConnectTo;
        private System.Windows.Forms.MenuItem BtnMenuEditFind;
		private System.Windows.Forms.MenuItem BtnMenuEditFindPrev;
		private System.Windows.Forms.MenuItem BtnMenuEditFindNext;
	}
}

