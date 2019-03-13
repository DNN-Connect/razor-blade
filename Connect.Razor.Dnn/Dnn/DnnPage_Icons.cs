using System.Collections.Generic;

namespace Connect.Razor.Dnn
{
    // goal: add these headers easily and quickly
    //<link rel = 'icon' type='image/png' href='/[dein-assets-pfad]/favicon/favicon500.png'>
    //<link rel = 'shortcut icon' type='image/png' href='/[dein-assets-pfad]/favicon/favicon500.png'>
    //<link rel = 'apple-touch-icon' type='image/png' href='/[dein-assets-pfad]/favicon/favicon500.png'>
    //<link rel = 'icon' type='image/x-icon' href='/favicon.ico'>


    public partial class DnnHtmlPage
    {
        private const int IconSizeUndefined = 0;
        private const string IconRelationshipDefault = "icon";
        private static readonly string[] IconSetDefaultRelationships = {"icon", "shortcut icon", "apple-touch-icon"};

        public void AddIcon(string path, string rel = IconRelationshipDefault, int size = IconSizeUndefined, string type = null)
        {
            if (string.IsNullOrWhiteSpace(path)) return;

            type = type ?? DetectImageMime(path);
            var sizeAttr = size == IconSizeUndefined ? "" : $" sizes='{size}x{size}'";

            var typeAttr = $" type='{Attribute(type)}'";
            var relAttr = $" rel='{Attribute(rel)}'";

            AddToHead($"link {relAttr} {sizeAttr} {typeAttr} href='path'>");
        }

        public void AddIconSet(string path, bool favicon = true, IEnumerable<string> rels = null, IEnumerable<int> sizes = null)
        {
            // if no sizes given, just assume the default size only
            sizes = sizes ?? new[] {IconSizeUndefined};

            foreach (var relationship in rels ?? IconSetDefaultRelationships)
                foreach (var size in sizes)
                    AddIcon(path, relationship, size);

            if(favicon)
                AddIcon("/favicon.ico", "shortcut icon");
        }


        // todo: probably move to a better, global, usefull place
        // todo: test with urls containing ? characters
        internal static string DetectImageMime(string path)
        {
            var ext = System.IO.Path.GetExtension(path);
            if (string.IsNullOrWhiteSpace(ext)) return "";
            ext = ext.ToLowerInvariant();
            switch (ext)
            {
                case "gif":
                case "webp":
                case "jpeg":
                case "png": return $"image/{ext}";
                case "ico": return "image/x-icon";
                case "jpg": return "image/jpeg";
                case "svg": return "image/svg+xml";
                default: return "";
            }
        }


    }
}