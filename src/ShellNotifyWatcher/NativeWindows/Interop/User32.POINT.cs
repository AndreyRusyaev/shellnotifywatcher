using System.Runtime.InteropServices;

namespace ShellSpy.NativeWindows.Interop
{
    internal static partial class User32
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;

            public int y;
        }
    }
}
