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
            return $"  public {tag.ClassName} {Name}({Type} value) => this.Attr(\"{Key}\", value, null);\n\n";
        }
    }
}
