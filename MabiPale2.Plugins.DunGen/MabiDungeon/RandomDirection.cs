using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MabiDungeon
{
	public class RandomDirection
	{
		public int[] directions;

		public RandomDirection()
		{
			this.directions = new int[] { 0, 0, 0, 0 };
		}

		public int getDirection(MTRandom MT)
		{
			var visited = true;
			var direction = 0;

			while (visited)
			{
				direction = (int)MT.GetUInt32() & 3;
				visited = this.directions[direction] != 0;
			}
			this.directions[direction] = 1;

			return direction;
		}
	}
}
