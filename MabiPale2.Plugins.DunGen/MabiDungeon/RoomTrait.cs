using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MabiDungeon
{
	public class RoomTrait
	{
		public RoomTrait[] neighbor;
		public int[] link;
		public int[] doorType;
		public int roomType = 0;
		public int shapeType = 0;
		public int shapeRotationCount = 0;

		public RoomTrait()
		{
			neighbor = new RoomTrait[4];
			link = new int[] { 0, 0, 0, 0 };
			doorType = new int[] { 0, 0, 0, 0 };
		}

		public void setNeighbor(int direction, RoomTrait room)
		{
			neighbor[direction] = room;
		}

		public bool isLinked(int direction)
		{
			if (direction > 3)
				throw new Exception();
			return link[direction] != 0;
		}

		public int getDoorType(int direction)
		{
			if (direction > 3)
				throw new Exception();
			return doorType[direction];
		}

		public void Link(int direction, int link_type)
		{
			if (direction > 3)
				throw new Exception();
			link[direction] = link_type;
			if (neighbor[direction] != null)
			{
				int opposite_direction = Direction.GetOppositeDirection(direction);
				if (link_type == 1)
					neighbor[direction].link[opposite_direction] = 2;
				else if (link_type == 2)
					neighbor[direction].link[opposite_direction] = 1;
				else
					neighbor[direction].link[opposite_direction] = 0;
			}
		}

		public void setDoorType(int direction, int door_type)
		{
			if (direction > 3)
				throw new Exception();
			doorType[direction] = door_type;
			int opposite_direction = Direction.GetOppositeDirection(direction);
			RoomTrait room = neighbor[direction];
			if (room != null)
				room.doorType[opposite_direction] = door_type;
		}
	}
}
