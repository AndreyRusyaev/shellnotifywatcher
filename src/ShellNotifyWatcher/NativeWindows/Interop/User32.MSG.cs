using System;
using System.Runtime.InteropServices;

namespace ShellSpy.NativeWindows.Interop
{
    internal static partial class User32
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MSG
        {
            public IntPtr hwnd;

            public int message;

            public IntPtr wParam;

            public IntPtr lParam;

            public int time;

            public POINT pt;

            public int lPrivate;
        }
    }
}
