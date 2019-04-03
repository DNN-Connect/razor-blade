using System.Collections.Generic;
using System.Linq;

namespace Connect.Razor.Blade.HtmlTags
{
    public class AttributeListBase: List<AttributeBase>
    {
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

        public AttributeOptions Options;

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
