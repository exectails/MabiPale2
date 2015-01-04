using MabiPale2.Plugins.PacketAnalyzer.Properties;
using MabiPale2.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MabiPale2.Plugins.PacketAnalyzer
{
	public class Main : Plugin
	{
		private FrmInfo form;

		public override string Name
		{
			get { return "Packet PacketAnalyzer"; }
		}

		public Main(IPluginManager pluginManager)
			: base(pluginManager)
		{
		}

		public override void Initialize()
		{
			manager.AddToMenu(Name, OnClick);
			manager.AddToToolbar(Resources.report_magnify, Name, OnClick);

			manager.Selected += OnSelected;
		}

		private void OnClick(object sender, EventArgs e)
		{
			if (form == null || form.IsDisposed)
				manager.OpenCentered(form = new FrmInfo());
			else
				form.Focus();

			var selected = manager.GetSelectedPacket();
			if (selected != null)
			{
				OnSelected(selected);
				selected.Packet.Rewind();
			}
		}

		private void OnSelected(PalePacket palePacket)
		{
			if (form != null && !form.IsDisposed)
				form.OnSelected(palePacket);
		}
	}
}
