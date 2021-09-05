using System;

using ShellSpy.Common;

namespace ShellSpy
{
    public sealed class ShellItemChangedEventArgs : EventArgs
    {
        public ShellItemChangedEventArgs(ShellItemType itemType, ItemIdList itemIdList, ShellItemChangeType changeType)
        {
            ItemType = itemType;
            Path = itemIdList;
            ChangeType = changeType;
        }

        public ShellItemChangeType ChangeType { get; }

        public ShellItemType ItemType { get; }

        public ItemIdList Path { get; }
    }
}
