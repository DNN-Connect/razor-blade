using System.Collections.Generic;
using SourceCodeGenerator.Parts;

namespace SourceCodeGenerator.Configuration
{
    internal class TagsImages : TagsBase
    {
        internal override string GroupName => "Images";

        /// <inheritdoc />
        public override List<TagCodeGenerator> List => SpecialConfigs;

        // ReSharper disable StringLiteralTypo
        public static List<TagCodeGenerator> SpecialConfigs = new List<TagCodeGenerator>
        {
            #region images / canvas
            new TagCodeGenerator("canvas")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("height", "int"),
                    new AttributeCodeGen("width", "int"),
                }
            },
            new TagCodeGenerator("img")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("alt"),
                    new AttributeCodeGen("crossorigin"),
                    new AttributeCodeGen("height", "int"),
                    //new AttributeCodeGen("ismap"), // not added, as it seems to be a crazy edge case
                    new AttributeCodeGen("longdesc"),
                    new AttributeCodeGen("sizes"),
                    new AttributeCodeGen("src"),
                    new AttributeCodeGen("srcset"),
                    new AttributeCodeGen("usemap"),
                    new AttributeCodeGen("width", "int"),
                },
                Standalone = true
            },

            // no special properties https://www.w3schools.com/tags/tag_picture.asp
            new TagCodeGenerator("picture"),

            // note: I'm only adding basic SVG ATM, since it could be a much more complex system
            // which I would then place into an own namespace
            //    // https://www.w3schools.com/tags/tag_svg.asp
            new TagCodeGenerator("svg")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("height", "int"),
                    new AttributeCodeGen("width", "int"),
                }
            },

            #endregion


            #region Image Maps
            new TagCodeGenerator("area")
            {
                // todo - maybe add all attributes https://www.w3schools.com/tags/tag_area.asp
            },
            new TagCodeGenerator("map")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("name"),
                }
            },

            #endregion
        };
    }
}
