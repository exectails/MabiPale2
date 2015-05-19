using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MabiDungeon
{
	public class MazeGenerator
	{
		public int width;
		public int height;
		public int start_direction;
		public Position start_pos;
		public Position current_pos;
		public Position end_pos;
		public int counter;
		public bool isCriticalPathGenerated;
		public bool isSubPathGenerated;
		public List<List<maze_room_internal>> rooms; // [width][height] array of maze_room_internal
		public List<maze_move> CriticalPath;  // list of maze_move
		public int _CritPathMinResult;
		public int _CritPathMaxResult;

		public MazeGenerator()
		{
			this.start_pos = new Position(0, 0);
			this.current_pos = new Position(0, 0);
			this.end_pos = new Position(0, 0);
			this.rooms = new List<List<maze_room_internal>>();
			this.CriticalPath = new List<maze_move>();
		}

		public void print_maze()
		{
			Console.WriteLine("maze gen");
			Console.WriteLine("  000102030405060708");
			for (int y = this.height - 1; y >= 0; --y)
			{
				var row = string.Format("{0,0:D2} ", y);
				for (int x = 0; x < this.width; ++x)
				{
					if (this.start_pos.X == x && this.start_pos.Y == y)
						row += "S ";
					else if (this.rooms[x][y].isVisited > 0)
						row += "X ";
					else
						row += "  ";
				}
				Console.WriteLine(row);
			}
		}

		public void setSize(int width, int height)
		{
			this.width = width;
			this.height = height;
			this.rooms = new List<List<maze_room_internal>>();
			this.CriticalPath = new List<maze_move>();
			for (int h = 0; h < this.width; ++h)
			{
				var row = new List<maze_room_internal>();
				for (int w = 0; w < this.height; ++w)
					row.Add(new maze_room_internal());
				this.rooms.Add(row);
			}
			this.end_pos = new Position(width - 1, height - 1);
		}

		public bool generateCriticalPath(MTRandom MT, int CritPathMin, int CritPathMax)
		{
			if (this.isCriticalPathGenerated)
				return true;

			if (CritPathMin > CritPathMax)
			{
				var min = CritPathMin;
				CritPathMin = CritPathMax;
				CritPathMax = min;
			}
			this._CritPathMinResult = 0;
			this._CritPathMaxResult = 0;
			this.isCriticalPathGenerated = this._generateCriticalPathRecursive(0, CritPathMin, CritPathMax, -1, MT);
			return this.isCriticalPathGenerated;
		}

		public bool generateSubPath(MTRandom MT, int coverageFactor, int branchProbability)
		{
			if (this.isCriticalPathGenerated)
			{
				if (this.isSubPathGenerated)
					return true;
				else
				{
					if (coverageFactor > 100)
						coverageFactor = 100;
					if (branchProbability > 100)
						branchProbability = 100;
					var free_rooms = 0;
					for (int y = 0; y < this.height; ++y)
					{
						for (var x = 0; x < this.width; ++x)
							if (!this.rooms[x][y].isOccupied())
								free_rooms += 1;
					}
					var coverage = (int)(free_rooms * coverageFactor / 100);
					var to_vector = new List<Position>();
					if (this.CriticalPath.Count > 0)
					{
						foreach (var move in this.CriticalPath)
							to_vector.Add(move.pos_to);
						to_vector.RemoveAt(to_vector.Count - 1);
					}
					to_vector = this._generateSubPath_sub_1(to_vector);
					var temp_vector = new List<Position>();
					if (coverage > 0)
					{
						for (int i = 0; i < coverage; ++i)
						{
							var vect = to_vector;
							bool flag = false;
							if (temp_vector.Count == 0)
							{
								if (to_vector.Count == 0)
									break;
								flag = true;
							}
							else
							{
								if (to_vector.Count == 0)
								{
									flag = false;
									vect = temp_vector;
								}
								else
								{
									var rnd = MT.GetUInt32() % 100;
									flag = branchProbability >= rnd;
									if (!flag)
										vect = temp_vector;
								}
							}
							int rand_idx = (int)(MT.GetUInt32() % (uint)vect.Count());
							var pos = vect[rand_idx];
							var room = this.getRoom(pos);
							var directions = new int[] { 0, 0, 0, 0 };
							var random_dir = -1;
							var direction = 0;
							while (true)
							{
								random_dir = this._generateSubPath_random_dir(MT, directions);
								if (room.GetPassageType(random_dir) == 0)
								{
									if (this.isRoomInDirectionFree(pos, random_dir))
										break;
								}
								direction += 1;
								if (direction >= 4)
									break;
							}
							if (direction >= 4)
							{
								temp_vector = this._generateSubPath_sub_3(temp_vector, to_vector);
								to_vector = this._generateSubPath_sub_1(to_vector);
								continue;
							}
							var biased_pos = pos.GetBiasedPosition(random_dir);
							var room2 = this.getRoom(biased_pos);
							room.directions[random_dir] = 2;
							room2.directions[Direction.GetOppositeDirection(random_dir)] = 1;
							this.counter += 1;
							room2.Visited(this.counter);
							temp_vector.Add(biased_pos);
							if (!flag)
							{
								temp_vector.RemoveAt(rand_idx);
								to_vector.Add(pos);
							}
							temp_vector = this._generateSubPath_sub_3(temp_vector, to_vector);
							to_vector = this._generateSubPath_sub_1(to_vector);
						}
						this.isSubPathGenerated = true;
						//Console.WriteLine("sub");
						//this.print_maze();
						return true;
					}
					else
						return true;
				}
			}
			else
				return false;
		}

		int _generateSubPath_random_dir(MTRandom MT, int[] directions)
		{
			for (int i = 0; i < 4; i++)
			{
				if (directions[i] == 0)
				{
					while (true)
					{
						int random_dir = (int)(MT.GetUInt32() & 3);
						if (directions[random_dir] == 0)
						{
							directions[random_dir] = 1;
							return random_dir;
						}
					}
				}
			}

			return -1;
		}

		List<Position> _generateSubPath_sub_3(List<Position> temp_vector, List<Position> to_vector)
		{
			List<Position> result = new List<Position>();

			foreach (Position pos in temp_vector)
			{
				if (_generateSubPath_sub_2(pos))
				{
					maze_room_internal room = getRoom(pos);
					bool vect = true;
					for (int i = 0; i < 4; i++)
					{
						if (room.directions[i] == 2)
						{
							vect = false;
							to_vector.Add(pos);
							break;
						}
					}
					if (vect) result.Add(pos);
				}
			}

			return result;
		}

		bool _generateSubPath_sub_2(Position pos)
		{
			maze_room_internal room = getRoom(pos);

			if (room != null)
			{
				for (int i = 0; i < 4; i++)
				{
					if (room.GetPassageType(i) == 0)
					{
						if (this.isRoomInDirectionFree(pos, i))
							return true;
					}
				}
			}

			return false;
		}

		bool _generateCriticalPathRecursive(int CritPathPos, int CritPathMin, int CritPathMax, int direction, MTRandom MT)
		{
			int[] directions = new int[4];
			_CritPathMaxResult += 1;

			if (_CritPathMaxResult <= 10 * CritPathMax)
			{
				if (CritPathMin <= CritPathPos && CritPathPos <= CritPathMax && this.isRoomInDirectionFree(this.current_pos, this.start_direction))
				{
					start_pos = current_pos;
					foreach (maze_move move in CriticalPath)
					{
						int temp = move.pos_from.X;
						move.pos_from.X = move.pos_to.X;
						move.pos_to.X = temp;

						temp = move.pos_from.Y;
						move.pos_from.Y = move.pos_to.Y;
						move.pos_to.Y = temp;

						move.direction = Direction.GetOppositeDirection(move.direction);
					}

					CriticalPath.Reverse();
					//print_maze();
					return true;
				}
				else
				{
					CritPathPos += 1;
					int count = 0;

					if (CritPathPos <= CritPathMax)
					{
						if (direction != -1)
							direction = Direction.GetOppositeDirection(direction);

						for (int i = 0; i < 4; i++)
						{
							if (i == direction)
								directions[i] = 0;
							else
							{
								Position next_pos = current_pos.GetBiasedPosition(i);
								directions[i] = _sub(next_pos);
								count += directions[i];
							}
						}
						while (count > 0)
						{
							var rnd = MT.GetUInt32() % count + 1;
							int cnt2 = 0;

							int i_dir = 0;
							while (i_dir < 4)
							{
								cnt2 += directions[i_dir];
								if (cnt2 >= rnd)
									break;
								i_dir++;
							}
							count -= directions[i_dir];
							directions[i_dir] = 0;
							//moves_count = len(self.CriticalPath)
							if (_make_move(i_dir))
							{
								if (_generateCriticalPathRecursive(CritPathPos, CritPathMin, CritPathMax, i_dir, MT))
									return true;
								_undo_move();
							}
						}
					}
				}
			}

			return false;
		}

		int _sub(Position pos)
		{
			if (getRoom(pos) != null)
			{
				int cnt = 1;

				for (int i_dir = 0; i_dir < 4; i_dir++)
				{
					maze_room_internal room = getRoom(pos.GetBiasedPosition(i_dir));
					if (room != null)
						if (!room.isOccupied())
							cnt += 1;
				}
				return cnt;
			}

			return 0;
		}

		bool _make_move(int direction)
		{
			if (isRoomInDirectionFree(current_pos, direction))
			{
				Position next_pos = current_pos.GetBiasedPosition(direction);
				maze_room_internal current_room = getRoom(current_pos);
				maze_room_internal next_room = getRoom(next_pos);
				maze_move move = new maze_move(current_pos, next_pos, direction);
				CriticalPath.Add(move);
				counter++;
				next_room.Visited(counter);
				next_room.isOnCriticalPath = true;
				current_room.directions[direction] = 1;
				next_room.directions[Direction.GetOppositeDirection(direction)] = 2;
				current_pos = next_pos;
				return true;
			}

			return false;
		}

		void _undo_move(int count = 1)
		{
			for (int i = 0; i < count; i++)
			{
				maze_move move = CriticalPath[CriticalPath.Count - 1];
				CriticalPath.Remove(CriticalPath[CriticalPath.Count - 1]);
				maze_room_internal current_room = getRoom(move.pos_from);
				maze_room_internal next_room = getRoom(move.pos_to);
				int opposite_direction = Direction.GetOppositeDirection(move.direction);
				if (next_room.isVisited != 0)											// Utter guesswork, but really the only thing that could make sense.
				{
					current_room.directions[move.direction] = 0;
					next_room.directions[opposite_direction] = 0;
					next_room.isVisited = 0;
					next_room.isOnCriticalPath = false;
					counter -= 1;
				}
				current_pos = current_pos.GetBiasedPosition(opposite_direction);
			}
		}

		public maze_room_internal getRoom(Position pos)
		{
			if ((0 <= pos.X) && (pos.X < width) && (0 <= pos.Y) && (pos.Y < height))
				return rooms[pos.X][pos.Y];

			return null;
		}

		public Position getStartPosition
		{
			get { return start_pos; }
		}

		public List<maze_move> getCriticalPath
		{
			get { return CriticalPath; }
		}

		public int setStartDir
		{
			set { start_direction = value; }
		}

		public int getStartDir
		{
			get { return start_direction; }
		}

		public bool isFree(Position pos)
		{
			return rooms[pos.X][pos.Y].isOccupied() == false; // Possible exception...?
		}


		public bool isRoomInDirectionFree(Position pos, int direction)
		{
			Position dir_pos = pos.GetBiasedPosition(direction);
			if ((0 <= dir_pos.X) && (dir_pos.X < width) && (0 <= dir_pos.Y) && (dir_pos.Y < height))
				return !rooms[dir_pos.X][dir_pos.Y].isOccupied();
			return false;
		}

		public void markReservedPosition(Position pos)
		{
			maze_room_internal room = rooms[pos.X][pos.Y];
			if (room.isVisited == 0)						// I'm not really clear on this, since it's basically used as a boolean, but, is an integer.. for whatever reason. So, again, guesswork.
				room.isReserved = true;
		}

		public void setPathPosition(Position pos)
		{
			if ((width > pos.X) && (height > pos.Y))
			{
				maze_room_internal room;

				for (int y = 0; y < height; y++)
				{
					for (int x = 0; x < width; x++)
					{
						room = rooms[x][y];
						room.directions = new int[4];
						room.isVisited = 0;
					}
				}
				CriticalPath = new List<maze_move>();
				start_pos = new Position(0, 0);
				current_pos = new Position(0, 0);

				//var temp = end_pos.x;
				end_pos.X = pos.X;
				//pos.x = temp;

				//temp = end_pos.y;
				end_pos.Y = pos.Y;
				//pos.y = temp;

				//temp = current_pos.x;
				current_pos.X = pos.X;
				//pos.x = temp;

				//temp = current_pos.y;
				current_pos.Y = pos.Y;
				//pos.y = temp;

				counter = 1;
				room = rooms[pos.X][pos.Y];
				room.isVisited = counter;
				room.isOnCriticalPath = true;
			}
		}

		List<Position> _generateSubPath_sub_1(List<Position> to_vector)
		{
			List<Position> result = new List<Position>();

			foreach (Position pos in to_vector)
			{
				if (this._generateSubPath_sub_2(pos))
					result.Add(pos);
			}

			return result;
		}
	}
}
