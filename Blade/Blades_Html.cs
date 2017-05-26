using System;
using System.Text.RegularExpressions;

namespace Connect.Razor
{
    public static partial class Blade
    {
        public static string StripHtml(string original)
        {
            // remove all tags, replace with spaces to prevent words sticking together
            var sanitizedText = Regex.Replace(original, "<[^>]*>", " ", RegexOptions.IgnoreCase);

            // technically there could still be some unmatched "<" or ">" characters 
            // this is low risk, but technically an attacker knowing the internals could abuse this
            sanitizedText = sanitizedText.Replace("<", "").Replace(">", "");

            // combine resulting multi-spaces
            sanitizedText = Regex.Replace(sanitizedText, "\\s{2,}", " ");

            return sanitizedText.Trim();
        }

        /// <summary>
        /// Todo: should convert \n into line-breaks
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static string LineBreaks(string original)
        {
            return original.Replace("\n", "<br>");
        }
    }
}
