using System;
using System.Runtime.InteropServices;

namespace Stub;

public class PlatformInvokeKERNEL32
{
	[DllImport("kernel32.dll")]
	public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);

	[DllImport("kernel32.dll")]
	private static extern int GetThreadId(IntPtr thread);

	[DllImport("kernel32.dll")]
	private static extern int GetProcessId(IntPtr process);
}
