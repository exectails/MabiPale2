using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MabiDungeon
{
	public class SDungeonFloor
	{
		public int width = 1;
		public int height = 1;
		public int crit_path_min = 1;
		public int crit_path_max = 1;
		public bool is_custom_floor = false;
		public bool HasBossRoom = false;
		public int branchProbability = 0;
		public int coverageFactor = 0;
	}
}
