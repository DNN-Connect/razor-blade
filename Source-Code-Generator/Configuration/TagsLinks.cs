using System.Collections.Generic;
using SourceCodeGenerator.Parts;

namespace SourceCodeGenerator.Configuration
{
    internal class TagsLinks : TagsBase
    {
        /// <inheritdoc />
        public override List<TagCodeGenerator> List => SpecialConfigs;

        // ReSharper disable StringLiteralTypo
        public static List<TagCodeGenerator> SpecialConfigs = new List<TagCodeGenerator>
        {
            new TagCodeGenerator("a")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("download"),
                    new AttributeCodeGen("href"),
                    new AttributeCodeGen("hreflang"),
                    new AttributeCodeGen("media"),
                    new AttributeCodeGen("ping"),
                    new AttributeCodeGen("rel"),
                    new AttributeCodeGen("target"),
                    new AttributeCodeGen("type"),
                }
            },
            // see https://www.w3schools.com/tags/tag_link.asp
            new TagCodeGenerator("link")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("crossorigin"),
                    new AttributeCodeGen("href"),
                    new AttributeCodeGen("hreflang"),

                    new AttributeCodeGen("media"),
                    new AttributeCodeGen("rel"),
                    // sizes not added, as only relevant for rel-icon
                    new AttributeCodeGen("type"),
                }
            },
            // see https://www.w3schools.com/tags/tag_nav.asp - no special properties
            new TagCodeGenerator("nav")



        };
    }
}
