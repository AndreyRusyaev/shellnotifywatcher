using System;

namespace ShellSpy.NativeWindows.Interop
{
    internal static partial class User32
    {
        /// <summary>
        /// The message is posted to all top-level windows in the system, 
        /// including disabled or invisible unowned windows, overlapped windows, and pop-up windows. 
        /// The message is not posted to child windows. 
        /// </summary>
        public static IntPtr HWND_BROADCAST = new IntPtr(0xffff);
    }
}
