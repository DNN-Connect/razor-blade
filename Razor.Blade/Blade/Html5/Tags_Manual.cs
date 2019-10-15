using Connect.Razor.Blade.Html5;

// ReSharper disable once CheckNamespace
namespace Connect.Razor.Blade
{
    public static partial class Tags
    {
        public static Comment Comment(string content = null) => new Comment(content);
    }
}
