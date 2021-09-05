using System.Runtime.InteropServices;

namespace ShellSpy.ChangeNotify.Interop
{
    internal static partial class Shell32
    {
        /// <summary>
        /// Stores two DWORD values in a form mimicking an ITEMIDLIST so that they can be used by SHChangeNotify.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct SHChangeDWORDAsIDList
        {
            public short cb;

            public int dwItem1;

            public int dwItem2;

            public short cbZero;
        }
    }
}
