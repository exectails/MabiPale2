using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace MabiDungeon
{
	public class DungeonClass
	{
		public string Name = "";
		public int BaseSeed = 0;
		public List<SDungeonFloor> Floors;

		public DungeonClass()
		{
			this.Floors = new List<SDungeonFloor>();
		}

		public SDungeonFloor GetFloorDesc(int n)
		{
			return this.Floors[n];
		}

		public static DungeonClass LoadDungeonClass(string dungeon_class)
		{
			foreach (var xmlName in new[] { "dungeondb2.xml", "dungeondb.xml", "dungeon_ruin.xml" })
			{
				var dom = XDocument.Load("data/" + xmlName);
				var dungeons = dom.Descendants("dungeon");
				foreach (var dungeon in dungeons)
				{
					var name = dungeon.Attribute("name").Value;
					if (name != null && name.ToLower() == dungeon_class.ToLower())
					{
						var dungeonClass = new DungeonClass();
						dungeonClass.Name = dungeon_class;
						dungeonClass.BaseSeed = (int)dungeon.Attribute("baseseed");
						var floorsDescs = dungeon.Descendants("floordesc");
						foreach (var floorDesc in floorsDescs)
						{
							var floor = new SDungeonFloor();
							floor.is_custom_floor = floorDesc.Attribute("custom") == null ? false : true;
							floor.width = (int)floorDesc.Attribute("width");
							floor.height = (int)floorDesc.Attribute("height");
							floor.crit_path_min = (int)floorDesc.Attribute("critpathmin");
							floor.crit_path_max = (int)floorDesc.Attribute("critpathmax");
							floor.HasBossRoom = floorDesc.Elements("boss").Count() > 0 ? true : false;
							floor.branchProbability = (int)floorDesc.Attribute("branch");
							floor.coverageFactor = (int)floorDesc.Attribute("coverage");
							dungeonClass.Floors.Add(floor);
						}
						return dungeonClass;
					}
				}
			}

			return null;
		}
	}
}
