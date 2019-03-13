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

    }
}
