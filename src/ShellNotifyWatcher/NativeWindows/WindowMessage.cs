using System;

namespace ShellSpy.NativeWindows
{
    internal readonly struct WindowMessage
    {
        public WindowMessage(IntPtr handle, int messageId, IntPtr wParam, IntPtr lParam)
        {
            WindowHandle = handle;
            Id = messageId;
            WParam = wParam;
            LParam = lParam;
        }

        public IntPtr WindowHandle { get; }

        public int Id { get; }

        public IntPtr WParam { get; }

        public IntPtr LParam { get; }
    }
}
