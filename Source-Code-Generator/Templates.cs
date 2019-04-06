namespace Source_Code_Generator
{
    public class Templates
    {
        public const string Wrapper =
            @"
// ****
// ****
// This is auto-generated code - don't modify
// Re-run the generation program to recreate
// ****
// ****
namespace Connect.Razor.Blade.HtmlTags
{
{Contents}
}
";

        public const string StandardTag =
            @"
    /// <summary>
    /// Generate a standard {TagHtml} tag
    /// </summary>
    public class {TagName} : Tag
    {
        public {TagName}(object content = null) : base(""{TagHtml}"", content{TagOptions}) { }
    }
";


        public static string ImplementStandardTag(HtmlTagConfig config)
        {
            var tagOptions = config.Standalone
                ? ", new TagOptions { Close = false }"
                : "";
            return StandardTag
                .Replace("{TagName}", config.ClassName)
                .Replace("{TagHtml}", config.TagName)
                .Replace("{TagOptions}", tagOptions);
        }

    }

}
