using MabiPale2.Plugins.Packer.Properties;
using MabiPale2.Shared;
using System;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace MabiPale2.Plugins.Packer
{
	public partial class FrmPacker : Form
	{
		private Main _plugin;
		private IPluginManager _manager;

		public FrmPacker(Main plugin, IPluginManager manager)
		{
			this.InitializeComponent();
			_plugin = plugin;
			_manager = manager;
		}

		private void BtnRecv_Click(object sender, EventArgs e)
		{
			var packet = this.GetPacketFromInput();
			if (packet == null)
				return;

			_manager.RecvPacket(packet);
		}

		private void BtnSend_Click(object sender, EventArgs e)
		{
			var packet = this.GetPacketFromInput();
			if (packet == null)
				return;

			_manager.SendPacket(packet);
		}

		private long ParseNumber(string str)
		{
			if (str.StartsWith("0x"))
			{
				str = str.Substring(2);
				return long.Parse(str, NumberStyles.HexNumber);
			}
			else
			{
				return long.Parse(str);
			}
		}

		private bool TryParseNumber(string str, out long number)
		{
			try
			{
				number = this.ParseNumber(str);
				return true;
			}
			catch
			{
				number = 0;
				return false;
			}
		}

		private Packet GetPacketFromInput()
		{
			if (!this.TryParseNumber(TxtOp.Text, out var op))
			{
				MessageBox.Show("Invalid OP code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}

			if (!this.TryParseNumber(TxtId.Text, out var id))
			{
				MessageBox.Show("Invalid id.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}

			var packet = new Packet((int)op, id);

			var i = 0;
			foreach (var line in this.TxtData.Lines)
			{
				i++;

				if (string.IsNullOrWhiteSpace(line))
					continue;

				var index = line.IndexOf(':');
				if (index == -1)
				{
					MessageBox.Show($"Invalid data on line {i}: '{line}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return null;
				}

				var typeStr = line.Substring(0, index).Trim();
				var dataStr = line.Substring(index + 1).Trim();

				try
				{
					switch (typeStr.ToLowerInvariant())
					{
						case "byte": packet.PutByte((byte)ParseNumber(dataStr)); break;
						case "short": packet.PutShort((short)ParseNumber(dataStr)); break;
						case "ushort": packet.PutUShort((ushort)ParseNumber(dataStr)); break;
						case "int": packet.PutInt((int)ParseNumber(dataStr)); break;
						case "uint": packet.PutUInt((uint)ParseNumber(dataStr)); break;
						case "long": packet.PutLong((long)ParseNumber(dataStr)); break;
						case "ulong": packet.PutULong((ulong)ParseNumber(dataStr)); break;
						case "float": packet.PutFloat(float.Parse(dataStr)); break;
						case "string": packet.PutString(dataStr.Replace("\\n", "\n").Replace("\\t", "\t")); break;
						case "bin": packet.PutBin(HexTool.ToByteArray(dataStr.Replace(" ", "").Replace("-", ""))); break;

						default: throw new Exception("Invalid type.");
					}
				}
				catch
				{
					MessageBox.Show($"Invalid data on line {i}: '{line}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return null;
				}
			}

			return packet;
		}

		public void ParsePacketToInput(Packet packet)
		{
			this.TxtOp.Text = "0x" + packet.Op.ToString("X4");
			this.TxtId.Text = "0x" + packet.Id.ToString("X16");

			packet.Rewind();

			try
			{
				var result = new StringBuilder();

				PacketElementType type;
				for (var i = 1; packet.IsValidType(type = packet.Peek()); ++i)
				{
					switch (type)
					{
						case PacketElementType.Byte: result.AppendFormat("Byte: {0}", packet.GetByte()); break;
						case PacketElementType.Short: result.AppendFormat("UShort: {0}", packet.GetUShort()); break;
						case PacketElementType.Int: result.AppendFormat("UInt: {0}", packet.GetUInt()); break;

						case PacketElementType.Long:
							var longValue = packet.GetLong();
							if (longValue < 0x00010000000000000) // Usually entity ids
								result.AppendFormat("Long: {0}", longValue);
							else
								result.AppendFormat("Long: 0x{0:X16}", longValue);
							break;

						case PacketElementType.Float: result.AppendFormat(CultureInfo.InvariantCulture, "Float: {0}", packet.GetFloat()); break;
						case PacketElementType.String: result.AppendFormat("String: {0}", packet.GetString().Replace("\n", "\\n").Replace("\t", "\\t")); break;
						case PacketElementType.Bin: result.AppendFormat("Bin: {0}", BitConverter.ToString(packet.GetBin()).Replace("-", " ")); break;
					}

					result.AppendLine();
				}

				this.TxtData.Text = result.ToString();
				this.TxtData.SelectionStart = this.TxtData.Text.Length;
				this.TxtData.Focus();
			}
			catch (Exception ex)
			{
				this.TxtData.Text = ex.ToString();
			}
			finally
			{
				packet.Rewind();
			}
		}

		private void BtnUseMyId_Click(object sender, EventArgs e)
		{
			if (_plugin.MyEntityId == null)
			{
				MessageBox.Show("Id not found, must be connected during login to receive it.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			this.TxtId.Text = "0x" + ((long)_plugin.MyEntityId).ToString("X16");
		}

		private void FrmPacker_Load(object sender, EventArgs e)
		{
			if (Settings.Default.X != -1 && Settings.Default.Y != -1)
			{
				this.StartPosition = FormStartPosition.Manual;
				this.Left = Settings.Default.X;
				this.Top = Settings.Default.Y;
			}
			this.Width = Settings.Default.Width;
			this.Height = Settings.Default.Height;
		}

		private void FrmPacker_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.WindowState != FormWindowState.Minimized)
			{
				Settings.Default.X = this.Left;
				Settings.Default.Y = this.Top;
				Settings.Default.Width = this.Width;
				Settings.Default.Height = this.Height;
			}
			Settings.Default.Save();
		}

		private void BtnParseHexPacket_Click(object sender, EventArgs e)
		{
			try
			{
				var packetHex = Clipboard.GetText();
				var bytes = HexTool.ToByteArray(packetHex.Replace(" ", "").Replace("-", ""));
				var packet = new Packet(bytes, 0);

				this.ParsePacketToInput(packet);
			}
			catch
			{
				MessageBox.Show("The text in your clipboard is not a valid packet.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void BtnClear_Click(object sender, EventArgs e)
		{
			this.TxtOp.Text = "";
			this.TxtId.Text = "";
			this.TxtData.Text = "";
		}
	}
}
