using Connect.Razor.Blade.HtmlTags;
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
    /// Basic tools to generate attributes and tags here, probably also move "Wrap" to this
    /// </summary>
    partial class Tags
    {
        ///// <summary>
        ///// Create an html tag for a specific name, optionally self self-closing (if specified in the options)
        ///// </summary>
        ///// <param name="name">tag name</param>
        ///// <param name="doNotRelyOnParameterOrder">dummy parameter, to ensure you use named parameters for anything optional, as the method signature may change in future</param>
        ///// <param name="attributes">optional attributes on the tag, either a string or a Dictionary of string, string</param>
        ///// <param name="content">optional content to place within the tag</param>
        ///// <param name="options">configuration of how to render the html - for example, when you want self-closing tags</param>
        ///// <returns>HtmlString of the tag, so you can use it directly with @Tag.Open(...) in your razor</returns>
        //public static HtmlString Tag(
        //    string name,
        //    string doNotRelyOnParameterOrder = EnforceNamedParameters.ProtectionKey,
        //    object attributes = null, 
        //    string content = null, 
        //    TagOptions options = null) 
        //    => new HtmlString(TagBuilder.Tag(name, 
        //        doNotRelyOnParameterOrder, 
        //        attributes: attributes,
        //        content: content, 
        //        options: options));


        ///// <summary>
        ///// Create an open tag for a specific tag name, optionally self self-closing (if specified in the options)
        ///// </summary>
        ///// <param name="name">tag name</param>
        ///// <param name="doNotRelyOnParameterOrder">dummy parameter, to ensure you use named parameters for anything optional, as the method signature may change in future</param>
        ///// <param name="attributes">optional attributes on the tag, either a string or a Dictionary of string, string</param>
        ///// <param name="options">configuration of how to render the html - for example, when you want self-closing tags</param>
        ///// <returns>HtmlString of the tag, so you can use it directly with @Tag.Open(...) in your razor</returns>
        //public static HtmlString Open(
        //    string name,
        //    string doNotRelyOnParameterOrder = EnforceNamedParameters.ProtectionKey,
        //    object attributes = null,
        //    //string id = null,
        //    //string classes = null,
        //    TagOptions options = null) 
        //    => new HtmlString(TagBuilder.Open(name, 
        //        doNotRelyOnParameterOrder, 
        //        attributes: attributes, 
        //        //id: id, 
        //        //classes: classes, 
        //        options: options));

        ///// <summary>
        ///// Create a close tag for a specific name
        ///// </summary>
        ///// <param name="name">tag name</param>
        ///// <returns>a tag like &lt;/tag-name&gt;</returns>
        //public static HtmlString Close(string name)
        //    => new HtmlString(TagBuilder.Close(name));


    }
}
