using System.Collections.Generic;
using System.Linq;
using SourceCodeGenerator.Parts;

namespace SourceCodeGenerator.Configuration
{
    public class Configuration
    {
        /// <summary>
        /// Target path to store generated code in
        /// </summary>
        public const string GeneratedTargetPath = @"C:\Projects\razor-blades\Razor.Blade\Blade\Html5\";

        /// <summary>
        /// Target file for generated code
        /// </summary>
        public static string GeneratedTags = "GeneratedTags.cs";

        public static List<TagCodeGenerator> GetAll()
        {
            return new TagsFormatting().List
                .Concat(new TagsSimple().List)
                .Concat(new TagsImages().List)
                .Concat(new TagsLinks().List)
                .OrderBy(c => c.ClassName)
                .ToList();
        }


        // ReSharper restore StringLiteralTypo

        // todo: forms/input
        // todo: frames
        // todo audio/video

        // todo: link-tag https://www.w3schools.com/tags/tag_link.asp
        // todo: tables
        // todo: styles/semantics

        // todo: meta

        // todo: programming
    }
}
