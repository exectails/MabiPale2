using Aura.Mabi.Network;
using MabiPale2.Plugins.DunGen.Properties;
using MabiPale2.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MabiPale2.Plugins.DunGen
{
	public class Main : Plugin
	{
		private FrmDunGen form;

		public override string Name
		{
			get { return "DunGen"; }
		}

		public Main(IPluginManager pluginManager)
			: base(pluginManager)
		{
		}

		public override void Initialize()
		{
			manager.AddToMenu(Name, OnClick);
			manager.AddToToolbar(Resources.chart_organisation, Name, OnClick);

			manager.Selected += OnSelected;
		}

		private void OnClick(object sender, EventArgs e)
		{
			if (form == null || form.IsDisposed)
			{
				form = new FrmDunGen();
				manager.OpenCentered(form);
			}
			else
			{
				form.Focus();
			}

			var selected = manager.GetSelectedPacket();
			if (selected != null)
			{
				OnSelected(selected);
				selected.Packet.Rewind();
			}
		}

		private void OnSelected(PalePacket palePacket)
		{
			if (form == null || form.IsDisposed || palePacket.Op != Op.DungeonInfo)
				return;

			if (palePacket.Packet.KR72Header)
			{
				palePacket.Packet.GetLong();
				var name = palePacket.Packet.GetString();
				var itemId = palePacket.Packet.GetInt();
				var floorPlan = palePacket.Packet.GetInt();
				palePacket.Packet.GetLong();

				form.SetValuesAndGenerate(name, itemId, floorPlan);
			}
			else
			{
				palePacket.Packet.GetLong();
				palePacket.Packet.GetLong();
				palePacket.Packet.GetByte();
				var name = palePacket.Packet.GetString();
				var itemId = palePacket.Packet.GetInt();
				var seed = palePacket.Packet.GetInt();
				var floorPlan = palePacket.Packet.GetInt();

				form.SetValuesAndGenerate(name, itemId, floorPlan);
			}
		}
	}
}
