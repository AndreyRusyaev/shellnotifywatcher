using ShellSpy.Common;

namespace ShellSpy
{
    public sealed class DriveChangedEventArgs : ShellNotifyEventArgs
    {
        public DriveChangedEventArgs(ItemIdList itemIdList, DriveChangeType driveChangeType)
        {
            Path = itemIdList;
            ChangeType = driveChangeType;
        }

        public DriveChangeType ChangeType { get; }

        public ItemIdList Path { get; }
    }
}
