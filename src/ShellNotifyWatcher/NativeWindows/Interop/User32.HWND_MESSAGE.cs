using System;

namespace ShellSpy.NativeWindows.Interop
{
    internal static partial class User32
    {
        /// <summary>
        /// A message-only window enables you to send and receive messages. 
        /// It is not visible, has no z-order, cannot be enumerated, 
        /// and does not receive broadcast messages. The window simply dispatches messages.
        /// To create a message-only window, specify the HWND_MESSAGE constant 
        /// or a handle to an existing message-only window in the hWndParent parameter 
        /// of the CreateWindowEx function.You can also change an existing window to a message-only window 
        /// by specifying HWND_MESSAGE in the hWndNewParent parameter of the SetParent function.
        /// </summary>
        public static IntPtr HWND_MESSAGE = new IntPtr(-3);
    }
}
