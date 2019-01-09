using Connect.Razor.V1.Internals;

namespace Connect.Razor.V1
{
    public static partial class Blade
    {
        /// <summary>
        /// Cut off a text at the best possible place with a max-length. 
        /// This will count html-entities like &amp; &nbsp; or umlaute as 1 character, 
        /// and will try to cut off between words if possible. 
        /// </summary>
        /// <param name="value">String to cut off. Can contain umlauts and html-entities, but should not contain html-tags as there are not treated properly.</param>
        /// <param name="length">length to cut off at</param>
        /// <returns></returns>
        public static string CutText(string value, int length)
        {
            return Truncator.SafeTruncate(value, length);
        }

        public static string Ellipsis(string value, int length, string trailer = null)
        {
            var truncated = Truncator.SafeTruncate(value, length);
            var addExtension = truncated != value;
            var extension = addExtension ? (trailer ?? Defaults.HtmlEllipsisCharacter) : "";
            return truncated + extension;
            //return value.Length > length
            //    ? value.Substring(0, length) + (trailer ?? Defaults.HtmlEllipsisCharacter)
            //    : value;
        }



    }
}
