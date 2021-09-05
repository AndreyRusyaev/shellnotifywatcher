﻿using System;
using System.Runtime.InteropServices;

using ShellSpy.Common;
using ShellSpy.ChangeNotify.Interop;
using ShellSpy.NativeWindows;

namespace ShellSpy.ChangeNotify
{
    internal sealed class ShellChangeNotifyWindow : MessageOnlyWindow
    {
        private const int WM_CHANGENOTIFY = (int)WindowMessages.WM_USER + 200;

        private readonly int changeNotifyRegistrationId;

        public ShellChangeNotifyWindow(ItemIdList itemIdList, bool recursive, Shell32.SHCNE notifyFilters) 
            : base("ShellChangeNotifyWindow")
        {
            ItemIdList = itemIdList.Clone();
            Recursive = recursive;
            NotifyFilters = notifyFilters;

            var changeNotifyEntries = new[]
            {
                new Shell32.SHChangeNotifyEntry
                {
                    pidl = ItemIdList.DangerousGetHandle(),
                    fRecursive = Recursive
                }
            };

            changeNotifyRegistrationId = Shell32.SHChangeNotifyRegister(
                    WindowHandle,
                    Shell32.SHCNRF.SHCNRF_ShellLevel
                        | Shell32.SHCNRF.SHCNRF_InterruptLevel
                        | Shell32.SHCNRF.SHCNRF_NewDelivery
                        | Shell32.SHCNRF.SHCNRF_RecursiveInterrupt,
                    notifyFilters,
                    WM_CHANGENOTIFY,
                    changeNotifyEntries.Length,
                    changeNotifyEntries);

            if (changeNotifyRegistrationId == 0)
            {
                throw new InvalidOperationException("Failed to register change notify register");
            }
        }

        public event EventHandler<ShellChangeNotifyEventArgs>? ShellChanged;

        public ItemIdList ItemIdList { get; }

        public bool Recursive { get; }

        public Shell32.SHCNE NotifyFilters { get; }

        protected override IntPtr OnMessageReceived(WindowMessage message)
        {
            if (message.Id == WM_CHANGENOTIFY)
{
                using (Shell32.SHChangeNotification_Lock(
                    message.WParam,
                    (int)message.LParam,
                    out IntPtr pppidl,
                    out Shell32.SHCNE plEvent))
                {
                    IntPtr[] affectedPidls = new IntPtr[2];

                    Marshal.Copy(pppidl, affectedPidls, 0, affectedPidls.Length);

                    ShellChanged?.Invoke(
                        this,
                        new ShellChangeNotifyEventArgs(plEvent, affectedPidls[0], affectedPidls[1]));
                }

                return IntPtr.Zero;
            }

            return base.OnMessageReceived(message);
        }

        protected override void DisposeManaged()
        {
            base.DisposeManaged();

            if (changeNotifyRegistrationId != 0)
            {
                if (!Shell32.SHChangeNotifyDeregister(changeNotifyRegistrationId))
                {
                    throw new InvalidOperationException("Failed to deregister notifications");
                }
            }

            ItemIdList.Dispose();
        }
    }
}
