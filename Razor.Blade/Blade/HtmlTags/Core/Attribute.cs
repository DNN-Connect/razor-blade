#if NET40
using IHtmlString = System.Web.IHtmlString;
#else
using System.IO;
using IHtmlString = Microsoft.AspNetCore.Html.IHtmlContent;
using HtmlEncoder = System.Text.Encodings.Web.HtmlEncoder;
#endif

namespace Connect.Razor.Blade.HtmlTags
{
    public class Attribute: AttributeBase, IHtmlString
    {
        public Attribute(string name, object value = null, AttributeOptions options = null)
            : base(name, value, options) { }

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
                throw new System.ArgumentNullException(nameof(writer));
            writer.Write(ToString());
        }
#endif

        #endregion

    }
}
