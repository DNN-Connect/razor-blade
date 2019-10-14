using System;
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

            //var fileName = GeneratedTargetPath + GeneratedTags;
            foreach (var tuple in files)
            {
                var fileName = GeneratedTargetPath + GeneratedTags.Replace("Tags", tuple.Item1);
                ReplaceFile(fileName, tuple.Item2);
            }
            //ReplaceFile(fileName, files.Item2);
        }

        private static void ReplaceFile(string fileName, string fileBody)
        {
            // Check if file already exists. If yes, delete it.     
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using var fs = File.CreateText(fileName);
            fs.Write(fileBody);
        }

        private static Tuple<string, string>[] Generate()
        {
            //var list = Configuration.Configuration.GetTagGroupsToGenerate();

            //var classes = list.Select(c => c.Code());

            var tuples = Configuration.Configuration.GetTagGroupsToGenerate()
                .Select(set =>
                    new Tuple<string, string>(
                        set.GroupName,
                        Templates.Wrapper.Replace("{Contents}", set.GenerateCode()
                        )));

            //var file = Templates.Wrapper
            //    .Replace("{Contents}", String.Join("\n", classes));
            return tuples.ToArray(); //new Tuple<string, string>("All", file);
        }
    }
}
