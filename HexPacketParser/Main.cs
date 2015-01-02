using MabiPale2.Plugins.HexPacketParser.Properties;
using System;

namespace MabiPale2.Plugins.HexPacketParser
{
	public class Main : Plugin
	{
		public Main(IPluginManager pluginManager)
			: base(pluginManager)
		{
		}

		public override string Name
		{
			get { return "Packet Parser"; }
		}

		public override void Initialize()
		{
			manager.AddToToolbar(Resources.folder_page_white, Name, OnClick);
			manager.AddToMenu(Name, OnClick);
		}

		private void OnClick(object sender, EventArgs args)
		{
			manager.OpenCentered(new FrmParser());
		}
	}
}
