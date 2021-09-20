using System;
using System.Runtime.InteropServices;

namespace ShellSpy.Common.Interop
{
    internal static partial class Shell32
    {
        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr SHSimpleIDListFromPath(string pszPath);
    }
}
