using System.Collections.Generic;
using System.Linq;

namespace Connect.Razor.Blade.Html
{
    public class AttributeBase
    {
        /// <summary>
        /// Create an attribute, which can then generated into a name='value' output
        /// </summary>
        /// <param name="name">The attribute name, can also be a prepared attribute. So you can pass in "id" or "id='27'"</param>
        /// <param name="value">The value, if the initial name was really only a name. If it's an object, it will be json serialized</param>
        /// <param name="options">Options how the attribute will be generated</param>
        public AttributeBase(string name, object value = null, AttributeOptions options = null)
        {
            if (name?.IndexOf("=") > 0)
                Prepared = name;
            else
            {
                Name = name;
                Value = value;
            }

            Options = options;
        }

        /// <summary>
        /// Attribute name
        /// is null, if a prepared attribute was added
        /// </summary>
        public string Name;

        /// <summary>
        /// Attribute value
        /// can be null if a prepared attribute was added, or no value specified
        /// </summary>
        public object Value;
        public AttributeOptions Options;

        /// <summary>
        /// An sequence already prepared, so no more building would be necessary
        /// </summary>
        internal string Prepared;


        /// <summary>
        /// Gets the HTML encoded value.
        /// </summary>
        public string Html => Prepared ?? Build(Name, Value, Options);

        public override string ToString() => Html ?? string.Empty;


        #region Build single attribute

        /// <summary>
        /// Internal string-based commands to keep data simple till ready for output
        /// </summary>
        /// <returns></returns>
        private static string Build(string name, string value, AttributeOptions options = null)
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
        private static string Build(string name, object value, AttributeOptions options = null) 
            => Build(name, ValueStringOrSerialized(value), options);

        #endregion

        //#region build attribute lists

        //internal static string Attributes(IEnumerable<KeyValuePair<string, string>> attributes,
        //    AttributeOptions options = null)
        //{
        //    options = AttributeOptions.UseOrCreate(options);
        //    return string.Join(" ",
        //        attributes.Select(a => Build(a.Key, a.Value, options))
        //            .Where(val => !string.IsNullOrEmpty(val))
        //    );
        //}

        //internal static string Attributes(IEnumerable<KeyValuePair<string, object>> attributes,
        //    AttributeOptions options = null)
        //    => Attributes(attributes.ToDictionary(
        //        a => a.Key,
        //        a => ValueStringOrSerialized(a.Value)
        //    ), options);

        //#endregion

        /// <summary>
        /// Will either return the string, empty-string if null, or json-encoded object
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string ValueStringOrSerialized(object value)
            => value as string 
               ?? (value == null ? "" : Internals.Html.ToJsonOrErrorMessage(value));
    }
}
