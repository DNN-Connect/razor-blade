using System.Text.RegularExpressions;

namespace Connect.Razor
{
    public static partial class Blade
    {
        #region HasText
        public static bool HasText(object valToTest)
        {
            // try to cast to string, it will be null if invalid
            return !string.IsNullOrWhiteSpace(valToTest as string);
        }

        #endregion

        #region Fallback
        /// <summary>
        /// Try to return a value, but if it's empty, return the fallback
        /// </summary>
        /// <param name="valToShow"></param>
        /// <param name="fallback"></param>
        /// <returns></returns>
        public static string Fallback(string valToShow, string fallback)
        {
            return HasText(valToShow) ? valToShow : fallback;
        }

        /// <summary>
        /// Fallback-chain with up to 5 backup-values
        /// </summary>
        /// <param name="valToShow"></param>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <param name="val3"></param>
        /// <param name="val4"></param>
        /// <param name="val5"></param>
        /// <returns></returns>
        public static string Fallback(string valToShow, string val1, string val2, string val3, string val4 = null, string val5 = null)
        {
            return Fallback(Fallback(Fallback(Fallback(Fallback(valToShow,val1), val2), val3), val4), val5);
        }
        #endregion

        #region Ellipsis
        public static string Ellipsis(string valToShow, int maxChars, string trailer = null)
        {
            return valToShow.Length > maxChars
                ? valToShow.Substring(0, maxChars) + (trailer ?? BladeDefaults.EllipsisChar)
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
