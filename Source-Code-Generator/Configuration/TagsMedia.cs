using System.Collections.Generic;
using SourceCodeGenerator.Parts;

namespace SourceCodeGenerator.Configuration
{
    internal class TagsMedia: TagsBase
    {
        internal override string GroupName => "Media";

        /// <inheritdoc />
        public override List<TagCodeGenerator> List => SpecialConfigs;

        // ReSharper disable StringLiteralTypo
        public static List<TagCodeGenerator> SpecialConfigs = new List<TagCodeGenerator>
        {
            new TagCodeGenerator("audio")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("autoplay"),
                    new AttributeCodeGen("controls"),
                    new AttributeCodeGen("loop"),
                    new AttributeCodeGen("muted"),
                    new AttributeCodeGen("preload"),
                    new AttributeCodeGen("src"),
                },
            },
            new TagCodeGenerator("source")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("src"),
                    new AttributeCodeGen("srcset"),
                    new AttributeCodeGen("media"),
                    new AttributeCodeGen("sizes"),
                    new AttributeCodeGen("type"),
                },
                Standalone = true
            },
            new TagCodeGenerator("track")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("default"),
                    new AttributeCodeGen("kind"),
                    new AttributeCodeGen("label"),
                    new AttributeCodeGen("src"),
                    new AttributeCodeGen("srclang"),
                },
                Standalone = true
            },

            // https://www.w3schools.com/tags/tag_video.asp
            new TagCodeGenerator("video")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("autoplay"),
                    new AttributeCodeGen("controls"),
                    new AttributeCodeGen("height", "int"),
                    new AttributeCodeGen("loop"),
                    new AttributeCodeGen("muted"),
                    new AttributeCodeGen("poster"),
                    new AttributeCodeGen("preload"),
                    new AttributeCodeGen("src"),
                    new AttributeCodeGen("width", "int"),
                },
            },




        };
    }
}
