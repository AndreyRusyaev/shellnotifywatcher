using System;
using System.Runtime.InteropServices;

namespace ShellSpy.ChangeNotify.Interop
{
    internal static partial class Shell32
    {
        /// <summary>
        /// Registers a window to receive notifications from the file system or Shell, if the file system supports notifications.
        /// </summary>
        /// <param name="hwnd">A handle to the window that receives the change or notification messages.</param>
        /// <param name="fSources">One or more of the following values that indicate the type of events for which to receive notifications.</param>
        /// <param name="fEvents">Change notification events for which to receive notification. See the SHCNE flags listed in SHChangeNotify for possible values.</param>
        /// <param name="wMsg">Message to be posted to the window procedure.</param>
        /// <param name="cEntries">Number of entries in the pshcne array.</param>
        /// <param name="pshcne">Array of SHChangeNotifyEntry structures that contain the notifications. 
        /// This array should always be set to one when calling SHChangeNotifyRegister or 
        /// SHChangeNotifyDeregister will not work properly.</param>
        /// <returns>Returns a positive integer registration ID. Returns 0 if out of memory or in response to invalid parameters.</returns>
        /// <remarks>
        /// When a change notification event is raised, the message indicated by wMsg is delivered to 
        /// the window specified by the hwnd parameter.
        ///     * If SHCNRF_NewDelivery is specified, the wParam and lParam values in the message 
        ///       should be passed to SHChangeNotification_Lock as the hChange and dwProcID parameters respectively.
        ///     * If SHCNRF_NewDelivery is not specified, wParam is a pointer to two PIDLIST_ABSOLUTE pointers, 
        ///       and lParam specifies the event. The two PIDLIST_ABSOLUTE pointers can be NULL, 
        ///       depending on the event being sent.
        /// When a relevant file system event takes place and the hwnd parameter is not NULL, 
        /// then the message indicated by wMsg is posted to the specified window.Otherwise, 
        /// if the pshcne parameter is not NULL, then that notification entry is used.
        /// For performance reasons, multiple notifications can be combined into a single notification.For example, 
        /// if a large number of SHCNE_UPDATEITEM notifications are generated for files in the same folder, 
        /// they can be joined into a single SHCNE_UPDATEDIR notification.
        /// </remarks>
        [DllImport("shell32.dll")]
        public static extern int SHChangeNotifyRegister(
              IntPtr hwnd,
              SHCNRF fSources,
              SHCNE fEvents,
              int wMsg,
              int cEntries,
              SHChangeNotifyEntry[] pshcne);

    }
}
