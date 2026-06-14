using ShellSpy.Common;

namespace ShellSpy;

public sealed class ShellItemChangedEventArgs(ShellItemType itemType, ItemIdList itemIdList, ShellItemChangeType changeType) : EventArgs
{
    public ShellItemChangeType ChangeType { get; } = changeType;

    public ShellItemType ItemType { get; } = itemType;

    public ItemIdList Path { get; } = itemIdList;
}
