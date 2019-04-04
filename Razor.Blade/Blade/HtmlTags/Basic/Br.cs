namespace Connect.Razor.Blade.HtmlTags
{
    public class Br : Tag
    {
        public Br() : base("br", new TagOptions {Close = false}) { }
    }
}
