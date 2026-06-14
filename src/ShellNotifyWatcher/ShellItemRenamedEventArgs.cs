using ShellSpy.Common;

namespace ShellSpy;

public sealed class ShellItemRenamedEventArgs(ShellItemType itemType, ItemIdList oldItemIdList, ItemIdList newItemIdList) : ShellNotifyEventArgs
{
    public ShellItemChangeType ChangeType { get; } = ShellItemChangeType.Renamed;

    public ShellItemType ItemType { get; } = itemType;

    public ItemIdList OldPath { get; } = oldItemIdList;

    public ItemIdList NewPath { get; } = newItemIdList;
}
