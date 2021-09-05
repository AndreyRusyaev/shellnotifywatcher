using System;
using System.Runtime.InteropServices;

using ShellSpy.ChangeNotify.Interop.SafeHandles;

namespace ShellSpy.ChangeNotify.Interop
{
    internal static partial class Shell32
    {
        /// <summary>
        /// Locks the shared memory associated with a Shell change notification event.
        /// </summary>
        /// <param name="hChange">A handle to a window received as a wParam in the specified Shell change notification message.</param>
        /// <param name="dwProcId">The process ID (lParam in the message callback).</param>
        /// <param name="pppidl">The address of a pointer to a PIDLIST_ABSOLUTE that, 
        /// when this function returns successfully, receives the list of affected PIDLs.</param>
        /// <param name="plEvent">A pointer to a LONG value that, when this function returns successfully, 
        /// receives the Shell change notification ID of the event that took place.</param>
        /// <returns>Returns a handle (HLOCK) to the locked memory. 
        /// Pass this value to SHChangeNotification_Unlock when finished.</returns>
        [DllImport("shell32.dll")]
        public static extern SHChangeNotificationLockHandle SHChangeNotification_Lock(
            IntPtr hChange,
            int dwProcId,
            out IntPtr pppidl,
            out SHCNE plEvent);
    }
}
