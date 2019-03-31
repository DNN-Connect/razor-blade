using System.Net;
#if NET40
    using HtmlString = System.Web.HtmlString;
#else
using HtmlString = Microsoft.AspNetCore.Html.HtmlString;
#endif


namespace Connect.Razor.Blade
{
    /// <summary>
    /// WIP: create basic tools to generate attributes and tags here, probably also move "Wrap" to this
    /// </summary>
    partial class Tags
    {
        internal static HtmlString Encode(string value) 
            => new HtmlString(EncodeString(value));


        /// <summary>
        /// Internal string-based commands to keep data simple till ready for output
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        internal static string EncodeString(string value)
            => WebUtility.HtmlEncode(value)
                .Replace("&#39;", "&apos;");
    }
}
