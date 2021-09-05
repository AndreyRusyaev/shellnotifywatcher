using System;

namespace ShellSpy.NativeWindows.Interop
{
    internal static partial class User32
    {
        public delegate IntPtr WNDPROC(IntPtr hwnd, int uMsg, IntPtr wParam, IntPtr lParam);
    }
}
