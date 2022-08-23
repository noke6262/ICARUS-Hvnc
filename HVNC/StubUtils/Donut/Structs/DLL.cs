using System.Runtime.InteropServices;

namespace BirdBrainmofo.HVNC.StubUtils.Donut.Structs
{
    public struct DLL
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public char[] dll_name;
    }
}
