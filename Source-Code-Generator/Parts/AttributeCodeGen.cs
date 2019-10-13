using System.Linq;

namespace SourceCodeGenerator.Parts
{
    public class AttributeCodeGen: GeneratorBase
    {
        public string Name;
        public string Type;
        public string Key;
        public string Separator;

        public AttributeCodeGen(string name, string type = "string", string separator = null)
        {
            Name = FirstCharToUpper(name);
            Key = name;
            Type = type;
            Separator = separator;
        }

        public string Code(TagCodeGenerator tag)
        {
            var booleanCall = IsBooleanAttribute()
                ? $"  public {tag.ClassName} {Name}() => this.Attr(\"{Key}\", null, null);\n\n"
                : "";
            return booleanCall 
                   + $"  public {tag.ClassName} {Name}({Type} value) => this.Attr(\"{Key}\", value, null);\n\n";
        }

        /// <summary>
        /// tells us if the desired attribute is a boolean
        /// this means that the attribute can be added by itself, without a value
        /// </summary>
        /// <returns></returns>
        public bool IsBooleanAttribute() => BooleanAttributes.Contains(Key);

        // got from here https://github.com/iandevlin/html-attributes/blob/master/boolean-attributes.json
        // ReSharper disable StringLiteralTypo
        public static string[] BooleanAttributes = {
            "allowfullscreen",
            "allowpaymentrequest",
            "async",
            "autofocus",
            "autoplay",
            "checked",
            "controls",
            "default",
            "defer",
            "disabled",
            "formnovalidate",
            "hidden",
            "ismap",
            "itemscope",
            "loop",
            "multiple",
            "muted",
            "nomodule",
            "novalidate",
            "open",
            "readonly",
            "required",
            "reversed",
            "selected",
            "typemustmatch"};
        // ReSharper restore StringLiteralTypo

    }

    // todo: maybe add enumerated attributes like 
    // https://github.com/iandevlin/html-attributes/blob/master/enumerated-attributes.json
}
