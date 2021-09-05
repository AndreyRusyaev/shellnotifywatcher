using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ShellSpy.NativeWindows.Interop
{
    internal static partial class User32
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct WNDCLASSEX
        {
            public int cbSize;

            public int style;

            [MarshalAs(UnmanagedType.FunctionPtr)]
            public WNDPROC lpfnWndProc;

            public int cbClsExtra;

            public int cbWndExtra;

            public IntPtr hInstance;

            public IntPtr hIcon;

            public IntPtr hCursor;

            public IntPtr hbrBackground;

            public string lpszMenuName;

            public string lpszClassName;

            public IntPtr hIconSm;
        }
    }
}
