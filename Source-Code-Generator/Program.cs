using System;

namespace Source_Code_Generator
{
    class Program
    {

        static void Main(string[] args)
        {
            HtmlTagsGenerator.GenerateFormatting();
            Console.Write("Done, press a key ");
            var name = Console.ReadLine();
        }
    }
}
