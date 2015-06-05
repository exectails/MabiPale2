using Aura.Mabi.Const;
using Aura.Mabi.Network;
using Aura.Mabi.Structs;
using MabiPale2.Plugins.PacketAnalyzer.Properties;
using MabiPale2.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MabiPale2.Plugins.PacketAnalyzer
{
	public partial class FrmInfo : Form
	{
		public FrmInfo()
		{
			InitializeComponent();

			TxtInfo.Visible = false;
		}

		private void FrmInfo_Load(object sender, EventArgs e)
		{
			if (Settings.Default.X != -1 && Settings.Default.Y != -1)
			{
				StartPosition = FormStartPosition.Manual;
				Left = Settings.Default.X;
				Top = Settings.Default.Y;
			}
			Width = Settings.Default.Width;
			Height = Settings.Default.Height;
		}

		private void FrmInfo_FormClosing(object sender, FormClosingEventArgs e)
		{
			Settings.Default.X = Left;
			Settings.Default.Y = Top;
			Settings.Default.Width = Width;
			Settings.Default.Height = Height;
			Settings.Default.Save();
		}

		public void OnSelected(PalePacket palePacket)
		{
			if (palePacket == null)
			{
				TxtInfo.Visible = false;
				return;
			}

			TxtInfo.WordWrap = true;

			try
			{
				switch (palePacket.Op)
				{
					case Op.ConditionUpdate: ParseConditionUpdate(palePacket); break;
					case Op.StatUpdatePublic:
					case Op.StatUpdatePrivate: ParseStatUpdate(palePacket); break;

					case Op.NpcTalk: ParseNpcTalk(palePacket); break;
					case Op.NpcTalkSelect: ParseNpcTalkSelect(palePacket); break;
					case Op.OpenNpcShop: ParseOpenNpcShop(palePacket); break;
					case Op.AddToNpcShop: ParseOpenNpcShop(palePacket); break;

					case Op.CombatActionPack: ParseCombatActionPacket(palePacket); break;

					case Op.ItemNew: ParseItemNew(palePacket); break;

					default: ParseUnknown(palePacket); break;
				}
			}
			catch (Exception ex)
			{
				TxtInfo.Text = "Error: " + ex.ToString();
			}

			TxtInfo.Visible = true;
		}

		private void ParseItemNew(PalePacket palePacket)
		{
			var sb = new StringBuilder();

			sb.AppendLine("Item Entity Id: {0:X16}", palePacket.Packet.GetLong());
			sb.AppendLine("Type: {0}", palePacket.Packet.GetByte());
			sb.AppendLine();

			var info = palePacket.Packet.GetObj<ItemInfo>();
			sb.AppendLine("Amount: {0}", info.Amount);
			sb.AppendLine("Color1: {0}", info.Color1);
			sb.AppendLine("Color2: {0}", info.Color2);
			sb.AppendLine("Color3: {0}", info.Color3);
			sb.AppendLine("Id: {0}", info.Id);
			sb.AppendLine("KnockCount: {0}", info.KnockCount);
			sb.AppendLine("Pocket: {0}", info.Pocket);
			sb.AppendLine("Region: {0}", info.Region);
			sb.AppendLine("FigureA: {0}", info.State);
			sb.AppendLine("FigureB: {0}", info.FigureB);
			sb.AppendLine("FigureC: {0}", info.FigureC);
			sb.AppendLine("FigureD: {0}", info.FigureD);
			sb.AppendLine("X: {0}", info.X);
			sb.AppendLine("Y: {0}", info.Y);
			sb.AppendLine();

			var optioninfo = palePacket.Packet.GetObj<ItemOptionInfo>();
			sb.AppendLine("__unknown15: {0}", optioninfo.__unknown15);
			sb.AppendLine("__unknown16: {0}", optioninfo.__unknown16);
			sb.AppendLine("__unknown17: {0}", optioninfo.__unknown17);
			sb.AppendLine("__unknown24: {0}", optioninfo.__unknown24);
			sb.AppendLine("__unknown25: {0}", optioninfo.__unknown25);
			sb.AppendLine("__unknown3: {0}", optioninfo.__unknown3);
			sb.AppendLine("__unknown31: {0}", optioninfo.__unknown31);
			sb.AppendLine("AttackMax: {0}", optioninfo.AttackMax);
			sb.AppendLine("AttackMin: {0}", optioninfo.AttackMin);
			sb.AppendLine("AttackSpeed: {0}", optioninfo.AttackSpeed);
			sb.AppendLine("Balance: {0}", optioninfo.Balance);
			sb.AppendLine("Critical: {0}", optioninfo.Critical);
			sb.AppendLine("Defense: {0}", optioninfo.Defense);
			sb.AppendLine("DucatPrice: {0}", optioninfo.DucatPrice);
			sb.AppendLine("Durability: {0}", optioninfo.Durability);
			sb.AppendLine("DurabilityMax: {0}", optioninfo.DurabilityMax);
			sb.AppendLine("DurabilityOriginal: {0}", optioninfo.DurabilityOriginal);
			sb.AppendLine("EffectiveRange: {0}", optioninfo.EffectiveRange);
			sb.AppendLine("Elemental: {0}", optioninfo.Elemental);
			sb.AppendLine("EP: {0}", optioninfo.EP);
			sb.AppendLine("Experience: {0}", optioninfo.Experience);
			sb.AppendLine("ExpireTime: {0}", optioninfo.ExpireTime);
			sb.AppendLine("Flags: {0}", optioninfo.Flags);
			sb.AppendLine("Grade: {0}", optioninfo.Grade);
			sb.AppendLine("JoustPointPrice: {0}", optioninfo.JoustPointPrice);
			sb.AppendLine("KnockCount: {0}", optioninfo.KnockCount);
			sb.AppendLine("LinkedPocketId: {0}", optioninfo.LinkedPocketId);
			sb.AppendLine("PonsPrice: {0}", optioninfo.PonsPrice);
			sb.AppendLine("Prefix: {0}", optioninfo.Prefix);
			sb.AppendLine("Price: {0}", optioninfo.Price);
			sb.AppendLine("Protection: {0}", optioninfo.Protection);
			sb.AppendLine("SellingPrice: {0}", optioninfo.SellingPrice);
			sb.AppendLine("StackRemainingTime: {0}", optioninfo.StackRemainingTime);
			sb.AppendLine("StarPrice: {0}", optioninfo.StarPrice);
			sb.AppendLine("Suffix: {0}", optioninfo.Suffix);
			sb.AppendLine("Upgraded: {0}", optioninfo.Upgraded);
			sb.AppendLine("UpgradeMax: {0}", optioninfo.UpgradeMax);
			sb.AppendLine("InjuryMax: {0}", optioninfo.InjuryMax);
			sb.AppendLine("InjuryMin: {0}", optioninfo.InjuryMin);
			sb.AppendLine("WeaponType: {0}", optioninfo.WeaponType);

			TxtInfo.Text = sb.ToString();
		}

		private void ParseCombatActionPacket(PalePacket palePacket)
		{
			var sb = new StringBuilder();

			sb.AppendLine("Id: " + palePacket.Packet.GetInt());
			sb.AppendLine("Prev Id: " + palePacket.Packet.GetInt());
			sb.AppendLine("Hit: " + palePacket.Packet.GetByte());
			sb.AppendLine("Max Hits: " + palePacket.Packet.GetByte());
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

				var attackeraction = len < 80 && type != 0; // Hot fix, TODO: Proper check of type.

				sb.AppendLine(attackeraction ? "Attacker Action" : "Target Action");
				sb.AppendLine("--------------------");
				sb.AppendLine("Creature: " + creatureEntityId.ToString("X16"));
				sb.AppendLine("Type: " + type);
				sb.AppendLine("Stun: " + actionPacket.GetShort());
				sb.AppendLine("Skill Id: " + (SkillId)actionPacket.GetShort());
				actionPacket.GetShort();

				// AttackerAction
				if (attackeraction)
				{
					sb.AppendLine("Target: " + actionPacket.GetLong().ToString("X16"));

					var options = new List<uint>();
					var topt = actionPacket.GetInt();
					for (uint foo2 = 1; foo2 < 0x80000000; )
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
					sb.AppendLine("X: " + actionPacket.GetInt());
					sb.AppendLine("Y: " + actionPacket.GetInt());
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
							var x = actionPacket.GetInt();
							var y = actionPacket.GetInt();
						}

						var options = new List<uint>();
						var topt = actionPacket.GetInt();
						for (uint foo2 = 1; foo2 < 0x80000000; )
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
						sb.AppendLine("? Damage: " + actionPacket.GetFloat());
						sb.AppendLine("Mana Damage?: " + actionPacket.GetInt());

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

						actionPacket.GetByte();
						sb.AppendLine("Delay: " + actionPacket.GetInt());
						sb.AppendLine("Attacker: " + actionPacket.GetLong().ToString("X16"));
					}
				}
			}

			TxtInfo.Text = sb.ToString();
		}

		private void ParseOpenNpcShop(PalePacket palePacket)
		{
			palePacket.Packet.GetString();
			palePacket.Packet.GetByte();
			palePacket.Packet.GetByte();
			palePacket.Packet.GetInt();

			var tabCount = palePacket.Packet.GetByte();
			var tabs = new Dictionary<string, List<ItemInfo>>();
			for (int i = 0; i < tabCount; ++i)
			{
				var name = palePacket.Packet.GetString();

				if (!tabs.ContainsKey(name))
					tabs.Add(name, new List<ItemInfo>());

				palePacket.Packet.GetByte();

				var itemCount = palePacket.Packet.GetShort();
				for (int j = 0; j < itemCount; ++j)
				{
					palePacket.Packet.GetLong();
					palePacket.Packet.GetByte();
					var itemInfo = palePacket.Packet.GetObj<ItemInfo>();
					palePacket.Packet.GetBin();
					palePacket.Packet.GetString();
					palePacket.Packet.GetString();
					palePacket.Packet.GetByte();
					palePacket.Packet.GetLong();

					// [190100, NA200 (2015-01-15)] New/Combined
					if (palePacket.Packet.NextIs(Shared.PacketElementType.Byte))
					{
						palePacket.Packet.GetByte();
						palePacket.Packet.GetByte();
					}

					tabs[name].Add(itemInfo);
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
					sb.AppendLine("// " + name);
				}

				prev = name;

				foreach (var item in tab.Value.OrderBy(a => a.Id))
				{
					var others = tab.Value.Count(a => a.Id == item.Id && a.Amount != item.Amount) != 0;

					if (item.Amount <= 1 && !others)
						sb.AppendLine("Add(\"{0}\", {1});", name, item.Id);
					else
						sb.AppendLine("Add(\"{0}\", {1}, {2});", name, item.Id, Math.Max(1, (int)item.Amount));
				}
			}

			TxtInfo.WordWrap = false;
			TxtInfo.Text = sb.ToString();
		}

		private void ParseNpcTalk(PalePacket palePacket)
		{
			var xmlstr = palePacket.Packet.GetString();

			var xml = XElement.Parse(xmlstr);
			if (xml.Name != "call")
				throw new ArgumentException("Expected root element to be call.");

			var function = xml.Element("function");
			if (function == null)
				throw new ArgumentException("Missing function element.");

			var prototype = function.Element("prototype");
			if (prototype == null)
				throw new ArgumentException("Missing prototype element.");

			var fIdx = prototype.Value.IndexOf("::");
			var fEnd = prototype.Value.IndexOf("(");
			var functionName = prototype.Value.Substring(fIdx + 2, fEnd - fIdx - 2);

			if (functionName == "OpenTravelerMemo")
				TxtInfo.Text = "OpenTravelerMemo" + Environment.NewLine + "Opens keyword window.";
			else if (functionName == "SelectInTalk")
				TxtInfo.Text = "SelectInTalk" + Environment.NewLine + "Sent after something selectable (buttons, keywords, etc), \"pauses\" dialog for the player to select something.";
			else if (functionName == "ShowTalkMessage")
			{
				var arguments = function.Element("arguments");
				if (prototype == null)
					throw new ArgumentException("Missing arguments element.");

				if (arguments.Elements("argument").Count() != 2)
					throw new ArgumentException("Mismatching argument count.");

				var last = arguments.Elements("argument").Last();
				var msgRaw = HttpUtility.HtmlDecode(last.Value);

				var msgs = msgRaw.Split(new string[] { "<p/>" }, StringSplitOptions.RemoveEmptyEntries);

				var sb = new StringBuilder();
				foreach (var msg in msgs)
				{
					var cleanMsg = msg.Trim();
					cleanMsg = Regex.Replace(cleanMsg, " *(<br/>) *", "$1");
					cleanMsg = cleanMsg.Replace("\"", "\\\"");

					// TODO: Expressions, buttons, etc. Or wait for the dialog parser?
					sb.AppendLine("Msg(\"{0}\");", cleanMsg);
				}

				TxtInfo.WordWrap = false;
				TxtInfo.Text = sb.ToString();
			}
			else
				TxtInfo.Text = "Unknown function name '" + functionName + "'.";
		}

		private void ParseNpcTalkSelect(PalePacket palePacket)
		{
			var xml = palePacket.Packet.GetString();

			var regex = Regex.Match(xml, @"<return type=""[^""]+"">([^<]+)</return>");
			if (!regex.Success)
				throw new Exception();

			TxtInfo.Text = "Response: " + regex.Groups[1].Value;
		}

		private void ParseStatUpdate(PalePacket palePacket)
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

			TxtInfo.Text = sb.ToString();
		}

		private void ParseConditionUpdate(PalePacket palePacket)
		{
			var conditionsA = palePacket.Packet.GetLong();
			var conditionsB = palePacket.Packet.GetLong();
			var conditionsC = palePacket.Packet.GetLong();
			var conditionsD = palePacket.Packet.Peek() == Shared.PacketElementType.Long ? palePacket.Packet.GetLong() : 0;
			var conditionsE = palePacket.Packet.Peek() == Shared.PacketElementType.Long ? palePacket.Packet.GetLong() : 0;
			var conditionsF = palePacket.Packet.Peek() == Shared.PacketElementType.Long ? palePacket.Packet.GetLong() : 0;

			var sb = new StringBuilder();
			sb.AppendLine("A: {0}", (ConditionsA)conditionsA);
			sb.AppendLine("B: {0}", (ConditionsB)conditionsB);
			sb.AppendLine("C: {0}", (ConditionsC)conditionsC);
			sb.AppendLine("D: {0}", (ConditionsD)conditionsD);
			sb.AppendLine("E: {0}", (ConditionsE)conditionsE);
			sb.AppendLine("F: {0}", (ConditionsF)conditionsF);

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
					default:
						var ident = (char)('A' + div) + ":0x" + ((ulong)1 << mod).ToString("X16");
						sb.AppendLine("{0} - {1}", ident, str);
						break;
				}
			}

			TxtInfo.Text = sb.ToString();
		}

		private void ParseUnknown(PalePacket palePacket)
		{
			TxtInfo.Text = "No information.";
		}
	}
}
