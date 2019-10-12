using System.Collections.Generic;
using System.Linq;
using SourceCodeGenerator.Parts;

namespace SourceCodeGenerator.Generator
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

        // source: https://www.w3schools.com/tags/ref_byfunc.asp
        public static string[] BasicTags
            = {"div","h1","h2","h3","h4","h5","h6","p","span"};

        public static string[] NonClosingTags
            = {"br","hr","wbr"};

        public static List<TagCodeGenerator> GetAll()
        {
            var formatting = MakeList(CommonTags);
            var nonClosing = MakeList(NonClosingTags, true);
            var basic = MakeList(BasicTags);

            return formatting
                .Concat(nonClosing)
                .Concat(basic)
                .Concat(SpecialConfigs)
                .Concat(MakeList(ListTags))
                .OrderBy(c => c.ClassName)
                .ToList();

        }

        private static List<TagCodeGenerator> MakeList(string[] stringList, bool standalone = false)
        {
            var list = stringList
                .Select(s => s.Trim())
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => new TagCodeGenerator(s) {Standalone = standalone} )
                .ToList();
            return list;
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
            new TagCodeGenerator("q")
            {
                Properties = new List<AttributeCodeGen>{ new AttributeCodeGen("cite") }
            },
            #endregion
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
            new TagCodeGenerator("time")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("datetime"),
                    new AttributeCodeGen("datetime", "DateTime")
                }
            },

        };

        // source https://www.w3schools.com/tags/ref_byfunc.asp
        public static string[] CommonTags
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
                "nav",
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
                "var"
            };


        private static readonly string[] ListTags = {"ul", "ol", "li", "dl", "dt", "dd"};
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
