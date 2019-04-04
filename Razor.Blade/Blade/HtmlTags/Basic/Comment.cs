namespace Connect.Razor.Blade.HtmlTags
{
    public class Comment : Tag
    {
        private const string Template = "<!-- {0} -->";

        public Comment(string content = null) : base(string.Format(Template, content))
        { }
    }
}
