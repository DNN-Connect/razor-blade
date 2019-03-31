using Connect.Razor.Blade.Options;
using Connect.Razor.Internals;
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
        /// <summary>
        /// Generate an html tag
        /// </summary>
        /// <param name="name">the tag name</param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static HtmlString Tag(
            string name,
            string doNotRelyOnParameterOrder = EnforceNamedParameters.ProtectionKey,
            object attributes = null, 
            string content = null, 
            string id = null, 
            string classes = null,
            Tag options = null) 
            => new HtmlString(TagBuilder.Tag(name, 
                doNotRelyOnParameterOrder, attributes,
                content, id, classes, options));


        public static HtmlString Open(
            string name,
            string doNotRelyOnParameterOrder = EnforceNamedParameters.ProtectionKey,
            object attributes = null,
            string id = null,
            string classes = null,
            Tag options = null) 
            => new HtmlString(TagBuilder.Open(name, 
                doNotRelyOnParameterOrder, attributes, 
                id, classes, options));

        public static HtmlString Close(string name)
            => new HtmlString(TagBuilder.Close(name));


    }
}
