using System;

namespace BirdBrainmofo
{
    internal static class NativeMethodsHelper
    {
        private static readonly IntPtr SB_PAGEBOTTOM;

        public static int MakeWin32Long(short wLow, short wHigh)
        {
            return (wLow << 16) | wHigh;
        }

        public static void SetItemState(IntPtr handle, int itemIndex, int mask, int value)
        {
            NativeMethods.LVITEM lVITEM = default(NativeMethods.LVITEM);
            lVITEM.stateMask = mask;
            lVITEM.state = value;
            NativeMethods.LVITEM lParam = lVITEM;
            NativeMethods.SendMessage_1(handle, 4139u, new IntPtr(itemIndex), ref lParam);
        }

        public static void ScrollToBottom(IntPtr handle)
        {
            NativeMethods.SendMessage(handle, 277u, NativeMethodsHelper.SB_PAGEBOTTOM, IntPtr.Zero);
        }

        static NativeMethodsHelper()
        {
            NativeMethodsHelper.SB_PAGEBOTTOM = new IntPtr(7);
        }
    }
}
