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
			var packet = palePacket.Packet;
			var sb = new StringBuilder();

			sb.AppendLine("Id: " + packet.GetInt());
			sb.AppendLine("Prev Id: " + packet.GetInt());
			sb.AppendLine("Hit: " + packet.GetByte());

			if (packet.NextAre(PacketElementType.Byte, PacketElementType.Byte, PacketElementType.Byte))
				packet.GetByte(); // [220200, NA296 (2019-04-11)]

			sb.AppendLine("Type: " + packet.GetByte());
			packet.GetByte(); // Flags
			sb.AppendLine();

			var count = packet.GetInt();
			for (int i = 0; i < count; ++i)
			{
				var len = packet.GetInt();
				var buff = packet.GetBin();

				var actionPacket = new Packet(buff, 0);
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
				if (actionPacket.Peek() == PacketElementType.Short)
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

					// ^ This int appears to be the attacker's Weapon ID
					// (not the enitity ID, but the base item ID).
					// Only seen in Spinning Uppercut, Somersault Kick, and Pummel so far.

					int unkInt, x, y;

					x = actionPacket.GetInt();
					y = actionPacket.GetInt();

					if (actionPacket.NextIs(PacketElementType.Int))
					{
						unkInt = x;
						x = y;
						y = actionPacket.GetInt();

						sb.AppendLine("WeaponId: " + unkInt);
					}

					sb.AppendLine("X: " + x);
					sb.AppendLine("Y: " + y);

					if (actionPacket.NextIs(PacketElementType.Byte))
						sb.AppendLine("Phase: " + actionPacket.GetByte()); // Used in Pummel

					if (actionPacket.NextIs(PacketElementType.Long))
						sb.AppendLine("Prop: " + actionPacket.GetLong().ToString("X16"));
				}
				// TargetAction
				else
				{
					// Target actions might end here, widnessed with a packet
					// that had "97" as the previous short.
					if (actionPacket.Peek() == PacketElementType.None)
						continue;

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

					if (actionPacket.NextIs(PacketElementType.Int))
						actionPacket.GetInt(); // [210100, NA280 (2018-06-14)]

					sb.AppendLine("X-Diff: " + actionPacket.GetFloat());
					sb.AppendLine("Y-Diff: " + actionPacket.GetFloat());
					if (actionPacket.NextIs(PacketElementType.Float))
					{
						sb.AppendLine("New X: " + actionPacket.GetFloat());
						sb.AppendLine("New Y: " + actionPacket.GetFloat());

						// [190200, NA203 (22.04.2015)]
						if (actionPacket.Peek() == PacketElementType.Int)
						{
							actionPacket.GetInt();
						}
					}

					// MultiHit Target Option
					if (actionPacket.NextIs(PacketElementType.Int))
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

			return sb.ToString();
		}
	}
}
