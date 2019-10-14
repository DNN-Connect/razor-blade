using System.Collections.Generic;
using System.Linq;

namespace SourceCodeGenerator.Parts
{
    public class TagCodeGenerator: GeneratorBase
    {
        public string TagName { get; }
        public string ClassName { get; }

        public bool Standalone { get; set; } = false;

        public IEnumerable<string> Parents { get; }

        public List<AttributeCodeGen> Properties = new List<AttributeCodeGen>();

        public TagCodeGenerator(string tagName, string expectedParents = null)
        {
            TagName = tagName.ToLowerInvariant();
            ClassName = FirstCharToUpper(tagName);
            if (!string.IsNullOrEmpty(expectedParents))
                Parents = expectedParents.Split(',').Select(p => p.Trim());
        }

        public string Code() => Comment + Class;

        public string ParentCode() => "// parent code";

        private string TagOptions => Standalone
            ? ", new TagOptions { Close = false }"
            : "";

        public string Comment => $@"
  /// <summary>
  /// Generate a standard {TagName} tag
  /// </summary>
";

        public string Class => $@"public partial class {ClassName} : Tag
{{
{Constructor}
{ConstructorWithParams}
{ConstructorWithAction}
{Attributes}
}}";

        public string Constructor => $@"
  public {ClassName}({ConstructorParameters}) : {BaseCall}
  {{
  }}";

        public string ConstructorWithParams => $@"
  public {ClassName}(params object[] content) : base(""{TagName}"", content)
  {{
  }}";

        public string ConstructorWithAction =>
            $@"
  public {ClassName}(Action<{ClassName}> innerAction) : this()
  {{
    innerAction?.Invoke(this);
  }}";

        public string ConstructorParameters => Standalone
            ? ""
            : "object content = null";


        public string BaseCall => $"base(\"{TagName}\"{(Standalone ? "" : ", content")}{TagOptions})";

        public string Attributes => string.Join("", Properties.Select(p => p.Code(this)));

    }
}
