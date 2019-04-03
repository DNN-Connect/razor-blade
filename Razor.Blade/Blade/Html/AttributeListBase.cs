using System.Collections.Generic;
using System.Linq;

namespace Connect.Razor.Blade.Html
{
    public class AttributeListBase: Dictionary<string, object>
    {
        public AttributeListBase(AttributeOptions options = null)
        {
            Options = options;
        }

        public AttributeListBase(IEnumerable<KeyValuePair<string, string>> attributes, AttributeOptions options = null): this(options)
        {
            if (attributes == null) return;
            foreach (var pair in attributes)
                Add(pair.Key, pair.Value);
        }

        public AttributeListBase(IEnumerable<KeyValuePair<string, object>> attributes, AttributeOptions options = null): this(options)
        {
            if (attributes == null) return;
            foreach (var pair in attributes)
                Add(pair.Key, pair.Value);
        }

        public string Manual;
        public AttributeOptions Options;

        /// <summary>
        /// Gets the HTML encoded value.
        /// </summary>
        public string Html =>
            Attributes(this, Options) 
            + (string.IsNullOrEmpty(Manual) ? "" : " " + Manual);



        public override string ToString() => Html ?? string.Empty;


        #region build attribute lists

        internal static string Attributes(IEnumerable<KeyValuePair<string, string>> attributes,
            AttributeOptions options = null)
        {
            options = AttributeOptions.UseOrCreate(options);
            return string.Join(" ",
                attributes.Select(a => new AttributeBase(a.Key, a.Value, options).ToString())
                    .Where(val => !string.IsNullOrEmpty(val))
            );
        }

        internal static string Attributes(IEnumerable<KeyValuePair<string, object>> attributes,
            AttributeOptions options = null)
        {
            return string.Join(" ",
                attributes.Select(a => new AttributeBase(a.Key, a.Value, options).ToString())
                    .Where(val => !string.IsNullOrEmpty(val))
            );
        }

        #endregion
    }
}
