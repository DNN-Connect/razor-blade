using System;
using SourceCodeGenerator.Generator;

namespace SourceCodeGenerator
{
    class Program
    {

        static void Main(string[] args)
        {
            CsFileGenerator.GenerateFormatting();
            Console.Write("Done, press a key ");
            Console.ReadLine();
        }
    }
}
