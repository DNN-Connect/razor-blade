using System.Collections.Generic;
using System.Linq;
using SourceCodeGenerator.Parts;

namespace SourceCodeGenerator.Configuration
{
    internal class TagsFormatting : TagsBase
    {
        internal override string GroupName => "Formatting";

        /// <inheritdoc />
        public override List<TagCodeGenerator> List => 
            MakeList(FormattingTags)
                .Concat(SpecialConfigs)
                .ToList();


        // source https://www.w3schools.com/tags/ref_byfunc.asp
        public static string[] FormattingTags
            =
            {
                "abbr", // could be enhanced
                "address",
                "b",
                "bdi",
                //"bdo|string dir", // https://www.w3schools.com/tags/tag_bdo.asp
                //"blockquote|string cite", // https://www.w3schools.com/tags/tag_blockquote.asp
                "cite",
                "code",
                //"del|string cite,string datetime", // could have cite / datetime https://www.w3schools.com/tags/tag_del.asp
                "dfn",
                "em",
                "i",
                "figure",
                "figcaption",
                //"ins", // cite/datetime https://www.w3schools.com/tags/tag_ins.asp
                "kbd",
                "mark",
                //"meter", // many attributes https://www.w3schools.com/tags/tag_meter.asp
                "pre",
                //"progress", // max value  https://www.w3schools.com/tags/tag_progress.asp
                //"q", // cite https://www.w3schools.com/tags/tag_q.asp
                "rp",
                "rt",
                "ruby",
                "s",
                "samp",
                "small",
                "strong",
                "sub",
                "sup",
                "template",
                //"time", // attribute datetime https://www.w3schools.com/tags/tag_time.asp
                "u",
                "var",
                // "wbr" // it's in the non-closing tags
            };

        public static List<TagCodeGenerator> SpecialConfigs = new List<TagCodeGenerator>
        {

            new TagCodeGenerator("bdo")
            {
                Properties = new List<AttributeCodeGen>{ new AttributeCodeGen("dir") }
            },
            #region citation, quotes, editing; blockquote, q, del, ins
            new TagCodeGenerator("blockquote")
            {
                Properties = new List<AttributeCodeGen>{ new AttributeCodeGen("cite") }
            },

            new TagCodeGenerator("del")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("cite"),
                    new AttributeCodeGen("datetime"),
                    new AttributeCodeGen("datetime", "DateTime")
                }
            },

            new TagCodeGenerator("ins")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("cite"),
                    new AttributeCodeGen("datetime"),
                    new AttributeCodeGen("datetime", "DateTime")
                }
            },

            new TagCodeGenerator("meter")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("form"),
                    new AttributeCodeGen("high"),
                    new AttributeCodeGen("low"),
                    new AttributeCodeGen("max"),
                    new AttributeCodeGen("min"),
                    new AttributeCodeGen("optimum"),
                    new AttributeCodeGen("value"),
                }
            },
            new TagCodeGenerator("progress")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("max"),
                    new AttributeCodeGen("value"),
                }
            },
            new TagCodeGenerator("q")
            {
                Properties = new List<AttributeCodeGen>{ new AttributeCodeGen("cite") }
            },
            #endregion

            new TagCodeGenerator("time")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("datetime"),
                    new AttributeCodeGen("datetime", "DateTime")
                }
            },

        };
    }
}
