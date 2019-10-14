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
            var fileBody = Generate();

            var fileName = GeneratedTargetPath + GeneratedTags;
            ReplaceFile(fileName, fileBody.Item2);
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

        private static Tuple<string, string> Generate()
        {
            var list = Configuration.Configuration.GetAll();

            var classes = list.Select(c => c.Code());

            var file = Templates.Wrapper
                .Replace("{Contents}", String.Join("\n", classes));
            return new Tuple<string, string>("All", file);
        }
    }
}
