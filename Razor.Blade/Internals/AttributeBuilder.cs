using System.Collections.Generic;
using System.Linq;
using Connect.Razor.Blade;

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
        internal static string Attribute(string name, string value, AttributeOptions options = null)
        {
            options = AttributeOptions.UseOrCreate(options);
            value = Html.Encode(value) ?? "";

            if (!options.EncodeQuotes)
            {
                var safeQuote = options.Quote == "'" ? "\"" : "'";
                value = value.Replace(Html.Encode(safeQuote), safeQuote);
            }

            return options.KeepEmpty || !string.IsNullOrEmpty(value)
                ? $"{name}={options.Quote}{value}{options.Quote}"
                : "";
        }

        public static string Attributes(IEnumerable<KeyValuePair<string, string>> attributes,
            AttributeOptions options = null)
        {
            options = AttributeOptions.UseOrCreate(options);
            return string.Join(" ",
                attributes.Select(a => Attribute(a.Key, a.Value, options))
                    .Where(val => !string.IsNullOrEmpty(val))
            );

        }


    }
}
