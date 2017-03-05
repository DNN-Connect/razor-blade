using System.Text.RegularExpressions;

namespace Connect.Razor
{
    public static partial class Blades
    {

        public static string StripHtml(string original)
        {
            var sanitizedText = Regex.Replace(original, "<[^>]*>", " ", RegexOptions.IgnoreCase).Trim();
            sanitizedText = Regex.Replace(sanitizedText, "\\s+", " ");
            return sanitizedText;
        }
    }
}
