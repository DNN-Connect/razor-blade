using System.Collections.Generic;
using System.Linq;
using Connect.Razor.Blade;
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
            object attributes = null,
            //IEnumerable<KeyValuePair<string, string>> attributeList = null,
            string content = null,
            string id = null,
            string classes = null,
            Tag options = null)
        {
            options = Blade.Options.Tag.UseOrCreate(options);
            var open = Open(name, doNotRelyOnParameterOrder,
                attributes, id, classes, options: options);
            return $"{open}{content}"
                   + (options.Close && !options.SelfClose ? Close(name) : "");
        }


        internal static string Open(
            string name,
            string doNotRelyOnParameterOrder = EnforceNamedParameters.ProtectionKey,
            object attributes = null,
            //string attributeText = null,
            string id = null,
            string classes = null,
            Tag options = null)
        {
            EnforceNamedParameters.VerifyProtectionKey(doNotRelyOnParameterOrder);

            if (string.IsNullOrWhiteSpace(name))
                return "";

            options = Blade.Options.Tag.UseOrCreate(options);

            // attributes might be a string, then use that
            var attributeText = attributes as string 
                                ?? "";

            // attributes might be a dictionary/ienumerable, then use that
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
                attributeText = $"{AttributeBuilder.Attributes(attributeList, options.Attribute)}"
                             + (!string.IsNullOrEmpty(attributeText) ? " " + attributeText : "");

            // if attributes is more than just a dictionary - then add manual keys...
            if (attributes is AttributeList attributeListObject && !string.IsNullOrEmpty(attributeListObject.Manual))
                attributeText += " " + attributeListObject.Manual;

            // ensure attributes have space in front
            if (!string.IsNullOrEmpty(attributeText) && attributeText[0] != ' ')
                attributeText = " " + attributeText;

            var selfClose = options.Close && options.SelfClose ? "/" : "";

            return $"<{name}{attributeText}{selfClose}>";
        }

        internal static string Close(string name) => $"</{name}>";
    }
}
