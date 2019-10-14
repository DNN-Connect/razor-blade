using System.Collections.Generic;
using System.Linq;
using SourceCodeGenerator.Parts;

namespace SourceCodeGenerator.Configuration
{
    internal class TagsScripts : TagsBase
    {
        internal override string GroupName => "Scripts";

        /// <inheritdoc />
        public override List<TagCodeGenerator> List => 
            MakeList(SimpleTags)
                .Concat(SpecialConfigs)
                .ToList();


        // source https://www.w3schools.com/tags/ref_byfunc.asp
        public static string[] SimpleTags
            =
            {
                "noscript", 
            };


        public static List<TagCodeGenerator> SpecialConfigs = new List<TagCodeGenerator>
        {
            new TagCodeGenerator("script")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("async"),
                    new AttributeCodeGen("charset"),
                    new AttributeCodeGen("defer"),
                    new AttributeCodeGen("src"),
                    new AttributeCodeGen("type"),

                },
            },

            new TagCodeGenerator("embed")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("height", "int"),
                    new AttributeCodeGen("src"),
                    new AttributeCodeGen("type"),
                    new AttributeCodeGen("width", "int"),
                },
            },

            // https://www.w3schools.com/tags/tag_object.asp
            new TagCodeGenerator("object")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("data"),
                    new AttributeCodeGen("form"),
                    new AttributeCodeGen("height", "int"),
                    new AttributeCodeGen("name"),
                    new AttributeCodeGen("type"),
                    new AttributeCodeGen("usemap"),
                    new AttributeCodeGen("width", "int"),
                },
            },

            // https://www.w3schools.com/tags/tag_param.asp
            new TagCodeGenerator("param")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("name"),
                    new AttributeCodeGen("value"),
                },
            },
        };
    }
}
