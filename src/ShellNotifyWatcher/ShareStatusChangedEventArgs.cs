using ShellSpy.Common;

namespace ShellSpy
{
    public sealed class ShareStatusChangedEventArgs : ShellNotifyEventArgs
    {
        public ShareStatusChangedEventArgs(ItemIdList itemIdList, ShareStatus status)
        {
            Path = itemIdList;
            Status = status;
        }

        public ShareStatus Status { get; }

        public ItemIdList Path { get; }
    }
}
