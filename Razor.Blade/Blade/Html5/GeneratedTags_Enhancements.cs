using Connect.Razor.Blade.HtmlTags;

namespace Connect.Razor.Blade.Html5
{
    public partial class Abbr
    {
        public Abbr(object content, string title) : this(content)
        {
            this.Title(title);
        }
        
    }

    public partial class Bdo
    {
        public Bdo(object content, string direction) : this(content)
        {
            Dir(direction);
        }

    }

    public partial class Img
    {
        public Img(string src) : this()
        {
            Src(src);
        }
    }

    public partial class A
    {
        public A(string href, string target = null) : this()
        {
            Href(href);
            if (target != null) Target(target);
        }
    }

}
