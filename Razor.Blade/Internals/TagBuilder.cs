using System.Collections.Generic;
using System.Linq;
using Connect.Razor.Blade;

namespace Connect.Razor.Internals
{
    internal class TagBuilder
    {
        /// <summary>
        /// Generate an html tag as a string for further processing
        /// </summary>
        internal static string Tag(string name,
            string doNotRelyOnParameterOrder = EnforceNamedParameters.ProtectionKey,
            object attributes = null,
            string content = null,
            string id = null,
            string classes = null,
            TagOptions options = null)
        {
            // default case, no content or no options, get default options or create new
            if(content == null || options == null)
                options = TagOptions.UseOrCreate(options);
            else
            {
                // special case: we have content AND options, so we must ensure that it will close correctly
                options = TagOptions.CloneOrCreate(options);
                options.SelfClose = false;
                options.Close = true;
            }

            var open = Open(name, doNotRelyOnParameterOrder,
                attributes, id, classes, options: options);
            return $"{open}{content}"
                   + (options.Close && !options.SelfClose ? Close(name) : "");
        }


        internal static string Open(
            string name,
            string doNotRelyOnParameterOrder = EnforceNamedParameters.ProtectionKey,
            object attributes = null,
            string id = null,
            string classes = null,
            TagOptions options = null)
        {
            EnforceNamedParameters.VerifyProtectionKey(doNotRelyOnParameterOrder);

            if (string.IsNullOrWhiteSpace(name))
                return "";

            options = TagOptions.UseOrCreate(options);

            // attributes might be a string, then use that
            // or if it's a typed AttributeList, use the Manual property
            var attributeText = attributes as string
                ?? (attributes as AttributeList)?.Manual
                ?? "";

            // attributes might be a Dictionary/IEnumerable, then use that as our list
            var attributeList = attributes as IEnumerable<KeyValuePair<string, string>>
                ?? new Dictionary<string, string>();

            // optionally add common attributes as specified
            if (id != null || classes != null)
            {
                var newAttributes = new Dictionary<string, string>();
                if (id != null) newAttributes.Add("id", id);
                if (classes != null) newAttributes.Add("class", classes);
                attributeList.ToList().ForEach(pair => newAttributes.Add(pair.Key, pair.Value));
                attributeList = newAttributes;
            }

            // if we have a data-list of attributes, add to object
            if (attributeList.Any())
                attributeText = AttributeBuilder.Attributes(attributeList, options.Attribute)
                             + (!string.IsNullOrEmpty(attributeText) ? " " + attributeText : "");

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
