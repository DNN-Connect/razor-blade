namespace Connect.Razor.Blade.Options
{
    public class Tag
    {
        public const bool DefaultClose = true;
        public const bool DefaultSelfCloseIfNoContent = false;

        public bool Close { get; set; } = DefaultClose;
        public bool SelfClose { get; set; } = DefaultSelfCloseIfNoContent;

        private Attribute _attribute;

        public Attribute Attribute => _attribute ?? (_attribute = new Attribute());

        public Tag(Attribute attributeOptions = null)
        {
            _attribute = attributeOptions;
        }

        internal static Tag UseOrCreate(Tag original) => original ?? new Tag();
    }
}
