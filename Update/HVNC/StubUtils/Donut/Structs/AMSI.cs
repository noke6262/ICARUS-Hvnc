using System.Runtime.InteropServices;

namespace BirdBrainmofo.HVNC.StubUtils.Donut.Structs
{
    [StructLayout(LayoutKind.Explicit)]
    public struct AMSI
    {
        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] char_0;

        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] uint_0;
    }
}
