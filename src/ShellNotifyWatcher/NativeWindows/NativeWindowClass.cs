using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

using ShellSpy.NativeWindows.Interop;

namespace ShellSpy.NativeWindows
{
    internal sealed class NativeWindowClass : IDisposable
    {
        private readonly IntPtr hInstance;

        private readonly User32.WNDPROC wndProc;

        private ushort classRegistrationAtom;

        private bool isDisposed;

        public NativeWindowClass(IntPtr hInstance, string className, User32.WNDPROC wndProc)
        {
            this.hInstance = hInstance;
            Name = className;
            this.wndProc = wndProc;

            var wndClass = new User32.WNDCLASSEX
            {
                cbSize = Marshal.SizeOf<User32.WNDCLASSEX>(),
                lpfnWndProc = wndProc,
                lpszClassName = className,
                hInstance = hInstance
            };

            classRegistrationAtom = User32.RegisterClassEx(ref wndClass);
            if (classRegistrationAtom == 0)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }

        public string Name { get; }

        public IntPtr CreateWindow(IntPtr hParentWindow, string windowName)
        {
            var hWindow = User32.CreateWindowEx(
                0,
                Name,
                windowName,
                0,
                0,
                0,
                0,
                0,
                hParentWindow,
                IntPtr.Zero,
                hInstance,
                IntPtr.Zero);

            if (hWindow == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            return hWindow;
        }

        public void Dispose()
        {
            if (!isDisposed)
            {
                if (!User32.UnregisterClass(new IntPtr(classRegistrationAtom), hInstance))
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }

                isDisposed = true;
            }
        }
    }
}
