using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MabiPale2
{
	public partial class FrmAlissaSelection : Form
	{
		public static FoundWindow Selection;

		public FrmAlissaSelection(IList<FoundWindow> windows)
		{
			InitializeComponent();

			foreach (var window in windows.OrderBy(a => a.ClassName))
				CboWindows.Items.Add(window);
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BtnConnect_Click(object sender, EventArgs e)
		{
			if (CboWindows.SelectedItem == null)
			{
				MessageBox.Show("Please select a packet provider.", Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}

			Selection = (FoundWindow)CboWindows.SelectedItem;
			DialogResult = DialogResult.OK;

			Close();
		}
	}
}
