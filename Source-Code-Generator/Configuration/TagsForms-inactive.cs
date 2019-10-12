using System.Collections.Generic;
using SourceCodeGenerator.Parts;

namespace SourceCodeGenerator.Configuration
{
    // 2019-10-12 as of now, forms not implemented or supported
    // will take a few hours to implement and really test all variations, so lower priority
    internal class TagsForms : TagsBase
    {
        /// <inheritdoc />
        public override List<TagCodeGenerator> List => SpecialConfigs;

        // ReSharper disable StringLiteralTypo
        public static List<TagCodeGenerator> SpecialConfigs = new List<TagCodeGenerator>
        {
            // Form not implemented https://www.w3schools.com/tags/tag_form.asp

            // https://www.w3schools.com/tags/tag_input.asp

            new TagCodeGenerator("input")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("accept"),
                    new AttributeCodeGen("alt"),
                    new AttributeCodeGen("autocomplete"),

                    new AttributeCodeGen("autofocus", type: "boolean"), // todo: special, because it's on/off only, no value expected
                    new AttributeCodeGen("ping"),
                    new AttributeCodeGen("rel"),
                    new AttributeCodeGen("target"),
                    new AttributeCodeGen("type"),
                },
                Standalone = true
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
                },
                Standalone = true
            },
            // see https://www.w3schools.com/tags/tag_nav.asp - no special properties
            new TagCodeGenerator("nav")



        };
    }
}
