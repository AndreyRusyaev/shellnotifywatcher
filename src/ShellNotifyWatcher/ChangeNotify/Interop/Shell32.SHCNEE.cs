namespace ShellSpy.ChangeNotify.Interop
{
    internal static partial class Shell32
    {
        // Those events are ordinal
        public enum SHCNEE : int
        {
            // SHCNEE_THEMECHANGED =  1,  // Deprecated. Removed, Undocumented
            SHCNEE_ORDERCHANGED =  2,  // pidl2 is the changed folder
            SHCNEE_WININETCHANGED = 3, // Undocumented
            SHCNEE_MSI_CHANGE =    4,  // pidl2 is a SHChangeProductKeyAsIDList
            SHCNEE_MSI_UNINSTALL = 5,  // pidl2 is a SHChangeProductKeyAsIDList

            // Undocumented
            // _WIN32_IE >= 0x0500
            SHCNEE_PROMOTEDITEM =  6,
            SHCNEE_DEMOTEDITEM = 7,
            SHCNEE_ALIASINUSE = 8,

            // _WIN32_IE >= 0x0600
            SHCNEE_SHORTCUTINVOKE = 9,
            SHCNEE_PINLISTCHANGED = 10,
            SHCNEE_USERINFOCHANGED = 11,
            SHCNEE_UPDATEFOLDERLOCATION = 12,
        }
    }
}
