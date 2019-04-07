using Connect.Razor.Blade.HtmlTags;

namespace Connect.Razor.Blade
{
    public partial class Tag
    {
        /// <summary>
        /// All attributes of this tag
        /// </summary>
        public AttributeList TagAttributes { get; } = new AttributeList();
    }
}
