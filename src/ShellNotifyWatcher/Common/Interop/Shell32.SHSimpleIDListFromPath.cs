using System;
using System.Runtime.InteropServices;

namespace ShellSpy.Common.Interop
{
    internal static partial class Shell32
    {
        /// <summary>
        /// Deprecated. Returns a pointer to an ITEMIDLIST structure when passed a path.
        /// </summary>
        /// <param name="pszPath">A pointer to a null-terminated string that contains the path to be converted to a PIDL.</param>
        /// <returns>Returns a pointer to an ITEMIDLIST structure if successful, or NULL otherwise.</returns>
        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr SHSimpleIDListFromPath(string pszPath);
    }
}
