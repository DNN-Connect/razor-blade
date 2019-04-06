using System.Collections.Generic;
using System.Linq;

namespace Source_Code_Generator
{
    public class Configuration
    {
        public const string GeneratedTargetPath = @"C:\Projects\razor-blades\Razor.Blade\Blade\HtmlTags\Generated\";

        public static string FormattingFile = "FormatTags.cs";

        // source: https://www.w3schools.com/tags/ref_byfunc.asp
        public const string BasicTags
            = "div,h1,h2,h3,h4,h5,h6,p,span";

        public const string NonClosingTags
            = "br,hr,wbr";

        public static List<HtmlTagConfig> GetAll()
        {
            var formatting = MakeList(FormattingTags);
            var nonClosing = MakeList(NonClosingTags, true);
            var basic = MakeList(BasicTags);

            return formatting
                .Concat(nonClosing)
                .Concat(basic)
                .OrderBy(c => c.ClassName)
                .ToList();

        }



        public static List<HtmlTagConfig> Formatting() => MakeList(FormattingTags);
        public static List<HtmlTagConfig> NonClosing() => MakeList(NonClosingTags, true);

        private static List<HtmlTagConfig> MakeList(string stringList, bool standalone = false)
        {
            var list = stringList.Split(',')
                .Select(s => s.Trim())
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => new HtmlTagConfig(s, standalone))
                .ToList();
            return list;
        }

        // source https://www.w3schools.com/tags/ref_byfunc.asp
        public const string FormattingTags
                = "abbr," + // could be enhanced
                  "address," +
                  "b,bdi," +
                  "bdo," + // could be enhanced with dir-attribute https://www.w3schools.com/tags/tag_bdo.asp
                  "blockquote," + // could have cite-attribute https://www.w3schools.com/tags/tag_blockquote.asp
                  "cite,code," +
                  "del," + // could have cite / datetime https://www.w3schools.com/tags/tag_del.asp
                  "dfn," +
                  "em," +
                  "i," +
                  "ins," + // cite/datetime https://www.w3schools.com/tags/tag_ins.asp
                  "kbd," +
                  "mark," +
                  "meter" + // many attributes https://www.w3schools.com/tags/tag_meter.asp
                  "pre," +
                  "progress," + // max, value  https://www.w3schools.com/tags/tag_progress.asp
                  "q," + // cite https://www.w3schools.com/tags/tag_q.asp
                  "rp,rt,ruby," +
                  "s,samp,small,strong,sub,sup," +
                  "template," +
                  "time," + // attribute datetime https://www.w3schools.com/tags/tag_time.asp
                  "u,var,"
            ;

        // todo: forms/input
        // todo: frames
        // todo: images - ca. 10
        // todo audio/video

        // todo: links, lists
        // todo: tables
        // todo: styles/semantics

        // todo: meta

        // todo: programming
    }
}
