using MabiLib.Const;
using MabiLib.Structs;
using MabiPale2.Shared;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MabiPale2.Plugins.EntityLogger
{
	[Serializable]
	public class Prop : IEntity
	{
		public long EntityId { get; set; }
		public int Id { get; set; }
		public string State { get; set; }
		public string Xml { get; set; }

		// Server only
		public string Name { get; set; }
		public string Title { get; set; }
		public PropInfo Info { get; set; }

		// Client only
		public float Direction { get; set; }

		public string EntityType
		{
			get { return "Prop"; }
			set { }
		}

		public bool IsServerProp
		{
			get { return EntityId >= MabiId.ServerProps; }
			set { }
		}

		public string GetInfo()
		{
			var sb = new StringBuilder();

			sb.AppendLine((IsServerProp ? "Server" : "Client") + " sided prop");
			sb.AppendLine();

			sb.AppendLine("Entity id: {0:X8}", EntityId);
			sb.AppendLine("Prop id: {0}", Id);
			sb.AppendLine("State: {0}", State);
			sb.AppendLine("XML: {0}", Xml);

			if (IsServerProp)
			{
				sb.AppendLine("Name: {0}", Name);
				sb.AppendLine("Title: {0}", Title);
				sb.AppendLine("Info: ");
				sb.AppendLine("   Altitude: {0:0.########}", Info.Altitude);
				sb.AppendLine("   Color1: 0x{0:X8}", Info.Color1);
				sb.AppendLine("   Color2: 0x{0:X8}", Info.Color2);
				sb.AppendLine("   Color3: 0x{0:X8}", Info.Color3);
				sb.AppendLine("   Color4: 0x{0:X8}", Info.Color4);
				sb.AppendLine("   Color5: 0x{0:X8}", Info.Color5);
				sb.AppendLine("   Color6: 0x{0:X8}", Info.Color6);
				sb.AppendLine("   Color7: 0x{0:X8}", Info.Color7);
				sb.AppendLine("   Color8: 0x{0:X8}", Info.Color8);
				sb.AppendLine("   Color9: 0x{0:X8}", Info.Color9);
				sb.AppendLine("   Direction: {0:0.########}", Info.Direction);
				sb.AppendLine("   FixedAltitude: {0}", Info.FixedAltitude);
				sb.AppendLine("   Id: {0}", Info.Id);
				sb.AppendLine("   Region: {0}", Info.Region);
				sb.AppendLine("   Scale: {0:0.########}", Info.Scale);
				sb.AppendLine("   X: {0:0.########}", Info.X);
				sb.AppendLine("   Y: {0:0.########}", Info.Y);
			}
			else
				sb.AppendLine("Direction: {0}", Direction);

			return sb.ToString();
		}

		public string GetScript()
		{
			var sb = new StringBuilder();

			if (IsServerProp)
			{
				sb.AppendLine("var prop = SpawnProp({0}, {1}, {2}, {3}, {4:0.########f}, {5:0.########f});", Id, Info.Region, Info.X, Info.Y, Info.Direction, Info.Scale);

				if (!string.IsNullOrWhiteSpace(State)) sb.AppendLine("prop.State = \"{0}\"", State);
				if (!string.IsNullOrWhiteSpace(Xml)) sb.AppendLine("prop.Xml = XElement.Parse(\"{0}\");", Xml.Replace("\"", "\\\""));
				if (!string.IsNullOrWhiteSpace(Name)) sb.AppendLine("prop.Name = \"{0}\";", Name);
				if (!string.IsNullOrWhiteSpace(Title)) sb.AppendLine("prop.Title = \"{0}\";", Title);

				if (Info.Altitude != 0) sb.AppendLine("prop.Info.Altitude = {0:0.########f};", Info.Altitude);
				if (Info.FixedAltitude != 0) sb.AppendLine("prop.Info.FixedAltitude = {0};", Info.FixedAltitude);

				if (Info.Color1 != 0xFF808080) sb.AppendFormat("prop.Info.Color1 = 0x{0:X8};", Info.Color1);
				if (Info.Color2 != 0xFF808080) sb.AppendFormat("prop.Info.Color2 = 0x{0:X8};", Info.Color2);
				if (Info.Color3 != 0xFF808080) sb.AppendFormat("prop.Info.Color3 = 0x{0:X8};", Info.Color3);
				if (Info.Color4 != 0xFF808080) sb.AppendFormat("prop.Info.Color4 = 0x{0:X8};", Info.Color4);
				if (Info.Color5 != 0xFF808080) sb.AppendFormat("prop.Info.Color5 = 0x{0:X8};", Info.Color5);
				if (Info.Color6 != 0xFF808080) sb.AppendFormat("prop.Info.Color6 = 0x{0:X8};", Info.Color6);
				if (Info.Color7 != 0xFF808080) sb.AppendFormat("prop.Info.Color7 = 0x{0:X8};", Info.Color7);
				if (Info.Color8 != 0xFF808080) sb.AppendFormat("prop.Info.Color8 = 0x{0:X8};", Info.Color8);
				if (Info.Color9 != 0xFF808080) sb.AppendFormat("prop.Info.Color9 = 0x{0:X8};", Info.Color9);
			}
			else
			{
				var format =
@"SetPropBehavior(0x{0:X8}, (creature, prop) =>
{{
	// On interaction...
}});
";
				sb.AppendFormat(format, EntityId);
			}

			return sb.ToString();
		}
	}
}
