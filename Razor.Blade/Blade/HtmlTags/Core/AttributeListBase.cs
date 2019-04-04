using System;
using System.Collections.Generic;
using System.Linq;

namespace Connect.Razor.Blade.HtmlTags
{
    public class AttributeListBase: List<AttributeBase>
    {
        #region constructors
        public AttributeListBase(AttributeOptions options = null)
        {
            Options = options;
        }

        public AttributeListBase(IEnumerable<KeyValuePair<string, string>> attributes, AttributeOptions options = null): this(options)
        {
            if (attributes == null) return;
            foreach (var pair in attributes)
                Add(new AttributeBase(pair.Key, pair.Value));
        }

        public AttributeListBase(IEnumerable<KeyValuePair<string, object>> attributes, AttributeOptions options = null): this(options)
        {
            if (attributes == null) return;
            foreach (var pair in attributes)
                Add(new AttributeBase(pair.Key, pair.Value));
        }

        #endregion

        /// <summary>
        /// Serialization options to use for all attributes,
        /// unless an attribute has own options
        /// </summary>
        public AttributeOptions Options;

        public void Add(string name, object value = null, bool replace = false, string separator = " ")
        {
            // bad entry, skip
            if (string.IsNullOrEmpty(name)) return;

            // pre-built entry, use that
            if (name.Contains("="))
            {
                Add(new AttributeBase(name));
                return;
            }

            // check if it has already been added
            // ignore case, as attributes are not case-sensitive
            var attrib = this.FirstOrDefault(a => string.Equals(a.Name, name, StringComparison.InvariantCultureIgnoreCase));

            // if found, try to remove or append
            if (attrib == null)
                Add(new AttributeBase(name, value));
            else
                ReplaceOrAppendValue(attrib, value, replace, separator);
        }

        private static void ReplaceOrAppendValue(AttributeBase attrib, object value, bool replace, string separator)
        {
            var maybeStr = attrib.Value as string;
            // check if we can actually append
            // this requires both values to be strings
            if (!replace)
                replace = string.IsNullOrEmpty(maybeStr)
                          || string.IsNullOrEmpty(value as string);

            attrib.Value = replace
                ? value
                : maybeStr + separator + value;
        }


        /// <summary>
        /// Gets the HTML safe string
        /// </summary>
        public override string ToString() => Build() ?? string.Empty;


        private string Build()
        {
            var options = AttributeOptions.UseOrCreate(Options);
            return string.Join(" ",
                this.Select(a =>
                    {
                        if (a.Options == null) a.Options = options;
                        return a.ToString();
                    })
                    .Where(val => !string.IsNullOrEmpty(val))
            );
        }
    }
}
