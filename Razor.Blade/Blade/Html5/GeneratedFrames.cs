using Connect.Razor.Blade.HtmlTags;
// ****
// ****
// This is auto-generated code - don't modify
// Re-run the generation program to recreate
// Created 14.10.2019 21:55
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

  /// <summary>
  /// Generate a standard iframe tag
  /// </summary>
public partial class Iframe : Tag
{

  public Iframe() : base("iframe", new TagOptions { Close = false })
  {
  }

  public Iframe(params Tag[] content) : base("iframe", new TagOptions { Close = false }, content)
  {
  }
    public Iframe Height(string value) => this.Attr("height", value);

    public Iframe Height(int value) => this.Attr("height", value);

    public Iframe Name(string value) => this.Attr("name", value);



    public Iframe Sandbox(string value) => this.Attr("sandbox", value);



    public Iframe Src(string value) => this.Attr("src", value);



    public Iframe Srcdoc(string value) => this.Attr("srcdoc", value);



    public Iframe Width(string value) => this.Attr("width", value);

    public Iframe Width(int value) => this.Attr("width", value);


}
}
