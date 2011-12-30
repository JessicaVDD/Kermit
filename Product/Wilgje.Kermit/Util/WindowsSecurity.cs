using System;
using System.Text;

namespace Willow.Kermit.Util
{
    /// <summary>  
    /// Wraps the GetUserNameEx API in secur32.dll  
    /// </summary>
    /// <see>
    /// http://msdn2.microsoft.com/en-us/library/ms724435.aspx
    /// </see>  
    public static class WindowsSecurity
    {
        #region Interop Definitions
        public enum NameFormattingOption
        {
            NameUnknown = 0,
            NameFullyQualifiedDN = 1,
            NameSamCompatible = 2,
            NameDisplay = 3,
            NameUniqueId = 6,
            NameCanonical = 7,
            NameUserPrincipal = 8,
            NameCanonicalEx = 9,
            NameServicePrincipal = 10,
            NameDnsDomain = 12,
        }

        [System.Runtime.InteropServices.DllImport("secur32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern int GetUserNameEx(int nameFormat, StringBuilder userName, ref int userNameSize);
        #endregion

        public static string GetUserName(NameFormattingOption nameFormat)
        {
            if (Environment.OSVersion.Platform != PlatformID.Win32NT) { return null; }
            var userName = new StringBuilder(1024);
            var userNameSize = userName.Capacity;
            if (GetUserNameEx((int)nameFormat, userName, ref userNameSize) != 0)
            {
                string[] nameParts = userName.ToString().Split('\\');
                return nameParts[0];
            }
            return null;
        }

        public static string GetUserFullName()
        {
            return GetUserName(NameFormattingOption.NameDisplay);
        }
    }
}