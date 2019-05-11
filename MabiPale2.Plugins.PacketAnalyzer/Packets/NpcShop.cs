using Aura.Mabi.Structs;
using MabiPale2.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MabiPale2.Plugins.PacketAnalyzer.Packets
{
	internal class NpcShop : IAnalyzer
	{
		private class ShopItem
		{
			public ItemInfo Info { get; set; }
			public ItemOptionInfo OptionInfo { get; set; }
			public string MetaData1 { get; set; }
		}

		public string AnalyzePacket(PalePacket palePacket)
		{
			palePacket.Packet.GetString();
			palePacket.Packet.GetByte();
			palePacket.Packet.GetByte();
			palePacket.Packet.GetInt();

			var tabCount = palePacket.Packet.GetByte();
			var tabs = new Dictionary<string, List<ShopItem>>();
			for (int i = 0; i < tabCount; ++i)
			{
				var name = palePacket.Packet.GetString();

				if (!tabs.ContainsKey(name))
					tabs.Add(name, new List<ShopItem>());

				// [160200] ?
				if (palePacket.Packet.NextIs(Shared.PacketElementType.Byte))
					palePacket.Packet.GetByte();

				var itemCount = palePacket.Packet.GetShort();
				for (int j = 0; j < itemCount; ++j)
				{
					palePacket.Packet.GetLong();
					palePacket.Packet.GetByte();
					var itemInfo = palePacket.Packet.GetObj<ItemInfo>();
					var itemOptionInfo = palePacket.Packet.GetObj<ItemOptionInfo>();
					var metaData1 = palePacket.Packet.GetString();
					var metaData2 = "";
					if (palePacket.Packet.NextIs(Shared.PacketElementType.String))
						metaData2 = palePacket.Packet.GetString();
					palePacket.Packet.GetByte();
					palePacket.Packet.GetLong();

					// [190100, NA200 (2015-01-15)] New/Combined
					if (palePacket.Packet.NextIs(Shared.PacketElementType.Byte))
					{
						palePacket.Packet.GetByte();
						palePacket.Packet.GetByte();
					}

					// [200200, NA252 (2017-05-18)]
					// New long that is equal to the owner's entity id for all
					// items in the creature info packet. Maybe the id of the
					// owner?
					if (palePacket.Packet.NextIs(Shared.PacketElementType.Long))
					{
						palePacket.Packet.GetLong();
					}

					// [200200, NA297 (2019-05-09] ?
					if (palePacket.Packet.NextIs(Shared.PacketElementType.Int))
					{
						palePacket.Packet.GetInt();
					}

					tabs[name].Add(new ShopItem() { Info = itemInfo, OptionInfo = itemOptionInfo, MetaData1 = metaData1 });
				}
			}

			var sb = new StringBuilder();
			var prev = "";
			foreach (var tab in tabs.OrderBy(a => a.Key))
			{
				var name = tab.Key.Substring(tab.Key.IndexOf("]") + 1);

				if (prev != name)
				{
					if (prev != "")
						sb.AppendLine();
					//sb.AppendLine("// " + name);
				}

				prev = name;

				foreach (var item in tab.Value.OrderBy(a => a.Info.Id))
				{
					var others = tab.Value.Count(a => a.Info.Id == item.Info.Id && a.Info.Amount != item.Info.Amount) != 0;

					if (!string.IsNullOrWhiteSpace(item.MetaData1) && item.Info.Id != 70023)
					{
						if (item.MetaData1.Contains("FORMID:"))
						{
							sb.AppendLine("Add(\"{0}\", {1}, \"{2}\", {3});", name, item.Info.Id, item.MetaData1, item.OptionInfo.Price);
						}
						else if (item.MetaData1.Contains("QSTTIP:"))
						{
							var start = "QSTTIP:s:N_".Length;
							var questName = item.MetaData1.Substring(start, item.MetaData1.IndexOf("|") - start);
							sb.AppendLine("//AddQuest(\"{0}\", InsertQuestId, {2}); // {3}", name, item.Info.Id, item.OptionInfo.Price, questName);
						}
						else
						{
							sb.AppendLine("Add(\"{0}\", {1}, \"{2}\");", name, item.Info.Id, item.MetaData1);
						}
					}
					else if (item.Info.Amount <= 1 && !others)
					{
						sb.AppendLine("Add(\"{0}\", {1});", name, item.Info.Id);
					}
					else
					{
						sb.AppendLine("Add(\"{0}\", {1}, {2});", name, item.Info.Id, Math.Max(1, (int)item.Info.Amount));
					}
				}
			}

			//TxtInfo.WordWrap = false;
			return sb.ToString();
		}
	}
}
