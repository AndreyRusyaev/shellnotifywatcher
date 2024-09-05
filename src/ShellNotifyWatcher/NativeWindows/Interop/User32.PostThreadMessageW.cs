using System;
using System.Runtime.InteropServices;

namespace ShellSpy.NativeWindows.Interop
{
    internal static partial class User32
    {
        /// <summary>
        /// Posts a message to the message queue of the specified thread. 
        /// It returns without waiting for the thread to process the message.
        /// </summary>
        /// <param name="idThread">The function fails if the specified thread does not have a message queue. 
        /// The system creates a thread's message queue when the thread makes its first call to one of the User or GDI functions. 
        /// For more information, see the Remarks section.
        /// Message posting is subject to UIPI.The thread of a process can post messages 
        /// only to posted-message queues of threads in processes of lesser or equal integrity level.
        /// This thread must have the SE_TCB_NAME privilege to post a message to a thread that belongs 
        /// to a process with the same locally unique identifier(LUID) but is in a different desktop.
        /// Otherwise, the function fails and returns ERROR_INVALID_THREAD_ID.
        /// This thread must either belong to the same desktop as the calling thread or to a process with the same LUID.
        /// Otherwise, the function fails and returns ERROR_INVALID_THREAD_ID.
        /// </param>
        /// <param name="uMsg">The type of message to be posted.</param>
        /// <param name="wParam">Additional message-specific information.</param>
        /// <param name="lParam">Additional message-specific information.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.To get extended error information, call GetLastError.
        /// GetLastError returns ERROR_INVALID_THREAD_ID if idThread is not a valid thread identifier, 
        /// or if the thread specified by idThread does not have a message queue.
        /// GetLastError returns ERROR_NOT_ENOUGH_QUOTA when the message limit is hit.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
        public static extern bool PostThreadMessageW(int idThread, int uMsg, IntPtr wParam, IntPtr lParam);
    }
}
