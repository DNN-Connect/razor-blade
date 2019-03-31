using Connect.Razor.Internals;
#if NET40
    using HtmlString = System.Web.HtmlString;
#else
using HtmlString = Microsoft.AspNetCore.Html.HtmlString;
// ReSharper disable ArgumentsStyleNamedExpression
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
        /// <returns></returns>
        public static HtmlString Tag(
            string name,
            string doNotRelyOnParameterOrder = EnforceNamedParameters.ProtectionKey,
            object attributes = null, 
            string content = null, 
            string id = null, 
            string classes = null,
            TagOptions options = null) 
            => new HtmlString(TagBuilder.Tag(name, 
                doNotRelyOnParameterOrder, 
                attributes: attributes,
                content: content, 
                id: id, 
                classes: classes, 
                options: options));


        /// <summary>
        /// Create an open tag for a specific tag name, optionally self self-closing (if specified in the 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="doNotRelyOnParameterOrder"></param>
        /// <param name="attributes"></param>
        /// <param name="id"></param>
        /// <param name="classes"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static HtmlString Open(
            string name,
            string doNotRelyOnParameterOrder = EnforceNamedParameters.ProtectionKey,
            object attributes = null,
            string id = null,
            string classes = null,
            TagOptions options = null) 
            => new HtmlString(TagBuilder.Open(name, 
                doNotRelyOnParameterOrder, 
                attributes: attributes, 
                id: id, 
                classes: classes, 
                options: options));

        /// <summary>
        /// Create a close tag for a specific name
        /// </summary>
        /// <param name="name">tag name</param>
        /// <returns>a tag like &lt;/tag-name&gt;</returns>
        public static HtmlString Close(string name)
            => new HtmlString(TagBuilder.Close(name));


    }
}
