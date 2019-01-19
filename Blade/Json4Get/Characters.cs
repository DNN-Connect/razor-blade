namespace Connect.Razor.Json4Get
{
    /// <summary>
    /// Constants / characters using in conversion of json4get
    /// </summary>
    public static class Characters
    {
        /// <summary>
        /// Quotes start a key or a value in the original JSON
        /// </summary>
        public const char QuoteOriginal = '"';

        /// <summary>
        /// Replacement for the quotes, which is url-compatible
        /// </summary>
        public const char QuoteEncoded = '\'';

        /// <summary>
        /// These characters are special when not inside a json key or value, so "outside"
        /// </summary>
        /// <remarks>
        /// Important, the quote must always be first and the { second, as these will be counted as "open" cases
        /// </remarks>
        public static char[] Specials = { '"', '{', '}' };

        /// <summary>
        /// Replacements in case a special character was detected
        /// </summary>
        public static char[] Replacements = { '\'', '(', ')' };

        public static int[] OpenCounters = { 1, 1, -1 };

        /// <summary>
        /// Additional escape prefix to add to a character when we want to escape it
        /// </summary>
        public const char EscapePrefix = '\\';

        /// <summary>
        /// Any JSON can start as an object, array, 0-9, quote, null, true, false
        /// see also https://www.w3schools.com/js/js_json_datatypes.asp
        /// So the first character would be any of these incl. n, t, f
        /// </summary>
        public const string JsonStartMarkers = "{[\"0123456789ntf";

        public const string Json4GetStartMarkers = "(['0123456789ntf";
    }
}
