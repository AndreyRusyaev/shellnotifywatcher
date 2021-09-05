
namespace ShellSpy.ChangeNotify.Interop
{
    internal static partial class Shell32
    {
        public enum SHCNF
        {
            // uFlags & SHCNF_TYPE is an ID which indicates what dwItem1 and dwItem2 mean
            SHCNF_IDLIST = 0x0000,       // LPITEMIDLIST
            SHCNF_PATHA = 0x0001,       // path name
            SHCNF_PRINTERA = 0x0002,       // printer friendly name
            SHCNF_DWORD = 0x0003,       // DWORD
            SHCNF_PATH = 0x0005,       // path name
            SHCNF_PRINTER = 0x0006,       // printer friendly name
            SHCNF_TYPE = 0x00FF,
            SHCNF_FLUSH = 0x1000,
            SHCNF_FLUSHNOWAIT = 0x3000,       // includes SHCNF_FLUSH

            SHCNF_NOTIFYRECURSIVE = 0x10000, // Notify clients registered for any child
        }
    }
}
