using System;

namespace SourceCodeGenerator.Generator
{
    public class Templates
    {
        public static string Wrapper =
            @"using System;
using Connect.Razor.Blade.HtmlTags;
// ****
// ****
// This is auto-generated code - don't modify
// Re-run the generation program to recreate
// Created [DATE]
//
// Each tag and attributes of it prepare code, and they return an object of the same type again
// to allow fluid chaining of the commands
// ****
// ****
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantArgumentDefaultValue
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global
namespace Connect.Razor.Blade.Html5
{
{Contents}
}
".Replace("[DATE]", DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
        

    }

}
