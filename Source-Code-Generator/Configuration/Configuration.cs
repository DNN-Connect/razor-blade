using System.Collections.Generic;
using System.Linq;
using SourceCodeGenerator.Parts;

namespace SourceCodeGenerator.Configuration
{
    public class Configuration
    {

        public static TagsBase[] GetTagGroupsToGenerate()
        {
            return new TagsBase[]
            {
                new TagsFormatting(),
                new TagsSimple(),
                new TagsImages(),
                new TagsLinks(),
                new TagsFrames(), 
                // new TagsForms(),
                new TagsMedia(),
            };
        }

        public static List<TagCodeGenerator> GetAll()
        {
            //var TagsToGenerate = new TagsBase[]
            //    {
            //        new TagsFormatting(),
            //        new TagsSimple(), 
            //        new TagsImages(), 
            //        new TagsLinks(), 
            //        new TagsFrames(), 
            //        // new TagsForms(),
            //        new TagsMedia(), 
            //    };

            return GetTagGroupsToGenerate()
                .SelectMany(t => t.SortedList)
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
