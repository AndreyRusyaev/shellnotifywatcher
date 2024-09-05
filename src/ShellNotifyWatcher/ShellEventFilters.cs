using System;

namespace ShellSpy
{
    [Flags]
    public enum ShellEventFilters
    {
        None = 0,

        /// <summary>
        /// All shell item (non-folder) events:
        /// SHCNE_CREATE | SHCNE_DELETE | SHCNE_UPDATEITEM | SHCNE_RENAMEITEM
        /// </summary>
        ItemEvents =            1 << 0,

        /// <summary>
        /// All shell folder events:
        /// SHCNE_MKDIR | SHCNE_RMDIR | SHCNE_UPDATEDIR | SHCNE_RENAMEFOLDER
        /// </summary>
        FolderEvents =          1 << 1,

        /// <summary>
        /// Shell item attributes changed events:
        /// SHCNE_ATTRIBUTES
        /// </summary>
        ItemAttributesChanged = 1 << 2,

        /// <summary>
        /// Drive events:
        /// SHCNE_MEDIAINSERTED | SHCNE_MEDIAREMOVED | SHCNE_DRIVEREMOVED | SHCNE_DRIVEADD.
        /// </summary>
        DriveEvents =           1 << 3,

        /// <summary>
        /// Share changes events:
        /// SHCNE_NETSHARE | SHCNE_NETUNSHARE
        /// </summary>
        ShareStatusChanged =    1 << 4,

        /// <summary>
        /// Similar to SHCNE_FREESPACE
        /// </summary>
        FreespaceChanged =      1 << 5,

        /// <summary>
        /// Similar to SHCNE_SERVERDISCONNECT
        /// </summary>
        ServerDisconnected =    1 << 6,

        /// <summary>
        /// Similar to SHCNE_ASSOCCHANGED
        /// </summary>
        AssocChanged =          1 << 7,

        /// <summary>
        /// Similar to SHCNE_UPDATEIMAGE
        /// </summary>
        SystemImageListChanged = 1 << 8,

        /// <summary>
        /// Similar to SHCNE_EXTENDED_EVENT
        /// </summary>
        ExtendedEvents =        1 << 9,

        /// <summary>
        /// Similar to SHCNE_DISKEVENTS = SHCNE_RENAMEITEM | SHCNE_CREATE | SHCNE_DELETE 
        ///     | SHCNE_MKDIR | SHCNE_RMDIR | SHCNE_ATTRIBUTES | SHCNE_UPDATEDIR | SHCNE_UPDATEITEM | SHCNE_RENAMEFOLDER
        /// </summary>
        DiskEvents = ItemEvents | FolderEvents | ItemAttributesChanged,

        /// <summary>
        /// Similar to 
        /// SHCNE_GLOBALEVENTS = SHCNE_MEDIAINSERTED | SHCNE_MEDIAREMOVED | SHCNE_DRIVEREMOVED | SHCNE_DRIVEADD
        ///     | SHCNE_UPDATEIMAGE | SHCNE_DRIVEADDGUI | SHCNE_FREESPACE | SHCNE_EXTENDED_EVENT | SHCNE_ASSOCCHANGED
        /// Events that dont match pidls first
        /// </summary>
        GlobalEvents = DriveEvents | FreespaceChanged | AssocChanged | SystemImageListChanged | ExtendedEvents,

        /// <summary>
        /// Similar to SHCNE_ALLEVENTS.
        /// All events have occurred.
        /// </summary>
        AllEvents =             1 << 31
    }
}
