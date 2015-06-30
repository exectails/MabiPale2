using MabiPale2.Properties;
using MabiPale2.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace MabiPale2.Plugins
{
	public class PluginManager : IPluginManager
	{
		private FrmMain frmMain;

		/// <summary>
		/// Fired when a new recv packet is added, either by logging or opening files.
		/// </summary>
		public event Action<PalePacket> Recv;

		/// <summary>
		/// Fired when a new send packet is added, either by logging or opening files.
		/// </summary>
		public event Action<PalePacket> Send;

		/// <summary>
		/// Fired when Pale has finished loading.
		/// </summary>
		public event Action Ready;

		/// <summary>
		/// Fired when Pale is closing.
		/// </summary>
		public event Action End;

		/// <summary>
		/// Fired when a packet is selected in the logger.
		/// Packet is null if selection was cleared or before changing.
		/// </summary>
		public event Action<PalePacket> Selected;

		/// <summary>
		/// Fired when the packet list is cleared
		/// </summary>
		public event Action Clear;

		/// <summary>
		/// Creates new plugin manager.
		/// </summary>
		/// <param name="frmMain">Main window</param>
		public PluginManager(FrmMain frmMain)
		{
			this.frmMain = frmMain;
		}

		/// <summary>
		/// Loads plugins from Plugins folder.
		/// </summary>
		internal void Load()
		{
			if (!Directory.Exists("Plugins"))
				return;

			foreach (var file in Directory.EnumerateFiles("Plugins/", "*.dll"))
			{
				try
				{
					var asm = Assembly.LoadFrom(file);
					var types = asm.GetTypes();

					foreach (var type in types.Where(a => typeof(Plugin).IsAssignableFrom(a) && !a.IsAbstract))
					{
						var plugin = Activator.CreateInstance(type, this) as Plugin;
						//plugin.Manager = this;
						plugin.Initialize();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Failed to load plugin '" + file + "' (" + ex.Message + ").", frmMain.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
					Trace.TraceError(ex.ToString());
				}
			}
		}

		/// <summary>
		/// Adds button to toolbar.
		/// </summary>
		/// <param name="icon">Icon for the button</param>
		/// <param name="tooltip">Tooltip for the button</param>
		/// <param name="onClick">Event handler for when the button is clicked</param>
		public void AddToToolbar(Image icon, string tooltip, EventHandler onClick)
		{
			AddToToolbar(frmMain.ToolBar.Items.Count, icon, tooltip, onClick);
		}

		/// <summary>
		/// Adds button to toolbar.
		/// </summary>
		/// <param name="index">Index at which to insert the button</param>
		/// <param name="icon">Icon for the button</param>
		/// <param name="tooltip">Tooltip for the button</param>
		/// <param name="onClick">Event handler for when the button is clicked</param>
		public void AddToToolbar(int index, Image icon, string tooltip, EventHandler onClick)
		{
			index = Math.Min(frmMain.ToolBar.Items.Count, Math.Max(0, index));

			var tsi = new ToolStripButton();
			tsi.Image = icon ?? Resources.brick;
			tsi.ToolTipText = tooltip;
			tsi.Click += onClick;

			frmMain.ToolBar.Items.Insert(index, tsi);
		}

		/// <summary>
		/// Adds item to Plugin menu.
		/// </summary>
		/// <param name="text">Text used for item</param>
		/// <param name="onClick">Event handler for when the item is clicked</param>
		public void AddToMenu(string text, EventHandler onClick)
		{
			AddToMenu(frmMain.MenuPlugins.MenuItems.Count, text, onClick);
		}

		/// <summary>
		/// Adds item to Plugin menu.
		/// </summary>
		/// <param name="index">Index at which to insert the item</param>
		/// <param name="text">Text used for item</param>
		/// <param name="onClick">Event handler for when the item is clicked</param>
		public void AddToMenu(int index, string text, EventHandler onClick)
		{
			index = Math.Min(frmMain.MenuPlugins.MenuItems.Count, Math.Max(0, index));

			var mi = new MenuItem();
			mi.Text = text;
			mi.Click += onClick;

			frmMain.MenuPlugins.MenuItems.Add(index, mi);
		}

		/// <summary>
		/// Opens form centered on the main window.
		/// </summary>
		/// <param name="form">Form to show</param>
		public void OpenCentered(Form form)
		{
			form.Left = frmMain.Left + frmMain.Width / 2 - form.Width / 2;
			form.Top = frmMain.Top + frmMain.Height / 2 - form.Height / 2;
			form.StartPosition = FormStartPosition.Manual;
			form.Show();
		}

		/// <summary>
		/// Returns a thread-safe list of all current packets.
		/// </summary>
		/// <returns></returns>
		public IList<PalePacket> GetPacketList()
		{
			return frmMain.GetPacketList();
		}

		/// <summary>
		/// Returns currently selected packet or null.
		/// </summary>
		/// <returns></returns>
		public PalePacket GetSelectedPacket()
		{
			return frmMain.GetSelectedPacket();
		}

		/// <summary>
		/// Fires Recv event.
		/// </summary>
		/// <param name="palePacket"></param>
		internal void OnRecv(PalePacket palePacket)
		{
			var ev = Recv;
			if (ev == null)
				return;

			try
			{
				var evs = ev.GetInvocationList().Cast<Action<PalePacket>>();
				foreach (var e in evs)
				{
					e(palePacket);
					palePacket.Packet.Rewind();
				}
			}
			catch (Exception ex)
			{
				Trace.TraceError(ex.ToString());
			}
		}

		/// <summary>
		/// Fires Send event.
		/// </summary>
		/// <param name="palePacket"></param>
		internal void OnSend(PalePacket palePacket)
		{
			var ev = Send;
			if (ev == null)
				return;

			try
			{
				var evs = ev.GetInvocationList().Cast<Action<PalePacket>>();
				foreach (var e in evs)
				{
					e(palePacket);
					palePacket.Packet.Rewind();
				}
			}
			catch (Exception ex)
			{
				Trace.TraceError(ex.ToString());
			}
		}

		/// <summary>
		/// Fires Ready event.
		/// </summary>
		internal void OnReady()
		{
			var ev = Ready;
			if (ev == null)
				return;

			try
			{
				ev();
			}
			catch (Exception ex)
			{
				Trace.TraceError(ex.ToString());
			}
		}

		/// <summary>
		/// Fires End event.
		/// </summary>
		internal void OnEnd()
		{
			var ev = End;
			if (ev == null)
				return;

			try
			{
				ev();
			}
			catch (Exception ex)
			{
				Trace.TraceError(ex.ToString());
			}
		}

		/// <summary>
		/// Fires End event.
		/// </summary>
		internal void OnSelected(PalePacket palePacket)
		{
			var ev = Selected;
			if (ev == null)
				return;

			try
			{
				var evs = ev.GetInvocationList().Cast<Action<PalePacket>>();
				foreach (var e in evs)
				{
					e(palePacket);
					if (palePacket != null)
						palePacket.Packet.Rewind();
				}
			}
			catch (Exception ex)
			{
				Trace.TraceError(ex.ToString());
			}
		}

		internal void OnClear()
		{
			var ev = Clear;
			if (ev == null)
				return;

			try
			{
				ev();
			}
			catch (Exception ex)
			{
				Trace.TraceError(ex.ToString());
			}
		}
	}
}
