using System.Collections.Generic;
using System.Linq;
using SourceCodeGenerator.Parts;

namespace SourceCodeGenerator.Configuration
{
    public class Configuration
    {
        /// <summary>
        /// Target path to store generated code in
        /// </summary>
        public const string GeneratedTargetPath = @"C:\Projects\razor-blades\Razor.Blade\Blade\Html5\";

        /// <summary>
        /// Target file for generated code
        /// </summary>
        public static string GeneratedTags = "GeneratedTags.cs";

        public static List<TagCodeGenerator> GetAll()
        {
            return new TagsFormatting().List
                .Concat(new TagsSimple().List)
                .Concat(SpecialConfigs)
                .OrderBy(c => c.ClassName)
                .ToList();
        }

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



        // ReSharper restore StringLiteralTypo

        // todo: forms/input
        // todo: frames
        // todo audio/video

        // todo: link-tag https://www.w3schools.com/tags/tag_link.asp
        // todo: tables
        // todo: styles/semantics

        // todo: meta

        // todo: programming
    }
}
