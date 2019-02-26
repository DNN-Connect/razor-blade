using Connect.Razor.Dnn;
using Connect.Razor.Interfaces;

namespace Connect.Razor.Blade
{
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

    }
}