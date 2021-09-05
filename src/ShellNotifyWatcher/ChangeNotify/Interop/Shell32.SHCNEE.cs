namespace ShellSpy.ChangeNotify.Interop
{
    internal static partial class Shell32
    {
        public enum SHCNEE : int
        {
            SHCNEE_ORDERCHANGED =            2,  // pidl2 is the changed folder
            SHCNEE_MSI_CHANGE =              4,  // pidl2 is a SHChangeProductKeyAsIDList
            SHCNEE_MSI_UNINSTALL =           5,  // pidl2 is a SHChangeProductKeyAsIDList
        }
    }
}
