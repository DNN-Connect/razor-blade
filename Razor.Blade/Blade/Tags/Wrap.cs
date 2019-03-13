namespace Connect.Razor.Blade
{
    public partial class Tags
    {
        /// <summary>
        /// internal test wrap-tag, not ready for use, so still marked internal
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="content"></param>
        /// <param name="id"></param>
        /// <param name="cls"></param>
        /// <param name="attr"></param>
        /// <returns></returns>
        internal static string Wrap(string tag, string content, string id = null, string cls = null, string attr = null)
        {
            if (attr == null) attr = "";

            if (cls != null)
                attr = $"class=\"{cls}\" " + attr;
            if (id != null)
                attr = $"id=\"{id}\" " + attr;

            if (!string.IsNullOrWhiteSpace(attr)) attr = " " + attr;
            return $"<{tag}{attr}>{content}</{tag}>";
        }
    }
}
