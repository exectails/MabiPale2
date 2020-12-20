using MabiPale2.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MabiPale2
{
	public partial class FrmSettings : Form
	{
		private const string OpsFileDefaultName = "ops.txt";

		public FrmSettings(string log)
		{
			InitializeComponent();

			TxtErrorLog.Text = log;
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void FrmSettings_Load(object sender, EventArgs e)
		{
			ChkFilterRecvEnabled.Checked = Settings.Default.FilterRecvEnabled;
			ChkFilterSendEnabled.Checked = Settings.Default.FilterSendEnabled;
			TxtFilterRecv.Text = Regex.Replace(Settings.Default.FilterRecv.TrimStart(), "\r?\n\r?\n", Environment.NewLine);
			TxtFilterSend.Text = Regex.Replace(Settings.Default.FilterSend.TrimStart(), "\r?\n\r?\n", Environment.NewLine);
			if (Settings.Default.FilterExcludeModeActive)
				RadFilterExcludeMode.Checked = true;
			else
				RadFilterIncludeMode.Checked = true;

			this.CboOpsFile.Items.Clear();
			foreach (var fileName in Directory.EnumerateFiles(".", "ops*.txt", SearchOption.TopDirectoryOnly))
			{
				var name = fileName.Replace("\\", "/");
				if (name.StartsWith("./"))
					name = name.Substring(2);

				this.CboOpsFile.Items.Add(name);
			}

			if (this.CboOpsFile.Items.Count == 0)
				this.CboOpsFile.Items.Add(OpsFileDefaultName);

			this.CboOpsFile.SelectedIndex = 0;

			try
			{
				TxtOpNames.Text = File.ReadAllText(OpsFileDefaultName);
			}
			catch
			{
			}
		}

		private void FrmSettings_FormClosing(object sender, FormClosingEventArgs e)
		{
			// Do not save if cancelling or Close button is clicked.
			if (DialogResult != DialogResult.OK)
				return;

			Settings.Default.FilterRecvEnabled = ChkFilterRecvEnabled.Checked;
			Settings.Default.FilterSendEnabled = ChkFilterSendEnabled.Checked;
			Settings.Default.FilterRecv = TxtFilterRecv.Text;
			Settings.Default.FilterSend = TxtFilterSend.Text;
			Settings.Default.FilterExcludeModeActive = RadFilterExcludeMode.Checked;
			Settings.Default.OpsFileName = this.CboOpsFile.SelectedItem.ToString();
			Settings.Default.Save();

			try
			{
				var fileName = Settings.Default.OpsFileName;
				File.WriteAllText(fileName, TxtOpNames.Text);
			}
			catch
			{
			}
		}

		private void CboOpsFile_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				var fileName = this.CboOpsFile.SelectedItem.ToString();
				TxtOpNames.Text = File.ReadAllText(fileName);
			}
			catch
			{
			}
		}
	}
}
