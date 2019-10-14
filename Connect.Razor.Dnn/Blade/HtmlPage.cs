using System.Collections.Generic;
using Connect.Razor.Dnn;
using Connect.Razor.Interfaces;
using Connect.Razor.Internals;

namespace Connect.Razor.Blade
{
    /// <summary>
    /// Access the surrounding page and read/modify some properties, 
    /// + add various kinds of headers
    /// </summary>
    /// <remarks>
    /// It's important that the commands on this class are the same as in the IHtmlPage,
    /// to allow the API to be consistent both when using this shortcut-class as well as 
    /// when using the GetPage() and then doing the same commands on that. 
    /// This cannot be enforced with interfaces, as the static class cannot be typed
    /// </remarks>
    public static class HtmlPage
    {
        public static IHtmlPage GetPage() => new DnnHtmlPage();

        /// <summary>
        /// The current page title
        /// Will return null if not running in a page context.
        /// </summary>
        public static string Title
        {
            get => GetPage().Title;
            set => GetPage().Title = value;
        }

        /// <summary>
        /// Get/Set description of this page
        /// Will return null if not running in a page context.
        /// </summary>
        public static string Description
        {
            get => GetPage().Description;
            set => GetPage().Description = value;
        }

        /// <summary>
        /// Get/Set keywords of this page
        /// Will return null if not running in a page context.
        /// </summary>
        public static string Keywords
        {
            get => GetPage().Keywords;
            set => GetPage().Keywords = value;
        }

        /// <summary>
        /// Add a tag to the header of the page
        /// Will simply not do anything if an error occurs, like if the page object doesn't exist
        /// </summary>
        /// <param name="tag"></param>
        public static void AddToHead(string tag) => GetPage().AddToHead(tag);


        /// <summary>
        /// Add a tag object to the header of the page
        /// Will simply not do anything if an error occurs, like if the page object doesn't exist
        /// </summary>
        /// <param name="tag"></param>
        /// <remarks>New in 2.1</remarks>
        public static void AddToHead(Tag tag) => GetPage().AddToHead(tag);

        /// <summary>
        /// Add a standard meta header tag.
        /// If you need to add more attributes, use AddHeader(...) instead
        /// </summary>
        /// <param name="name"></param>
        /// <param name="content"></param>
        public static void AddMeta(string name, string content) => GetPage().AddMeta(name, content);

        /// <summary>
        /// Add an open-graph header according to http://ogp.me/
        /// </summary>
        /// <param name="property">Open Graph property name, like og:title or og:image:type</param>
        /// <param name="content">value of this property</param>
        public static void AddOpenGraph(string property, string content) => GetPage().AddOpenGraph(property, content);

        /// <summary>
        /// Add a JSON-LD header according https://developers.google.com/search/docs/guides/intro-structured-data
        /// </summary>
        /// <param name="jsonString">A prepared JSON string</param>
        public static void AddJsonLd(string jsonString) => GetPage().AddJsonLd(jsonString);

        /// <summary>
        /// Add a JSON-LD header according https://developers.google.com/search/docs/guides/intro-structured-data
        /// </summary>
        /// <param name="jsonObject">A object which will be converted to JSON. We recommend using dictionaries to build the object.</param>
        public static void AddJsonLd(object jsonObject) => GetPage().AddJsonLd(jsonObject);



        #region Icon stuff

        /// <summary>
        /// Add an icon tag to the page
        /// </summary>
        /// <param name="path">Path to the image/icon file</param>
        /// <param name="rel">the rel-text, default is 'icon'. common terms are also 'shortcut icon' or 'apple-touch-icon'</param>
        /// <param name="size">Will be used in size='#x#' tag; only relevant if you want to provide multiple separate sizes</param>
        /// <param name="type">An optional type. If not provided, will be auto-detected from known types or remain empty</param>
        static void AddIcon(
            string path,
            string doNotRelyOnParameterOrder = EnforceNamedParameters.ProtectionKey,
            string rel = "",
            int size = 0,
            string type = null) 
            => GetPage().AddIcon(path, rel: rel, size: size, type: type);

        /// <summary>
        /// Add a set of icons to the page
        /// </summary>
        /// <param name="path">Path to the image/icon file</param>
        /// <param name="favicon">Auto-generate a default favicon tag, which always points to the root. </param>
        /// <param name="rels"></param>
        /// <param name="sizes"></param>
        static void AddIconSet(
            string path,
            string doNotRelyOnParameterOrder = EnforceNamedParameters.ProtectionKey,
            bool favicon = true,
            IEnumerable<string> rels = null,
            IEnumerable<int> sizes = null)
            => GetPage().AddIconSet(path, favicon:favicon, rels:rels, sizes:sizes);

        /// <summary>
        /// Add a set of icons to the page
        /// </summary>
        /// <param name="path">Path to the image/icon file</param>
        /// <param name="favicon">path to favicon, default is '/favicon.ico' </param>
        /// <param name="rels"></param>
        /// <param name="sizes"></param>
        static void AddIconSet(
            string path,
            string doNotRelyOnParameterOrder = EnforceNamedParameters.ProtectionKey,
            string favicon = null,
            IEnumerable<string> rels = null,
            IEnumerable<int> sizes = null)
            => GetPage().AddIconSet(path, favicon:favicon, rels:rels, sizes:sizes);

        #endregion
    }
}