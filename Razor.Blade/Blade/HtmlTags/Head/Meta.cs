namespace Connect.Razor.Blade.HtmlTags
{
    public abstract class MetaBase : Tag
    {
        protected MetaBase(): base("meta", new TagOptions { SelfClose = true }) { }
    }

    public class Meta : MetaBase
    {
        public Meta(string name = null, string content = null)
        {
            if(name != null) Name(name);
            if (content != null) Content(content);
        }

        public Meta Name(string value) => this.Attr("name", value, null);
        public Meta Content(string value) => this.Attr("content", value, null);
    }

    public class MetaOg : MetaBase
    {
        public MetaOg(string property = null, string content = null)
        {
            if(property != null) Property(property);
            if(content != null) Content(content);
        }
        public MetaOg Property(string value) => this.Attr("property", value, null);
        public MetaOg Content(string value) => this.Attr("content", value, null);
   }
    
}
