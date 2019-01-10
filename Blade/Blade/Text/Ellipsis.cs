using Connect.Razor.Internals;

namespace Connect.Razor.Blade
{
    public static partial class Text
    {

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
