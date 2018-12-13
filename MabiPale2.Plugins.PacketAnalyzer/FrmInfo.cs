using Aura.Mabi.Network;
using MabiPale2.Plugins.PacketAnalyzer.Packets;
using MabiPale2.Plugins.PacketAnalyzer.Properties;
using MabiPale2.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MabiPale2.Plugins.PacketAnalyzer
{
	public partial class FrmInfo : Form
	{
		private Dictionary<int, IAnalyzer> _analyzers = new Dictionary<int, IAnalyzer>()
		{
			[Op.ConditionUpdate] = new ConditionUpdate(),
			[Op.StatUpdatePublic] = new StatUpdate(),
			[Op.StatUpdatePrivate] = new StatUpdate(),
			[Op.NpcTalk] = new NpcTalk(),
			[Op.NpcTalkSelect] = new NpcTalkSelect(),
			[Op.OpenNpcShop] = new NpcShop(),
			[Op.AddToNpcShop] = new NpcShop(),
			[Op.CombatActionPack] = new CombatActionPack(),
			[Op.ItemUpdate] = new ItemNew(),
			[Op.ItemNew] = new ItemNew(),
		};

		public FrmInfo()
		{
			InitializeComponent();
			TxtInfo.Visible = false;
		}

		private void FrmInfo_Load(object sender, EventArgs e)
		{
			if (Settings.Default.X != -1 && Settings.Default.Y != -1)
			{
				StartPosition = FormStartPosition.Manual;
				Left = Settings.Default.X;
				Top = Settings.Default.Y;
			}
			Width = Settings.Default.Width;
			Height = Settings.Default.Height;
		}

		private void FrmInfo_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (WindowState != FormWindowState.Minimized)
			{
				Settings.Default.X = Left;
				Settings.Default.Y = Top;
				Settings.Default.Width = Width;
				Settings.Default.Height = Height;
			}
			Settings.Default.Save();
		}

		public void OnSelected(PalePacket palePacket)
		{
			if (palePacket == null)
			{
				TxtInfo.Visible = false;
				return;
			}

			TxtInfo.WordWrap = false;

			try
			{
				if (_analyzers.TryGetValue(palePacket.Op, out var analyzer))
				{
					TxtInfo.Text = analyzer.AnalyzePacket(palePacket);
				}
				else
				{
					TxtInfo.Text = "No information.";
				}
			}
			catch (Exception ex)
			{
				TxtInfo.Text = "Error: " + ex.ToString();
			}

			TxtInfo.Visible = true;
		}
	}
}
