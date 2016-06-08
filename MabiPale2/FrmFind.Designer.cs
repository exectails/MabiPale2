namespace MabiPale2
{
    partial class FrmFind
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
			System.Windows.Forms.Label label1;
			System.Windows.Forms.GroupBox GrpSearchMode;
			System.Windows.Forms.GroupBox GrpLookAt;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFind));
			this.LblHexNotice = new System.Windows.Forms.Label();
			this.RadSearchModeHex = new System.Windows.Forms.RadioButton();
			this.RadSearchModeStr = new System.Windows.Forms.RadioButton();
			this.ChkSearchInRecvs = new System.Windows.Forms.CheckBox();
			this.ChkSearchInSends = new System.Windows.Forms.CheckBox();
			this.ChkSearchInData = new System.Windows.Forms.CheckBox();
			this.ChkSearchInIds = new System.Windows.Forms.CheckBox();
			this.ChkSearchInOps = new System.Windows.Forms.CheckBox();
			this.TxtSearchQuery = new System.Windows.Forms.TextBox();
			this.BtnFindPrev = new System.Windows.Forms.Button();
			this.BtnFindNext = new System.Windows.Forms.Button();
			this.BtnCancel = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			GrpSearchMode = new System.Windows.Forms.GroupBox();
			GrpLookAt = new System.Windows.Forms.GroupBox();
			GrpSearchMode.SuspendLayout();
			GrpLookAt.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(12, 12);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 13);
			label1.TabIndex = 0;
			label1.Text = "Find what:";
			// 
			// GrpSearchMode
			// 
			GrpSearchMode.Controls.Add(this.LblHexNotice);
			GrpSearchMode.Controls.Add(this.RadSearchModeHex);
			GrpSearchMode.Controls.Add(this.RadSearchModeStr);
			GrpSearchMode.Location = new System.Drawing.Point(12, 38);
			GrpSearchMode.Name = "GrpSearchMode";
			GrpSearchMode.Size = new System.Drawing.Size(149, 112);
			GrpSearchMode.TabIndex = 3;
			GrpSearchMode.TabStop = false;
			GrpSearchMode.Text = "Search mode";
			// 
			// LblHexNotice
			// 
			this.LblHexNotice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.LblHexNotice.ForeColor = System.Drawing.Color.Gray;
			this.LblHexNotice.Location = new System.Drawing.Point(6, 76);
			this.LblHexNotice.Name = "LblHexNotice";
			this.LblHexNotice.Size = new System.Drawing.Size(137, 30);
			this.LblHexNotice.TabIndex = 2;
			this.LblHexNotice.Text = "Entire packet contents will be searched.";
			// 
			// RadSearchModeHex
			// 
			this.RadSearchModeHex.AutoSize = true;
			this.RadSearchModeHex.Location = new System.Drawing.Point(6, 42);
			this.RadSearchModeHex.Name = "RadSearchModeHex";
			this.RadSearchModeHex.Size = new System.Drawing.Size(86, 17);
			this.RadSearchModeHex.TabIndex = 0;
			this.RadSearchModeHex.Text = "Hexadecimal";
			this.RadSearchModeHex.UseVisualStyleBackColor = true;
			// 
			// RadSearchModeStr
			// 
			this.RadSearchModeStr.AutoSize = true;
			this.RadSearchModeStr.Checked = true;
			this.RadSearchModeStr.Location = new System.Drawing.Point(6, 19);
			this.RadSearchModeStr.Name = "RadSearchModeStr";
			this.RadSearchModeStr.Size = new System.Drawing.Size(52, 17);
			this.RadSearchModeStr.TabIndex = 0;
			this.RadSearchModeStr.TabStop = true;
			this.RadSearchModeStr.Text = "String";
			this.RadSearchModeStr.UseVisualStyleBackColor = true;
			this.RadSearchModeStr.CheckedChanged += new System.EventHandler(this.RadSearchModeStr_CheckedChanged);
			// 
			// GrpLookAt
			// 
			GrpLookAt.Controls.Add(this.ChkSearchInRecvs);
			GrpLookAt.Controls.Add(this.ChkSearchInSends);
			GrpLookAt.Controls.Add(this.ChkSearchInData);
			GrpLookAt.Controls.Add(this.ChkSearchInIds);
			GrpLookAt.Controls.Add(this.ChkSearchInOps);
			GrpLookAt.Location = new System.Drawing.Point(167, 38);
			GrpLookAt.Name = "GrpLookAt";
			GrpLookAt.Size = new System.Drawing.Size(149, 112);
			GrpLookAt.TabIndex = 3;
			GrpLookAt.TabStop = false;
			GrpLookAt.Text = "Look at";
			// 
			// ChkSearchInRecvs
			// 
			this.ChkSearchInRecvs.AutoSize = true;
			this.ChkSearchInRecvs.Location = new System.Drawing.Point(63, 89);
			this.ChkSearchInRecvs.Name = "ChkSearchInRecvs";
			this.ChkSearchInRecvs.Size = new System.Drawing.Size(52, 17);
			this.ChkSearchInRecvs.TabIndex = 0;
			this.ChkSearchInRecvs.Text = "Recv";
			this.ChkSearchInRecvs.UseVisualStyleBackColor = true;
			this.ChkSearchInRecvs.CheckedChanged += new System.EventHandler(this.FrmFindCommon_TriggerValidation);
			// 
			// ChkSearchInSends
			// 
			this.ChkSearchInSends.AutoSize = true;
			this.ChkSearchInSends.Location = new System.Drawing.Point(6, 89);
			this.ChkSearchInSends.Name = "ChkSearchInSends";
			this.ChkSearchInSends.Size = new System.Drawing.Size(51, 17);
			this.ChkSearchInSends.TabIndex = 0;
			this.ChkSearchInSends.Text = "Send";
			this.ChkSearchInSends.UseVisualStyleBackColor = true;
			this.ChkSearchInSends.CheckedChanged += new System.EventHandler(this.FrmFindCommon_TriggerValidation);
			// 
			// ChkSearchInData
			// 
			this.ChkSearchInData.AutoSize = true;
			this.ChkSearchInData.Location = new System.Drawing.Point(6, 65);
			this.ChkSearchInData.Name = "ChkSearchInData";
			this.ChkSearchInData.Size = new System.Drawing.Size(90, 17);
			this.ChkSearchInData.TabIndex = 0;
			this.ChkSearchInData.Text = "Data (Strings)";
			this.ChkSearchInData.UseVisualStyleBackColor = true;
			this.ChkSearchInData.CheckedChanged += new System.EventHandler(this.FrmFindCommon_TriggerValidation);
			// 
			// ChkSearchInIds
			// 
			this.ChkSearchInIds.AutoSize = true;
			this.ChkSearchInIds.Location = new System.Drawing.Point(6, 42);
			this.ChkSearchInIds.Name = "ChkSearchInIds";
			this.ChkSearchInIds.Size = new System.Drawing.Size(40, 17);
			this.ChkSearchInIds.TabIndex = 0;
			this.ChkSearchInIds.Text = "Ids";
			this.ChkSearchInIds.UseVisualStyleBackColor = true;
			this.ChkSearchInIds.CheckedChanged += new System.EventHandler(this.FrmFindCommon_TriggerValidation);
			// 
			// ChkSearchInOps
			// 
			this.ChkSearchInOps.AutoSize = true;
			this.ChkSearchInOps.Location = new System.Drawing.Point(6, 19);
			this.ChkSearchInOps.Name = "ChkSearchInOps";
			this.ChkSearchInOps.Size = new System.Drawing.Size(45, 17);
			this.ChkSearchInOps.TabIndex = 0;
			this.ChkSearchInOps.Text = "Ops";
			this.ChkSearchInOps.UseVisualStyleBackColor = true;
			this.ChkSearchInOps.CheckedChanged += new System.EventHandler(this.FrmFindCommon_TriggerValidation);
			this.ChkSearchInOps.Validating += new System.ComponentModel.CancelEventHandler(this.GrpLookAt_Validating);
			this.ChkSearchInOps.Validated += new System.EventHandler(this.FrmFindCommon_Validated);
			// 
			// TxtSearchQuery
			// 
			this.TxtSearchQuery.Location = new System.Drawing.Point(74, 12);
			this.TxtSearchQuery.Name = "TxtSearchQuery";
			this.TxtSearchQuery.Size = new System.Drawing.Size(242, 20);
			this.TxtSearchQuery.TabIndex = 1;
			this.TxtSearchQuery.TextChanged += new System.EventHandler(this.FrmFindCommon_TriggerValidation);
			this.TxtSearchQuery.Validating += new System.ComponentModel.CancelEventHandler(this.TxtSearchQuery_Validating);
			this.TxtSearchQuery.Validated += new System.EventHandler(this.FrmFindCommon_Validated);
			// 
			// BtnFindPrev
			// 
			this.BtnFindPrev.Location = new System.Drawing.Point(322, 12);
			this.BtnFindPrev.Name = "BtnFindPrev";
			this.BtnFindPrev.Size = new System.Drawing.Size(75, 23);
			this.BtnFindPrev.TabIndex = 2;
			this.BtnFindPrev.Text = "Find Prev";
			this.BtnFindPrev.UseVisualStyleBackColor = true;
			this.BtnFindPrev.Click += new System.EventHandler(this.BtnFind_Click);
			// 
			// BtnFindNext
			// 
			this.BtnFindNext.Location = new System.Drawing.Point(322, 41);
			this.BtnFindNext.Name = "BtnFindNext";
			this.BtnFindNext.Size = new System.Drawing.Size(75, 23);
			this.BtnFindNext.TabIndex = 2;
			this.BtnFindNext.Text = "Find Next";
			this.BtnFindNext.UseVisualStyleBackColor = true;
			this.BtnFindNext.Click += new System.EventHandler(this.BtnFind_Click);
			// 
			// BtnCancel
			// 
			this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BtnCancel.Location = new System.Drawing.Point(322, 127);
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.Size = new System.Drawing.Size(75, 23);
			this.BtnCancel.TabIndex = 2;
			this.BtnCancel.Text = "Cancel";
			this.BtnCancel.UseVisualStyleBackColor = true;
			this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// FrmFind
			// 
			this.AcceptButton = this.BtnFindNext;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.BtnCancel;
			this.ClientSize = new System.Drawing.Size(409, 162);
			this.ControlBox = false;
			this.Controls.Add(GrpSearchMode);
			this.Controls.Add(GrpLookAt);
			this.Controls.Add(this.BtnCancel);
			this.Controls.Add(this.BtnFindNext);
			this.Controls.Add(this.BtnFindPrev);
			this.Controls.Add(this.TxtSearchQuery);
			this.Controls.Add(label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmFind";
			this.ShowInTaskbar = false;
			this.Text = "Find";
			this.Load += new System.EventHandler(this.FrmFindCommon_TriggerValidation);
			GrpSearchMode.ResumeLayout(false);
			GrpSearchMode.PerformLayout();
			GrpLookAt.ResumeLayout(false);
			GrpLookAt.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtSearchQuery;
        private System.Windows.Forms.Button BtnFindPrev;
        private System.Windows.Forms.Button BtnFindNext;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.CheckBox ChkSearchInOps;
        private System.Windows.Forms.RadioButton RadSearchModeHex;
        private System.Windows.Forms.RadioButton RadSearchModeStr;
        private System.Windows.Forms.CheckBox ChkSearchInRecvs;
        private System.Windows.Forms.CheckBox ChkSearchInSends;
        private System.Windows.Forms.CheckBox ChkSearchInData;
        private System.Windows.Forms.CheckBox ChkSearchInIds;
		private System.Windows.Forms.Label LblHexNotice;
    }
}