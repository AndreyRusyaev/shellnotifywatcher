using System;
using System.Runtime.InteropServices;

namespace ShellSpy.ChangeNotify.Interop.SafeHandles
{
    internal class SHChangeNotificationLockHandle : SafeHandle
    {
        private SHChangeNotificationLockHandle() : base(IntPtr.Zero, true)
        {
        }

        public SHChangeNotificationLockHandle(IntPtr handle) : this()
        {
            this.handle = handle;
        }

        public override bool IsInvalid => handle == IntPtr.Zero;

        protected override bool ReleaseHandle()
        {
            return Shell32.SHChangeNotification_Unlock(handle);
        }
    }
}
