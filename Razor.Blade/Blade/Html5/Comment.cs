namespace Connect.Razor.Blade.Html5
{
    public class Comment : Tag
    {
        private const string Template = "<!-- {0} -->";

        public Comment(string content = null) : base(string.Format(Template, content))
        { }
    }
}
