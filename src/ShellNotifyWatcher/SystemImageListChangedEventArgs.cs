namespace ShellSpy
{
    public sealed class SystemImageListChangedEventArgs : ShellNotifyEventArgs
    {
        public SystemImageListChangedEventArgs(int imageIndex)
        {
            ImageIndex = imageIndex;
        }

        public int ImageIndex { get; }
    }
}
