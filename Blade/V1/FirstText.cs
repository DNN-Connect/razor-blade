using System.Linq;

namespace Connect.Razor.V1
{
    public static partial class Blade
    {
        /// <summary>
        /// Try to return a value, but if it's empty, return the fallback
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="handleHtmlWhitespaces">if true (default) will treat html-whitespace as a space</param>
        /// <returns></returns>
        public static string FirstText(string value1, string value2, bool handleHtmlWhitespaces = true)
        {
            return HasText(value1, handleHtmlWhitespaces) ? value1 : value2;
        }

        /// <summary>
        /// Try to return the first possible value, but if it's empty, return null
        /// </summary>
        /// <param name="values">array of values to check consecutively</param>
        /// <param name="handleHtmlWhitespaces">if true (default) will treat html-whitespace as a space</param>
        /// <returns></returns>
        public static string FirstText(string[] values, bool handleHtmlWhitespaces = true)
        {
            return values.FirstOrDefault(value => HasText(value, handleHtmlWhitespaces));
        }


        /// <summary>
        /// Try to return a value, but if it's empty, return the next in line
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        /// <param name="handleHtmlWhitespaces">if true (default) will treat html-whitespace as a space</param>
        /// <returns></returns>
        public static string FirstText(string value1, string value2, string value3, bool handleHtmlWhitespaces = true)
        {
            return FirstText(new[] {value1, value2, value3}, handleHtmlWhitespaces);
        }

        /// <summary>
        /// Try to return a value, but if it's empty, return the next in line
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        /// <param name="value4"></param>
        /// <param name="handleHtmlWhitespaces">if true (default) will treat html-whitespace as a space</param>
        /// <returns></returns>
        public static string FirstText(string value1, string value2, string value3, string value4, bool handleHtmlWhitespaces = true)
        {
            return FirstText(new[] { value1, value2, value3, value4 }, handleHtmlWhitespaces);
        }

        /// <summary>
        /// Try to return a value, but if it's empty, return the next in line
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        /// <param name="value4"></param>
        /// <param name="value5"></param>
        /// <param name="handleHtmlWhitespaces">if true (default) will treat html-whitespace as a space</param>
        /// <returns></returns>
        public static string FirstText(string value1, string value2, string value3, string value4, string value5, bool handleHtmlWhitespaces = true)
        {
            return FirstText(new[] { value1, value2, value3, value4, value5 }, handleHtmlWhitespaces);
        }


    }
}
