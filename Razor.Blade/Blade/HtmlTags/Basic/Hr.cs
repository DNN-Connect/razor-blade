namespace Connect.Razor.Blade.HtmlTags
{
    public class Hr : Tag
    {
        public Hr(string content = null) : base("hr", content, new TagOptions { Close = false }) { }
    }
}
