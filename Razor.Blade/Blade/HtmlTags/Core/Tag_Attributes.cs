namespace Connect.Razor.Blade.HtmlTags
{
    public partial class Tag
    {
        /// <summary>
        /// All attributes of this tag
        /// </summary>
        public AttributeList TagAttributes { get; } = new AttributeList();

        /// <summary>
        /// Quickly add an attribute
        /// it always returns the tag itself again, allowing chaining of multiple add-calls
        /// </summary>
        /// <param name="name">the attribute name, or a complete value like "name='value'"</param>
        /// <param name="value">optional value - if the attribute already exists, it will be appended</param>
        /// <param name="separator">attribute separator in case the value is appended</param>
        /// <returns></returns>
        public Tag Attr(string name, object value = null, string separator = "")
        {
            TagAttributes.Add(name, value, separator);
            return this;
        }
        
        internal TagType Attr<TagType>(string name, object value = null, string separator = "")
        {
            TagAttributes.Add(name, value, separator);
            return (TagType)(object)this;
        }

    }
}
