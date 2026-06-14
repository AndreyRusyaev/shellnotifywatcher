namespace ShellSpy.NativeWindows;

internal readonly struct WindowMessage(IntPtr handle, int messageId, IntPtr wParam, IntPtr lParam)
{
    public IntPtr WindowHandle { get; } = handle;

    public int Id { get; } = messageId;

    public IntPtr WParam { get; } = wParam;

    public IntPtr LParam { get; } = lParam;
}
