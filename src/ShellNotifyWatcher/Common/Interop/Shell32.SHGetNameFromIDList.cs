using System;
using System.Runtime.InteropServices;

namespace ShellSpy.Common.Interop
{
    internal static partial class Shell32
    {
        /// <summary>
        /// Retrieves the display name of an item identified by its IDList.
        /// </summary>
        /// <param name="pidl">A PIDL that identifies the item.</param>
        /// <param name="sigdnName">A value from the SIGDN enumeration that specifies the type of display name to retrieve.</param>
        /// <param name="ppszName">A value that, when this function returns successfully, receives the address of a pointer to the retrieved display name.</param>
        /// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [DllImport("shell32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        public static extern int SHGetNameFromIDList(IntPtr pidl,
                                                     SIGDN sigdnName,
                                                     out string ppszName);
    }
}
