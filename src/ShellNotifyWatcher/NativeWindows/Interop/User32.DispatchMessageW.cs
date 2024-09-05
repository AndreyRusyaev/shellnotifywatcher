using System.Runtime.InteropServices;

namespace ShellSpy.NativeWindows.Interop
{
    internal static partial class User32
    {
        /// <summary>
        /// Dispatches a message to a window procedure. 
        /// It is typically used to dispatch a message retrieved by the GetMessage function.
        /// </summary>
        /// <param name="lpMsg">A pointer to a structure that contains the message.</param>
        /// <returns>The return value specifies the value returned by the window procedure.
        /// Although its meaning depends on the message being dispatched, 
        /// the return value generally is ignored.</returns>
        [DllImport("User32.dll", ExactSpelling = true)]
        public static extern int DispatchMessageW([In] ref MSG lpMsg);
    }
}
