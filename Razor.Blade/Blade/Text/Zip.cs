using System.Text.RegularExpressions;

namespace Connect.Razor.Blade
{
    public static partial class Text
    {
        /// <summary>
        /// Will remove all new-lines from a string and merge multiple spaces together
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Zip(string value)
        {
            return string.IsNullOrEmpty(value) 
                ? value 
                : ShrinkSpaces(Nl2X(value, " "));
        }

        internal static string ShrinkSpaces(string value)
        {
            return Regex.Replace(value, @"\s{2,}", " ");
        }

        internal static readonly Regex NewLine = new Regex(@"[\r\n]");

        internal static string Nl2X(string value, string replacement)
        {
            return NewLine.Replace(value, replacement);
        }
    }
}
