using Aura.Mabi.Const;
using MabiPale2.Shared;
using System.Globalization;
using System.Text;

namespace MabiPale2.Plugins.PacketAnalyzer.Packets
{
	internal class StatUpdate : IAnalyzer
	{
		public string AnalyzePacket(PalePacket palePacket)
		{
			palePacket.Packet.GetByte();
			var count = palePacket.Packet.GetInt();

			var sb = new StringBuilder();
			for (int i = 0; i < count; ++i)
			{
				sb.AppendFormat("{0}: ", (Stat)palePacket.Packet.GetInt());

				switch (palePacket.Packet.Peek())
				{
					case Shared.PacketElementType.Byte: sb.AppendLine(palePacket.Packet.GetByte().ToString()); break;
					case Shared.PacketElementType.Short: sb.AppendLine(palePacket.Packet.GetShort().ToString()); break;
					case Shared.PacketElementType.Int: sb.AppendLine(palePacket.Packet.GetInt().ToString()); break;
					case Shared.PacketElementType.Long: sb.AppendLine(palePacket.Packet.GetLong().ToString()); break;
					case Shared.PacketElementType.Float: sb.AppendLine(palePacket.Packet.GetFloat().ToString(CultureInfo.InvariantCulture)); break;
					case Shared.PacketElementType.String: sb.AppendLine(palePacket.Packet.GetString().ToString()); break;
					default: palePacket.Packet.Skip(1); sb.AppendLine("?"); break;
				}
			}

			return sb.ToString();
		}
	}
}
