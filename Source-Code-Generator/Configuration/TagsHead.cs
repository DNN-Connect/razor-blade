using System.Collections.Generic;
using System.Linq;
using SourceCodeGenerator.Parts;

namespace SourceCodeGenerator.Configuration
{
    internal class TagsHead : TagsBase
    {
        internal override string GroupName => "Head";

        /// <inheritdoc />
        public override List<TagCodeGenerator> List => 
            MakeList(SimpleTags)
                .Concat(SpecialConfigs)
                .ToList();


        // source https://www.w3schools.com/tags/ref_byfunc.asp
        public static string[] SimpleTags
            =
            {
                "head", 
            };


        public static List<TagCodeGenerator> SpecialConfigs = new List<TagCodeGenerator>
        {
            new TagCodeGenerator("meta")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("charset"),
                    new AttributeCodeGen("content"),
                    new AttributeCodeGen("http-equiv"),
                    new AttributeCodeGen("name"),

                },
                Standalone = true
            },

            new TagCodeGenerator("base")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("href"),
                    new AttributeCodeGen("target"),

                },
                Standalone = true
            },

        };
    }
}
