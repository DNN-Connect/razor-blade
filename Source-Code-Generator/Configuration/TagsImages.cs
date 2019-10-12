using System.Collections.Generic;
using SourceCodeGenerator.Parts;

namespace SourceCodeGenerator.Configuration
{
    internal class TagsImages : TagsBase
    {
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
                    new AttributeCodeGen("height"),
                    new AttributeCodeGen("width"),
                }
            },
            new TagCodeGenerator("img")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("alt"),
                    new AttributeCodeGen("crossorigin"),
                    new AttributeCodeGen("height"),
                    new AttributeCodeGen("height", "int"),
                    //new AttributeCodeGen("ismap"), // not added, as it seems to be a crazy edge case
                    new AttributeCodeGen("longdesc"),
                    new AttributeCodeGen("sizes"),
                    new AttributeCodeGen("src"),
                    new AttributeCodeGen("srcset"),
                    new AttributeCodeGen("usemap"),
                    new AttributeCodeGen("width"),
                    new AttributeCodeGen("width", "int"),
                },
                Standalone = true
            },
            new TagCodeGenerator("picture")
            {
                // no special properties https://www.w3schools.com/tags/tag_picture.asp
            },
            // note: I'm not adding SVG ATM, since it could be a much more complex system
            // which I would then place into an own namespace
            //new TagCodeGenerator("svg")
            //{
            //    // https://www.w3schools.com/tags/tag_svg.asp
            //},

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
