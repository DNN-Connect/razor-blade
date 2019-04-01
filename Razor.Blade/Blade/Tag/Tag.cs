﻿using System.Collections.Generic;
using Connect.Razor.Internals;
#if NET40
    using IHtmlString = System.Web.IHtmlString;
#else
using System;
    using System.IO;
    using IHtmlString = Microsoft.AspNetCore.Html.IHtmlContent;
    using HtmlEncoder = System.Text.Encodings.Web.HtmlEncoder;
#endif

namespace Connect.Razor.Blade
{
    internal class Tag: IHtmlString
    {
        /// <inheritdoc />
        public Tag() { }

        public Tag(string name = null, string attributes = null, string content = null)
        {

        }

        public string Name = "div";
        public Dictionary<string, string> Attributes { get; } = new Dictionary<string, string>();
        public string Content = string.Empty;

        /// <summary>
        /// Gets the HTML encoded value.
        /// </summary>
        public string Value => TagBuilder.Tag(Name, attributes: Attributes, content: Content);

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
                throw new ArgumentNullException(nameof(writer));
            }

            // was in original file but seems unused https://github.com/aspnet/AspNetCore/blob/6cc9f6f130af4ed0e7f321b144265cfbcec0ceee/src/Html/Abstractions/src/HtmlString.cs
            //if (encoder == null)
            //{
            //    throw new ArgumentNullException(nameof(encoder));
            //}

            writer.Write(Value);
        }
#endif
        public override string ToString() => Value ?? string.Empty;
    }
}
