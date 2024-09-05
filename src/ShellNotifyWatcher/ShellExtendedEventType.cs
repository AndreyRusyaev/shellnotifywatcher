
namespace ShellSpy
{
    public enum ShellExtendedEventType
    {
        /// <summary>
        /// Corresponds to SHCNEE_ORDERCHANGED
        /// </summary>
        OrderChanged,

        /// <summary>
        /// Corresponds to SHCNEE_WININETCHANGED
        /// </summary>
        WinInetChanged,

        /// <summary>
        /// Corresponds to SHCNEE_MSI_CHANGE
        /// </summary>
        MsiChange,

        /// <summary>
        /// Corresponds to SHCNEE_MSI_UNINSTALL
        /// </summary>
        MsiUninstall,

        /// <summary>
        /// Corresponds to SHCNEE_PROMOTEDITEM
        /// </summary>
        PromotedItem,

        /// <summary>
        /// Corresponds to SHCNEE_DEMOTEDITEM
        /// </summary>
        DemotedItem,

        /// <summary>
        /// Corresponds to SHCNEE_ALIASINUSE
        /// </summary>
        AliasInUse,

        /// <summary>
        /// Corresponds to SHCNEE_SHORTCUTINVOKE
        /// </summary>
        ShortcutInvoke,

        /// <summary>
        /// Corresponds to SHCNEE_PINLISTCHANGED
        /// </summary>
        PinListChanged,

        /// <summary>
        /// Corresponds to SHCNEE_USERINFOCHANGED
        /// </summary>
        UserInfoChanged,

        /// <summary>
        /// Corresponds to SHCNEE_UPDATEFOLDERLOCATION
        /// </summary>
        UpdateFolderLocation,
    }
}
