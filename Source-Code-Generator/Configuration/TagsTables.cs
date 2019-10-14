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
            MakeList(SimpleTags)
                .Concat(SpecialConfigs)
                .ToList();


        // source https://www.w3schools.com/tags/ref_byfunc.asp
        public static string[] SimpleTags
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
            new TagCodeGenerator("col", "colgroup")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("span", "int"),
                }
            },

            new TagCodeGenerator("colgroup", "table")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("span", "int"),
                }
            },

            new TagCodeGenerator("th", "table")
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

            new TagCodeGenerator("td", "th, tr")
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
