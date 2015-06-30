using MabiPale2.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace MabiPale2.Plugins
{
	public interface IPluginManager
	{
		/// <summary>
		/// Fired when a new recv packet is added, either by logging or opening files.
		/// </summary>
		event Action<PalePacket> Recv;

		/// <summary>
		/// Fired when a new send packet is added, either by logging or opening files.
		/// </summary>
		event Action<PalePacket> Send;

		/// <summary>
		/// Fired when Pale has finished loading.
		/// </summary>
		event Action Ready;

		/// <summary>
		/// Fired when Pale is closing.
		/// </summary>
		event Action End;

		/// <summary>
		/// Fired when the packet list is cleared.
		/// </summary>
		event Action Clear;

		/// <summary>
		/// Fired when a packet is selected in the logger.
		/// Packet is null if selection was cleared or before changing.
		/// </summary>
		event Action<PalePacket> Selected;

		/// <summary>
		/// Adds button to toolbar.
		/// </summary>
		/// <param name="icon">Icon for the button</param>
		/// <param name="tooltip">Tooltip for the button</param>
		/// <param name="onClick">Event handler for when the button is clicked</param>
		void AddToToolbar(Image icon, string tooltip, EventHandler onClick);

		/// <summary>
		/// Adds button to toolbar.
		/// </summary>
		/// <param name="index">Index at which to insert the button</param>
		/// <param name="icon">Icon for the button</param>
		/// <param name="tooltip">Tooltip for the button</param>
		/// <param name="onClick">Event handler for when the button is clicked</param>
		void AddToToolbar(int index, Image icon, string tooltip, EventHandler onClick);

		/// <summary>
		/// Adds item to Plugin menu.
		/// </summary>
		/// <param name="text">Text used for item</param>
		/// <param name="onClick">Event handler for when the item is clicked</param>
		void AddToMenu(string text, EventHandler onClick);

		/// <summary>
		/// Adds item to Plugin menu.
		/// </summary>
		/// <param name="index">Index at which to insert the item</param>
		/// <param name="text">Text used for item</param>
		/// <param name="onClick">Event handler for when the item is clicked</param>
		void AddToMenu(int index, string text, EventHandler onClick);

		/// <summary>
		/// Opens form centered on the main window.
		/// </summary>
		/// <param name="form">Form to show</param>
		void OpenCentered(Form form);

		/// <summary>
		/// Returns a thread-safe list of all current packets.
		/// </summary>
		/// <returns></returns>
		IList<PalePacket> GetPacketList();

		/// <summary>
		/// Returns currently selected packet or null.
		/// </summary>
		/// <returns></returns>
		PalePacket GetSelectedPacket();
	}
}
