using System.IO;
using System.Linq;

namespace SourceCodeGenerator.Generator
{
    public class CsFileGenerator
    {
        public static void GenerateFormatting()
        {
            var fileBody = Generate();

            var fileName = Configuration.Configuration.GeneratedTargetPath + Configuration.Configuration.GeneratedTags;
            ReplaceFile(fileName, fileBody);
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

        private static string Generate()
        {
            var list = Configuration.Configuration.GetAll();

            var classes = list.Select(c => c.Code());

            var file = Templates.Wrapper
                .Replace("{Contents}", string.Join("\n", classes));
            return file;
        }
    }
}
