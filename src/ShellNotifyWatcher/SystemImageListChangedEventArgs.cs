namespace ShellSpy;

public sealed class SystemImageListChangedEventArgs(int imageIndex) : ShellNotifyEventArgs
{
    public int ImageIndex { get; } = imageIndex;
}
