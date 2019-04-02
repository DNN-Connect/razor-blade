using System.Collections.Generic;
using System.Linq;

namespace Connect.Razor.Blade.Html
{
    internal class AttributeBuilder
    {
        /// <summary>
        /// Internal string-based commands to keep data simple till ready for output
        /// </summary>
        /// <returns></returns>
        internal static string Attribute(string name, string value, AttributeOptions options = null)
        {
            options = AttributeOptions.UseOrCreate(options);
            value = Internals.Html.Encode(value) ?? "";

            if (!options.EncodeQuotes)
            {
                var safeQuote = options.Quote == "'" ? "\"" : "'";
                value = value.Replace(Internals.Html.Encode(safeQuote), safeQuote);
            }

            return options.KeepEmpty || !string.IsNullOrEmpty(value)
                ? $"{name}={options.Quote}{value}{options.Quote}"
                : "";
        }

        /// <summary>
        /// Internal string-based commands to keep data simple till ready for output
        /// </summary>
        /// <returns></returns>
        internal static string Attribute(string name, object value, AttributeOptions options = null) 
            => Attribute(name, ValueStringOrSerialized(value), options);

        public static string Attributes(IEnumerable<KeyValuePair<string, string>> attributes,
            AttributeOptions options = null)
        {
            options = AttributeOptions.UseOrCreate(options);
            return string.Join(" ",
                attributes.Select(a => Attribute(a.Key, a.Value, options))
                    .Where(val => !string.IsNullOrEmpty(val))
            );
        }

        public static string Attributes(IEnumerable<KeyValuePair<string, object>> attributes,
            AttributeOptions options = null)
            => Attributes(attributes.ToDictionary(
                a => a.Key,
                a => ValueStringOrSerialized(a.Value)
            ), options);

        private static string ValueStringOrSerialized(object value)
            => value as string ?? Internals.Html.ToJsonOrErrorMessage(value);
    }
}
