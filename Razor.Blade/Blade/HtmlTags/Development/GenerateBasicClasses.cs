using System.Linq;

namespace Connect.Razor.Blade.HtmlTags.Development
{
    /// <summary>
    /// This is a helper to simply generate a bunch of identical classes for the Html Tag
    /// I'll need to rerun this whenever the template changes
    /// </summary>
    internal class GenerateBasicClasses
    {
        private const string Wrapper =
            @"namespace Connect.Razor.Blade.HtmlTags
{
{Contents}
}
";
        private const string StandardTagTemplate =
            @"
    /// <summary>
    /// Generate a standard {TagHtml} tag
    /// </summary>
    public class {TagName} : Tag
    {
        public {TagName}(object content = null) : base(""{TagHtml}"", content) { }
    }
";
        // source: https://www.w3schools.com/tags/ref_byfunc.asp
        private const string BasicTags
            = "div,h1,h2,h3,h4,h5,h6,p,span";

        private const string NonClosingTags
            = "br,hr,wbr";

        // source https://www.w3schools.com/tags/ref_byfunc.asp
        private const string FormattingTags
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



        public static string Generate(string stringList)
        {
            var list = stringList.Split(',')
                .Select(s => s.Trim())
                .Where(s => !string.IsNullOrWhiteSpace(s));

            var classes = list.Select(s => StandardTagTemplate
                .Replace("{TagName}", FirstCharToUpper(s))
                .Replace("{TagHtml}", s));

            var file = Wrapper.Replace("{Contents}", string.Join("\n", classes));
            return file;
        }

        private static string FirstCharToUpper(string s)
        {
            // Check for empty string.  
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.  
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}
