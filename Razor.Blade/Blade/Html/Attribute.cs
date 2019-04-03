using System.IO;
#if NET40
    using IHtmlString = System.Web.IHtmlString;
#else
    using IHtmlString = Microsoft.AspNetCore.Html.IHtmlContent;
    using HtmlEncoder = System.Text.Encodings.Web.HtmlEncoder;
#endif

namespace Connect.Razor.Blade.Html
{
    public class Attribute: IHtmlString
    {
        public Attribute(string name, object value = null, AttributeOptions options = null)
        {
            Name = name;
            Options = options;
            Value = value;
        }

        public string Name;
        public object Value;
        public AttributeOptions Options;

        #region ToString and ToHtml for all interfaces

        /// <summary>
        /// Gets the HTML encoded value.
        /// </summary>
        public string Html => AttributeBuilder.Attribute(Name, Value, Options);

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
