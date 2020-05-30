using Aura.Mabi.Const;
using MabiPale2.Shared;
using System.Text;

namespace MabiPale2.Plugins.PacketAnalyzer.Packets
{
	internal class ConditionUpdate : IAnalyzer
	{
		public string AnalyzePacket(PalePacket palePacket)
		{
			var sb = new StringBuilder();

			// [200300, NA262 (2017-10-20)]
			// The condition format changed, first, with the longs, is the
			// old one, the other is the new one.

			// [(2020-05-30)]
			// Updated Pale's Mabi.dll, which doesn't include the old conditions
			// format.
			/*
			if (palePacket.Packet.Peek() == Shared.PacketElementType.Long)
			{
				var conditionsA = palePacket.Packet.GetLong();
				var conditionsB = palePacket.Packet.GetLong();
				var conditionsC = palePacket.Packet.GetLong();
				var conditionsD = palePacket.Packet.Peek() == Shared.PacketElementType.Long ? palePacket.Packet.GetLong() : 0;
				var conditionsE = palePacket.Packet.Peek() == Shared.PacketElementType.Long ? palePacket.Packet.GetLong() : 0;
				var conditionsF = palePacket.Packet.Peek() == Shared.PacketElementType.Long ? palePacket.Packet.GetLong() : 0;
				var conditionsG = palePacket.Packet.Peek() == Shared.PacketElementType.Long ? palePacket.Packet.GetLong() : 0;

				sb.AppendLine("A: {0}", (ConditionsA)conditionsA);
				sb.AppendLine("B: {0}", (ConditionsB)conditionsB);
				sb.AppendLine("C: {0}", (ConditionsC)conditionsC);
				sb.AppendLine("D: {0}", (ConditionsD)conditionsD);
				sb.AppendLine("E: {0}", (ConditionsE)conditionsE);
				sb.AppendLine("F: {0}", (ConditionsF)conditionsF);
				sb.AppendLine("G: {0}", (ConditionsG)conditionsG);

				var extraCount = palePacket.Packet.GetInt();
				if (extraCount != 0)
					sb.AppendLine();

				for (int i = 0; i < extraCount; ++i)
				{
					var id = palePacket.Packet.GetInt();
					var str = palePacket.Packet.GetString();
					var div = id / 64;
					var mod = id % 64;

					switch (div)
					{
						case 0: sb.AppendLine("{0} - {1}", (ConditionsA)((ulong)1 << mod), str); break;
						case 1: sb.AppendLine("{0} - {1}", (ConditionsB)((ulong)1 << mod), str); break;
						case 2: sb.AppendLine("{0} - {1}", (ConditionsC)((ulong)1 << mod), str); break;
						case 3: sb.AppendLine("{0} - {1}", (ConditionsD)((ulong)1 << mod), str); break;
						case 4: sb.AppendLine("{0} - {1}", (ConditionsE)((ulong)1 << mod), str); break;
						case 5: sb.AppendLine("{0} - {1}", (ConditionsF)((ulong)1 << mod), str); break;
						case 6: sb.AppendLine("{0} - {1}", (ConditionsG)((ulong)1 << mod), str); break;
						default:
							var ident = (char)('A' + div) + ":0x" + ((ulong)1 << mod).ToString("X16");
							sb.AppendLine("{0} - {1}", ident, str);
							break;
					}
				}
			}
			else
			{
				var active = palePacket.Packet.GetBool();
				var conditionId = palePacket.Packet.GetInt();

				sb.AppendLine("Condition Id: {0} ({1})", (ConditionId)conditionId, conditionId);
				sb.AppendLine("Active: {0}", (active ? "Yes" : "No"));

				if (active)
				{
					palePacket.Packet.GetLong();
					var parameters = palePacket.Packet.GetString();

					sb.AppendLine("Parameters: {0}", parameters);
				}
			}
			*/

			var active = palePacket.Packet.GetBool();
			var conditionId = palePacket.Packet.GetInt();

			sb.AppendLine("Condition Id: {0} ({1})", (ConditionId)conditionId, conditionId);
			sb.AppendLine("Active: {0}", (active ? "Yes" : "No"));

			if (active)
			{
				palePacket.Packet.GetLong();
				var parameters = palePacket.Packet.GetString();

				sb.AppendLine("Parameters: {0}", parameters);
			}

			return sb.ToString();
		}
	}
}
