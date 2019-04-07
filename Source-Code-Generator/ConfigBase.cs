using System;

namespace Source_Code_Generator
{
    public class ConfigBase
    {
        public static string FirstCharToUpper(string s)
        {
            // Check for empty string.  
            if (String.IsNullOrEmpty(s))
            {
                return String.Empty;
            }
            // Return char and concat substring.  
            return Char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}
