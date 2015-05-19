using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MabiDungeon
{
	public class DungeonFloorStructure
	{
		DungeonStructure dungeon_structure;
		DungeonFloorStructure prev_floor_structure;
		DungeonFloorStructure next_floor_structure;
		public MazeGenerator maze_generator;
		List<List<RoomTrait>> rooms;
		public int width = 1;
		public int height = 1;
		bool HasBossRoom = false;
		bool IsLastFloor = true;
		Position pos;
		Position start_pos;
		int start_direction = Direction.Down;

		int branchProbability;
		int coverageFactor;

		public DungeonFloorStructure(DungeonStructure dungeon_structure, SDungeonFloor floor_desc, bool isLastFloor, DungeonFloorStructure prev)
		{
			pos = new Position(0, 0);
			start_pos = new Position(0, 0);
			prev_floor_structure = prev;
			this.dungeon_structure = dungeon_structure;
			HasBossRoom = floor_desc.HasBossRoom;
			branchProbability = floor_desc.branchProbability;
			coverageFactor = floor_desc.coverageFactor;
			IsLastFloor = isLastFloor;
			_calculate_size(floor_desc);
			_init_roomtraits();
			maze_generator = new MazeGenerator();
			_generate_maze(floor_desc);
		}

		void _calculate_size(SDungeonFloor floor_desc)
		{
			int w = floor_desc.width;
			int h = floor_desc.height;
			if (floor_desc.width < 6)
				w = 6;
			else if (floor_desc.width > 18)
				w = 18;

			if (floor_desc.height < 6)
				h = 6;
			else if (floor_desc.height > 18)
				h = 18;
			var rnd = dungeon_structure.MT_maze.GetUInt32();
			width = (int)(w - rnd % (int)(w / 5.0));
			rnd = dungeon_structure.MT_maze.GetUInt32();
			height = (int)(h - rnd % (int)(h / 5.0));
		}

		void _init_roomtraits()
		{
			rooms = new List<List<RoomTrait>>();
			for (int h = 0; h < width; h++)
			{
				List<RoomTrait> row = new List<RoomTrait>();
				for (int w = 0; w < height; w++)
					row.Add(new RoomTrait());
				rooms.Add(row);
			}
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					for (int direction = 0; direction < 4; direction++)
					{
						Position biased_pos = new Position(x, y).GetBiasedPosition(direction);
						if ((biased_pos.X >= 0) && (biased_pos.Y >= 0))
							if ((biased_pos.X < width) && (biased_pos.Y < height))
								rooms[x][y].setNeighbor(direction, rooms[biased_pos.X][biased_pos.Y]);
					}
				}
			}
		}



		RoomTrait getRoom(Position pos)
		{
			if ((pos.X < 0) || (pos.Y < 0) || (pos.X >= width) || (pos.Y >= height))
				throw new Exception();
			return rooms[pos.X][pos.Y];
		}

		bool _set_traits(Position pos, int direction, int door_type)
		{
			Position biased_pos = pos.GetBiasedPosition(direction);
			if ((biased_pos.X >= 0) && (biased_pos.Y >= 0))
			{
				if ((biased_pos.X < width) && (biased_pos.Y < height))
				{
					if (!maze_generator.isFree(biased_pos))
						return false;
					maze_generator.markReservedPosition(biased_pos);
				}
			}
			RoomTrait room = getRoom(pos);
			if (room.isLinked(direction))
				throw new Exception();

			if (room.getDoorType(direction) != 0)
				throw new Exception();

			int link_type;
			if (door_type == 3100)
				link_type = 2;
			else if (door_type == 3000)
				link_type = 1;
			else
				throw new Exception();
			room.Link(direction, link_type);
			room.setDoorType(direction, door_type);
			return true;
		}

		void _generate_maze(SDungeonFloor floor_desc)
		{
			int crit_path_min = floor_desc.crit_path_min;
			int crit_path_max = floor_desc.crit_path_max;
			if (crit_path_min < 1)
				crit_path_min = 1;
			if (crit_path_max < 1)
				crit_path_max = 1;
			if (crit_path_min > crit_path_max)
			{
				int temp = crit_path_max;
				crit_path_max = crit_path_min;
				crit_path_min = temp;
			}
			_create_critical_path(crit_path_min, crit_path_max);
			_create_sub_path(coverageFactor, branchProbability);
			_update_path_position();
		}

		List<maze_move> _create_critical_path(int crit_path_min, int crit_path_max)
		{
			while (true)
			{
				maze_generator.setSize(width, height);
				_set_random_path_position();
				if (maze_generator.generateCriticalPath(dungeon_structure.MT_maze, crit_path_min, crit_path_max))
				{
					start_pos = maze_generator.getStartPosition;
					if (_set_traits(start_pos, maze_generator.getStartDir, 3000))
						break;
				}

				maze_generator = new MazeGenerator();
				_init_roomtraits();
			}
			return maze_generator.getCriticalPath;
		}

		bool _create_sub_path(int coverageFactor, int branchProbability)
		{
			maze_generator.generateSubPath(dungeon_structure.MT_maze, coverageFactor, branchProbability);
			return _create_sub_path_recursive(start_pos);
		}

		bool _create_sub_path_recursive(Position pos)
		{
			RoomTrait room = getRoom(pos);
			maze_room_internal maze_room = maze_generator.getRoom(pos);
			room.roomType = 1;
			for (int direction = 0; direction < 4; direction++)
			{
				if (maze_room.GetPassageType(direction) == 2)
				{
					Position biased_pos = pos.GetBiasedPosition(direction);
					if (room != null)
						room.Link(direction, 2);
					return _create_sub_path_recursive(biased_pos);
				}
			}
			return true;
		}

		void _update_path_position()
		{
			//TODO: _update_path_position
		}

		void _set_random_path_position()
		{
			if (prev_floor_structure != null)
				start_direction = Direction.GetOppositeDirection(prev_floor_structure.start_direction);
			else
				start_direction = Direction.Down;
			maze_generator.setStartDir = start_direction;
			MTRandom mt = dungeon_structure.MT_maze;
			if (HasBossRoom)
			{
				if (dungeon_structure.option.Contains("largebossroom=" + '"' + "true"))  // <option largebossroom="true" />
				{
					while (true)
					{
						pos.X = (int)(mt.GetUInt32() % (width - 2) + 1);
						pos.Y = (int)(mt.GetUInt32() % (height - 3) + 1);
						if (maze_generator.isFree(pos))
							if (maze_generator.isFree(new Position(pos.X - 1, pos.Y)))
								if (maze_generator.isFree(new Position(pos.X + 1, pos.Y)))
									if (maze_generator.isFree(new Position(pos.X, pos.Y + 1)))
										if (maze_generator.isFree(new Position(pos.X - 1, pos.Y + 1)))
											if (maze_generator.isFree(new Position(pos.X + 1, pos.Y + 1)))
												if (maze_generator.isFree(new Position(pos.X, pos.Y + 2)))
													if (maze_generator.isFree(new Position(pos.X - 1, pos.Y + 2)))
														if (maze_generator.isFree(new Position(pos.X + 1, pos.Y + 2)))
															break;
					}
					maze_generator.markReservedPosition(new Position(pos.X - 1, pos.Y));
					maze_generator.markReservedPosition(new Position(pos.X + 1, pos.Y));
					maze_generator.markReservedPosition(new Position(pos.X, pos.Y + 1));
					maze_generator.markReservedPosition(new Position(pos.X - 1, pos.Y + 1));
					maze_generator.markReservedPosition(new Position(pos.X + 1, pos.Y + 1));
					maze_generator.markReservedPosition(new Position(pos.X, pos.Y + 2));
					maze_generator.markReservedPosition(new Position(pos.X - 1, pos.Y + 2));
					maze_generator.markReservedPosition(new Position(pos.X + 1, pos.Y + 2));
				}

				else
				{
					while (true)
					{
						pos.X = (int)(mt.GetUInt32() % (width - 2) + 1);
						pos.Y = (int)(mt.GetUInt32() % (height - 3) + 1);
						if (maze_generator.isFree(pos))
							if (maze_generator.isFree(new Position(pos.X - 1, pos.Y)))
								if (maze_generator.isFree(new Position(pos.X + 1, pos.Y)))
									if (maze_generator.isFree(new Position(pos.X, pos.Y + 1)))
										if (maze_generator.isFree(new Position(pos.X - 1, pos.Y + 1)))
											if (maze_generator.isFree(new Position(pos.X + 1, pos.Y + 1)))
												if (maze_generator.isFree(new Position(pos.X, pos.Y + 2)))
													break;
					}
					maze_generator.markReservedPosition(new Position(pos.X - 1, pos.Y));
					maze_generator.markReservedPosition(new Position(pos.X + 1, pos.Y));
					maze_generator.markReservedPosition(new Position(pos.X, pos.Y + 1));
					maze_generator.markReservedPosition(new Position(pos.X - 1, pos.Y + 1));
					maze_generator.markReservedPosition(new Position(pos.X + 1, pos.Y + 1));
					maze_generator.markReservedPosition(new Position(pos.X, pos.Y + 2));
				}
			}
			else
			{
				bool free = false;
				while (!free)
				{
					pos.X = (int)(mt.GetUInt32() % width);
					pos.Y = (int)(mt.GetUInt32() % height);
					free = maze_generator.isFree(pos);
				}
			}
			if (!IsLastFloor && !HasBossRoom)
			{
				RandomDirection rnd_dir = new RandomDirection();
				while (true)
				{
					int direction = rnd_dir.getDirection(mt);
					if (_set_traits(pos, direction, 3100))
					{
						start_direction = direction;
						break;
					}
					//			# core::ICommonAPI::stdapi_SetNPCDirection();  // Server stuff?
				}
			}
			maze_generator.setPathPosition(pos);

		}
	}
}
