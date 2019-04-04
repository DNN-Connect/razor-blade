namespace Connect.Razor.Blade.HtmlTags
{
    public partial class Tag
    {
        private Tag() { }

        public Tag(string name = null, TagOptions options = null)
        {
            Options = options;
            if (name?.Contains("<") ?? false)
                Override = name;
            else
                Name = name;
        }

        public Tag(string name, object content, TagOptions options = null)
            :this(name,options)
        {
            if (content != null)
                Wrap(content);
        }

        public static Tag Text(string text) 
            => new Tag {Override = text};

        /// <summary>
        /// The tag name
        /// </summary>
        public string Name;

        /// <summary>
        /// Tag serialization options, like what quotes to use
        /// If null, will use defaults
        /// </summary>
        public TagOptions Options;

        private TagOptions RealOptions => TagOptions.UseOrCreate(Options);

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

        public ChildTags Children => _children ?? (_children = new ChildTags());
        private ChildTags _children;

        /// <summary>
        /// Helper to ensure that both strings/tags can be passed around and added to list
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        internal static Tag EnsureTag(object child)
        {
            switch (child)
            {
                case string text:
                    return Text(text);
                case Tag tag:
                    return tag;
                default:
                    return new Tag();
            }
        }

        public Tag Add(object child)
        {
            Children.Add(child);
            return this;
        }

        /// <summary>
        /// The contents of this tag
        /// </summary>
        public string Content
        {
            get => Children.Build(RealOptions);
            set => Wrap(value);
        }

        /// <summary>
        /// A full override of the internal mechanisms of this tag
        /// It's usually used to create very special tags like comments
        /// if it is set, all other mechanisms will not do anything
        /// so no attributes, no content etc.
        /// </summary>
        /// <remarks>Must be null to be deactivated</remarks>
        public string Override;

        public Tag Wrap(object content)
        {
            Children.Replace(content);
            return this;
        }

        /// <summary>
        /// ID - set multiple times always overwrites previous ID
        /// </summary>
        public Tag Id(string id) => Attr("id", id, replace: true);

        /// <summary>
        /// class attribute
        /// </summary>
        public Tag Class(string value) => Attr("class", value);

        /// <summary>
        /// style attribute. If called multiple times, will append styles.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Tag Style(string value) => Attr("style", value, separator: ";");

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
        public override string ToString() => ToString(RealOptions);

        internal string ToString(TagOptions options)
            => Override
               ?? TagBuilder.Tag(Name, Attributes, Content, options);

    }
}
