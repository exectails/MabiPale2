using MabiPale2.Shared;
using System;

namespace MabiPale2.Plugins.PacketAnalyzer
{
	internal interface IAnalyzer
	{
		string AnalyzePacket(PalePacket palePacket);
	}

	internal class PacketAttribute : Attribute
	{
		public int[] Ops { get; }

		public PacketAttribute(params int[] ops)
		{
			this.Ops = ops;
		}
	}
}
