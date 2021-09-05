using System;
using System.Runtime.InteropServices;

namespace ShellSpy.NativeWindows.Interop
{
    internal static partial class User32
    {
        /// <summary>
        /// Unregisters a window class, freeing the memory required for the class.
        /// </summary>
        /// <param name="lpClassName">A null-terminated string or a class atom. If lpClassName is a string, 
        /// it specifies the window class name. 
        /// This class name must have been registered by a previous call to the RegisterClass or RegisterClassEx function. 
        /// System classes, such as dialog box controls, cannot be unregistered. 
        /// If this parameter is an atom, it must be a class atom created by a previous call 
        /// to the RegisterClass or RegisterClassEx function. The atom must be in the low-order word of lpClassName; 
        /// the high-order word must be zero.</param>
        /// <param name="hInstance">A handle to the instance of the module that created the class.</param>
        /// <returns>If the function succeeds, the return value is nonzero.
        /// If the class could not be found or if a window still exists that was created with the class, 
        /// the return value is zero.To get extended error information, call GetLastError.</returns>
        /// <remarks>
        /// Before calling this function, an application must destroy all windows created with the specified class.
        /// All window classes that an application registers are unregistered when it terminates.
        /// Class atoms are special atoms returned only by RegisterClass and RegisterClassEx.
        /// No window classes registered by a DLL are unregistered when the .dll is unloaded.
        /// </remarks>
        [DllImport("User32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern bool UnregisterClass(string lpClassName, IntPtr hInstance);

        [DllImport("User32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern bool UnregisterClass(IntPtr lpClassName, IntPtr hInstance);
    }
}
