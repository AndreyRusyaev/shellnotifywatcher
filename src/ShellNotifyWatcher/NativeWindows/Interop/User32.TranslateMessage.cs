using System.Runtime.InteropServices;

namespace ShellSpy.NativeWindows.Interop
{
    internal static partial class User32
    {
        /// <summary>
        /// Translates virtual-key messages into character messages. 
        /// The character messages are posted to the calling thread's message queue, 
        /// to be read the next time the thread calls the GetMessage or PeekMessage function.
        /// </summary>
        /// <param name="lpMsg">A pointer to an MSG structure that contains message information 
        /// retrieved from the calling thread's message queue by using the GetMessage or PeekMessage function.</param>
        /// <returns>
        /// If the message is translated (that is, a character message is posted to the thread's message queue), 
        /// the return value is nonzero.
        /// If the message is WM_KEYDOWN, WM_KEYUP, WM_SYSKEYDOWN, or WM_SYSKEYUP, the return value is nonzero, 
        /// regardless of the translation.
        /// If the message is not translated (that is, a character message is not posted to the thread's message queue), 
        /// the return value is zero.
        /// </returns>
        [DllImport("User32.dll")]
        public static extern bool TranslateMessage(ref MSG lpMsg);
    }
}
