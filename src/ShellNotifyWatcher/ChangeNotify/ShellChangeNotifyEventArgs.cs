using System;

using ShellSpy.ChangeNotify.Interop;

namespace ShellSpy.ChangeNotify
{
    internal sealed class ShellChangeNotifyEventArgs : EventArgs
    {
        public ShellChangeNotifyEventArgs(Shell32.SHCNE plEvent, IntPtr pidl1, IntPtr pidl2)
        {
            Event = plEvent;
            Pidl1 = pidl1;
            Pidl2 = pidl2;
        }

        public Shell32.SHCNE Event { get; }

        public IntPtr Pidl1 { get; }
        
        public IntPtr Pidl2 { get; }
    }
}
