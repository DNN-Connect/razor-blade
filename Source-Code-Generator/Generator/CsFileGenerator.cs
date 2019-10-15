using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SourceCodeGenerator.Generator
{
    public class CsFileGenerator
    {
        /// <summary>
        /// Target path to store generated code in
        /// </summary>
        public const string GeneratedTargetPath = @"C:\Projects\razor-blades\Razor.Blade\Blade\Html5\";

        /// <summary>
        /// Target file for generated code
        /// </summary>
        public static string GeneratedTags = "GeneratedTags.cs";


        public static void GenerateFormatting()
        {
            var files = Generate();

            foreach (var tuple in files)
            {
                var fileName = GeneratedTargetPath + GeneratedTags.Replace("Tags", tuple.Item1);
                ReplaceFile(fileName, tuple.Item2);
            }
        }

        private static void ReplaceFile(string fileName, string fileBody)
        {
            // Check if file already exists. If yes, delete it.     
            if (File.Exists(fileName)) File.Delete(fileName);

            using var fs = File.CreateText(fileName);
            fs.Write(fileBody);
        }

        private static IEnumerable<Tuple<string, string>> Generate()
        {
            var tuples = Configuration.Configuration.GetTagGroupsToGenerate()
                .Select(set =>
                    new Tuple<string, string>(
                        set.GroupName,
                        Templates.Wrapper.Replace("{Contents}", set.GenerateCode()
                        )));

            return tuples;
        }

        private static string GenerateShortcuts()
        {
            var list = Configuration.Configuration.GetTagGroupsToGenerate()
                .SelectMany(g => g.List)
                .OrderBy(t => t.ClassName)
                ;//.Select(c => c.co)
            return "";
        }
    }
}
