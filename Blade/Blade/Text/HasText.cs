using Connect.Razor.Internals;

namespace Connect.Razor.Blade
{
    public static partial class Text
    {
        /// <summary>
        /// Will check if a variable is a string, and it actually has contents (not null, empty or just spaces)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="handleHtmlWhitespaces">if true (default) will treat html-whitespace as a space</param>
        /// <remarks>will try to cast the object as string first, so it will be null if not a real string</remarks>
        /// <returns>true, if it's a string with real content</returns>
        public static bool Has(object value, bool handleHtmlWhitespaces = true)
        {
            return Has(value as string, handleHtmlWhitespaces);
        }

        /// <summary>
        /// Will check if a string actually has contents (not null, empty or just spaces)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="handleHtmlWhitespaces">if true (default) will treat html-whitespace as a space</param>
        /// <returns>true, if the string has real contents</returns>
        public static bool Has(string value, bool handleHtmlWhitespaces = true)
        {
            // do quick-check, as this will usually be all it needs
            if(string.IsNullOrWhiteSpace(value))
                return false;

            // if it got here and we don't want to re-check for html-whitespace, then we do have text
            if (!handleHtmlWhitespaces)
                return true;

            // convert html-whitespace to normal spaces for final check
            foreach (var whitespace in Defaults.HtmlNonBreakingSpaces)
                value = value.Replace(whitespace, " ");

            return !string.IsNullOrWhiteSpace(value);
        }

    }
}
