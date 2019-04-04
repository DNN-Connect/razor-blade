namespace Connect.Razor.Blade.HtmlTags
{
    public class Meta : Tag
    {
        public Meta(): base("meta", new TagOptions { SelfClose = true }) { }

        public Meta(string name, string content) : this()
        {
            Attr("name", name);
            Attr("content", content);
        }
    }

    public class MetaOg : Meta
    {
        public MetaOg(string property, string content)
        {
            Attr("property", property);
            Attr("content", content);
        }
    }
    
}
