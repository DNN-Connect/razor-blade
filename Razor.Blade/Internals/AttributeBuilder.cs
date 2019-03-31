using System.Collections.Generic;
using System.Linq;
using Attribute = Connect.Razor.Blade.Options.Attribute;

namespace Connect.Razor.Internals
{
    internal class AttributeBuilder
    {
        /// <summary>
        /// Internal string-based commands to keep data simple till ready for output
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        internal static string Attribute(string name, string value, Attribute options = null)
        {
            options = Blade.Options.Attribute.UseOrCreate(options);
            value = Html.EncodeString(value) ?? "";
            if (!options.EncodeQuotes)
                value = value.Replace(options.Quote, Html.DecodeString(options.Quote));
            return options.KeepEmpty || !string.IsNullOrEmpty(value)
                ? $"{name}={options.Quote}{value}{options.Quote}"
                : "";
        }

        public static string Attributes(IEnumerable<KeyValuePair<string, string>> attributes,
            Attribute options = null)
        {
            options = Blade.Options.Attribute.UseOrCreate(options);
            return string.Join(" ",
                attributes.Select(a => Attribute(a.Key, a.Value, options))
                    .Where(val => !string.IsNullOrEmpty(val))
            );

        }


    }
}
