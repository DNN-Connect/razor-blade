using System.Collections.Generic;
using System.Linq;
using SourceCodeGenerator.Parts;

namespace SourceCodeGenerator.Configuration
{
    internal class TagsStylesAndSemantics : TagsBase
    {
        internal override string GroupName => "Semantics";

        /// <inheritdoc />
        public override List<TagCodeGenerator> List => 
            MakeList(SimpleTags)
                .Concat(SpecialConfigs)
                .ToList();


        // source https://www.w3schools.com/tags/ref_byfunc.asp
        public static string[] SimpleTags
            =
            {
                "div", 
                "span",
                "header",
                "footer",
                "main",
                "section",
                "article",
                "aside",
                "summary",
            };

        public static List<TagCodeGenerator> SpecialConfigs = new List<TagCodeGenerator>
        {
            new TagCodeGenerator("style")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("media"),
                    new AttributeCodeGen("type"),
                }
            },

            new TagCodeGenerator("details")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("open"),
                }
            },

            new TagCodeGenerator("dialog")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("open"),
                }
            },

            new TagCodeGenerator("data")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("open"),
                }
            },

        };
    }
}
