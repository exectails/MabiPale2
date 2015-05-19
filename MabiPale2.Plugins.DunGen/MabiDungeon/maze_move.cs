using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MabiDungeon
{
	public class maze_move
	{
		public Position pos_from;
		public Position pos_to;

		public int direction;

		public maze_move(Position from, Position to, int direction)
		{
			this.pos_from = new Position(from);
			this.pos_to = new Position(to);
			this.direction = direction;
		}
	}
}
