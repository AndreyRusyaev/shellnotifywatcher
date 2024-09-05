using System;
using System.Runtime.InteropServices;

namespace ShellSpy.NativeWindows.Interop
{
    internal static partial class User32
    {
        /// <summary>
        /// Places (posts) a message in the message queue associated with the thread 
        /// that created the specified window and returns without waiting for the thread to process the message.
        /// To post a message in the message queue associated with a thread, use the PostThreadMessage function.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose window procedure is to receive the message. 
        /// The following values have special meanings:
        ///  * HWND_BROADCAST: The message is posted to all top-level windows in the system, 
        ///    including disabled or invisible unowned windows, overlapped windows, and pop-up windows. 
        ///    The message is not posted to child windows. 
        ///
        ///  * NULL: The function behaves like a call to PostThreadMessage with the dwThreadId parameter 
        ///    set to the identifier of the current thread. 
        /// </param>
        /// <param name="uMsg">The message to be posted.</param>
        /// <param name="wParam">Additional message-specific information.</param>
        /// <param name="lParam">Additional message-specific information.</param>
        /// <returns>If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.To get extended error information, 
        /// call GetLastError.GetLastError returns ERROR_NOT_ENOUGH_QUOTA when the limit is hit.</returns>

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
        public static extern bool PostMessageW(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);
    }
}
