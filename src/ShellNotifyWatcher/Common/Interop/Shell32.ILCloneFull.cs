using System;
using System.Runtime.InteropServices;

namespace ShellSpy.Common.Interop
{
    internal static partial class Shell32
    {
        /// <summary>
        /// Clones a full, or absolute, ITEMIDLIST structure.
        /// </summary>
        /// <param name="pidl">A pointer to the full, or absolute, ITEMIDLIST structure to be cloned.</param>
        /// <returns>A pointer to a copy of the ITEMIDLIST structure pointed to by pidl.</returns>
        [DllImport("shell32.dll", EntryPoint = "ILClone")]
        public static extern IntPtr ILCloneFull(IntPtr pidl);
    }
}
