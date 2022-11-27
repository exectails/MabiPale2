using Aura.Mabi.Const;
using Aura.Mabi.Network;
using MabiPale2.Plugins.Packer.Properties;
using MabiPale2.Shared;
using System;
using System.Windows.Forms;

namespace MabiPale2.Plugins.Packer
{
	public class Main : Plugin
	{
		private FrmPacker form;

		internal long? MyEntityId;

		public override string Name
		{
			get { return "Packer"; }
		}

		public Main(IPluginManager pluginManager)
			: base(pluginManager)
		{
		}

		public override void Initialize()
		{
			manager.AddToMenu(Name, OnClick);
			manager.AddToToolbar(Resources.application_edit, Name, OnClick);

			manager.AddToListContextMenu("-", null).Enabled = false;
			manager.AddToListContextMenu("Copy to Packer", OnCopyClick);
			manager.AddToListContextMenu("Replay", OnReplayClick);
			manager.AddToListContextMenu("Replay with my id", OnReplayMyIdClick);

			manager.Send += OnSend;
		}

		private void OnSend(PalePacket palePacket)
		{
			if (palePacket.Op == Op.ChannelLogin)
			{
				var packet = palePacket.Packet;
				packet.GetString();
				packet.GetString();
				packet.GetLong();
				this.MyEntityId = packet.GetLong();
			}
			else if (palePacket.Id >= MabiId.Characters && palePacket.Id < MabiId.Pets)
			{
				this.MyEntityId = palePacket.Id;
			}
		}

		private void BringUpForm()
		{
			if (form == null || form.IsDisposed)
			{
				form = new FrmPacker(this, manager);
				manager.OpenCentered(form);
			}
			else
			{
				form.Focus();
			}
		}

		private void OnCopyClick(object sender, EventArgs e)
		{
			this.BringUpForm();

			var selected = manager.GetSelectedPacket();
			if (selected != null)
				form.ParsePacketToInput(selected.Packet);
		}

		private void OnReplayClick(object sender, EventArgs e)
		{
			var selected = manager.GetSelectedPacket();
			if (selected != null)
			{
				if (selected.Received)
					manager.RecvPacket(selected.Packet);
				else
					manager.SendPacket(selected.Packet);
			}
		}

		private void OnReplayMyIdClick(object sender, EventArgs e)
		{
			if (this.MyEntityId == null)
			{
				MessageBox.Show("Id not found, must be connected during login to receive it.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			var selected = manager.GetSelectedPacket();
			if (selected != null)
			{
				var packet = new Shared.Packet(selected.Packet.Build(), 0);

				if (packet.Id >= MabiId.Characters && packet.Id < MabiId.Npcs + 0x00000FFFFFFFFFFF)
					packet.Id = (long)this.MyEntityId;

				if (selected.Received)
					manager.RecvPacket(packet);
				else
					manager.SendPacket(packet);
			}
		}

		private void OnClick(object sender, EventArgs e)
		{
			this.BringUpForm();
		}
	}
}
