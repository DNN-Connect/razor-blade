using System.Text.RegularExpressions;

namespace Connect.Razor
{
    public static partial class Temporary
    {


        #region Replace helpers
        public static string Replace(this string input, string search, string replacement, bool caseSensitive)
        {
            input = input ?? "";
            search = search ?? "";
            replacement = replacement ?? "";

            if (caseSensitive)
                return input.Replace(search, replacement);

            string result = Regex.Replace(
                input,
                Regex.Escape(search ),
                (replacement).Replace("$", "$$"),
                RegexOptions.IgnoreCase
            );
            return result;
        }
        #endregion
    }
}
