using System;
using System.Runtime.InteropServices;

namespace ShellSpy.ChangeNotify.Interop
{
    internal static partial class Shell32
    {
        /// <summary>
        /// Notifies the system of an event that an application has performed. 
        /// An application should use this function if it performs an action that may affect the Shell.
        /// </summary>
        /// <param name="wEventId">Describes the event that has occurred. 
        /// Typically, only one event is specified at a time. 
        /// If more than one event is specified, the values contained in the dwItem1 and dwItem2 parameters 
        /// must be the same, respectively, for all specified events.</param>
        /// <param name="dwFlags">Flags that, when combined bitwise with SHCNF_TYPE, 
        /// indicate the meaning of the dwItem1 and dwItem2 parameters. </param>
        /// <param name="dwItem1">Optional. First event-dependent value.</param>
        /// <param name="dwItem2">Optional. Second event-dependent value.</param>
        /// <remarks>Applications that register new handlers of any type must call SHChangeNotify with the SHCNE_ASSOCCHANGED flag 
        /// to instruct the Shell to invalidate the icon and thumbnail cache. 
        /// This will also load new icon and thumbnail handlers that have been registered. 
        /// Note, however, that icon overlay handlers are not reloaded.
        /// The strings pointed to by dwItem1 and dwItem2 can be either ANSI or Unicode.</remarks>
        [DllImport("shell32.dll", ExactSpelling = true)]
        public static extern void SHChangeNotify(SHCNE wEventId, SHCNF dwFlags, IntPtr dwItem1, IntPtr dwItem2);
    }
}
