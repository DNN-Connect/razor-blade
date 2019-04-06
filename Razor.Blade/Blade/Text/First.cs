using System.Linq;

namespace Connect.Razor.Blade
{
    public static partial class Text
    {
        /// <summary>
        /// Try to return a value, but if it's empty, return the fallback
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="handleHtmlWhitespaces">if true (default) will treat html-whitespace as a space</param>
        /// <returns></returns>
        public static string First(string value1, string value2, bool handleHtmlWhitespaces = true) 
            => Has(value1, handleHtmlWhitespaces) ? value1 : value2;

        /// <summary>
        /// Try to return the first possible value, but if it's empty, return null
        /// </summary>
        /// <param name="values">array of values to check consecutively</param>
        /// <param name="handleHtmlWhitespaces">if true (default) will treat html-whitespace as a space</param>
        /// <returns></returns>
        public static string First(string[] values, bool handleHtmlWhitespaces = true) 
            => values.FirstOrDefault(value => Has(value, handleHtmlWhitespaces));


        /// <summary>
        /// Try to return a value, but if it's empty, return the next in line
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        /// <param name="handleHtmlWhitespaces">if true (default) will treat html-whitespace as a space</param>
        /// <returns></returns>
        public static string First(string value1, string value2, string value3, bool handleHtmlWhitespaces = true) 
            => First(new[] {value1, value2, value3}, handleHtmlWhitespaces);

        /// <summary>
        /// Try to return a value, but if it's empty, return the next in line
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        /// <param name="value4"></param>
        /// <param name="handleHtmlWhitespaces">if true (default) will treat html-whitespace as a space</param>
        /// <returns></returns>
        public static string First(string value1, string value2, string value3, string value4, bool handleHtmlWhitespaces = true) 
            => First(new[] { value1, value2, value3, value4 }, handleHtmlWhitespaces);

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
        public static string First(string value1, string value2, string value3, string value4, string value5, bool handleHtmlWhitespaces = true) 
            => First(new[] { value1, value2, value3, value4, value5 }, handleHtmlWhitespaces);
    }
}
