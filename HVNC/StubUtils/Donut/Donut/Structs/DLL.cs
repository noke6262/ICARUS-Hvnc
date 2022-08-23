using System.Runtime.InteropServices;

namespace ICARUS.HVNC.StubUtils.Donut.Structs
{
    public struct DLL
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public char[] dll_name;
    }
}
