using System.Text.RegularExpressions;

namespace Connect.Razor.V1
{
    public static partial class Blade
    {
        #region Show

        /// <summary>
        /// Try to return a value, but if it's empty, return the fallback
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fallback"></param>
        /// <returns></returns>
        public static string FirstText(string value, string fallback = null)
        {
            return HasText(value) ? value : fallback;
        }

        /// <summary>
        /// Fallback-chain with up to 5 backup-values
        /// </summary>
        /// <param name="value"></param>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <param name="val3"></param>
        /// <param name="val4"></param>
        /// <param name="val5"></param>
        /// <returns></returns>
        public static string FirstText(string value, string val1, string val2, string val3 = null, string val4 = null, string val5 = null)
        {
            return FirstText(FirstText(FirstText(FirstText(FirstText(value,val1), val2), val3), val4), val5);
        }
        #endregion

        #region Ellipsis
        public static string Ellipsis(string valToShow, int maxChars, string trailer = null)
        {
            return valToShow.Length > maxChars
                ? valToShow.Substring(0, maxChars) + (trailer ?? BladeDefaults.HtmlEllipsisCharacter)
                : valToShow;
        }

        #endregion

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
