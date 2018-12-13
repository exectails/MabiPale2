using MabiPale2.Shared;
using System;
using System.Text.RegularExpressions;

namespace MabiPale2.Plugins.PacketAnalyzer.Packets
{
	internal class NpcTalkSelect : IAnalyzer
	{
		public string AnalyzePacket(PalePacket palePacket)
		{
			var xml = palePacket.Packet.GetString();

			var regex = Regex.Match(xml, @"<return type=""[^""]+"">([^<]+)</return>");
			if (!regex.Success)
				throw new Exception();

			return "Response: " + regex.Groups[1].Value;
		}
	}
}
