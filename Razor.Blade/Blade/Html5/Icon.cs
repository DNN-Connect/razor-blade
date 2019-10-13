using Connect.Razor.Blade.HtmlTags;

namespace Connect.Razor.Blade.Html5
{
    public class Icon : Link
    {
        internal const int SizeUndefined = 0;
        internal const string Relationship = "icon";
        internal const string RootFavicon = "/favicon.ico";
        internal const string ShortcutRelationship = "shortcut icon";
        internal const string AppleRelationship = "apple-touch-icon";

        public Icon(string path, string rel = null, int size = SizeUndefined, string type = null)
        {
            // override empty attributes
            TagOptions = new TagOptions(new AttributeOptions {KeepEmpty = false}) {Close = false};

            Rel(rel ?? Relationship);
            Sizes(size == SizeUndefined ? "" : $"{size}x{size}");
            Type(type ?? Mime.DetectImageMime(path));
            Href(path);
        }

        public Icon Sizes(string value) => this.Attr("sizes", value, null);

    }
}
