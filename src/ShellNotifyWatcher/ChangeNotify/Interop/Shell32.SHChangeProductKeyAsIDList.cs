using System.Runtime.InteropServices;

namespace ShellSpy.ChangeNotify.Interop
{
    internal static partial class Shell32
    {
        /// <summary>
        /// Stores product key in a form mimicking an ITEMIDLIST so that it can be used by SHChangeNotify.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
        internal struct SHChangeProductKeyAsIDList
        {
            public short cb;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 39)]
            public string wszProductKey;

            public short cbZero;
        }
    }
}
