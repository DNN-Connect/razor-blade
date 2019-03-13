using System.Net;
#if NET40
    using HtmlString = System.Web.HtmlString;
#else
using HtmlString = Microsoft.AspNetCore.Html.HtmlString;
#endif


namespace Connect.Razor.Blade
{
    /// <summary>
    /// WIP: create basic tools to generate atttributes and tags here, probably also move "Wrap" to this
    /// </summary>
    partial class Tags
    {
        internal static HtmlString Attribute(string value) 
            => new HtmlString(AttributeS(value));


        internal static HtmlString Attribute(string name, string value, string quote = "\"") 
            => new HtmlString(AttributeS(name, value, quote));


        #region Internal string-based commands to keep data simple till ready for output
        internal static string AttributeS(string value)
            => WebUtility.HtmlEncode(value)
                .Replace("&#39;", "&apos;");
        internal static string AttributeS(string name, string value, string quote = "\"") 
            => $"{name}={quote}{Attribute(value)}{quote}";

        #endregion
    }
}
