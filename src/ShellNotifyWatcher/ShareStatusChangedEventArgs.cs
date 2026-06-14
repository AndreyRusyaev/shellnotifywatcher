using ShellSpy.Common;

namespace ShellSpy;

public sealed class ShareStatusChangedEventArgs(ItemIdList itemIdList, ShareStatus status) : ShellNotifyEventArgs
{
    public ShareStatus Status { get; } = status;

    public ItemIdList Path { get; } = itemIdList;
}
