using System.Collections.Generic;
using System.Linq;
using SourceCodeGenerator.Parts;

namespace SourceCodeGenerator.Configuration
{
    internal class TagsSimple: TagListBase
    {
        // source: https://www.w3schools.com/tags/ref_byfunc.asp
        public static string[] BasicTags
            = { "div", "h1", "h2", "h3", "h4", "h5", "h6", "p", "span" };

        public static string[] NonClosingTags
            = { "br", "hr", "wbr" };

        private static readonly string[] ListTags = {"ul", "ol", "li", "dl", "dt", "dd"};


        /// <inheritdoc />
        public override List<TagCodeGenerator> List =>
            MakeList(NonClosingTags, true)
                .Concat(MakeList(BasicTags))
                .Concat(MakeList(ListTags))
                .ToList();
    }
}
