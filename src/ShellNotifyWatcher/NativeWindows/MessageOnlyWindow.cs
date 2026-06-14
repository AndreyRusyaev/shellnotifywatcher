using ShellSpy.NativeWindows.Interop;

namespace ShellSpy.NativeWindows;

internal class MessageOnlyWindow(string windowName) : NativeWindow(User32.HWND_MESSAGE, windowName)
{
}
