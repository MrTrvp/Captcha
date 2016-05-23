using System;
using System.Runtime.InteropServices;
using System.Security;

namespace dCaptcha.Core.Extensions
{
    public static class SecureStringExtensions
    {
        public static string ToStringEx(this SecureString secureString)
        {
            var intPtr = IntPtr.Zero;
            try
            {
                intPtr = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(intPtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(intPtr);
            }
        }
    }
}           