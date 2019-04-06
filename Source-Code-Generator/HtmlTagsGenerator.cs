using System.IO;
using System.Linq;

namespace Source_Code_Generator
{
    public class HtmlTagsGenerator
    {


        public static void GenerateFormatting()
        {
            var fileBody = Generate(Configuration.FormattingTags);

            var fileName = Configuration.GeneratedTargetPath + Configuration.FormattingFile;
            ReplaceFile(fileName, fileBody);
        }

        public static void ReplaceFile(string fileName, string fileBody)
        {
            // Check if file already exists. If yes, delete it.     
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            using (var fs = File.CreateText(fileName))
            {
                fs.Write(fileBody);
            }
        }

        internal static string Generate(string stringList)
        {
            var list = Configuration.GetAll();

            var classes = list.Select(Templates.ImplementStandardTag);

            var file = Templates.Wrapper
                .Replace("{Contents}", string.Join("\n", classes));
            return file;
        }
    }
}
