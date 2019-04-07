namespace Connect.Razor.Blade.HtmlTags
{
    internal class TagBuilder
    {
        /// <summary>
        /// Generate an html tag as a string for further processing
        /// </summary>
        internal static string Tag(string name,
            AttributeList attributes,
            string content,
            TagOptions options)
        {
            // default case, no content or no options, get default options or create new
            if (string.IsNullOrEmpty(content) || options == null)
                options = TagOptions.UseOrCreate(options);
            else
            {
                // special case: we have content AND options, so we must ensure that it will close correctly
                options = TagOptions.CloneOrCreate(options);
                options.SelfClose = false;
                options.Close = true;
            }

            var open = Open(name, attributes, options);
            return $"{open}{content}"
                   + (options.Close && !options.SelfClose ? Close(name) : "");
        }


        internal static string Open(
            string name,
            AttributeList attributes,
            TagOptions options)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "";

            options = TagOptions.UseOrCreate(options);

            // if we have a data-list of attributes, add to object
            if (attributes.Options == null)
                attributes.Options = options.Attribute;
            var attributeText = attributes?.ToString() ?? "";

            // ensure attributes have space in front
            if (!string.IsNullOrEmpty(attributeText) && attributeText[0] != ' ')
                attributeText = " " + attributeText;

            var selfClose = options.Close && options.SelfClose ? "/" : "";

            return $"<{name}{attributeText}{selfClose}>";
        }

        internal static string Close(string name)
            => string.IsNullOrWhiteSpace(name)
                ? ""
                : $"</{name}>";
    }
}
