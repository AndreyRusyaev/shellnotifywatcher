using System.Runtime.InteropServices;

namespace ShellSpy.ChangeNotify.Interop
{
    internal static partial class Shell32
    {
        /// <summary>
        /// Unregisters the client's window process from receiving SHChangeNotify messages.
        /// </summary>
        /// <param name="ulID">A value of type ULONG that specifies the registration ID returned by SHChangeNotifyRegister.</param>
        /// <returns>Returns TRUE if the specified client was found and removed; otherwise FALSE.</returns>
        [DllImport("shell32.dll")]
        public static extern bool SHChangeNotifyDeregister(int ulID);

    }
}
