using MabiDungeon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MabiPale2.Plugins.DunGen
{
	public partial class FrmDunGen : Form
	{
		public FrmDunGen()
		{
			InitializeComponent();
		}
		private Bitmap GetBitmap(DungeonStructure dungeon)
		{
			var colorBackground = Color.FromArgb(0xf8, 0xdb, 0xb3);
			var colorPath = Color.FromArgb(0x9e, 0x85, 0x67);
			var colorStart = Color.FromArgb(0xff, 0xff, 0xff);
			var colorEnd = Color.FromArgb(0x5b, 0x4d, 0x3b);
			var solidBlack = new SolidBrush(Color.Black);

			var tileSize = 20;
			var maxTilesX = 0;
			var maxTilesY = 0;
			var perLine = 3;
			var fontSize = 10;

			var font = new Font(FontFamily.GenericSansSerif, fontSize);

			var textHeight = 10;
			using (var bmp = new Bitmap(1, 1))
			using (var g = Graphics.FromImage(bmp))
				textHeight = (int)g.MeasureString("test", font).Height;

			foreach (var floor in dungeon.floors)
			{
				if (floor.maze_generator.width > maxTilesX)
					maxTilesX = floor.maze_generator.width;
				if (floor.maze_generator.height > maxTilesY)
					maxTilesY = floor.maze_generator.height;
			}
			maxTilesX++;
			maxTilesY++;

			var imageW = (maxTilesX * tileSize) * (dungeon.floors.Count >= perLine ? perLine : dungeon.floors.Count) + tileSize * 2;
			var imageH = (maxTilesY * tileSize) * (int)Math.Ceiling(dungeon.floors.Count / (float)perLine) + tileSize * 2 + 10 + textHeight;

			var result = new Bitmap(imageW, imageH);

			using (var g = Graphics.FromImage(result))
			{
				g.FillRectangle(new SolidBrush(colorBackground), new Rectangle(0, 0, imageW, imageH));

				g.DrawString(dungeon.name, font, solidBlack, new PointF(10, 10));

				var xoff = tileSize;
				var yoff = tileSize + 10 + textHeight;
				var xcount = 0;

				for (int i = 0; i < dungeon.floors.Count; ++i)
				{
					var floor = dungeon.floors[i];
					var rooms = floor.maze_generator.rooms;

					if (i > 0)
					{
						xoff += (maxTilesX * tileSize);
						if (++xcount >= perLine)
						{
							xoff = tileSize;
							yoff += (maxTilesY * tileSize);
							xcount = 0;
						}
					}

					for (int y = 0; y < floor.maze_generator.height; ++y)
					{
						for (int x = 0; x < floor.maze_generator.width; ++x)
						{
							var color = Color.Transparent;

							if (floor.maze_generator.start_pos.X == x && floor.maze_generator.start_pos.Y == y)
							{
								color = colorStart;
							}
							else if (floor.maze_generator.end_pos.X == x && floor.maze_generator.end_pos.Y == y)
							{
								color = colorEnd;
							}
							else if (rooms[x][y].isVisited > 0)
							{
								color = colorPath;
							}

							if (color != Color.Transparent)
							{
								var brush = new SolidBrush(color);

								var xp = x * tileSize + xoff;
								var yp = (floor.maze_generator.height - y - 1) * tileSize + yoff;
								var wp = tileSize;
								var hp = tileSize;

								if (color != colorPath)
								{
									g.FillRectangle(new SolidBrush(color), new Rectangle(xp, yp, wp, hp));
								}
								else
								{
									var subTileSize = (int)(tileSize / 4f);
									wp = subTileSize * 2;
									hp = subTileSize * 2;
									xp += subTileSize;
									yp += subTileSize;

									g.FillRectangle(new SolidBrush(color), new Rectangle(xp, yp, wp, hp));

									var code = 0;
									for (var d = 0; d < 4; ++d)
									{
										if (rooms[x][y].directions[d] > 0)
											code |= 1 << d * 4;
									}

									if ((code & 0x1000) != 0)
										g.FillRectangle(brush, new Rectangle(xp - subTileSize, yp, wp, hp));

									if ((code & 0x0100) != 0)
										g.FillRectangle(brush, new Rectangle(xp, yp + subTileSize, wp, hp));

									if ((code & 0x0010) != 0)
										g.FillRectangle(brush, new Rectangle(xp + subTileSize, yp, wp, hp));

									if ((code & 0x0001) != 0)
										g.FillRectangle(brush, new Rectangle(xp, yp - subTileSize, wp, hp));
								}

								//g.DrawString(x + "," + y, new Font(FontFamily.GenericSansSerif, 8), solidBlack, new PointF(x * tileSize + xoff, (floor.maze_generator.height - y - 1) * tileSize + yoff));
								//g.DrawRectangle(new Pen(Color.Black), new Rectangle(x * tileSize + xoff, (floor.maze_generator.height - y - 1) * tileSize + yoff, tileSize, tileSize));
							}
						}
					}
				}
			}

			return result;
		}

		static string GetMazeAsString(DungeonStructure dungeon)
		{
			var sw = new System.IO.StringWriter();

			for (int floorN = 0; floorN < dungeon.floors.Count; ++floorN)
			{
				var floor = dungeon.floors[floorN];
				var rooms = floor.maze_generator.rooms;

				sw.WriteLine("Floor {0}", floorN + 1);
				sw.WriteLine("  000102030405060708");
				for (int y = floor.maze_generator.height - 1; y >= 0; --y)
				{
					var row = string.Format("{0,0:D2} ", y);
					for (int x = 0; x < floor.maze_generator.width; ++x)
					{
						if (floor.maze_generator.start_pos.X == x && floor.maze_generator.start_pos.Y == y)
							row += "S ";
						else if (floor.maze_generator.end_pos.X == x && floor.maze_generator.end_pos.Y == y)
							row += "B ";
						else if (floor.maze_generator.rooms[x][y].isVisited > 0)
							row += "X ";
						else
							row += "  ";
					}
					sw.WriteLine(row);
				}

				sw.WriteLine();
			}

			var result = sw.ToString();
			sw.Close();
			return result.Trim();
		}

		public void Generate(string name, int itemId, int floorPlan)
		{
			var test = DungeonClass.LoadDungeonClass(TxtDungeonName.Text);
			if (test == null)
			{
				MessageBox.Show("Dungeon not found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			try
			{
				var dungeon = new DungeonStructure(name, 0, itemId, "", 0, floorPlan);
				if (!ChkImage.Checked)
				{
					TxtDungeon.Text = GetMazeAsString(dungeon);

					TxtDungeon.Visible = true;
					ImgDungeon.Visible = false;
				}
				else
				{
					ImgDungeon.Image = GetBitmap(dungeon);

					TxtDungeon.Visible = false;
					ImgDungeon.Visible = true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message + ".", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void SetValuesAndGenerate(string name, int itemId, int floorPlan)
		{
			TxtDungeonName.Text = name;
			TxtItemId.Text = itemId.ToString();
			TxtFloorPlan.Text = floorPlan.ToString();

			GenerateFromInput();
		}

		public void GenerateFromInput()
		{
			var name = TxtDungeonName.Text;
			var itemId = Convert.ToInt32(TxtItemId.Text);
			var floorPlan = Convert.ToInt32(TxtFloorPlan.Text);

			Generate(name, itemId, floorPlan);
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			if (ImgDungeon.Image == null)
				return;

			SaveFileDialog.FileName = TxtDungeonName.Text;

			var result = SaveFileDialog.ShowDialog();
			if (result != DialogResult.OK)
				return;

			ImgDungeon.Image.Save(SaveFileDialog.FileName, ImageFormat.Png);
		}

		private void FrmMain_Load(object sender, EventArgs e)
		{
			if (!File.Exists("data/dungeondb.xml") || !File.Exists("data/dungeondb2.xml") || !File.Exists("data/dungeon_ruin.xml"))
			{
				MessageBox.Show("DunGen requires the following client files, please put them into the Data folder: dungeondb.xml, dungeondb2.xml, dungeon_ruin.xml", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
			}

			TxtDungeon.Left = ImgDungeon.Left;
			TxtDungeon.Top = ImgDungeon.Top;
			TxtDungeon.Width = ImgDungeon.Width;
			TxtDungeon.Height = ImgDungeon.Height;
		}

		private void ChkImage_CheckedChanged(object sender, EventArgs e)
		{
			GenerateFromInput();
		}

		private void BtnGenerateImage_Click(object sender, EventArgs e)
		{
			GenerateFromInput();
		}
	}
}
