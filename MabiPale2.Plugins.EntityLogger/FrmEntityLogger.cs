using MabiPale2.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MabiPale2.Plugins.EntityLogger
{
	public partial class FrmEntityLogger : Form
	{
		public FrmEntityLogger(List<IEntity> entities)
		{
			InitializeComponent();

			if (entities == null)
				return;

			lock (entities)
			{
				foreach (var entity in entities)
					AddEntity(entity);
			}

			LstEntities.ListViewItemSorter = new ListViewColumnSorter();
		}

		public void AddEntity(IEntity entity)
		{
			LstEntities.InvokeIfRequired((MethodInvoker)delegate
			{
				var lvi = new ListViewItem(entity.EntityType);
				lvi.SubItems.Add(entity.EntityId.ToString("X16"));
				lvi.SubItems.Add(entity.Name);
				lvi.Tag = entity;

				LstEntities.Items.Add(lvi);
			});
		}

		public void ClearEntities()
		{
			LstEntities.InvokeIfRequired((MethodInvoker)delegate
			{
				LstEntities.Items.Clear();
				TxtEntityInfo.Clear();
				TxtEntityScript.Clear();
			});
		}

		private void BtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void LstEntities_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (LstEntities.SelectedItems.Count == 0)
			{
				TxtEntityInfo.Text = "";
				TxtEntityScript.Text = "";
				return;
			}

			var selected = LstEntities.SelectedItems[0];

			TxtEntityInfo.Text = (selected.Tag as IEntity).GetInfo();
			TxtEntityScript.Text = (selected.Tag as IEntity).GetScript();
		}

		private void LstEntities_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			var sorter = (ListViewColumnSorter)LstEntities.ListViewItemSorter;

			if (e.Column == sorter.SortColumn)
			{
				if (sorter.Order == SortOrder.Ascending)
					sorter.Order = SortOrder.Descending;
				else
					sorter.Order = SortOrder.Ascending;
			}
			else
			{
				sorter.SortColumn = e.Column;
				sorter.Order = SortOrder.Ascending;
			}

			LstEntities.Sort();
		}

		private void BtnInfo_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Entity Logger reads all logged packets and displays information about the creatures and props found.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
