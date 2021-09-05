using System.Runtime.InteropServices;

namespace ShellSpy.ChangeNotify.Interop
{
    internal static partial class Shell32
    {
        /// <summary>
        /// Stores two DWORD values in a form mimicking an ITEMIDLIST so that they can be used by SHChangeNotify.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct SHChangeProductKeyAsIDList
        {
            public short cb;

            [MarshalAs(UnmanagedType.LPWStr, SizeConst = 39)]
            public string wszProductKey;

            public short cbZero;
        }
    }
}
