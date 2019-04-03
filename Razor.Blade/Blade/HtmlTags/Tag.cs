using System.Linq;

namespace Connect.Razor.Blade.HtmlTags
{
    public partial class Tag
    {
        public Tag(string name = null, TagOptions options = null)
        {
            Name = name ?? "div";
            Options = options;
        }

        /// <summary>
        /// The tag name
        /// </summary>
        public string Name;

        public TagOptions Options;

        /// <summary>
        /// List of attributes of this tag
        /// </summary>
        public AttributeList Attributes { get; } = new AttributeList();

        public Tag Attr(string name, string value = null, AttributeOptions options = null)
        {
            var attrib = name?.IndexOf("=") == -1
                ? Attributes.FirstOrDefault(a => a.Name == name)
                : null;
            if(attrib != null)
                attrib.Value = attrib.Value += " " + value;
            else
                Attributes.Add(new AttributeBase(name, value, options));
            return this;
        }

        /// <summary>
        /// The contents of this tag
        /// </summary>
        public string Content = string.Empty;

        /// <summary>
        /// Optional ID, if null, will not be generated, otherwise will be added
        /// </summary>
        public Tag Id(string id) => Attr("id", id);

        /// <summary>
        /// Optional class names - if null, will not generate the class-attribute
        /// </summary>
        public Tag Classes(string value) => Attr("class", value);


        /// <summary>
        /// Gets the HTML encoded value.
        /// </summary>
        public override string ToString() 
            => TagBuilder.Tag(Name, attributes: Attributes, content: Content, options:Options);
        
    }
}
