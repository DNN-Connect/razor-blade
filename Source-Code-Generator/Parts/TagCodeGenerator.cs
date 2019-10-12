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
            // 2019-10-12 disabled, all code-generation doesn't use this any more
            //var splitBar = tagName.IndexOf("|");
            //if (splitBar > 0)
            //{
            //    throw new Exception("test");
            //    var props = tagName.Substring(splitBar + 1);
            //    foreach (var p in props.Split(','))
            //    {
            //        var parts = p.Split(' ');
            //        if(parts.Length != 2) throw new Exception("bad length");
                    
            //        Properties.Add(new AttributeCodeGen(parts[1], parts[0]));
                    
            //    }
            //    tagName = tagName.Substring(0, splitBar);
            //}

            TagName = tagName.ToLowerInvariant();
            ClassName = FirstCharToUpper(tagName);
        }

        public string Code() => Comment + Class;

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
{Attributes}
}}";

        public string Constructor =>
            $@"
  public {ClassName}({ConstructorParameters}) : {BaseCall}
  {{
  }}";

        public string ConstructorParameters => Standalone
            ? ""
            : "object content = null";


        public string BaseCall => $"base(\"{TagName}\"{(Standalone ? "" : ", content")}{TagOptions})";

        public string Attributes => string.Join("", Properties.Select(p => p.Code(this)));

    }
}
