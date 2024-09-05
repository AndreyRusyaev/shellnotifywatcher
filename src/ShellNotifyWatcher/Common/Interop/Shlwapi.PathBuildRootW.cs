using System;
using System.Runtime.InteropServices;

namespace ShellSpy.Common.Interop
{
    internal static partial class Shlwapi
    {
        /// <summary>
        /// Creates a root path from a given drive number.
        /// </summary>
        /// <param name="pszPath">
        /// A pointer to the string that receives the constructed root path. 
        /// This buffer must be at least four characters in size.</param>
        /// <param name="driveNum">
        /// A variable of type int that indicates the desired drive number. 
        /// It should be between 0 and 25.</param>
        /// <returns>Returns the address of the constructed root path. If the call fails for any reason (for example, an invalid drive number), szRoot is returned unchanged.</returns>
        [DllImport("shlwapi.dll", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true)]
        public static extern IntPtr PathBuildRootW(IntPtr pszPath, int driveNum);
    }
}
