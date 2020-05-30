using Aura.Mabi.Const;
using MabiPale2.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MabiPale2.Plugins.PacketAnalyzer.Packets
{
	internal class CombatActionPack : IAnalyzer
	{
		public string AnalyzePacket(PalePacket palePacket)
		{
			var sb = new StringBuilder();

			sb.AppendLine("Id: " + palePacket.Packet.GetInt());
			sb.AppendLine("Prev Id: " + palePacket.Packet.GetInt());
			sb.AppendLine("Hit: " + palePacket.Packet.GetByte());
			palePacket.Packet.GetByte(); // [220200, NA296 (2019-04-11)]
			sb.AppendLine("Type: " + palePacket.Packet.GetByte());
			palePacket.Packet.GetByte();
			sb.AppendLine();

			var count = palePacket.Packet.GetInt();
			for (int i = 0; i < count; ++i)
			{
				var len = palePacket.Packet.GetInt();
				var buff = palePacket.Packet.GetBin();

				var actionPacket = new MabiPale2.Shared.Packet(buff, 0);
				actionPacket.GetInt();
				if (i > 0)
					sb.AppendLine();

				var creatureEntityId = actionPacket.GetLong();
				var type = (CombatActionType)actionPacket.GetByte();

				var attackeraction = len < 86 && type != 0; // Hot fix, TODO: Proper check of type.

				sb.AppendLine(attackeraction ? "Attacker Action" : "Target Action");
				sb.AppendLine("--------------------");
				sb.AppendLine("Creature: " + creatureEntityId.ToString("X16"));
				sb.AppendLine("Type: " + type);
				sb.AppendLine("Stun: " + actionPacket.GetShort());
				sb.AppendLine("Skill Id: " + (SkillId)actionPacket.GetShort());
				actionPacket.GetShort();
				if (actionPacket.Peek() == Shared.PacketElementType.Short)
					actionPacket.GetShort(); // [200300, NA258 (2017-08-19)] ? 

				// AttackerAction
				if (attackeraction)
				{
					sb.AppendLine("Target: " + actionPacket.GetLong().ToString("X16"));

					var options = new List<uint>();
					var topt = actionPacket.GetInt();
					for (uint foo2 = 1; foo2 < 0x80000000;)
					{
						if ((topt & foo2) != 0)
							options.Add(foo2);
						foo2 <<= 1;
					}
					var strOptions = string.Join(", ", options.Select(a =>
					{
						var en = (AttackerOptions)a;
						return "0x" + a.ToString("X2") + (en.ToString() != a.ToString() ? "(" + en + ")" : "");
					}));

					sb.AppendLine("Options: " + strOptions);

					actionPacket.GetByte();
					actionPacket.GetByte();

					// Another int was added in front of the position at
					// some point, to handle old and new logs we have to
					// read the first two ints and then determine if there's
					// another one. If there is, we shift the information,
					// so the variables point to the correct info.

					int unkInt, x, y;

					x = actionPacket.GetInt();
					y = actionPacket.GetInt();

					if (actionPacket.NextIs(Shared.PacketElementType.Int))
					{
						unkInt = x;
						x = y;
						y = actionPacket.GetInt();
					}

					sb.AppendLine("X: " + x);
					sb.AppendLine("Y: " + y);
					if (actionPacket.NextIs(Shared.PacketElementType.Long))
						sb.AppendLine("Prop: " + actionPacket.GetLong().ToString("X16"));
				}
				// TargetAction
				else
				{
					// Target actions might end here, widnessed with a packet
					// that had "97" as the previous short.
					if (actionPacket.Peek() != Shared.PacketElementType.None)
					{
						// Target used Defense or Counter
						if (type.HasFlag(CombatActionType.Defended) || type.HasFlag(CombatActionType.CounteredHit) || type.HasFlag((CombatActionType)0x73) || type.HasFlag((CombatActionType)0x13))
						{
							var attackerEntityId = actionPacket.GetLong();
							actionPacket.GetInt();
							actionPacket.GetByte();
							actionPacket.GetByte();
							actionPacket.GetInt();
							var x = actionPacket.GetInt();
							var y = actionPacket.GetInt();
						}

						var options = new List<uint>();
						var topt = actionPacket.GetInt();
						for (uint foo2 = 1; foo2 < 0x80000000;)
						{
							if ((topt & foo2) != 0)
								options.Add(foo2);
							foo2 <<= 1;
						}
						var strOptions = string.Join(", ", options.Select(a =>
						{
							var en = (TargetOptions)a;
							return "0x" + a.ToString("X2") + (en.ToString() != a.ToString() ? "(" + en + ")" : "");
						}));

						sb.AppendLine("Options: " + strOptions);
						sb.AppendLine("Damage: " + actionPacket.GetFloat());
						sb.AppendLine("Wound: " + actionPacket.GetFloat());
						sb.AppendLine("Mana Damage?: " + actionPacket.GetInt());

						if (actionPacket.NextIs(Shared.PacketElementType.Int))
							actionPacket.GetInt(); // [210100, NA280 (2018-06-14)]

						sb.AppendLine("X-Diff: " + actionPacket.GetFloat());
						sb.AppendLine("Y-Diff: " + actionPacket.GetFloat());
						if (actionPacket.NextIs(Shared.PacketElementType.Float))
						{
							sb.AppendLine("New X: " + actionPacket.GetFloat());
							sb.AppendLine("New Y: " + actionPacket.GetFloat());

							// [190200, NA203 (22.04.2015)]
							if (actionPacket.Peek() == Shared.PacketElementType.Int)
							{
								actionPacket.PutInt(0);
							}
						}

						// MultiHit Target Option
						if (actionPacket.NextIs(Shared.PacketElementType.Int))
						{
							sb.AppendLine("MultiHitCount: " + actionPacket.GetInt());
							sb.AppendLine("MultiHitInterval: " + actionPacket.GetInt());
							sb.AppendLine("MultiHitUnk: " + actionPacket.GetInt());
							sb.AppendLine("MultiHitDivisionSeed: " + actionPacket.GetInt());
						}

						sb.AppendLine("EffectFlags: " + actionPacket.GetByte());
						sb.AppendLine("Delay: " + actionPacket.GetInt());
						sb.AppendLine("Attacker: " + actionPacket.GetLong().ToString("X16"));
					}
				}
			}

			return sb.ToString();
		}
	}
}
