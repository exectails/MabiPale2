namespace MabiPale2
{
	partial class FrmAlissaSelection
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAlissaSelection));
			this.CboWindows = new System.Windows.Forms.ComboBox();
			this.BtnConnect = new System.Windows.Forms.Button();
			this.BtnCancel = new System.Windows.Forms.Button();
			this.LblInfo = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// CboWindows
			// 
			this.CboWindows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboWindows.FormattingEnabled = true;
			this.CboWindows.Location = new System.Drawing.Point(15, 42);
			this.CboWindows.Name = "CboWindows";
			this.CboWindows.Size = new System.Drawing.Size(215, 21);
			this.CboWindows.TabIndex = 0;
			this.CboWindows.SelectedIndexChanged += new System.EventHandler(this.CboWindows_SelectedIndexChanged);
			// 
			// BtnConnect
			// 
			this.BtnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnConnect.Enabled = false;
			this.BtnConnect.Location = new System.Drawing.Point(74, 73);
			this.BtnConnect.Name = "BtnConnect";
			this.BtnConnect.Size = new System.Drawing.Size(75, 23);
			this.BtnConnect.TabIndex = 1;
			this.BtnConnect.Text = "Connect";
			this.BtnConnect.UseVisualStyleBackColor = true;
			this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
			// 
			// BtnCancel
			// 
			this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BtnCancel.Location = new System.Drawing.Point(155, 73);
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.Size = new System.Drawing.Size(75, 23);
			this.BtnCancel.TabIndex = 2;
			this.BtnCancel.Text = "Cancel";
			this.BtnCancel.UseVisualStyleBackColor = true;
			this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// LblInfo
			// 
			this.LblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LblInfo.Location = new System.Drawing.Point(12, 9);
			this.LblInfo.Name = "LblInfo";
			this.LblInfo.Size = new System.Drawing.Size(218, 30);
			this.LblInfo.TabIndex = 3;
			this.LblInfo.Text = "Select the packet provider you\'d like to use during this session from the list be" +
    "low.";
			// 
			// FrmAlissaSelection
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.BtnCancel;
			this.ClientSize = new System.Drawing.Size(242, 108);
			this.Controls.Add(this.LblInfo);
			this.Controls.Add(this.BtnCancel);
			this.Controls.Add(this.BtnConnect);
			this.Controls.Add(this.CboWindows);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmAlissaSelection";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Packet Provider";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox CboWindows;
		private System.Windows.Forms.Button BtnConnect;
		private System.Windows.Forms.Button BtnCancel;
		private System.Windows.Forms.Label LblInfo;
	}
}