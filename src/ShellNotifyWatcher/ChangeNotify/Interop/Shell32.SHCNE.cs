using System;

namespace ShellSpy.ChangeNotify.Interop
{
    internal static partial class Shell32
    {
        [Flags]
        public enum SHCNE : uint
        {
            /// <summary>
            /// The name of a nonfolder item has changed. 
            /// SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. 
            /// dwItem1 contains the previous PIDL or name of the item. 
            /// dwItem2 contains the new PIDL or name of the item.
            /// </summary>
            SHCNE_RENAMEITEM = 0x00000001,

            /// <summary>
            /// A nonfolder item has been created. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. 
            /// dwItem1 contains the item that was created. 
            /// dwItem2 is not used and should be NULL.
            /// </summary>
            SHCNE_CREATE = 0x00000002,

            /// <summary>
            /// A nonfolder item has been deleted. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. 
            /// dwItem1 contains the item that was deleted. 
            /// dwItem2 is not used and should be NULL.
            /// </summary>
            SHCNE_DELETE = 0x00000004,

            /// <summary>
            /// A folder has been created. 
            /// SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. 
            /// dwItem1 contains the folder that was created. 
            /// dwItem2 is not used and should be NULL.
            /// </summary>
            SHCNE_MKDIR = 0x00000008,

            /// <summary>
            /// A folder has been removed. 
            /// SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags.
            /// dwItem1 contains the folder that was removed. 
            /// dwItem2 is not used and should be NULL.
            /// </summary>
            SHCNE_RMDIR = 0x00000010,

            /// <summary>
            /// Storage media has been inserted into a drive. 
            /// SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. 
            /// dwItem1 contains the root of the drive that contains the new media. 
            /// dwItem2 is not used and should be NULL.
            /// </summary>
            SHCNE_MEDIAINSERTED = 0x00000020,

            /// <summary>
            /// Storage media has been removed from a drive. 
            /// SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. 
            /// dwItem1 contains the root of the drive from which the media was removed. 
            /// dwItem2 is not used and should be NULL.
            /// </summary>
            SHCNE_MEDIAREMOVED = 0x00000040,

            /// <summary>
            /// A drive has been removed. 
            /// SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. 
            /// dwItem1 contains the root of the drive that was removed. 
            /// dwItem2 is not used and should be NULL.
            /// </summary>
            SHCNE_DRIVEREMOVED = 0x00000080,

            /// <summary>
            /// A drive has been added. 
            /// SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. 
            /// dwItem1 contains the root of the drive that was added. 
            /// dwItem2 is not used and should be NULL.
            /// </summary>
            SHCNE_DRIVEADD = 0x00000100,

            /// <summary>
            /// A folder on the local computer is being shared via the network. 
            /// SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. 
            /// dwItem1 contains the folder that is being shared. 
            /// dwItem2 is not used and should be NULL.
            /// </summary>
            SHCNE_NETSHARE = 0x00000200,

            /// <summary>
            /// A folder on the local computer is no longer being shared via the network. 
            /// SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. 
            /// dwItem1 contains the folder that is no longer being shared. 
            /// dwItem2 is not used and should be NULL.
            /// </summary>
            SHCNE_NETUNSHARE = 0x00000400,

            /// <summary>
            /// The attributes of an item or folder have changed. 
            /// SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. 
            /// dwItem1 contains the item or folder that has changed. 
            /// dwItem2 is not used and should be NULL.
            /// </summary>
            SHCNE_ATTRIBUTES = 0x00000800,

            /// <summary>
            /// The contents of an existing folder have changed, 
            /// but the folder still exists and has not been renamed. 
            /// SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. 
            /// dwItem1 contains the folder that has changed. 
            /// dwItem2 is not used and should be NULL. 
            /// If a folder has been created, deleted, or renamed, 
            /// use SHCNE_MKDIR, SHCNE_RMDIR, or SHCNE_RENAMEFOLDER, respectively.
            /// </summary>
            SHCNE_UPDATEDIR = 0x00001000,

            /// <summary>
            /// An existing item (a folder or a nonfolder) has changed, 
            /// but the item still exists and has not been renamed. 
            /// SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. 
            /// dwItem1 contains the item that has changed. 
            /// dwItem2 is not used and should be NULL. 
            /// If a nonfolder item has been created, deleted, or renamed, 
            /// use SHCNE_CREATE, SHCNE_DELETE, or SHCNE_RENAMEITEM, respectively, instead.
            /// </summary>
            SHCNE_UPDATEITEM = 0x00002000,

            /// <summary>
            /// The computer has disconnected from a server. 
            /// SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. 
            /// dwItem1 contains the server from which the computer was disconnected. 
            /// dwItem2 is not used and should be NULL.
            /// </summary>
            SHCNE_SERVERDISCONNECT = 0x00004000,

            /// <summary>
            /// An image in the system image list has changed. 
            /// SHCNF_DWORD must be specified in uFlags. 
            /// dwItem2 contains the index in the system image list that has changed. 
            /// dwItem1 is not used and should be NULL.
            /// </summary>
            SHCNE_UPDATEIMAGE = 0x00008000,

            /// <summary>
            /// Windows XP and later: Not used.
            /// </summary>
            [Obsolete]
            SHCNE_DRIVEADDGUI = 0x00010000,

            /// <summary>
            /// The name of a folder has changed. 
            /// SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. 
            /// dwItem1 contains the previous PIDL or name of the folder. 
            /// dwItem2 contains the new PIDL or name of the folder.
            /// </summary>
            SHCNE_RENAMEFOLDER = 0x00020000,

            /// <summary>
            /// The amount of free space on a drive has changed. 
            /// SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. 
            /// dwItem1 contains the root of the drive on which the free space changed. 
            /// dwItem2 is not used and should be NULL.
            /// </summary>
            SHCNE_FREESPACE = 0x00040000,

            /// <summary>
            ///  SHCNE_EXTENDED_EVENT: the extended event is identified in dwItem1,
            ///  packed in LPITEMIDLIST format (same as SHCNF_DWORD packing).
            ///  Additional information can be passed in the dwItem2 parameter
            ///  of SHChangeNotify(called "pidl2" below), which if present, must also
            ///  be in LPITEMIDLIST format.
            ///  
            /// Unlike the standard events, the extended events are ORDINALs, so we
            /// don't run out of bits.  Extended events follow the SHCNEE_* naming
            /// convention.
            /// The dwItem2 parameter varies according to the extended event.
            /// </summary>
            SHCNE_EXTENDED_EVENT = 0x04000000,

            /// <summary>
            /// A file type association has changed. 
            /// SHCNF_IDLIST must be specified in the uFlags parameter. 
            /// dwItem1 and dwItem2 are not used and must be NULL. 
            /// This event should also be sent for registered protocols.
            /// </summary>
            SHCNE_ASSOCCHANGED = 0x08000000,

            SHCNE_DISKEVENTS = 0x0002381F,

            // Flag combinations

            /// <summary>
            /// Events that dont match pidls first
            /// </summary>
            SHCNE_GLOBALEVENTS = 0x0C0581E0,

            /// <summary>
            /// All events have occurred.
            /// </summary>
            SHCNE_ALLEVENTS = 0x7FFFFFFF,

            /// <summary>
            /// The presence of this flag indicates
            /// that the event was generated by an
            /// interrupt.  It is stripped out before
            /// the clients of SHCNNotify_ see it.
            /// </summary>
            SHCNE_INTERRUPT = 0x80000000,
        }
    }
}
