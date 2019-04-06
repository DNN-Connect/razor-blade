namespace Connect.Razor.Blade.HtmlTags
{
    public partial class Tag
    {
        #region Constructors
        private Tag() { }

        public Tag(string name = null, TagOptions options = null)
        {
            TagOptions = options;
            if (name?.Contains("<") ?? false)
                TagOverride = name;
            else
                TagName = name;
        }

        public Tag(string name, object content, TagOptions options = null)
            :this(name,options)
        {
            if (content != null)
                TagChildren.Replace(content);
        }
        #endregion

        internal static Tag Text(string text) 
            => new Tag {TagOverride = text};

        /// <summary>
        /// The tag name
        /// </summary>
        public string TagName;

        /// <summary>
        /// Tag serialization options, like what quotes to use
        /// If null, will use defaults
        /// </summary>
        public TagOptions TagOptions;

        private TagOptions RealOptions => TagOptions.UseOrCreate(TagOptions);

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

        /// <summary>
        /// Gets the HTML encoded value.
        /// </summary>
        public override string ToString() => ToString(RealOptions);

        internal string ToString(TagOptions options)
            => TagOverride
               ?? TagBuilder.Tag(TagName, TagAttributes, TagContents, options);

    }
}
