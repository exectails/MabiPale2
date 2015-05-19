using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MabiDungeon
{
	public class DungeonStructure
	{
		public int item_dropped = 0;
		public string name = "untitled";
		public int seed = 0;
		public int floorplan = 0;
		public string option = "";
		public MTRandom MT_maze;
		public MTRandom MT_puzzle;
		public List<DungeonFloorStructure> floors;

		public DungeonStructure(string dungeon_class, int instance_id, int item_id, string option, int seed, int floorplan)
		{
			DungeonClass s_dungeon_class = DungeonClass.LoadDungeonClass(dungeon_class);
			this.name = s_dungeon_class.Name;
			this.seed = seed;
			this.floorplan = floorplan;
			this.option = option.ToLower();
			// init random generators
			MT_maze = new MTRandom(s_dungeon_class.BaseSeed + item_id + floorplan);
			MT_puzzle = new MTRandom(seed);
			//init floors
			floors = new List<DungeonFloorStructure>();
			DungeonFloorStructure prev = null;
			for (int i = 0; i < s_dungeon_class.Floors.Count; i++)
			{
				bool last_floor = i == s_dungeon_class.Floors.Count - 1;
				DungeonFloorStructure floor = new DungeonFloorStructure(this, s_dungeon_class.GetFloorDesc(i), last_floor, prev);
				prev = floor;
				floors.Add(floor);
			}
		}
	}
}
