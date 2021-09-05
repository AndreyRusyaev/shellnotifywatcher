using System.Collections.Generic;

using ShellSpy.Common;

namespace ShellSpy
{
    public sealed class FreespaceChangedEventArgs : ShellNotifyEventArgs
    {
        private const int MaxDriveNum = 25;

        private readonly List<int> driveNums = new List<int>();
        private readonly List<string> driveRoots = new List<string>();

        public FreespaceChangedEventArgs(int driveMask)
        {
            var driveNums = new List<int>();
            for(int driveNum = 0; driveNum < MaxDriveNum; driveNum++)
            {
                if (((1 << driveNum) & driveMask) != 0)
                {
                    driveNums.Add(driveNum);
                    driveRoots.Add(DriveRoot.GetDriveByNum(driveNum));
                }
            }
        }

        public IEnumerable<int> DriveNums { get { return driveNums; } }

        public IEnumerable<string> Drives { get { return driveRoots; } }
    }
}
