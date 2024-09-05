using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

using ShellSpy.Common.Interop;

namespace ShellSpy.Common
{
    internal class DriveRoot
    {
        public static string GetDriveByNum(int driveNum)
        {
            // buffer for 4 characters "C:\" + '\0'
            IntPtr pszPath = Marshal.AllocHGlobal(4);
            try
            {
                Shlwapi.PathBuildRootW(pszPath, driveNum);

                int lastError = Marshal.GetLastWin32Error();
                if (lastError != 0)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }

                string? result = Marshal.PtrToStringUni(pszPath);
                if (result == null)
                {
                    throw new InvalidOperationException("Unexpected empty drive path");
                }

                return result;
            }
            finally
            {
                Marshal.FreeHGlobal(pszPath);
            }
        }
    }
}
