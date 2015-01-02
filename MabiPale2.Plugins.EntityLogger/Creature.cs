using MabiLib.Structs;
using MabiPale2.Shared;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MabiPale2.Plugins.EntityLogger
{
	[Serializable]
	public class Creature : IEntity
	{
		public long EntityId { get; set; }
		public byte Type { get; set; }

		public string Name { get; set; }
		public int Race { get; set; }

		public byte SkinColor { get; set; }
		public int EyeType { get; set; }
		public byte EyeColor { get; set; }
		public byte MouthType { get; set; }

		public uint State { get; set; }
		public uint StateEx { get; set; }
		public uint StateEx2 { get; set; }

		public float Height { get; set; }
		public float Weight { get; set; }
		public float Upper { get; set; }
		public float Lower { get; set; }

		public int Region { get; set; }
		public int X { get; set; }
		public int Y { get; set; }

		public byte Direction { get; set; }
		public int BattleState { get; set; }
		public byte WeaponSet { get; set; }

		public uint Color1 { get; set; }
		public uint Color2 { get; set; }
		public uint Color3 { get; set; }

		public float CombatPower { get; set; }
		public string StandStyle { get; set; }

		public float LifeRaw { get; set; }
		public float LifeMaxBase { get; set; }
		public float LifeMaxMod { get; set; }
		public float LifeInjured { get; set; }

		public ushort Title { get; set; }
		public DateTime TitleApplied { get; set; }
		public ushort OptionTitle { get; set; }

		public string MateName { get; set; }
		public byte Destiny { get; set; }

		public Dictionary<long, ItemInfo> Items { get; set; }

		public bool IsMonster { get { return (Regex.IsMatch(this.Name, "^[0-9]+$", RegexOptions.Compiled) && Regex.IsMatch(this.EntityId.ToString(), "^[0-9]+$", RegexOptions.Compiled)); } set { } }
		public bool IsNpc { get { return Name.StartsWith("_"); } set { } }
		public bool IsPlayer { get { return !IsMonster && !IsNpc; } set { } }

		public float Life { get { return Math.Min(LifeMax, LifeRaw); } set { } }
		public float LifeMax { get { return LifeMaxBase + LifeMaxMod; } set { } }

		public string EntityType
		{
			get
			{
				if (IsMonster)
					return "Monster";
				else if (IsNpc)
					return "NPC";
				else if (IsPlayer)
					return "Player";
				else
					return "Unknown";
			}
			set { }
		}

		public Creature()
		{
			this.Items = new Dictionary<long, ItemInfo>();
		}

		public string GetInfo()
		{
			var sb = new StringBuilder();

			var height = (Height < 1f && Height > 0.999f) ? 1 : Height;
			var weight = (Weight < 1f && Weight > 0.999f) ? 1 : Weight;
			var upper = (Upper < 1f && Upper > 0.999f) ? 1 : Upper;
			var lower = (Lower < 1f && Lower > 0.999f) ? 1 : Lower;

			sb.AppendLine("Entity id: {0:X16}", EntityId);
			sb.AppendLine("Name: {0}", Name);
			sb.AppendLine("Race: {0}", Race);
			sb.AppendLine();

			sb.AppendLine("CP: {0}", CombatPower);
			sb.AppendLine("Life: {0:0.00} ({1:0.00}) / {2:0.00} ({3:0.00})", Life, LifeRaw, LifeMax, LifeMaxBase);
			sb.AppendLine();

			sb.AppendLine("Region: {0}", Region);
			sb.AppendLine("Position: {0} / {1}", X, Y);
			sb.AppendLine("Direction: {0}", Direction);
			sb.AppendLine();

			sb.AppendLine("Skin color: {0}", SkinColor);
			sb.AppendLine("Eye type: {0}", EyeType);
			sb.AppendLine("Eye color: {0}", EyeColor);
			sb.AppendLine("Mouth type: {0}", MouthType);
			sb.AppendLine();

			sb.AppendLine("Height: {0}", height);
			sb.AppendLine("Weight: {0}", weight);
			sb.AppendLine("Upper:  {0}", upper);
			sb.AppendLine("Lower:  {0}", lower);
			sb.AppendLine();

			sb.AppendLine("Color 1: 0x{0:X8}", Color1);
			sb.AppendLine("Color 2: 0x{0:X8}", Color2);
			sb.AppendLine("Color 3: 0x{0:X8}", Color3);
			sb.AppendLine();

			sb.AppendLine("Stand style: {0}", StandStyle);
			sb.AppendLine();

			sb.AppendLine("Equipped items: (Pocket, Class, Color1, Color2, Color3)");
			foreach (var item in Items.Values)
				sb.AppendLine("{0}, {1}, 0x{2:X08}, 0x{3:X08}, 0x{4:X08}", item.Pocket, item.Id, item.Color1, item.Color2, item.Color3);

			return sb.ToString();
		}

		public string GetScript()
		{
			var sb = new StringBuilder();

			var height = (Height < 1f && Height > 0.999f) ? 1 : Height;
			var weight = (Weight < 1f && Weight > 0.999f) ? 1 : Weight;
			var upper = (Upper < 1f && Upper > 0.999f) ? 1 : Upper;
			var lower = (Lower < 1f && Lower > 0.999f) ? 1 : Lower;

			sb.AppendLine("SetName(\"{0}\");", IsPlayer || IsNpc ? Name : "?");
			sb.AppendLine("SetRace({0});", Race);

			if (height != 1 || weight != 1 || upper != 1 || lower != 1)
			{
				var setBodySb = new StringBuilder("SetBody(");
				if (height != 1) setBodySb.Append("height: {0:0.##}f, ", height);
				if (weight != 1) setBodySb.Append("weight: {0:0.##}f, ", weight);
				if (upper != 1) setBodySb.Append("upper: {0:0.##}f, ", upper);
				if (lower != 1) setBodySb.Append("lower: {0:0.##}f, ", lower);

				sb.AppendLine(setBodySb.ToString().TrimEnd(',', ' ') + ");");
			}

			if (SkinColor != 0 || EyeType != 0 || EyeColor != 0 || MouthType != 0)
			{
				var setFaceSb = new StringBuilder("SetFace(");
				if (SkinColor != 1) setFaceSb.Append("skinColor: {0}, ", SkinColor);
				if (EyeType != 1) setFaceSb.Append("eyeType: {0}, ", EyeType);
				if (EyeColor != 1) setFaceSb.Append("eyeColor: {0}, ", EyeColor);
				if (MouthType != 1) setFaceSb.Append("mouthType: {0}, ", MouthType);

				sb.AppendLine(setFaceSb.ToString().TrimEnd(',', ' ') + ");");
			}

			if (!((Color1 == 0 || Color1 == 0x808080) && (Color2 == 0 || Color2 == 0x808080) && (Color3 == 0 || Color3 == 0x808080)))
				sb.AppendLine("SetColor(0x{0:X08}, 0x{1:X08}, 0x{2:X08});", Color1, Color2, Color3);

			if (!string.IsNullOrWhiteSpace(StandStyle))
				sb.Append(string.Format(@"SetStand(""{0}"");" + Environment.NewLine, StandStyle));

			sb.AppendLine("SetLocation({0}, {1}, {2}, {3});", Region, X, Y, Direction);

			if (Items.Count > 0)
			{
				sb.AppendLine();

				foreach (var item in Items.Values)
					sb.AppendLine(@"EquipItem(Pocket.{0}, {1}, 0x{2:X08}, 0x{3:X08}, 0x{4:X08});", item.Pocket, item.Id, item.Color1, item.Color2, item.Color3);
			}

			return sb.ToString();
		}
	}
}
