namespace MabiPale2.Plugins.HexPacketParser
{
	partial class FrmParser
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmParser));
			this.BtnConvert = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.TxtHex = new System.Windows.Forms.TextBox();
			this.TxtPacket = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// BtnConvert
			// 
			this.BtnConvert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnConvert.Location = new System.Drawing.Point(294, 25);
			this.BtnConvert.Name = "BtnConvert";
			this.BtnConvert.Size = new System.Drawing.Size(36, 441);
			this.BtnConvert.TabIndex = 1;
			this.BtnConvert.Text = ">";
			this.BtnConvert.UseVisualStyleBackColor = true;
			this.BtnConvert.Click += new System.EventHandler(this.BtnConvert_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(102, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Packet as hex code";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(333, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(76, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Parsed packet";
			// 
			// TxtHex
			// 
			this.TxtHex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.TxtHex.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtHex.Location = new System.Drawing.Point(12, 25);
			this.TxtHex.MaxLength = 98301;
			this.TxtHex.Multiline = true;
			this.TxtHex.Name = "TxtHex";
			this.TxtHex.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TxtHex.Size = new System.Drawing.Size(276, 441);
			this.TxtHex.TabIndex = 0;
			// 
			// TxtPacket
			// 
			this.TxtPacket.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TxtPacket.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtPacket.Location = new System.Drawing.Point(336, 25);
			this.TxtPacket.MaxLength = 98301;
			this.TxtPacket.Multiline = true;
			this.TxtPacket.Name = "TxtPacket";
			this.TxtPacket.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TxtPacket.Size = new System.Drawing.Size(513, 441);
			this.TxtPacket.TabIndex = 2;
			this.TxtPacket.WordWrap = false;
			// 
			// FrmParser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(861, 478);
			this.Controls.Add(this.TxtPacket);
			this.Controls.Add(this.TxtHex);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.BtnConvert);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmParser";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Packet Parser";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button BtnConvert;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox TxtHex;
		private System.Windows.Forms.TextBox TxtPacket;
	}
}