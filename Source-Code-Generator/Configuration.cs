using System.Collections.Generic;
using System.Linq;

namespace Source_Code_Generator
{
    public class Configuration
    {
        public const string GeneratedTargetPath = @"C:\Projects\razor-blades\Razor.Blade\Blade\Html5\";

        public static string GeneratedTags = "GeneratedTags.cs";

        // source: https://www.w3schools.com/tags/ref_byfunc.asp
        public static string[] BasicTags
            = {"div","h1","h2","h3","h4","h5","h6","p","span"};

        public static string[] NonClosingTags
            = {"br","hr","wbr"};

        public static List<HtmlTag> GetAll()
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

        private static List<HtmlTag> MakeList(string[] stringList, bool standalone = false)
        {
            var list = stringList
                .Select(s => s.Trim())
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => new HtmlTag(s) {Standalone = standalone} )
                .ToList();
            return list;
        }

        // ReSharper disable StringLiteralTypo
        public static List<HtmlTag> SpecialConfigs = new List<HtmlTag>
        {
            new HtmlTag("a")
            {
                Properties = new List<TagProp>
                {
                    new TagProp("download"),
                    new TagProp("href"),
                    new TagProp("hreflang"),
                    new TagProp("media"),
                    new TagProp("ping"),
                    new TagProp("rel"),
                    new TagProp("target"),
                    new TagProp("type"),
                }
            },
            new HtmlTag("bdo")
            {
                Properties = new List<TagProp>{ new TagProp("dir") }
            },
            #region citation, quotes, editing; blockquote, q, del, ins
            new HtmlTag("blockquote")
            {
                Properties = new List<TagProp>{ new TagProp("cite") }
            },
            new HtmlTag("del")
            {
                Properties = new List<TagProp>
                {
                    new TagProp("cite"),
                    new TagProp("datetime"),
                    new TagProp("datetime", "DateTime")
                }
            },
            new HtmlTag("ins")
            {
                Properties = new List<TagProp>
                {
                    new TagProp("cite"),
                    new TagProp("datetime"),
                    new TagProp("datetime", "DateTime")
                }
            },
            new HtmlTag("q")
            {
                Properties = new List<TagProp>{ new TagProp("cite") }
            },
            #endregion
            #region images / canvas
            new HtmlTag("canvas")
            {
                Properties = new List<TagProp>
                {
                    new TagProp("height"),
                    new TagProp("width"),
                }
            },
            new HtmlTag("img")
            {
                Properties = new List<TagProp>
                {
                    new TagProp("alt"),
                    new TagProp("crossorigin"),
                    new TagProp("height"),
                    new TagProp("height", "int"),
                    //new TagProp("ismap"), // not added, as it seems to be a crazy edge case
                    new TagProp("longdesc"),
                    new TagProp("sizes"),
                    new TagProp("src"),
                    new TagProp("srcset"),
                    new TagProp("usemap"),
                    new TagProp("width"),
                    new TagProp("width", "int"),
                },
                Standalone = true
            },
            new HtmlTag("picture")
            {
                // no special properties https://www.w3schools.com/tags/tag_picture.asp
            },
            // note: I'm not adding SVG ATM, since it could be a much more complex system
            // which I would then place into an own namespace
            //new HtmlTag("svg")
            //{
            //    // https://www.w3schools.com/tags/tag_svg.asp
            //},

            #endregion
            #region Image Maps
            new HtmlTag("area")
            {
                // todo - maybe add all attributes https://www.w3schools.com/tags/tag_area.asp
            },
            new HtmlTag("map")
            {
                Properties = new List<TagProp>
                {
                    new TagProp("name"),
                }
            },

            #endregion
            new HtmlTag("meter")
            {
                Properties = new List<TagProp>
                {
                    new TagProp("form"),
                    new TagProp("high"),
                    new TagProp("low"),
                    new TagProp("max"),
                    new TagProp("min"),
                    new TagProp("optimum"),
                    new TagProp("value"),
                }
            },
            new HtmlTag("progress")
            {
                Properties = new List<TagProp>
                {
                    new TagProp("max"),
                    new TagProp("value"),
                }
            },
            new HtmlTag("time")
            {
                Properties = new List<TagProp>
                {
                    new TagProp("datetime"),
                    new TagProp("datetime", "DateTime")
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


        private static string[] ListTags = {"ul", "ol", "li", "dl", "dt", "dd"};
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
