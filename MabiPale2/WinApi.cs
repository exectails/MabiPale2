using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace MabiPale2
{
	internal static class WinApi
	{
		/// <summary>
		/// An application sends the WM_COPYDATA message to pass data to another application.
		/// </summary>
		public const int WM_COPYDATA = 0x004A;

		/// <summary>
		/// Window class already exists.
		/// </summary>
		public const int ERROR_CLASS_ALREADY_EXISTS = 1410;

		/// <summary>
		/// Contains the window class attributes that are registered by the RegisterClass function.
		/// </summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct WNDCLASS
		{
			public uint style;
			public IntPtr lpfnWndProc;
			public int cbClsExtra;
			public int cbWndExtra;
			public IntPtr hInstance;
			public IntPtr hIcon;
			public IntPtr hCursor;
			public IntPtr hbrBackground;
			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpszMenuName;
			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpszClassName;
		}

		/// <summary>
		/// Registers a window class for subsequent use in calls to the CreateWindow or CreateWindowEx function.
		/// </summary>
		/// <param name="lpWndClass"></param>
		/// <returns></returns>
		[DllImport("user32.dll", SetLastError = true)]
		public static extern ushort RegisterClassW([In] ref WNDCLASS lpWndClass);

		/// <summary>
		/// Creates an overlapped, pop-up, or child window with an extended
		/// window style; otherwise, this function is identical to the
		/// CreateWindow function.
		/// </summary>
		/// <param name="dwExStyle"></param>
		/// <param name="lpClassName"></param>
		/// <param name="lpWindowName"></param>
		/// <param name="dwStyle"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="nWidth"></param>
		/// <param name="nHeight"></param>
		/// <param name="hWndParent"></param>
		/// <param name="hMenu"></param>
		/// <param name="hInstance"></param>
		/// <param name="lpParam"></param>
		/// <returns></returns>
		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr CreateWindowExW(uint dwExStyle, [MarshalAs(UnmanagedType.LPWStr)] string lpClassName, [MarshalAs(UnmanagedType.LPWStr)] string lpWindowName, uint dwStyle, Int32 x, Int32 y, Int32 nWidth, Int32 nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

		/// <summary>
		/// Calls the default window procedure to provide default processing
		/// for any window messages that an application does not process.
		/// This function ensures that every message is processed.
		/// DefWindowProc is called with the same parameters received by the
		/// window procedure.
		/// </summary>
		/// <param name="hWnd"></param>
		/// <param name="msg"></param>
		/// <param name="wParam"></param>
		/// <param name="lParam"></param>
		/// <returns></returns>
		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr DefWindowProcW(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

		/// <summary>
		/// Destroys the specified window. The function sends WM_DESTROY and
		/// WM_NCDESTROY messages to the window to deactivate it and remove
		/// the keyboard focus from it. The function also destroys the
		/// window's menu, flushes the thread message queue, destroys timers,
		/// removes clipboard ownership, and breaks the clipboard viewer
		/// chain (if the window is at the top of the viewer chain).
		/// </summary>
		/// <param name="hWnd"></param>
		/// <returns></returns>
		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool DestroyWindow(IntPtr hWnd);

		/// <summary>
		/// Retrieves a handle to the top-level window whose class name and
		/// window name match the specified strings. This function does not
		/// search child windows. This function does not perform a
		/// case-sensitive search.
		/// </summary>
		/// <param name="lpClassName"></param>
		/// <param name="lpWindowName"></param>
		/// <returns></returns>
		[DllImport("user32.dll")]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		/// <summary>
		/// Retrieves a handle to a window whose class name and window name
		/// match the specified strings. The function searches child windows,
		/// beginning with the one following the specified child window.
		/// This function does not perform a case-sensitive search.
		/// </summary>
		/// <param name="hwndParent"></param>
		/// <param name="hwndChildAfter"></param>
		/// <param name="lpClassName"></param>
		/// <param name="lpWindowName"></param>
		/// <returns></returns>
		[DllImport("user32.dll")]
		public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpClassName, string lpWindowName);

		/// <summary>
		/// Determines whether the specified window handle identifies an existing window.
		/// </summary>
		/// <param name="hWnd"></param>
		/// <returns></returns>
		[DllImport("user32.dll")]
		public static extern bool IsWindow(IntPtr hWnd);

		/// <summary>
		/// Retrieves the name of the class to which the specified window belongs.
		/// </summary>
		/// <param name="hwnd"></param>
		/// <param name="lpClassName"></param>
		/// <param name="nMaxCount"></param>
		/// <returns></returns>
		[DllImport("user32.dll")]
		public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

		/// <summary>
		/// Copies the text of the specified window's title bar (if it has one)
		/// into a buffer. If the specified window is a control, the text of the
		/// control is copied. However, GetWindowText cannot retrieve the text
		/// of a control in another application.
		/// </summary>
		/// <param name="hwnd"></param>
		/// <param name="lpString"></param>
		/// <param name="nMaxCount"></param>
		/// <returns></returns>
		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

		/// <summary>
		/// Retrieves the length, in characters, of the specified window's title
		/// bar text (if the window has a title bar). If the specified window is
		/// a control, the function retrieves the length of the text within the
		/// control. However, GetWindowTextLength cannot retrieve the length
		/// of the text of an edit control in another application.
		/// </summary>
		/// <param name="hwnd"></param>
		/// <returns></returns>
		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		public static extern int GetWindowTextLength(IntPtr hWnd);

		/// <summary>
		/// Sends the specified message to a window or windows. The SendMessage
		/// function calls the window procedure for the specified window and
		/// does not return until the window procedure has processed the message.
		/// </summary>
		/// <param name="hWnd"></param>
		/// <param name="Msg"></param>
		/// <param name="wParam"></param>
		/// <param name="lParam"></param>
		/// <returns></returns>
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		/// <summary>
		/// Retrieves a message from the calling thread's message queue.
		/// The function dispatches incoming sent messages until a posted
		/// message is available for retrieval.
		/// </summary>
		/// <param name="lpMsg"></param>
		/// <param name="handle"></param>
		/// <param name="mMsgFilterInMain"></param>
		/// <param name="mMsgFilterMax"></param>
		/// <returns></returns>
		[DllImport("user32.dll")]
		public static extern int GetMessage(ref MSG lpMsg, IntPtr handle, uint mMsgFilterInMain, uint mMsgFilterMax);

		/// <summary>
		/// Translates virtual-key messages into character messages.
		/// The character messages are posted to the calling thread's
		/// message queue, to be read the next time the thread calls
		/// the GetMessage or PeekMessage function.
		/// </summary>
		/// <param name="lpMsg"></param>
		/// <returns></returns>
		[DllImport("user32.dll")]
		public static extern bool TranslateMessage([In] ref MSG lpMsg);

		/// <summary>
		/// Dispatches a message to a window procedure. It is typically
		/// used to dispatch a message retrieved by the GetMessage function.
		/// </summary>
		/// <param name="lpMsg"></param>
		/// <returns></returns>
		[DllImport("user32.dll")]
		public static extern uint DispatchMessage([In] ref MSG lpMsg);

		/// <summary>
		/// Creates a timer with the specified time-out value.
		/// </summary>
		/// <param name="hWnd"></param>
		/// <param name="nIDEvent"></param>
		/// <param name="uElapse"></param>
		/// <param name="lpTimerFunc"></param>
		/// <returns></returns>
		[DllImport("user32.dll")]
		public static extern UIntPtr SetTimer(IntPtr hWnd, UIntPtr nIDEvent, uint uElapse, IntPtr lpTimerFunc);

		/// <summary>
		/// Contains data to be passed to another application by the WM_COPYDATA message.
		/// </summary>
		public struct COPYDATASTRUCT
		{
			public IntPtr dwData;
			public int cbData;
			public IntPtr lpData;
		}

		/// <summary>
		/// Contains message information from a thread's message queue.
		/// </summary>
		public struct MSG
		{
			public IntPtr hwnd;
			public uint message;
			public IntPtr wParam;
			public IntPtr lParam;
			public uint time;
			public POINT pt;
		}

		/// <summary>
		/// The POINT structure defines the x- and y- coordinates of a point.
		/// </summary>
		public struct POINT
		{
			public uint x;
			public uint y;
		}

		/// <summary>
		/// Delegate for window message handler.
		/// </summary>
		/// <param name="hWnd"></param>
		/// <param name="msg"></param>
		/// <param name="wParam"></param>
		/// <param name="lParam"></param>
		/// <returns></returns>
		public delegate IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

		/// <summary>
		/// Custom: Returns list of all windows with given name,
		/// utilizing FindWindowEx and GetClassName.
		/// </summary>
		/// <returns></returns>
		public static IList<FoundWindow> FindAllWindows(string windowName)
		{
			var result = new List<FoundWindow>();

			if (windowName.Length == 38 && windowName.Contains('-'))
			{
				var s = windowName.Replace("-", "");
				var b = Enumerable.Range(0, s.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(s.Substring(x, 2), 16)).ToArray();
				byte g(int v) { return (byte)(((v * 1103515245) + 12345) & 0x7fffffff); };
				var e = b[b.Length - 1];

				for (var i = 0; i < b.Length; ++i)
					b[i] ^= (e = g(e));

				windowName = Encoding.UTF8.GetString(b);
				var index = windowName.IndexOf('\0');
				windowName = windowName.Substring(0, index);
			}

			var hWnd = IntPtr.Zero;
			do
			{
				if ((hWnd = FindWindowEx(IntPtr.Zero, hWnd, null, windowName)) != IntPtr.Zero)
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

	/// <summary>
	/// Describes a window found with the FindAllWindows function.
	/// </summary>
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
