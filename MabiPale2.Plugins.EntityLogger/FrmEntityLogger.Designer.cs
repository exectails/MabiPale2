namespace MabiPale2.Plugins.EntityLogger
{
	partial class FrmEntityLogger
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEntityLogger));
			this.BtnClose = new System.Windows.Forms.Button();
			this.TxtEntityInfo = new System.Windows.Forms.TextBox();
			this.TxtEntityScript = new System.Windows.Forms.TextBox();
			this.LblInfo = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.LstEntities = new MabiPale2.Shared.ListViewNF();
			this.ColType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.BtnInfo = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// BtnClose
			// 
			this.BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnClose.Location = new System.Drawing.Point(803, 578);
			this.BtnClose.Name = "BtnClose";
			this.BtnClose.Size = new System.Drawing.Size(75, 23);
			this.BtnClose.TabIndex = 1;
			this.BtnClose.Text = "Close";
			this.BtnClose.UseVisualStyleBackColor = true;
			this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
			// 
			// TxtEntityInfo
			// 
			this.TxtEntityInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TxtEntityInfo.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtEntityInfo.Location = new System.Drawing.Point(416, 28);
			this.TxtEntityInfo.Multiline = true;
			this.TxtEntityInfo.Name = "TxtEntityInfo";
			this.TxtEntityInfo.ReadOnly = true;
			this.TxtEntityInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TxtEntityInfo.Size = new System.Drawing.Size(462, 275);
			this.TxtEntityInfo.TabIndex = 2;
			this.TxtEntityInfo.WordWrap = false;
			// 
			// TxtEntityScript
			// 
			this.TxtEntityScript.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TxtEntityScript.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtEntityScript.Location = new System.Drawing.Point(416, 322);
			this.TxtEntityScript.Multiline = true;
			this.TxtEntityScript.Name = "TxtEntityScript";
			this.TxtEntityScript.ReadOnly = true;
			this.TxtEntityScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TxtEntityScript.Size = new System.Drawing.Size(462, 250);
			this.TxtEntityScript.TabIndex = 3;
			this.TxtEntityScript.WordWrap = false;
			// 
			// LblInfo
			// 
			this.LblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LblInfo.AutoSize = true;
			this.LblInfo.Location = new System.Drawing.Point(416, 12);
			this.LblInfo.Name = "LblInfo";
			this.LblInfo.Size = new System.Drawing.Size(59, 13);
			this.LblInfo.TabIndex = 4;
			this.LblInfo.Text = "Information";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(413, 306);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Setup Script";
			// 
			// LstEntities
			// 
			this.LstEntities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.LstEntities.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColType,
            this.ColId,
            this.ColName});
			this.LstEntities.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LstEntities.FullRowSelect = true;
			this.LstEntities.Location = new System.Drawing.Point(12, 12);
			this.LstEntities.Name = "LstEntities";
			this.LstEntities.Size = new System.Drawing.Size(398, 560);
			this.LstEntities.TabIndex = 0;
			this.LstEntities.UseCompatibleStateImageBehavior = false;
			this.LstEntities.View = System.Windows.Forms.View.Details;
			this.LstEntities.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LstEntities_ColumnClick);
			this.LstEntities.SelectedIndexChanged += new System.EventHandler(this.LstEntities_SelectedIndexChanged);
			// 
			// ColType
			// 
			this.ColType.Text = "Type";
			this.ColType.Width = 82;
			// 
			// ColId
			// 
			this.ColId.Text = "Id";
			this.ColId.Width = 130;
			// 
			// ColName
			// 
			this.ColName.Text = "Name";
			this.ColName.Width = 153;
			// 
			// BtnInfo
			// 
			this.BtnInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnInfo.Image = ((System.Drawing.Image)(resources.GetObject("BtnInfo.Image")));
			this.BtnInfo.Location = new System.Drawing.Point(766, 578);
			this.BtnInfo.Name = "BtnInfo";
			this.BtnInfo.Size = new System.Drawing.Size(31, 23);
			this.BtnInfo.TabIndex = 6;
			this.BtnInfo.UseVisualStyleBackColor = true;
			this.BtnInfo.Click += new System.EventHandler(this.BtnInfo_Click);
			// 
			// FrmEntityLogger
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(890, 613);
			this.Controls.Add(this.BtnInfo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.LblInfo);
			this.Controls.Add(this.TxtEntityScript);
			this.Controls.Add(this.TxtEntityInfo);
			this.Controls.Add(this.BtnClose);
			this.Controls.Add(this.LstEntities);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmEntityLogger";
			this.Text = "Entity Logger";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MabiPale2.Shared.ListViewNF LstEntities;
		private System.Windows.Forms.ColumnHeader ColType;
		private System.Windows.Forms.ColumnHeader ColId;
		private System.Windows.Forms.ColumnHeader ColName;
		private System.Windows.Forms.Button BtnClose;
		private System.Windows.Forms.TextBox TxtEntityInfo;
		private System.Windows.Forms.TextBox TxtEntityScript;
		private System.Windows.Forms.Label LblInfo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button BtnInfo;
	}
}