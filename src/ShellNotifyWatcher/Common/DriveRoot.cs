using System.Text;

using ShellSpy.Common.Interop;

namespace ShellSpy.Common
{
    internal class DriveRoot
    {
        public static string GetDriveByNum(int driveNum)
        {
            // buffer for 5 chars: for 4 letters "C:\" + '\0'
            StringBuilder builder = new StringBuilder(5);

            Shlwapi.PathBuildRoot(builder, driveNum);

            return builder.ToString();
        }
    }
}
