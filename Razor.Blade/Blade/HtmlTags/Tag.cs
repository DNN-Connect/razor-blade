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

        /// <summary>
        /// Tag serialization options, like what quotes to use
        /// If null, will use defaults
        /// </summary>
        public TagOptions Options;

        /// <summary>
        /// All attributes of this tag
        /// </summary>
        public AttributeList Attributes { get; } = new AttributeList();

        /// <summary>
        /// Quickly add an attribute
        /// it always returns the tag itself again, allowing chaining of multiple add-calls
        /// </summary>
        /// <param name="name">the attribute name, or a complete value like "name='value'"</param>
        /// <param name="value">optional value - if the attribute already exists, it will be appended</param>
        /// <param name="replace"></param>
        /// <param name="separator">attribute separator in case the value is appended</param>
        /// <returns></returns>
        public Tag Attr(string name, object value = null, bool replace = false, string separator = " ")
        {
            Attributes.Add(name, value, replace, separator);
            return this;
        }

        // Thoughts for content
        // Content = replace
        // Append = append
        // ClearContent


        /// <summary>
        /// The contents of this tag
        /// </summary>
        public string Content = string.Empty;

        /// <summary>
        /// ID - set multiple times always overwrites previous ID
        /// </summary>
        public Tag Id(string id) => Attr("id", id, replace:true);

        /// <summary>
        /// class attribute
        /// </summary>
        public Tag Class(string value) => Attr("class", value);

        /// <summary>
        /// style attribute. If called multiple times, will append styles.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Tag Style(string value) => Attr("style", value, separator:";");

        /// <summary>
        /// title attribute
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Tag Title(string value) => Attr("title", value);

        /// <summary>
        /// Add a data-... attribute
        /// </summary>
        /// <param name="key">the term behind data-, so "name" becomes "data-name"</param>
        /// <param name="value">string or object, objects will be json serialized</param>
        /// <returns></returns>
        public Tag Data(string key, object value) => Attr("data-" + key, value);

        /// <summary>
        /// Gets the HTML encoded value.
        /// </summary>
        public override string ToString() 
            => TagBuilder.Tag(Name, attributes: Attributes, content: Content, options:Options);
        
    }
}
