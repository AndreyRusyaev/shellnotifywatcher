using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;

using ShellSpy.NativeWindows.Interop;

namespace ShellSpy.NativeWindows
{
    internal sealed class MessageLoop : IDisposable
    {
        private readonly CancellationToken cancellationToken;

        private readonly CancellationTokenRegistration cancellationTokenRegistration;

        private readonly AutoResetEvent stopHandle = new AutoResetEvent(false);

        private int threadId;

        private MessageLoop(CancellationToken cancellationToken)
        {
            this.cancellationToken = cancellationToken;

            cancellationTokenRegistration = this.cancellationToken.Register(Stop);
        }

        public static void Run(CancellationToken cancellationToken)
        {
            using MessageLoop messageLoop = new MessageLoop(cancellationToken);
            messageLoop.Run();
        }

        private void Run()
        {
            threadId = Kerne32.GetCurrentThreadId();

            User32.MSG msg = new User32.MSG();

            while (true)
            {
                int result = User32.GetMessageW(ref msg, IntPtr.Zero, 0, 0);
                if (result == 0)
                {
                    // Received WM_QUIT
                    break;
                }

                if (result == -1)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
                else
                {
                    User32.DispatchMessageW(ref msg);
                }
            }

            stopHandle.Set();
        }

        private void Stop()
        {
            if (!User32.PostThreadMessageW(threadId, (int) WindowMessages.WM_QUIT, new IntPtr(0), IntPtr.Zero))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            stopHandle.WaitOne();
        }

        public void Dispose()
        {
            cancellationTokenRegistration.Dispose();
        }
    }
}
