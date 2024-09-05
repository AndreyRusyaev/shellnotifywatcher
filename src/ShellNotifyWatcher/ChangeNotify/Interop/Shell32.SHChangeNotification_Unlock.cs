using System;
using System.Runtime.InteropServices;

namespace ShellSpy.ChangeNotify.Interop
{
    internal static partial class Shell32
    {
        /// <summary>
        /// Unlocks shared memory for a change notification.
        /// </summary>
        /// <param name="hLock">A handle to the memory lock. This is the handle returned by SHChangeNotification_Lock when it locked the memory.</param>
        /// <returns>Returns TRUE on success; otherwise, FALSE.</returns>
        [DllImport("shell32.dll", ExactSpelling = true)]
        public static extern bool SHChangeNotification_Unlock(IntPtr hLock);
    }
}
