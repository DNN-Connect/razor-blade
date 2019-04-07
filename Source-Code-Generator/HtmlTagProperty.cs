namespace Source_Code_Generator
{
    public class HtmlTagProperty: ConfigBase
    {
        public string Name;
        public string Type;
        public string Key;
        public string Separator;

        public HtmlTagProperty(string name, string type = "string", string separator = null)
        {
            Name = FirstCharToUpper(name);
            Key = name;
            Type = type;
            Separator = separator;
        }

        public string Code(HtmlTag tag)
        {
            return $"  public {tag.ClassName} {Name}({Type} value) => this.Attr(\"{Key}\", value, null);\n\n";
        }
    }
}
