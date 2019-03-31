using System.Net;
#if NET40
    using HtmlString = System.Web.HtmlString;
#else
    using HtmlString = Microsoft.AspNetCore.Html.HtmlString;
#endif

namespace Connect.Razor.Internals
{
    internal class Html
    {
        /// <summary>
        /// Internal string-based commands to keep data simple till ready for output
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        internal static string Encode(string value)
            => WebUtility.HtmlEncode(value)
                ?.Replace("&#39;", "&apos;");


        /// <summary>
        /// Internal string-based commands to keep data simple till ready for output
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        internal static string Decode(string value)
            => WebUtility.HtmlDecode(value);
    }
}
