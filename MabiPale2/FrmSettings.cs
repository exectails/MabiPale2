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

			try
			{
				TxtOpNames.Text = File.ReadAllText("ops.txt");
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
			Settings.Default.Save();

			try
			{
				File.WriteAllText("ops.txt", TxtOpNames.Text);
			}
			catch
			{
			}
		}
	}
}
