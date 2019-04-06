namespace Connect.Razor.Blade.HtmlTags
{
    public partial class Tag
    {
        /// <summary>
        /// ID - set multiple times always overwrites previous ID
        /// </summary>
        public Tag Id(string id) => Attr("id", id, null);

        /// <summary>
        /// class attribute
        /// </summary>
        public Tag Class(string value) => Attr("class", value, " ");

        /// <summary>
        /// style attribute. If called multiple times, will append styles.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Tag Style(string value) => Attr("style", value, separator: ";");

        /// <summary>
        /// title attribute
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Tag Title(string value) => Attr("title", value, null);

        /// <summary>
        /// Add a data-... attribute
        /// </summary>
        /// <param name="name">the term behind data-, so "name" becomes "data-name"</param>
        /// <param name="value">string or object, objects will be json serialized</param>
        /// <returns></returns>
        public Tag Data(string name, object value = null) => Attr("data-" + name, value, null);

    }
}
