namespace MabiPale2.Plugins.DunGen
{
	partial class FrmDunGen
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

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDunGen));
			this.BtnGenerateImage = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.TxtDungeonName = new System.Windows.Forms.TextBox();
			this.TxtItemId = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.TxtFloorPlan = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.ImgDungeon = new System.Windows.Forms.PictureBox();
			this.label7 = new System.Windows.Forms.Label();
			this.BtnSave = new System.Windows.Forms.Button();
			this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.TxtDungeon = new System.Windows.Forms.TextBox();
			this.ChkImage = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.ImgDungeon)).BeginInit();
			this.SuspendLayout();
			// 
			// BtnGenerateImage
			// 
			this.BtnGenerateImage.Location = new System.Drawing.Point(15, 139);
			this.BtnGenerateImage.Name = "BtnGenerateImage";
			this.BtnGenerateImage.Size = new System.Drawing.Size(196, 31);
			this.BtnGenerateImage.TabIndex = 0;
			this.BtnGenerateImage.Text = "Generate";
			this.BtnGenerateImage.UseVisualStyleBackColor = true;
			this.BtnGenerateImage.Click += new System.EventHandler(this.BtnGenerateImage_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(82, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Dungeon Name";
			// 
			// TxtDungeonName
			// 
			this.TxtDungeonName.Location = new System.Drawing.Point(15, 25);
			this.TxtDungeonName.Name = "TxtDungeonName";
			this.TxtDungeonName.Size = new System.Drawing.Size(246, 20);
			this.TxtDungeonName.TabIndex = 2;
			this.TxtDungeonName.Text = "TirCho_Alby_DropTest_Dungeon";
			// 
			// TxtItemId
			// 
			this.TxtItemId.Location = new System.Drawing.Point(15, 69);
			this.TxtItemId.Name = "TxtItemId";
			this.TxtItemId.Size = new System.Drawing.Size(246, 20);
			this.TxtItemId.TabIndex = 6;
			this.TxtItemId.Text = "2000";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 53);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(38, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Item id";
			// 
			// TxtFloorPlan
			// 
			this.TxtFloorPlan.Location = new System.Drawing.Point(15, 113);
			this.TxtFloorPlan.Name = "TxtFloorPlan";
			this.TxtFloorPlan.Size = new System.Drawing.Size(246, 20);
			this.TxtFloorPlan.TabIndex = 12;
			this.TxtFloorPlan.Text = "0";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 97);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(53, 13);
			this.label6.TabIndex = 11;
			this.label6.Text = "Floor plan";
			// 
			// ImgDungeon
			// 
			this.ImgDungeon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ImgDungeon.Location = new System.Drawing.Point(292, 12);
			this.ImgDungeon.Name = "ImgDungeon";
			this.ImgDungeon.Size = new System.Drawing.Size(590, 411);
			this.ImgDungeon.TabIndex = 13;
			this.ImgDungeon.TabStop = false;
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.label7.Location = new System.Drawing.Point(278, -10);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(657, 475);
			this.label7.TabIndex = 15;
			// 
			// BtnSave
			// 
			this.BtnSave.Location = new System.Drawing.Point(217, 139);
			this.BtnSave.Name = "BtnSave";
			this.BtnSave.Size = new System.Drawing.Size(44, 31);
			this.BtnSave.TabIndex = 16;
			this.BtnSave.Text = "Save";
			this.BtnSave.UseVisualStyleBackColor = true;
			this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
			// 
			// SaveFileDialog
			// 
			this.SaveFileDialog.Filter = "PNG-File|*.png";
			// 
			// TxtDungeon
			// 
			this.TxtDungeon.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TxtDungeon.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtDungeon.Location = new System.Drawing.Point(469, 141);
			this.TxtDungeon.Multiline = true;
			this.TxtDungeon.Name = "TxtDungeon";
			this.TxtDungeon.ReadOnly = true;
			this.TxtDungeon.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TxtDungeon.Size = new System.Drawing.Size(275, 214);
			this.TxtDungeon.TabIndex = 17;
			this.TxtDungeon.Visible = false;
			this.TxtDungeon.WordWrap = false;
			// 
			// ChkImage
			// 
			this.ChkImage.AutoSize = true;
			this.ChkImage.Checked = true;
			this.ChkImage.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ChkImage.Location = new System.Drawing.Point(15, 176);
			this.ChkImage.Name = "ChkImage";
			this.ChkImage.Size = new System.Drawing.Size(55, 17);
			this.ChkImage.TabIndex = 18;
			this.ChkImage.Text = "Image";
			this.ChkImage.UseVisualStyleBackColor = true;
			this.ChkImage.CheckedChanged += new System.EventHandler(this.ChkImage_CheckedChanged);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.Location = new System.Drawing.Point(12, 385);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(249, 38);
			this.label2.TabIndex = 19;
			this.label2.Text = "Select a DungeonInfo packet in Pale to\r\ngenerate that dungeon.";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// FrmDunGen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(894, 435);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.ChkImage);
			this.Controls.Add(this.TxtDungeon);
			this.Controls.Add(this.BtnSave);
			this.Controls.Add(this.ImgDungeon);
			this.Controls.Add(this.TxtFloorPlan);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.TxtItemId);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.TxtDungeonName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.BtnGenerateImage);
			this.Controls.Add(this.label7);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmDunGen";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DunGen";
			this.Load += new System.EventHandler(this.FrmMain_Load);
			((System.ComponentModel.ISupportInitialize)(this.ImgDungeon)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button BtnGenerateImage;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox TxtDungeonName;
		private System.Windows.Forms.TextBox TxtItemId;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox TxtFloorPlan;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.PictureBox ImgDungeon;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button BtnSave;
		private System.Windows.Forms.SaveFileDialog SaveFileDialog;
		private System.Windows.Forms.TextBox TxtDungeon;
		private System.Windows.Forms.CheckBox ChkImage;
		private System.Windows.Forms.Label label2;
	}
}