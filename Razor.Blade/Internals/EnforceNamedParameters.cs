using System;

namespace Connect.Razor.Internals
{
    /// <summary>
    /// Helper to ensure that commands with various overloads must use named parameters
    /// </summary>
    public class EnforceNamedParameters
    {
        /// <summary>
        /// This is just a constant to give to the parameter "protecting" the others
        /// Its value and type can be changed from time to time, as it's value is only checked internally. 
        /// </summary>
        public const string ProtectionKey = "0239fse[4332xhkne";

        public static bool VerifyProtectionKey(string value, bool throwError = true)
        {
            var valid = value == ProtectionKey;
            if(!valid && throwError)
                throw new Exception("");
            return valid;
        }
    }
}
