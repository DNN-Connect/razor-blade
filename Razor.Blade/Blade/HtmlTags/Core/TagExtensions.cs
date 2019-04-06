namespace Connect.Razor.Blade.HtmlTags
{
    public static class TagExtensions
    {
        public static T AttrTyped<T>(this T tag, string name, object value = null, string separator = "")
            where T: Tag
        {
            // ReSharper disable once MustUseReturnValue
            tag.Attr(name, value, separator);
            return tag;
        }

    }
}
