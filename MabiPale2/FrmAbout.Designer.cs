namespace MabiPale2
{
	partial class FrmAbout
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbout));
			this.BtnClose = new System.Windows.Forms.Button();
			this.LblName = new System.Windows.Forms.Label();
			this.LblVersion = new System.Windows.Forms.Label();
			this.GrpGpl = new System.Windows.Forms.GroupBox();
			this.TxtGpl = new System.Windows.Forms.TextBox();
			this.LblLink = new System.Windows.Forms.LinkLabel();
			this.LblAuthor = new System.Windows.Forms.Label();
			this.ImgLogo = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.GrpGpl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ImgLogo)).BeginInit();
			this.SuspendLayout();
			// 
			// BtnClose
			// 
			this.BtnClose.Location = new System.Drawing.Point(140, 330);
			this.BtnClose.Name = "BtnClose";
			this.BtnClose.Size = new System.Drawing.Size(75, 23);
			this.BtnClose.TabIndex = 0;
			this.BtnClose.Text = "Close";
			this.BtnClose.UseVisualStyleBackColor = true;
			this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
			// 
			// LblName
			// 
			this.LblName.AutoSize = true;
			this.LblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblName.Location = new System.Drawing.Point(50, 12);
			this.LblName.Name = "LblName";
			this.LblName.Size = new System.Drawing.Size(74, 20);
			this.LblName.TabIndex = 2;
			this.LblName.Text = "MabiPale";
			// 
			// LblVersion
			// 
			this.LblVersion.AutoSize = true;
			this.LblVersion.Location = new System.Drawing.Point(51, 32);
			this.LblVersion.Name = "LblVersion";
			this.LblVersion.Size = new System.Drawing.Size(43, 13);
			this.LblVersion.TabIndex = 3;
			this.LblVersion.Text = "v2.11.0";
			// 
			// GrpGpl
			// 
			this.GrpGpl.Controls.Add(this.TxtGpl);
			this.GrpGpl.Location = new System.Drawing.Point(15, 104);
			this.GrpGpl.Name = "GrpGpl";
			this.GrpGpl.Size = new System.Drawing.Size(325, 220);
			this.GrpGpl.TabIndex = 4;
			this.GrpGpl.TabStop = false;
			this.GrpGpl.Text = "GPL License";
			// 
			// TxtGpl
			// 
			this.TxtGpl.BackColor = System.Drawing.SystemColors.Control;
			this.TxtGpl.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TxtGpl.Location = new System.Drawing.Point(11, 19);
			this.TxtGpl.Multiline = true;
			this.TxtGpl.Name = "TxtGpl";
			this.TxtGpl.Size = new System.Drawing.Size(310, 195);
			this.TxtGpl.TabIndex = 2;
			this.TxtGpl.Text = resources.GetString("TxtGpl.Text");
			// 
			// LblLink
			// 
			this.LblLink.AutoSize = true;
			this.LblLink.Location = new System.Drawing.Point(12, 78);
			this.LblLink.Name = "LblLink";
			this.LblLink.Size = new System.Drawing.Size(112, 13);
			this.LblLink.TabIndex = 5;
			this.LblLink.TabStop = true;
			this.LblLink.Text = "http://aura-project.org";
			this.LblLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblLink_LinkClicked);
			// 
			// LblAuthor
			// 
			this.LblAuthor.AutoSize = true;
			this.LblAuthor.Location = new System.Drawing.Point(12, 62);
			this.LblAuthor.Name = "LblAuthor";
			this.LblAuthor.Size = new System.Drawing.Size(67, 13);
			this.LblAuthor.TabIndex = 6;
			this.LblAuthor.Text = "Author: exec";
			// 
			// ImgLogo
			// 
			this.ImgLogo.Image = ((System.Drawing.Image)(resources.GetObject("ImgLogo.Image")));
			this.ImgLogo.Location = new System.Drawing.Point(12, 12);
			this.ImgLogo.Name = "ImgLogo";
			this.ImgLogo.Size = new System.Drawing.Size(32, 32);
			this.ImgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.ImgLogo.TabIndex = 1;
			this.ImgLogo.TabStop = false;
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.Color.Silver;
			this.label1.Location = new System.Drawing.Point(183, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(157, 63);
			this.label1.TabIndex = 7;
			this.label1.Text = "MabiPale2 requires an Alissa compatible packet provider such as Morrighan.";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// FrmAbout
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(352, 365);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.LblAuthor);
			this.Controls.Add(this.LblLink);
			this.Controls.Add(this.GrpGpl);
			this.Controls.Add(this.LblVersion);
			this.Controls.Add(this.LblName);
			this.Controls.Add(this.ImgLogo);
			this.Controls.Add(this.BtnClose);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmAbout";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About";
			this.Load += new System.EventHandler(this.FrmAbout_Load);
			this.GrpGpl.ResumeLayout(false);
			this.GrpGpl.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ImgLogo)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button BtnClose;
		private System.Windows.Forms.PictureBox ImgLogo;
		private System.Windows.Forms.Label LblName;
		private System.Windows.Forms.Label LblVersion;
		private System.Windows.Forms.GroupBox GrpGpl;
		private System.Windows.Forms.TextBox TxtGpl;
		private System.Windows.Forms.LinkLabel LblLink;
		private System.Windows.Forms.Label LblAuthor;
		private System.Windows.Forms.Label label1;
	}
}