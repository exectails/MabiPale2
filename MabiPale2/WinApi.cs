using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace MabiPale2
{
	public static class WinApi
	{
		[DllImport("user32.Dll")]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll")]
		public static extern bool IsWindow(IntPtr hWnd);

		public const int WM_COPYDATA = 0x004A;

		internal struct COPYDATASTRUCT
		{
			internal IntPtr dwData;
			internal int cbData;
			internal IntPtr lpData;
		}
	}
}
