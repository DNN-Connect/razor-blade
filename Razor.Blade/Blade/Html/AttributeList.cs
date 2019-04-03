using System.Collections.Generic;
using System.IO;
using System.Linq;
#if NET40
    using IHtmlString = System.Web.IHtmlString;
#else
    using IHtmlString = Microsoft.AspNetCore.Html.IHtmlContent;
    using HtmlEncoder = System.Text.Encodings.Web.HtmlEncoder;
#endif

namespace Connect.Razor.Blade.Html
{
    public class AttributeList: Dictionary<string, object>, IHtmlString
    {
        public AttributeList(AttributeOptions options = null)
        {
            Options = options;
        }
        public AttributeList(IEnumerable<KeyValuePair<string, string>> attributes, AttributeOptions options = null): this(options)
        {
            if(attributes != null)
                foreach (var pair in attributes)
                    Add(pair.Key, pair.Value);
        }

        public AttributeList(IEnumerable<KeyValuePair<string, object>> attributes, AttributeOptions options = null): this(options)
        {
            if(attributes != null)
                foreach (var pair in attributes)
                    Add(pair.Key, pair.Value);
        }

        public string Manual;
        public AttributeOptions Options;

        /// <summary>
        /// Gets the HTML encoded value.
        /// </summary>
        public string Html =>
            AttributeBuilder.Attributes(this, Options) 
            + (string.IsNullOrEmpty(Manual) ? "" : " " + Manual);


        #region ToString and ToHtml for all interfaces

#if NET40
        /// <summary>
        /// This is the serialization for the old-style asp.net razor
        /// </summary>
        /// <returns></returns>
        public string ToHtmlString() => ToString();
#else

        /// <inheritdoc />
        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            if (writer == null)
            {
                throw new System.ArgumentNullException(nameof(writer));
            }

            // was in original file but seems unused https://github.com/aspnet/AspNetCore/blob/6cc9f6f130af4ed0e7f321b144265cfbcec0ceee/src/Html/Abstractions/src/HtmlString.cs
            //if (encoder == null)
            //{
            //    throw new ArgumentNullException(nameof(encoder));
            //}

            writer.Write(Html);
        }
#endif
        public override string ToString() => Html ?? string.Empty;

        #endregion
    }
}
