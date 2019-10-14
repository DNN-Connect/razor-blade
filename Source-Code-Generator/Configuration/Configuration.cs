using System.Collections.Generic;
using System.Linq;
using SourceCodeGenerator.Parts;

namespace SourceCodeGenerator.Configuration
{
    public class Configuration
    {
        public static List<TagCodeGenerator> GetAll()
        {
            return new TagsFormatting().List
                .Concat(new TagsSimple().List)
                .Concat(new TagsImages().List)
                .Concat(new TagsLinks().List)
                .Concat(new TagsFrames().List)
                // .Concat(new TagsForms().List)
                .Concat(new TagsMedia().List)
                .OrderBy(c => c.ClassName)
                .ToList();
        }


        // ReSharper restore StringLiteralTypo

        // todo: forms/input

        // todo: tables
        // todo: styles/semantics

        // todo: meta
        // todo: programming
    }
}
