namespace Connect.Razor.Blade.HtmlTags
{
    public class TagOptions
    {
        public const bool DefaultClose = true;
        public const bool DefaultSelfCloseIfNoContent = false;


        public bool Close { get; set; } = DefaultClose;
        public bool SelfClose { get; set; } = DefaultSelfCloseIfNoContent;

        private AttributeOptions _attribute;

        public AttributeOptions Attribute => _attribute ?? (_attribute = new AttributeOptions());

        public TagOptions(AttributeOptions attributeOptions = null)
        {
            _attribute = attributeOptions;
        }

        #region Cloning / Re-Using / Re-Generating options
        /// <summary>
        /// Check if options were already provided, or create new default options
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        internal static TagOptions UseOrCreate(TagOptions original) => original ?? new TagOptions();

        /// <summary>
        /// Clone the options for situations where the options must be changed
        /// but only in a copy
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        internal static TagOptions CloneOrCreate(TagOptions original) =>
            original != null
                ? new TagOptions(original.Attribute)
                {
                    Close = original.Close,
                    SelfClose = original.SelfClose
                }
                : new TagOptions();
        #endregion
    }
}
