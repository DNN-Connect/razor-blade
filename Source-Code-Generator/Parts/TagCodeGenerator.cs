using System.Collections.Generic;
using System.Linq;

namespace SourceCodeGenerator.Parts
{
    public class TagCodeGenerator: GeneratorBase
    {
        public string TagName { get; }
        public string ClassName { get; }

        public bool Standalone { get; set; } = false;

        public List<AttributeCodeGen> Properties = new List<AttributeCodeGen>();

        public TagCodeGenerator(string tagName)
        {
            TagName = tagName.ToLowerInvariant();
            ClassName = FirstCharToUpper(tagName);
        }

        public string Code() => Comment + Class;

        private string TagOptions => Standalone
            ? ", new TagOptions { Close = false }"
            : string.Empty;

        private string TagOptionsWithExplicitNull => TagOptions == string.Empty ? ", null" : TagOptions;

        public string Comment => $@"
  /// <summary>
  /// Generate a standard {TagName} tag
  /// </summary>
";

        public string Class => $@"public partial class {ClassName} : Tag
{{
{Constructor}
{ConstructorWithParams}
{Attributes}
}}";

        public string Constructor => $@"
  public {ClassName}({ConstructorParameters}) : {BaseCall}
  {{
  }}";

        public string ConstructorWithParams => $@"
  public {ClassName}(params object[] content) : base(""{TagName}""{TagOptionsWithExplicitNull}, content)
  {{
  }}";

        public string ConstructorParameters => Standalone
            ? ""
            : "object content = null";

        public string CallParameters(bool chain = true) => Standalone ? "" : ((chain ? ", " : "") + "content");


        public string BaseCall => $"base(\"{TagName}\"{CallParameters(true)}{TagOptions})";

        public string Attributes => string.Join("", Properties.Select(p => p.Code(this)));


        public string QuickAccessCode => $@"{Comment}{QuickAccess}

{Comment}{QuickAccessWithParams}";

        public string QuickAccess => $"  public static {ClassName} {ClassName}({ConstructorParameters}) => new {ClassName}({CallParameters(false)});";

        public string QuickAccessWithParams => $"  public static {ClassName} {ClassName}(params object[] content) => new {ClassName}(content);";
    }
}
