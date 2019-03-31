using Connect.Razor.Internals;
#if NET40
    using HtmlString = System.Web.HtmlString;
#else
using HtmlString = Microsoft.AspNetCore.Html.HtmlString;
#endif


namespace Connect.Razor.Blade
{
    /// <summary>
    /// Encode a string for placing in the source of html or an attribute
    /// </summary>
    partial class Tags
    {
        public static HtmlString Encode(string value) 
            => new HtmlString(Html.EncodeString(value));

        public static HtmlString Decode(string value) 
            => new HtmlString(Html.DecodeString(value));
    }
}
