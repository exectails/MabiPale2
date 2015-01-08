namespace MabiPale2
{
	partial class FrmSettings
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettings));
			this.TabsSettings = new System.Windows.Forms.TabControl();
			this.TabFilters = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.ChkFilterSendEnabled = new System.Windows.Forms.CheckBox();
			this.TxtFilterSend = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ChkFilterRecvEnabled = new System.Windows.Forms.CheckBox();
			this.TxtFilterRecv = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.TabOpNames = new System.Windows.Forms.TabPage();
			this.TxtOpNames = new System.Windows.Forms.TextBox();
			this.BtnSave = new System.Windows.Forms.Button();
			this.BtnCancel = new System.Windows.Forms.Button();
			this.TabErrorLog = new System.Windows.Forms.TabPage();
			this.TxtErrorLog = new System.Windows.Forms.TextBox();
			this.TabsSettings.SuspendLayout();
			this.TabFilters.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.TabOpNames.SuspendLayout();
			this.TabErrorLog.SuspendLayout();
			this.SuspendLayout();
			// 
			// TabsSettings
			// 
			this.TabsSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TabsSettings.Controls.Add(this.TabFilters);
			this.TabsSettings.Controls.Add(this.TabOpNames);
			this.TabsSettings.Controls.Add(this.TabErrorLog);
			this.TabsSettings.Location = new System.Drawing.Point(12, 12);
			this.TabsSettings.Name = "TabsSettings";
			this.TabsSettings.SelectedIndex = 0;
			this.TabsSettings.Size = new System.Drawing.Size(407, 275);
			this.TabsSettings.TabIndex = 0;
			// 
			// TabFilters
			// 
			this.TabFilters.Controls.Add(this.groupBox2);
			this.TabFilters.Controls.Add(this.groupBox1);
			this.TabFilters.Controls.Add(this.label1);
			this.TabFilters.Location = new System.Drawing.Point(4, 22);
			this.TabFilters.Name = "TabFilters";
			this.TabFilters.Padding = new System.Windows.Forms.Padding(3);
			this.TabFilters.Size = new System.Drawing.Size(399, 249);
			this.TabFilters.TabIndex = 0;
			this.TabFilters.Text = "Filters";
			this.TabFilters.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox2.Controls.Add(this.ChkFilterSendEnabled);
			this.groupBox2.Controls.Add(this.TxtFilterSend);
			this.groupBox2.Location = new System.Drawing.Point(202, 6);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(190, 209);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Send";
			// 
			// ChkFilterSendEnabled
			// 
			this.ChkFilterSendEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ChkFilterSendEnabled.AutoSize = true;
			this.ChkFilterSendEnabled.Checked = true;
			this.ChkFilterSendEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ChkFilterSendEnabled.Location = new System.Drawing.Point(13, 185);
			this.ChkFilterSendEnabled.Name = "ChkFilterSendEnabled";
			this.ChkFilterSendEnabled.Size = new System.Drawing.Size(56, 17);
			this.ChkFilterSendEnabled.TabIndex = 8;
			this.ChkFilterSendEnabled.Text = "Active";
			this.ChkFilterSendEnabled.UseVisualStyleBackColor = true;
			// 
			// TxtFilterSend
			// 
			this.TxtFilterSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.TxtFilterSend.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtFilterSend.Location = new System.Drawing.Point(11, 24);
			this.TxtFilterSend.Multiline = true;
			this.TxtFilterSend.Name = "TxtFilterSend";
			this.TxtFilterSend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TxtFilterSend.Size = new System.Drawing.Size(168, 155);
			this.TxtFilterSend.TabIndex = 5;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox1.Controls.Add(this.ChkFilterRecvEnabled);
			this.groupBox1.Controls.Add(this.TxtFilterRecv);
			this.groupBox1.Location = new System.Drawing.Point(6, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(190, 209);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Recv";
			// 
			// ChkFilterRecvEnabled
			// 
			this.ChkFilterRecvEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ChkFilterRecvEnabled.AutoSize = true;
			this.ChkFilterRecvEnabled.Checked = true;
			this.ChkFilterRecvEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ChkFilterRecvEnabled.Location = new System.Drawing.Point(13, 185);
			this.ChkFilterRecvEnabled.Name = "ChkFilterRecvEnabled";
			this.ChkFilterRecvEnabled.Size = new System.Drawing.Size(56, 17);
			this.ChkFilterRecvEnabled.TabIndex = 7;
			this.ChkFilterRecvEnabled.Text = "Active";
			this.ChkFilterRecvEnabled.UseVisualStyleBackColor = true;
			// 
			// TxtFilterRecv
			// 
			this.TxtFilterRecv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.TxtFilterRecv.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtFilterRecv.Location = new System.Drawing.Point(11, 24);
			this.TxtFilterRecv.Multiline = true;
			this.TxtFilterRecv.Name = "TxtFilterRecv";
			this.TxtFilterRecv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TxtFilterRecv.Size = new System.Drawing.Size(168, 155);
			this.TxtFilterRecv.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.ForeColor = System.Drawing.Color.Gray;
			this.label1.Location = new System.Drawing.Point(6, 218);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(386, 26);
			this.label1.TabIndex = 1;
			this.label1.Text = "One op per line. Packets are filtered as they come in, these settings don\'t affec" +
    "t existing log files, unless filtered explicitly.";
			// 
			// TabOpNames
			// 
			this.TabOpNames.Controls.Add(this.TxtOpNames);
			this.TabOpNames.Location = new System.Drawing.Point(4, 22);
			this.TabOpNames.Name = "TabOpNames";
			this.TabOpNames.Padding = new System.Windows.Forms.Padding(3);
			this.TabOpNames.Size = new System.Drawing.Size(399, 249);
			this.TabOpNames.TabIndex = 1;
			this.TabOpNames.Text = "Op Names";
			this.TabOpNames.UseVisualStyleBackColor = true;
			// 
			// TxtOpNames
			// 
			this.TxtOpNames.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TxtOpNames.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtOpNames.Location = new System.Drawing.Point(3, 3);
			this.TxtOpNames.Multiline = true;
			this.TxtOpNames.Name = "TxtOpNames";
			this.TxtOpNames.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TxtOpNames.Size = new System.Drawing.Size(393, 243);
			this.TxtOpNames.TabIndex = 0;
			// 
			// BtnSave
			// 
			this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnSave.Location = new System.Drawing.Point(263, 293);
			this.BtnSave.Name = "BtnSave";
			this.BtnSave.Size = new System.Drawing.Size(75, 23);
			this.BtnSave.TabIndex = 1;
			this.BtnSave.Text = "Save";
			this.BtnSave.UseVisualStyleBackColor = true;
			this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
			// 
			// BtnCancel
			// 
			this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BtnCancel.Location = new System.Drawing.Point(344, 293);
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.Size = new System.Drawing.Size(75, 23);
			this.BtnCancel.TabIndex = 2;
			this.BtnCancel.Text = "Cancel";
			this.BtnCancel.UseVisualStyleBackColor = true;
			this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// TabErrorLog
			// 
			this.TabErrorLog.Controls.Add(this.TxtErrorLog);
			this.TabErrorLog.Location = new System.Drawing.Point(4, 22);
			this.TabErrorLog.Name = "TabErrorLog";
			this.TabErrorLog.Padding = new System.Windows.Forms.Padding(3);
			this.TabErrorLog.Size = new System.Drawing.Size(399, 249);
			this.TabErrorLog.TabIndex = 2;
			this.TabErrorLog.Text = "Error log";
			this.TabErrorLog.UseVisualStyleBackColor = true;
			// 
			// TxtErrorLog
			// 
			this.TxtErrorLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TxtErrorLog.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtErrorLog.Location = new System.Drawing.Point(3, 3);
			this.TxtErrorLog.Multiline = true;
			this.TxtErrorLog.Name = "TxtErrorLog";
			this.TxtErrorLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TxtErrorLog.Size = new System.Drawing.Size(393, 243);
			this.TxtErrorLog.TabIndex = 1;
			this.TxtErrorLog.WordWrap = false;
			// 
			// FrmSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.BtnCancel;
			this.ClientSize = new System.Drawing.Size(431, 328);
			this.Controls.Add(this.BtnCancel);
			this.Controls.Add(this.BtnSave);
			this.Controls.Add(this.TabsSettings);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmSettings";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Settings";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSettings_FormClosing);
			this.Load += new System.EventHandler(this.FrmSettings_Load);
			this.TabsSettings.ResumeLayout(false);
			this.TabFilters.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.TabOpNames.ResumeLayout(false);
			this.TabOpNames.PerformLayout();
			this.TabErrorLog.ResumeLayout(false);
			this.TabErrorLog.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl TabsSettings;
		private System.Windows.Forms.TabPage TabFilters;
		private System.Windows.Forms.TabPage TabOpNames;
		private System.Windows.Forms.Button BtnSave;
		private System.Windows.Forms.Button BtnCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox TxtFilterSend;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox TxtFilterRecv;
		private System.Windows.Forms.CheckBox ChkFilterSendEnabled;
		private System.Windows.Forms.CheckBox ChkFilterRecvEnabled;
		private System.Windows.Forms.TextBox TxtOpNames;
		private System.Windows.Forms.TabPage TabErrorLog;
		private System.Windows.Forms.TextBox TxtErrorLog;
	}
}