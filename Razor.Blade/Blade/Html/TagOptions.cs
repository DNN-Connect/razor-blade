namespace Connect.Razor.Blade.Html
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

        internal static TagOptions UseOrCreate(TagOptions original) => original ?? new TagOptions();

        internal static TagOptions CloneOrCreate(TagOptions original) =>
            original != null
                ? new TagOptions(original.Attribute)
                {
                    Close = original.Close,
                    SelfClose = original.SelfClose
                }
                : new TagOptions();
    }
}
