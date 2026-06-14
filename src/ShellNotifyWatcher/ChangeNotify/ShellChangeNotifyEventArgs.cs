using ShellSpy.ChangeNotify.Interop;

namespace ShellSpy.ChangeNotify;

internal sealed class ShellChangeNotifyEventArgs(Shell32.SHCNE plEvent, IntPtr pidl1, IntPtr pidl2) : EventArgs
{
    public Shell32.SHCNE Event { get; } = plEvent;

    public IntPtr Pidl1 { get; } = pidl1;

    public IntPtr Pidl2 { get; } = pidl2;
}
