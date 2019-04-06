namespace Connect.Razor.Blade.HtmlTags
{
    public class AttributeOptions
    {
        public const bool DefaultEncodeQuotes = false;
        public const bool DefaultKeepEmptyAttributes = true;
        public const string DefaultQuote = "'";
        public const bool DefaultValueIfNull = true;

        /// <summary>
        /// What character is used for wrapping attribute values
        /// </summary>
        public string Quote { get; set; } = DefaultQuote;

        /// <summary>
        /// Encode quotes or apostrophes in attributes which clearly don't need encoding
        /// </summary>
        public bool EncodeQuotes { get; set; } = DefaultEncodeQuotes;

        /// <summary>
        /// Place empty attributes on the tag anyhow
        /// </summary>
        public bool KeepEmpty { get; set; } = DefaultKeepEmptyAttributes;

        public bool DropValueIfNull { get; set; } = DefaultValueIfNull;

        internal static AttributeOptions UseOrCreate(AttributeOptions original) => original ?? new AttributeOptions();

    }
}
