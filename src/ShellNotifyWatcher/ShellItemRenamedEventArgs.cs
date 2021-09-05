using ShellSpy.Common;

namespace ShellSpy
{
    public sealed class ShellItemRenamedEventArgs : ShellNotifyEventArgs
    {
        public ShellItemRenamedEventArgs(ShellItemType itemType, ItemIdList oldItemIdList, ItemIdList newItemIdList)
        {
            ItemType = itemType;
            OldPath = oldItemIdList;
            NewPath = newItemIdList;
        }

        public ShellItemChangeType ChangeType { get; } = ShellItemChangeType.Renamed;

        public ShellItemType ItemType { get; }

        public ItemIdList OldPath { get; }

        public ItemIdList NewPath { get; }
    }
}
