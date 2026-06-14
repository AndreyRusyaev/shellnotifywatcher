using ShellSpy.Common;

namespace ShellSpy;

public sealed class DriveChangedEventArgs(ItemIdList itemIdList, DriveChangeType driveChangeType) : ShellNotifyEventArgs
{
    public DriveChangeType ChangeType { get; } = driveChangeType;

    public ItemIdList Path { get; } = itemIdList;
}
