using System;
using System.Runtime.InteropServices;

namespace ShellSpy.NativeWindows.Interop
{
    internal static partial class User32
    {
        /// <summary>
        /// Calls the default window procedure to provide default processing 
        /// for any window messages that an application does not process. 
        /// This function ensures that every message is processed. 
        /// DefWindowProc is called with the same parameters received by the window procedure.
        /// </summary>
        /// <param name="hWnd">A handle to the window procedure that received the message.</param>
        /// <param name="uMsg">The message.</param>
        /// <param name="wParam">Additional message information. The content of this parameter depends on the value of the Msg parameter.</param>
        /// <param name="lParam">Additional message information. The content of this parameter depends on the value of the Msg parameter.</param>
        /// <returns>The return value is the result of the message processing and depends on the message.</returns>
        [DllImport("User32.dll")]
        public static extern IntPtr DefWindowProc(IntPtr hWnd, int uMsg, IntPtr wParam, IntPtr lParam);
    }
}
