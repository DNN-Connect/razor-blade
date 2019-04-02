namespace Connect.Razor.Blade.Html
{
    public class AttributeOptions
    {
        public const bool DefaultEncodeQuotes = false;
        public const bool DefaultKeepEmptyAttributes = true;
        public const string DefaultQuote = "'";

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

        internal static AttributeOptions UseOrCreate(AttributeOptions original) => original ?? new AttributeOptions();

    }
}
