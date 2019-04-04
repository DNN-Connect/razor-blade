#if NET40
using IHtmlString = System.Web.IHtmlString;
using HtmlString = System.Web.HtmlString;
#else
using System.IO;
using IHtmlString = Microsoft.AspNetCore.Html.IHtmlContent;
using HtmlString = Microsoft.AspNetCore.Html.HtmlString;
using HtmlEncoder = System.Text.Encodings.Web.HtmlEncoder;
#endif

namespace Connect.Razor.Blade.HtmlTags
{
    public partial class Tag: IHtmlString
    {

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


        #region .Open and .Close

        public HtmlString Open => new HtmlString(TagBuilder.Open(Name, Attributes, Options));
        public HtmlString Close => new HtmlString(TagBuilder.Close(Name));

        #endregion
    }
}
