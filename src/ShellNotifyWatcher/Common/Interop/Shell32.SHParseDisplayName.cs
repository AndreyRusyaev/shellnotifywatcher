using System;
using System.Runtime.InteropServices;

namespace ShellSpy.Common.Interop
{
    internal static partial class Shell32
    {
        /// <summary>
        /// Translates a Shell namespace object's display name into an item identifier list 
        /// and returns the attributes of the object. This function is the preferred method 
        /// to convert a string to a pointer to an item identifier list (PIDL).
        /// </summary>
        /// <param name="pszName">A pointer to a zero-terminated wide string that contains the display name to parse.</param>
        /// <param name="pbc">A bind context that controls the parsing operation. This parameter is normally set to NULL.</param>
        /// <param name="ppidl">The address of a pointer to a variable of type ITEMIDLIST that receives the item identifier list for the object. If an error occurs, then this parameter is set to NULL.</param>
        /// <param name="sfgaoIn">A ULONG value that specifies the attributes to query. To query for one or more attributes, initialize this parameter with the flags that represent the attributes of interest. For a list of available SFGAO flags, see SFGAO.</param>
        /// <param name="psfgaoOut">A pointer to a ULONG. On return, those attributes that are true for the object and were requested in sfgaoIn are set. An object's attribute flags can be zero or a combination of SFGAO flags. For a list of available SFGAO flags, see SFGAO.</param>
        /// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [DllImport("shell32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        public static extern int SHParseDisplayName(string pszName,
                                                    IntPtr pbc,
                                                    out IntPtr ppidl,
                                                    int sfgaoIn,
                                                    out int psfgaoOut);
    }
}
