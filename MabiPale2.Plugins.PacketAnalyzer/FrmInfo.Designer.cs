namespace MabiPale2.Plugins.PacketAnalyzer
{
	partial class FrmInfo
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInfo));
			this.LblSelect = new System.Windows.Forms.Label();
			this.TxtInfo = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// LblSelect
			// 
			this.LblSelect.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LblSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblSelect.ForeColor = System.Drawing.Color.Silver;
			this.LblSelect.Location = new System.Drawing.Point(0, 0);
			this.LblSelect.Name = "LblSelect";
			this.LblSelect.Size = new System.Drawing.Size(284, 362);
			this.LblSelect.TabIndex = 0;
			this.LblSelect.Text = "Select a packet";
			this.LblSelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// TxtInfo
			// 
			this.TxtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TxtInfo.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtInfo.Location = new System.Drawing.Point(12, 12);
			this.TxtInfo.Multiline = true;
			this.TxtInfo.Name = "TxtInfo";
			this.TxtInfo.ReadOnly = true;
			this.TxtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TxtInfo.Size = new System.Drawing.Size(260, 338);
			this.TxtInfo.TabIndex = 1;
			this.TxtInfo.TabStop = false;
			this.TxtInfo.WordWrap = false;
			// 
			// FrmInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 362);
			this.Controls.Add(this.TxtInfo);
			this.Controls.Add(this.LblSelect);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmInfo";
			this.Text = "Packet Analyzer";
			this.TopMost = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmInfo_FormClosing);
			this.Load += new System.EventHandler(this.FrmInfo_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label LblSelect;
		private System.Windows.Forms.TextBox TxtInfo;
	}
}