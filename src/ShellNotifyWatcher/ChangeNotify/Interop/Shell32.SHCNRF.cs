namespace ShellSpy.ChangeNotify.Interop
{
    internal static partial class Shell32
    {
        public enum SHCNRF
        {
            /// <summary>
            /// Interrupt level notifications from the file system.
            /// </summary>
            SHCNRF_InterruptLevel = 0x0001,

            /// <summary>
            /// Shell-level notifications from the shell.
            /// </summary>
            SHCNRF_ShellLevel = 0x0002,

            /// <summary>
            /// Interrupt events on the whole subtree. This flag must be combined with the SHCNRF_InterruptLevel flag. 
            /// When using this flag, notifications must also be made recursive 
            /// by setting the fRecursive member of the corresponding SHChangeNotifyEntry structure 
            /// referenced by pshcne to TRUE. 
            /// Use of SHCNRF_RecursiveInterrupt on a single level view—for example, a PIDL that is relative 
            /// and contains only one SHITEMID—will block event notification at the highest level and 
            /// thereby prevent a recursive, child update. Thus, an icon dragged into the lowest level of 
            /// a folder hierarchy may fail to appear in the view as expected.
            /// </summary>
            SHCNRF_RecursiveInterrupt = 0x1000,

            /// <summary>
            /// Messages received use shared memory. Call SHChangeNotification_Lock to access the actual data. 
            /// Call SHChangeNotification_Unlock to release the memory when done.
            /// </summary>
            SHCNRF_NewDelivery = 0x8000,
        }
    }
}
