using System;
using System.Runtime.InteropServices;

namespace ShellSpy.ChangeNotify.Interop
{
    internal static partial class Shell32
    {
        /// <summary>
        /// Contains and receives information for change notifications. 
        /// This structure is used with the SHChangeNotifyRegister function and the SFVM_QUERYFSNOTIFY notification.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SHChangeNotifyEntry
        {
            /// <summary>
            /// PIDL for which to receive notifications.
            /// </summary>
            public IntPtr pidl;

            /// <summary>
            /// A flag indicating whether to post notifications for children of this PIDL. 
            /// For example, if the PIDL points to a folder, then file notifications would come 
            /// from the folder's children if this flag was TRUE.
            /// </summary>
            public bool fRecursive;
        }
    }
}
