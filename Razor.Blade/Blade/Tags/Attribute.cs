#if NET40
    using HtmlString = System.Web.HtmlString;
#else
using HtmlString = Microsoft.AspNetCore.Html.HtmlString;
#endif
using System.Collections.Generic;
using System.Linq;


namespace Connect.Razor.Blade
{
    /// <summary>
    /// WIP: create basic tools to generate attributes and tags here, probably also move "Wrap" to this
    /// </summary>
    partial class Tags
    {
        public static HtmlString Attribute(string name, string value, string quote = "\"", bool keepEmpty = true)
            => new HtmlString(AttributeStr(name, value, quote, keepEmpty));

        private static bool UseAttribute(bool keepEmpty, string value) 
            => keepEmpty || !string.IsNullOrEmpty(value);

        // wip
        public static HtmlString Attributes(IEnumerable<KeyValuePair<string, string>> attributes, string quote = "\"", bool keepEmpty = true)
            => new HtmlString(string.Join(" ", 
                attributes.Select(a => AttributeStr(a.Key, a.Value, quote, keepEmpty))
                    .Where(val => !string.IsNullOrEmpty(val)))
            );

        /// <summary>
        /// Internal string-based commands to keep data simple till ready for output
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="quote"></param>
        /// <returns></returns>
        internal static string AttributeStr(string name, string value, string quote = "\"", bool keepEmpty = true) 
            => UseAttribute(keepEmpty, value) ? $"{name}={quote}{Encode(value)}{quote}" : "";
    }
}
