using System;
using System.Runtime.InteropServices;

namespace ShellSpy.NativeWindows.Interop
{
    internal static partial class User32
    {
        /// <summary>
        /// Destroys the specified window. The function sends WM_DESTROY and WM_NCDESTROY messages to the window 
        /// to deactivate it and remove the keyboard focus from it. The function also destroys the window's menu, 
        /// flushes the thread message queue, destroys timers, removes clipboard ownership, and breaks 
        /// the clipboard viewer chain (if the window is at the top of the viewer chain).
        /// If the specified window is a parent or owner window, DestroyWindow automatically 
        /// destroys the associated child or owned windows when it destroys the parent or owner window.
        /// The function first destroys child or owned windows, and then it destroys the parent or owner window.
        /// DestroyWindow also destroys modeless dialog boxes created by the CreateDialog function.
        /// </summary>
        /// <param name="hWnd">A handle to the window to be destroyed.</param>
        /// <returns>If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.To get extended error information, call GetLastError.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool DestroyWindow(IntPtr hWnd);
    }
}
