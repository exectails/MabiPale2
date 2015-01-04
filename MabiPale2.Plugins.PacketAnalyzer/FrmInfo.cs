using MabiLib.Const;
using MabiLib.Network;
using MabiLib.Structs;
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

					default: ParseUnknown(palePacket); break;
				}
			}
			catch (Exception ex)
			{
				TxtInfo.Text = "Error: " + ex.ToString();
			}

			TxtInfo.Visible = true;
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

			var sb = new StringBuilder();
			sb.AppendLine("A: {0}", (ConditionsA)conditionsA);
			sb.AppendLine("B: {0}", (ConditionsB)conditionsB);
			sb.AppendLine("C: {0}", (ConditionsC)conditionsC);
			sb.AppendLine("D: {0}", (ConditionsD)conditionsD);
			sb.AppendLine("E: {0}", (ConditionsE)conditionsE);

			TxtInfo.Text = sb.ToString();
		}

		private void ParseUnknown(PalePacket palePacket)
		{
			TxtInfo.Text = "No information.";
		}
	}
}
