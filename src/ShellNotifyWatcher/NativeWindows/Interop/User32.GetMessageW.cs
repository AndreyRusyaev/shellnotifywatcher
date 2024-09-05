using System;
using System.Runtime.InteropServices;

namespace ShellSpy.NativeWindows.Interop
{
    internal static partial class User32
    {
        /// <summary>
        /// Retrieves a message from the calling thread's message queue. 
        /// The function dispatches incoming sent messages until a posted message is available for retrieval.
        /// Unlike GetMessage, the PeekMessage function does not wait for a message to be posted before returning.
        /// </summary>
        /// <param name="lpMsg">A pointer to an MSG structure that receives message information from the thread's message queue.</param>
        /// <param name="hWnd">A handle to the window whose messages are to be retrieved. 
        /// The window must belong to the current thread.
        /// If hWnd is NULL, GetMessage retrieves messages for any window that belongs to the current thread, 
        /// and any messages on the current thread's message queue whose hwnd value is NULL (see the MSG structure). 
        /// Therefore if hWnd is NULL, both window messages and thread messages are processed.
        /// If hWnd is -1, GetMessage retrieves only messages on the current thread's message queue whose hwnd value is NULL, 
        /// that is, thread messages as posted by PostMessage (when the hWnd parameter is NULL) or PostThreadMessage.</param>
        /// <param name="wMsgFilterMin">The integer value of the lowest message value to be retrieved. 
        /// Use WM_KEYFIRST (0x0100) to specify the first keyboard message or WM_MOUSEFIRST (0x0200) to specify the first mouse message.
        /// Use WM_INPUT here and in wMsgFilterMax to specify only the WM_INPUT messages.
        /// If wMsgFilterMin and wMsgFilterMax are both zero, GetMessage returns 
        /// all available messages(that is, no range filtering is performed).</param>
        /// <param name="wMsgFilterMax">The integer value of the highest message value to be retrieved.</param>
        /// <returns>
        /// If the function retrieves a message other than WM_QUIT, the return value is nonzero.
        /// If the function retrieves the WM_QUIT message, the return value is zero.
        /// If there is an error, the return value is -1. For example, the function fails 
        /// if hWnd is an invalid window handle or lpMsg is an invalid pointer.
        /// To get extended error information, call GetLastError.
        /// </returns>
        [DllImport("User32.dll", CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
        public static extern int GetMessageW([In, Out] ref MSG lpMsg,
                                             IntPtr hWnd,
                                             int wMsgFilterMin,
                                             int wMsgFilterMax);
    }
}
