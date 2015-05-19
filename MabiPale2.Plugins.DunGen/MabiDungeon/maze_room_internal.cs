using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MabiDungeon
{
	public class maze_room_internal
	{
		public int[] directions;
		public bool isOnCriticalPath = false;
		public int isVisited = 0;
		public bool isReserved = false;

		public maze_room_internal()
		{
			this.directions = new int[] { 0, 0, 0, 0 };
		}

		public bool isOccupied()
		{
			return (this.isVisited != 0 || this.isReserved);
		}

		public void Visited(int cnt)
		{
			this.isVisited = cnt;
		}

		public int GetPassageType(int direction)
		{
			return this.directions[direction];
		}
	}
}
