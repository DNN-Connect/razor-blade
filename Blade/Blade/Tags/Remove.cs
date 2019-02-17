using System.Text.RegularExpressions;

namespace Connect.Razor.Blade
{
    public static partial class Tags
    {
        public static string Strip(string original)
        {
            // remove all tags, replace with spaces to prevent words from sticking together
            var sanitizedText = Regex.Replace(original, "<[^>]*>", " ", RegexOptions.IgnoreCase);

            // remove remaining < and >
            // because there could still be some unmatched "<" or ">" characters 
            // this is unlikely, but otherwise an attacker knowing these internals could abuse this
            sanitizedText = sanitizedText.Replace("<", " ").Replace(">", " ");

            // combine resulting multi-spaces
            sanitizedText = Text.ShrinkSpaces(sanitizedText);

            return sanitizedText.Trim();
        }


    }
}
