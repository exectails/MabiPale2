using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace MabiPale2
{
	public static class WinApi
	{
		[DllImport("user32.dll")]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll")]
		public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpClassName, string lpWindowName);

		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll")]
		public static extern bool IsWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern int GetClassName(IntPtr hwnd, StringBuilder lpClassName, long nMaxCount);

		public const int WM_COPYDATA = 0x004A;

		internal struct COPYDATASTRUCT
		{
			internal IntPtr dwData;
			internal int cbData;
			internal IntPtr lpData;
		}

		/// <summary>
		/// Custom, returns list of all windows with given title,
		/// utilizing FindWindowEx and GetClassName.
		/// </summary>
		/// <returns></returns>
		public static IList<FoundWindow> FindAllWindows(string windowName)
		{
			var result = new List<FoundWindow>();

			var hWnd = IntPtr.Zero;
			do
			{
				if ((hWnd = WinApi.FindWindowEx(IntPtr.Zero, hWnd, null, windowName)) != IntPtr.Zero)
				{
					var window = new FoundWindow();
					window.HWnd = hWnd;
					window.WindowName = windowName;

					var className = new StringBuilder(255);
					GetClassName(hWnd, className, className.Capacity);
					window.ClassName = className.ToString();

					result.Add(window);
				}
			}
			while (hWnd != IntPtr.Zero);

			return result;
		}
	}

	public class FoundWindow
	{
		public IntPtr HWnd { get; set; }
		public string ClassName { get; set; }
		public string WindowName { get; set; }

		public override string ToString()
		{
			return ClassName;
		}
	}
}
