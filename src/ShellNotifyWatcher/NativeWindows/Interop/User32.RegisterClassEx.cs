using System.Runtime.InteropServices;

namespace ShellSpy.NativeWindows.Interop
{
    internal static partial class User32
    {
        /// <summary>
        /// Registers a window class for subsequent use in calls to the CreateWindow or CreateWindowEx function.
        /// </summary>
        /// <param name="lpWndClass">A pointer to a WNDCLASSEX structure. 
        /// You must fill the structure with the appropriate class attributes before passing it to the function.</param>
        /// <returns>
        /// If the function succeeds, the return value is a class atom that uniquely identifies the class being registered. 
        /// This atom can only be used by the CreateWindow, CreateWindowEx, GetClassInfo, GetClassInfoEx, 
        /// FindWindow, FindWindowEx, and UnregisterClass functions and the IActiveIMMap::FilterClientWindows method.
        /// If the function fails, the return value is zero.To get extended error information, call GetLastError.
        /// </returns>
        [DllImport("User32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern ushort RegisterClassEx(ref WNDCLASSEX lpWndClass);
    }
}
