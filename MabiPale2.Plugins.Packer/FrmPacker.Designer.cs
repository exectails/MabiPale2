namespace MabiPale2.Plugins.Packer
{
	partial class FrmPacker
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPacker));
			this.TxtOp = new System.Windows.Forms.TextBox();
			this.TxtId = new System.Windows.Forms.TextBox();
			this.TxtData = new System.Windows.Forms.TextBox();
			this.LblOp = new System.Windows.Forms.Label();
			this.LblId = new System.Windows.Forms.Label();
			this.BtnSend = new System.Windows.Forms.Button();
			this.BtnRecv = new System.Windows.Forms.Button();
			this.BtnUseMyId = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.BtnClear = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// TxtOp
			// 
			this.TxtOp.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtOp.Location = new System.Drawing.Point(12, 25);
			this.TxtOp.Name = "TxtOp";
			this.TxtOp.Size = new System.Drawing.Size(69, 23);
			this.TxtOp.TabIndex = 0;
			// 
			// TxtId
			// 
			this.TxtId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.TxtId.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtId.Location = new System.Drawing.Point(87, 25);
			this.TxtId.Name = "TxtId";
			this.TxtId.Size = new System.Drawing.Size(385, 23);
			this.TxtId.TabIndex = 1;
			// 
			// TxtData
			// 
			this.TxtData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.TxtData.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtData.Location = new System.Drawing.Point(12, 54);
			this.TxtData.Multiline = true;
			this.TxtData.Name = "TxtData";
			this.TxtData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TxtData.Size = new System.Drawing.Size(460, 326);
			this.TxtData.TabIndex = 2;
			this.TxtData.WordWrap = false;
			// 
			// LblOp
			// 
			this.LblOp.AutoSize = true;
			this.LblOp.Location = new System.Drawing.Point(9, 9);
			this.LblOp.Name = "LblOp";
			this.LblOp.Size = new System.Drawing.Size(21, 13);
			this.LblOp.TabIndex = 3;
			this.LblOp.Text = "Op";
			// 
			// LblId
			// 
			this.LblId.AutoSize = true;
			this.LblId.Location = new System.Drawing.Point(84, 9);
			this.LblId.Name = "LblId";
			this.LblId.Size = new System.Drawing.Size(16, 13);
			this.LblId.TabIndex = 4;
			this.LblId.Text = "Id";
			// 
			// BtnSend
			// 
			this.BtnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnSend.Location = new System.Drawing.Point(316, 386);
			this.BtnSend.Name = "BtnSend";
			this.BtnSend.Size = new System.Drawing.Size(75, 23);
			this.BtnSend.TabIndex = 5;
			this.BtnSend.Text = "Send";
			this.ToolTip.SetToolTip(this.BtnSend, "Sends packet to the server.");
			this.BtnSend.UseVisualStyleBackColor = true;
			this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
			// 
			// BtnRecv
			// 
			this.BtnRecv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnRecv.Location = new System.Drawing.Point(397, 386);
			this.BtnRecv.Name = "BtnRecv";
			this.BtnRecv.Size = new System.Drawing.Size(75, 23);
			this.BtnRecv.TabIndex = 6;
			this.BtnRecv.Text = "Recv";
			this.ToolTip.SetToolTip(this.BtnRecv, "Sends packet to the client.");
			this.BtnRecv.UseVisualStyleBackColor = true;
			this.BtnRecv.Click += new System.EventHandler(this.BtnRecv_Click);
			// 
			// BtnUseMyId
			// 
			this.BtnUseMyId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnUseMyId.Location = new System.Drawing.Point(12, 386);
			this.BtnUseMyId.Name = "BtnUseMyId";
			this.BtnUseMyId.Size = new System.Drawing.Size(75, 23);
			this.BtnUseMyId.TabIndex = 7;
			this.BtnUseMyId.Text = "Use my id";
			this.ToolTip.SetToolTip(this.BtnUseMyId, "Sets id to the current character\'s entity id.");
			this.BtnUseMyId.UseVisualStyleBackColor = true;
			this.BtnUseMyId.Click += new System.EventHandler(this.BtnUseMyId_Click);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button1.Location = new System.Drawing.Point(93, 386);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(113, 23);
			this.button1.TabIndex = 8;
			this.button1.Text = "Parse Hex Packet";
			this.ToolTip.SetToolTip(this.button1, "Parses hex packet from clipboard.");
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.BtnParseHexPacket_Click);
			// 
			// BtnClear
			// 
			this.BtnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnClear.Location = new System.Drawing.Point(212, 386);
			this.BtnClear.Name = "BtnClear";
			this.BtnClear.Size = new System.Drawing.Size(50, 23);
			this.BtnClear.TabIndex = 9;
			this.BtnClear.Text = "Clear";
			this.ToolTip.SetToolTip(this.BtnClear, "Cleares all input fields.");
			this.BtnClear.UseVisualStyleBackColor = true;
			this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
			// 
			// FrmPake
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(484, 421);
			this.Controls.Add(this.BtnClear);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.BtnUseMyId);
			this.Controls.Add(this.BtnRecv);
			this.Controls.Add(this.BtnSend);
			this.Controls.Add(this.LblId);
			this.Controls.Add(this.LblOp);
			this.Controls.Add(this.TxtData);
			this.Controls.Add(this.TxtId);
			this.Controls.Add(this.TxtOp);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmPacker";
			this.Text = "Packer";
			this.TopMost = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPacker_FormClosing);
			this.Load += new System.EventHandler(this.FrmPacker_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox TxtOp;
		private System.Windows.Forms.TextBox TxtId;
		private System.Windows.Forms.TextBox TxtData;
		private System.Windows.Forms.Label LblOp;
		private System.Windows.Forms.Label LblId;
		private System.Windows.Forms.Button BtnSend;
		private System.Windows.Forms.Button BtnRecv;
		private System.Windows.Forms.Button BtnUseMyId;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ToolTip ToolTip;
		private System.Windows.Forms.Button BtnClear;
	}
}