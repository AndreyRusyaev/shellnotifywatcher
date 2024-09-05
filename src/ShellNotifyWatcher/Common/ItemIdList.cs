using System;
using System.Runtime.InteropServices;

using ShellSpy.Common.Interop;

namespace ShellSpy.Common
{
    public sealed class ItemIdList : SafeHandle
    {
        public ItemIdList(IntPtr pidl) : this(pidl, true)
        {
        }

        public ItemIdList(IntPtr pidl, bool ownsHandle)
            : base(IntPtr.Zero, ownsHandle)
        {
            handle = pidl;
        }

        public override bool IsInvalid => handle == IntPtr.Zero;

        public ItemIdList Clone()
        {
            return new ItemIdList(Shell32.ILCloneFull(handle), true);
        }

        public string ToAbsoluteParsingName()
        {
           var hResult = Shell32.SHGetNameFromIDList(
                handle,
                Shell32.SIGDN.SIGDN_DESKTOPABSOLUTEPARSING,
                out string ppszName);

            if (hResult >= 0)
            {
                return ppszName;
            }

            return $"<Unresolved: 0x{hResult:x8}>";
        }

        public static ItemIdList FromPidl(IntPtr pidl)
        {
            return new ItemIdList(Shell32.ILCloneFull(pidl), true);
        }

        public static ItemIdList GetDesktop()
{
            return FromAbsoluteParsingName("");
        }

        public static ItemIdList FromAbsoluteParsingName(string path)
        {
            var hResult = Shell32.SHParseDisplayName(path, IntPtr.Zero, out IntPtr ppidl, 0, out _);
            if (hResult != 0)
            {
                Marshal.ThrowExceptionForHR(hResult);
            }

            return new ItemIdList(ppidl);
        }

        protected override bool ReleaseHandle()
        {
            Shell32.ILFree(handle);
            return true;
        }

        public override string ToString()
        {
            return ToAbsoluteParsingName();
        }
    }
}
