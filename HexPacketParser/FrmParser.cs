using MabiPale2;
using MabiPale2.Shared;
using System;
using System.Windows.Forms;

namespace MabiPale2.Plugins.HexPacketParser
{
	public partial class FrmParser : Form
	{
		public FrmParser()
		{
			InitializeComponent();
		}

		private void BtnConvert_Click(object sender, EventArgs e)
		{
			if (TxtHex.Text.Length < 4 + 8 + 3)
				return;

			try
			{
				var packetStr = TxtHex.Text.Replace(" ", "").Replace("-", "").Replace("\r", "").Replace("\n", "");
				var packetArr = HexTool.ToByteArray(packetStr);
				var packet = new Packet(packetArr, 0);
				TxtPacket.Text = packet.ToString();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
