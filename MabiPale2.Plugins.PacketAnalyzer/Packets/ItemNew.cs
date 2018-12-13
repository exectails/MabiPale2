using Aura.Mabi.Structs;
using MabiPale2.Shared;
using System.Text;

namespace MabiPale2.Plugins.PacketAnalyzer.Packets
{
	internal class ItemNew : IAnalyzer
	{
		public string AnalyzePacket(PalePacket palePacket)
		{
			var sb = new StringBuilder();

			sb.AppendLine("Item Entity Id: {0:X16}", palePacket.Packet.GetLong());
			sb.AppendLine("Type: {0}", palePacket.Packet.GetByte());
			sb.AppendLine();

			var info = palePacket.Packet.GetObj<ItemInfo>();
			sb.AppendLine("Amount: {0}", info.Amount);
			sb.AppendLine("Color1: 0x{0:X6}", info.Color1);
			sb.AppendLine("Color2: 0x{0:X6}", info.Color2);
			sb.AppendLine("Color3: 0x{0:X6}", info.Color3);
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
			sb.AppendLine("PonsPrice: {0}", optioninfo.PointPrice);
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

			return sb.ToString();
		}
	}
}
