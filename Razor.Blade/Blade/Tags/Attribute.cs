#if NET40
    using HtmlString = System.Web.HtmlString;
#else
using HtmlString = Microsoft.AspNetCore.Html.HtmlString;
#endif
using System.Collections.Generic;
using Connect.Razor.Internals;


namespace Connect.Razor.Blade
{
    /// <summary>
    /// Basic tools to generate attributes and tags here
    /// </summary>
    partial class Tags
    {
        /// <summary>
        /// Generate an attribute for use in a tag
        /// </summary>
        /// <param name="name">attribute name</param>
        /// <param name="value">attribute value</param>
        /// <param name="options">optional configuration regarding quotes and encoding</param>
        /// <returns>HtmlString so you can use @Tag.Attribute(...) in your code</returns>
        public static HtmlString Attribute(string name, string value, AttributeOptions options = null)
            => new HtmlString(AttributeBuilder.Attribute(name, value, options));


        /// <summary>
        /// Create a string for rendering a set of attributes
        /// </summary>
        /// <param name="attributes">An enumerable of key/value pairs, usually a dictionary</param>
        /// <param name="options">optional configuration regarding quotes and encoding</param>
        /// <returns>HtmlString so you can use @Tag.Attributes(...) in your code</returns>
        public static HtmlString Attributes(IEnumerable<KeyValuePair<string, string>> attributes, AttributeOptions options = null) 
            => new HtmlString(AttributeBuilder.Attributes(attributes, options));
    }
}
