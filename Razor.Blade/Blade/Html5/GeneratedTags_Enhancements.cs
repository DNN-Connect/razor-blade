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


    public class MediaSource : Source
    {
        public MediaSource(string src, string type = null) : base()
        {
            Src(src);
            if (type != null) Type(type);
        }
    }
    public class PictureSource : Source
    {
        public PictureSource(string srcset, string media = null, string sizes = null, string type = null) : base()
        {
            Srcset(srcset);
            if (media != null) Media(media);
            if (sizes != null) Sizes(sizes);
            if (type != null) Type(type);
        }
    }


}
