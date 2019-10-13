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
        public Img(string src, int width = -1, int height = -1) : this()
        {
            Src(src);
            if (height > -1) Height(height);
            if (width > -1) Width(width);
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

    // ReSharper disable once InconsistentNaming
    public partial class Iframe
    {
        public Iframe(string src, int width = -1, int height = -1) : this()
        {
            Src(src);
            if (height > -1) Height(height);
            if (width > -1) Width(width);
        }
    }

    public partial class Source
    {
        // note: we're not adding this constructor
        // because a similar constructor with srcSet and media (string/string)
        // would be needed for image tags, so there is no clear way to distinct them
        //public Source(string src, string type = null): this()
        //{
        //    Src(src);
        //    if (type != null) Type(type);
        //}
    }

}
