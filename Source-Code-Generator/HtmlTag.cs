using System;
using System.Collections.Generic;
using System.Linq;

namespace Source_Code_Generator
{
    public class HtmlTag: ConfigBase
    {
        public string TagName { get; }
        public string ClassName { get; }

        public bool Standalone { get; set; } = false;

        public List<HtmlTagProperty> Properties = new List<HtmlTagProperty>();

        public HtmlTag(string tagName)
        {
            var splitBar = tagName.IndexOf("|");
            if (splitBar > 0)
            {
                var props = tagName.Substring(splitBar + 1);
                foreach (var p in props.Split(','))
                {
                    var parts = p.Split(' ');
                    if(parts.Length != 2) throw new Exception("bad length");
                    
                    Properties.Add(new HtmlTagProperty(parts[1], parts[0]));
                    
                }
                tagName = tagName.Substring(0, splitBar);
            }

            TagName = tagName;
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


        public string ConstructorParameters => Standalone
            ? ""
            : "object content = null";

        public string BaseCall => $"base(\"{TagName}\"{(Standalone ? "" : ", content")}{TagOptions})";

        public string Attributes => string.Join("", Properties.Select(p => p.Code(this)));

        public string Constructor =>
            $@"
  public {ClassName}({ConstructorParameters}) : {BaseCall}
  {{
  }}";

        public string Class => $@"public class {ClassName} : Tag
{{
{Constructor}
{Attributes}
}}";


    }
}
