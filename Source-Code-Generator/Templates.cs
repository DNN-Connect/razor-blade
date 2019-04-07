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


        //public static string ImplementStandardTag(HtmlTag config)
        //{
        //    var tagOptions = config.Standalone
        //        ? ", new TagOptions { Close = false }"
        //        : "";
        //    return StandardTag
        //        .Replace("{TagName}", config.ClassName)
        //        .Replace("{TagHtml}", config.TagName)
        //        .Replace("{TagOptions}", tagOptions);
        //}

        //public static string CreateAttributes(HtmlTag config, string template)
        //{
        //    var attributeMethods = "";
        //    return template.Replace(PlaceholderAttributes, attributeMethods);
        //}

    }

}
