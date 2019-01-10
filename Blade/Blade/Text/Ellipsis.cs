using Connect.Razor.Internals;

namespace Connect.Razor.Blade
{
    public static partial class Text
    {
        /// <summary>
        /// Cut off a text at the best possible place with a max-length. 
        /// This will count html-entities like &amp; &nbsp; or umlauts as 1 character, 
        /// and will try to cut off between words if possible. 
        /// </summary>
        /// <param name="value">String to cut off. Can contain umlauts and html-entities, but should not contain html-tags as there are not treated properly.</param>
        /// <param name="length">length to cut off at</param>
        /// <returns></returns>
        public static string Crop(string value, int length)
        {
            return Truncator.SafeTruncate(value, length);
        }

        /// <summary>
        /// Crop a text if too long, add in that case, also add an ellipsis or a custom suffix
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length"></param>
        /// <param name="suffix"></param>
        /// <remarks>If you don't need the suffix, use CropText(...) instead</remarks>
        /// <returns></returns>
        public static string Ellipsis(string value, int length, string suffix = null)
        {
            var truncated = Truncator.SafeTruncate(value, length);
            var addExtension = truncated != value;
            var extension = addExtension ? (suffix ?? Defaults.HtmlEllipsisCharacter) : "";
            return truncated + extension;
        }



    }
}
