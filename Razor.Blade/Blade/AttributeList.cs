using System.Collections.Generic;
using Connect.Razor.Blade.Html;
using Connect.Razor.Internals;

namespace Connect.Razor.Blade
{
    public class AttributeList: Dictionary<string, string>
    {
        public string Manual;

        /// <inheritdoc />
        public override string ToString() =>
            AttributeBuilder.Attributes(this) 
            + (string.IsNullOrEmpty(Manual) ? "" : " " + Manual);
    }
}
