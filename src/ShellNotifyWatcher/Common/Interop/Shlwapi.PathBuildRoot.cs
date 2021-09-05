using System.Runtime.InteropServices;
using System.Text;

namespace ShellSpy.Common.Interop
{
    internal static partial class Shlwapi
    {
        [DllImport("shlwapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern void PathBuildRoot([In, Out] StringBuilder pszPath, int driveNum);
    }
}
