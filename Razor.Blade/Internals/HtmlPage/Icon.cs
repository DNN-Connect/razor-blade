using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Connect.Razor.Blade;

namespace Connect.Razor.Internals.HtmlPage
{
    internal class Icon
    {
        internal const int SizeUndefined = 0;
        internal const string DefaultRelationship = "icon";
        internal const string RootFavicon = "/favicon.ico";
        internal const string ShortcutRelationship = "shortcut icon";
        internal const string AppleRelationship = "apple-touch-icon";
        internal static readonly string[] IconSetDefaultRelationships = {
            DefaultRelationship,
            AppleRelationship,
        };

        internal static string Generate(string path, string rel = null, int size = SizeUndefined, string type = null)
        {
            if (string.IsNullOrWhiteSpace(path)) return null;

            var attributes = new Dictionary<string, string>
            {
                {"rel", rel ?? DefaultRelationship},
                {"sizes", size == SizeUndefined ? "" : $"{size}x{size}"},
                {"type", type ?? DetectImageMime(path)},
                {"href", path },
            };

            return TagBuilder.Open("link", attributes: attributes, 
                options: new TagOptions(new AttributeOptions {KeepEmpty = false})
                {
                    Close = false,
                    SelfClose = false
                });
            //return $"<link {Tags.Attributes(attributes, new Attribute {KeepEmpty = false})}>";
        }


        internal static List<string> GenerateIconSet(string path, object favicon = null, IEnumerable<string> rels = null, IEnumerable<int> sizes = null)
        {
            // if no sizes given, just assume the default size only
            sizes = sizes ?? new[] { SizeUndefined };

            var relList = (rels ?? IconSetDefaultRelationships).ToList();

            var result = relList.SelectMany(relationship => sizes,
                    (relationship, size) => Generate(path, relationship, size))
                .ToList();

            switch (favicon)
            {
                case null:
                case bool favBool when favBool:
                    result.Add(Generate(RootFavicon, ShortcutRelationship));
                    break;
                case string favString when !string.IsNullOrEmpty(favString):
                    result.Add(Generate(favString, ShortcutRelationship));
                    break;
            }
            return result;
        }

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
