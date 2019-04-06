using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Connect.Razor.Blade.HtmlTags
{
    public class Icon : Tag
    {
        internal const int SizeUndefined = 0;
        internal const string DefaultRelationship = "icon";
        internal const string RootFavicon = "/favicon.ico";
        internal const string ShortcutRelationship = "shortcut icon";
        internal const string AppleRelationship = "apple-touch-icon";

        public Icon(string path, string rel = null, int size = SizeUndefined, string type = null) 
            : base("link", new TagOptions(new AttributeOptions { KeepEmpty = false }) {Close = false})
        {
            Rel(rel ?? DefaultRelationship);
            Sizes(size == SizeUndefined ? "" : $"{size}x{size}");
            Type(type ?? DetectImageMime(path));
            Href(path);
        }

        public Icon Rel(string value) => this.Attr("rel", value, null);
        public Icon Sizes(string value) => this.Attr("sizes", value, null);
        public Icon Type(string value) => this.Attr("type", value, null);
        public Icon Href(string value) => this.Attr("href", value, null);



        /// <summary>
        /// Find mime type of file in url
        /// </summary>
        /// <param name="path">path to use</param>
        /// <returns></returns>
        internal static string DetectImageMime(string path)
        {
            // ReSharper disable StringIndexOfIsCultureSpecific.1
            if (string.IsNullOrWhiteSpace(path) || path.IndexOf(".") < 1)
                return "";

            // keep only the part before question mark and hash
            var pathOnly = Regex.Match(path, @"([^\?#])+");
            if (pathOnly.Length == 0)
                return "";

            path = pathOnly.Value;

            // find extension
            var ext = System.IO.Path.GetExtension(path);
            if (string.IsNullOrWhiteSpace(ext)) return "";
            ext = ext
                .Replace(".", "")
                .ToLowerInvariant();

            // resolve to mime type
            return MimeTypes.ContainsKey(ext) ? MimeTypes[ext] : DefaultImageType + ext;
        }

        internal const string DefaultImageType = "image/";
        internal static Dictionary<string, string> MimeTypes = new Dictionary<string, string>
        {
            {"ico",  "image/x-icon"},
            {"svg",  "image/svg+xml"},
            {"gif", "image/gif" },
            {"png", "image/png" },
            {"jpg", "image/jpeg" },
            {"jpeg", "image/jpeg" },
            {"webp", "image/webp" },
        };
    }
}
