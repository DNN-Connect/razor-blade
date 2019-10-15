using Connect.Razor.Internals;

namespace Connect.Razor.Blade.Html5
{
    public class ScriptJsonLd : Script
    {
        /// <summary>
        /// Create a JsonLd Script-Tag
        /// </summary>
        /// <param name="content"></param>
        public ScriptJsonLd(string content)
        {
            Type("application/ld+json");
            TagContents = content;
        }

        /// <summary>
        /// Create a JsonLd Script tag and automatically json-serialize the object inside it
        /// </summary>
        /// <param name="content"></param>
        public ScriptJsonLd(object content)
            : this(Html.ToJsonOrErrorMessage(content)) {}
    }
}
