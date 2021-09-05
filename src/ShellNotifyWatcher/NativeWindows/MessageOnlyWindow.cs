using ShellSpy.NativeWindows.Interop;

namespace ShellSpy.NativeWindows
{
    internal class MessageOnlyWindow : NativeWindow
    {
        public MessageOnlyWindow(string windowName) 
            : base(User32.HWND_MESSAGE, windowName)
        {
        }
    }
}
