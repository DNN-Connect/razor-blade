using System.Text.RegularExpressions;

namespace Connect.Razor.Blade
{
    internal static class TagReplacer
    {
        internal static Regex Replacer(string names, bool open = true, bool close = true)
        {
            if (names.IndexOf(',') > -1)
                names = "[" + names.Replace(',', '|') + "]";
            const string closeOptional = "[/]?";
            const string closeRequired = "/";
            var closer = open ? (close ? closeOptional : "") : (close ? closeRequired : "");
            return new Regex("<" + closer + names + "[^>]*>", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
        }

    }
}
