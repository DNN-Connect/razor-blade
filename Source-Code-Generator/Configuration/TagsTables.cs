using System.Collections.Generic;
using System.Linq;
using SourceCodeGenerator.Parts;

namespace SourceCodeGenerator.Configuration
{
    internal class TagsTables : TagsBase
    {
        internal override string GroupName => "Tables";

        /// <inheritdoc />
        public override List<TagCodeGenerator> List => 
            MakeList(FormattingTags)
                .Concat(SpecialConfigs)
                .ToList();


        // source https://www.w3schools.com/tags/ref_byfunc.asp
        public static string[] FormattingTags
            =
            {
                "table", 
                "caption",
                "tr",
                "thead",
                "tbody",
                "tfoot",

            };

        public static List<TagCodeGenerator> SpecialConfigs = new List<TagCodeGenerator>
        {
            new TagCodeGenerator("col")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("span", "int"),
                }
            },

            new TagCodeGenerator("colgroup")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("span", "int"),
                }
            },

            new TagCodeGenerator("th")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("abbr"),
                    new AttributeCodeGen("colspan", "int"),
                    new AttributeCodeGen("headers"),
                    new AttributeCodeGen("rowspan", "int"),
                    new AttributeCodeGen("scope"),
                    new AttributeCodeGen("sorted"),
                }
            },

            new TagCodeGenerator("td")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("colspan", "int"),
                    new AttributeCodeGen("headers"),
                    new AttributeCodeGen("rowspan", "int"),
                }
            },

        };
    }
}
