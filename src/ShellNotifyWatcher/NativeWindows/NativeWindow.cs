using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

using ShellSpy.NativeWindows.Interop;

namespace ShellSpy.NativeWindows
{
    internal class NativeWindow : IDisposable
    {
        private readonly NativeWindowClass windowClass;

        public NativeWindow(IntPtr parentWindowHandle, string windowName)
            : this(Kernel32.GetModuleHandleW(null), parentWindowHandle, windowName)
        {
        }

        public NativeWindow(IntPtr hInstance, IntPtr parentWindowHandle, string windowName)
        {
            Name = windowName;
            ParentWindowHandle = parentWindowHandle;

            string className = GetType().Name + "Class+" + Guid.NewGuid().ToString("B");

            windowClass = 
                new NativeWindowClass(hInstance, className, WndProc);

            WindowHandle = windowClass.CreateWindow(ParentWindowHandle, Name);
        }

        protected IntPtr ParentWindowHandle { get; }

        protected IntPtr WindowHandle { get; private set; }

        public string Name { get; }

        protected virtual IntPtr OnMessageReceived(WindowMessage message)
        {
            return DefWindowProc(message);
        }

        private IntPtr WndProc(IntPtr hwnd, int uMsg, IntPtr wParam, IntPtr lParam)
        {
            WindowMessage message = new WindowMessage(hwnd, uMsg, wParam, lParam);

            return OnMessageReceived(message);
        }

        private IntPtr DefWindowProc(WindowMessage message)
        {
            return User32.DefWindowProcW(message.WindowHandle,
                                         message.Id,
                                         message.WParam,
                                         message.LParam);
        }

        public void Close()
        {
            if (!User32.PostMessageW(WindowHandle, (uint)WindowMessages.WM_CLOSE, IntPtr.Zero, IntPtr.Zero))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }

        public void Destroy()
        {
            if (!User32.DestroyWindow(WindowHandle))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }

        public void Dispose()
        {
            DisposeManaged();
        }

        protected virtual void DisposeManaged()
        {
            if (WindowHandle != IntPtr.Zero)
            {
                Destroy();
                WindowHandle = IntPtr.Zero;
            }

            windowClass.Dispose();
        }
    }
}
