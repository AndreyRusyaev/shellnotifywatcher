using System;
using System.Runtime.InteropServices;

namespace ShellSpy.Common.Interop
{
    internal static partial class Shell32
    {
        [DllImport("shell32.dll", CharSet = CharSet.Unicode, PreserveSig = true)]
        public static extern uint SHGetNameFromIDList(IntPtr pidl,
                                                      SIGDN sigdnName,
                                                      out string ppszName);
    }
}
