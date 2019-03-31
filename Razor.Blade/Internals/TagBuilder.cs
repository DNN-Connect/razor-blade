using System.Collections.Generic;
using System.Linq;
using Connect.Razor.Blade.Options;

namespace Connect.Razor.Internals
{
    internal class TagBuilder
    {
        /// <summary>
        /// Generate an html tag as a string for further processing
        /// </summary>
        internal static string Tag(string name,
            string doNotRelyOnParameterOrder = EnforceNamedParameters.ProtectionKey,
            string attributes = null,
            IEnumerable<KeyValuePair<string, string>> attributeList = null,
            string content = null,
            string id = null,
            string classes = null,
            Tag options = null)
        {
            options = Blade.Options.Tag.UseOrCreate(options);
            var open = Open(name, doNotRelyOnParameterOrder,
                attributes, attributeList, id, classes, options: options);
            return $"{open}{content}"
                   + (options.Close && !options.SelfClose ? Close(name) : "");
        }

        internal static string Open(
            string name,
            string doNotRelyOnParameterOrder = EnforceNamedParameters.ProtectionKey,
            string attributes = null,
            IEnumerable<KeyValuePair<string, string>> attributeList = null,
            string id = null,
            string classes = null,
            Tag options = null)
        {
            EnforceNamedParameters.VerifyProtectionKey(doNotRelyOnParameterOrder);

            if (string.IsNullOrWhiteSpace(name))
                return "";

            options = Blade.Options.Tag.UseOrCreate(options);
            attributes = attributes ?? "";

            // optionally add common attributes as specified
            if (id != null || classes != null)
            {
                var newAttributes = new Dictionary<string, string>();
                if (id != null) newAttributes.Add("id", id);
                if (classes != null) newAttributes.Add("class", classes);
                attributeList?.ToList().ForEach(pair => newAttributes.Add(pair.Key, pair.Value));
                attributeList = newAttributes;
            }

            // if we have a data-list of attributes, add to object
            if (attributeList != null)
                attributes = $"{AttributeBuilder.Attributes(attributeList, options.Attribute)}"
                             + (!string.IsNullOrEmpty(attributes) ? " " + attributes : "");

            // ensure attributes have space in front
            if (!string.IsNullOrEmpty(attributes) && attributes[0] != ' ')
                attributes = " " + attributes;

            var selfClose = options.Close && options.SelfClose ? "/" : "";

            return $"<{name}{attributes}{selfClose}>";
        }

        internal static string Close(string name) => $"</{name}>";
    }
}
