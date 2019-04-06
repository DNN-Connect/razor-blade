namespace Connect.Razor.Blade.HtmlTags
{
    public static class TagExtensions
    {
        /// <summary>
        /// Helper to easily build typed attributes on objects inheriting from Tag
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tag"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static T FluidAttr<T>(this T tag, string name, object value = null, string separator = "")
            where T: Tag
        {
            // ReSharper disable once MustUseReturnValue
            tag.Attr(name, value, separator);
            return tag;
        }


        /// <summary>
        /// ID - set multiple times always overwrites previous ID
        /// </summary>
        public static T Id<T>(this T tag, string id) where T: Tag
            => tag.FluidAttr("id", id, null);

        /// <summary>
        /// class attribute
        /// </summary>
        public static T Class<T>(this T tag, string value) where T: Tag
            => tag.FluidAttr("class", value, " ");

        /// <summary>
        /// style attribute. If called multiple times, will append styles.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T Style<T>(this T tag, string value) where T: Tag
            => tag.FluidAttr("style", value, separator: ";");

        /// <summary>
        /// title attribute
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T Title<T>(this T tag, string value) where T: Tag
            => tag.FluidAttr("title", value, null);

        /// <summary>
        /// Add a data-... attribute
        /// </summary>
        /// <param name="name">the term behind data-, so "name" becomes "data-name"</param>
        /// <param name="value">string or object, objects will be json serialized</param>
        /// <returns></returns>
        public static T Data<T>(this T tag, string name, object value = null) where T: Tag
            => tag.FluidAttr("data-" + name, value, null);
    }
}
