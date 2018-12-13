using MabiPale2.Shared;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;

namespace MabiPale2.Plugins.PacketAnalyzer.Packets
{
	internal class NpcTalk : IAnalyzer
	{
		public string AnalyzePacket(PalePacket palePacket)
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
			{
				return "OpenTravelerMemo" + Environment.NewLine + "Opens keyword window.";
			}
			else if (functionName == "SelectInTalk")
			{
				return "SelectInTalk" + Environment.NewLine + "Sent after something selectable (buttons, keywords, etc), \"pauses\" dialog for the player to select something.";
			}
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

				var sb1 = new StringBuilder("// NPC Script" + Environment.NewLine);
				var sb2 = new StringBuilder("// Quest Script" + Environment.NewLine);
				var sb3 = new StringBuilder();
				foreach (var msg in msgs)
				{
					var cleanMsg = msg.Trim();
					cleanMsg = Regex.Replace(cleanMsg, " *(<br/>) *", "$1");
					cleanMsg = cleanMsg.Replace("\"", "\\\"");

					sb1.AppendLine("Msg(L(\"{0}\"));", cleanMsg);
					sb2.AppendLine("npc.Msg(L(\"{0}\"));", cleanMsg);
				}

				//TxtInfo.WordWrap = false;
				return sb1.ToString() + Environment.NewLine + sb2.ToString();
			}
			else
			{
				return $"Unknown function name '{ functionName }'.";
			}
		}
	}
}
