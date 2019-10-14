using System;
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
  /// Generate a standard area tag
  /// </summary>
public partial class Area : Tag
{

  public Area(object content = null) : base("area", content)
  {
  }

  public Area(params Tag[] content) : base("area", null, content)
  {
  }

}

  /// <summary>
  /// Generate a standard canvas tag
  /// </summary>
public partial class Canvas : Tag
{

  public Canvas(object content = null) : base("canvas", content)
  {
  }

  public Canvas(params Tag[] content) : base("canvas", null, content)
  {
  }
    public Canvas Height(string value) => this.Attr("height", value);

    public Canvas Height(int value) => this.Attr("height", value);

    public Canvas Width(string value) => this.Attr("width", value);

    public Canvas Width(int value) => this.Attr("width", value);


}

  /// <summary>
  /// Generate a standard img tag
  /// </summary>
public partial class Img : Tag
{

  public Img() : base("img", new TagOptions { Close = false })
  {
  }

  public Img(params Tag[] content) : base("img", new TagOptions { Close = false }, content)
  {
  }
    public Img Alt(string value) => this.Attr("alt", value);



    public Img Crossorigin(string value) => this.Attr("crossorigin", value);



    public Img Height(string value) => this.Attr("height", value);

    public Img Height(int value) => this.Attr("height", value);

    public Img Longdesc(string value) => this.Attr("longdesc", value);



    public Img Sizes(string value) => this.Attr("sizes", value);



    public Img Src(string value) => this.Attr("src", value);



    public Img Srcset(string value) => this.Attr("srcset", value, ",");



    public Img Srcset(int multiplier, string name) => Srcset(name + " " + multiplier + (multiplier > 8 ? "w" : "x"));

    public Img Usemap(string value) => this.Attr("usemap", value);



    public Img Width(string value) => this.Attr("width", value);

    public Img Width(int value) => this.Attr("width", value);


}

  /// <summary>
  /// Generate a standard map tag
  /// </summary>
public partial class Map : Tag
{

  public Map(object content = null) : base("map", content)
  {
  }

  public Map(params Tag[] content) : base("map", null, content)
  {
  }
    public Map Name(string value) => this.Attr("name", value);




}

  /// <summary>
  /// Generate a standard picture tag
  /// </summary>
public partial class Picture : Tag
{

  public Picture(object content = null) : base("picture", content)
  {
  }

  public Picture(params Tag[] content) : base("picture", null, content)
  {
  }

}

  /// <summary>
  /// Generate a standard svg tag
  /// </summary>
public partial class Svg : Tag
{

  public Svg(object content = null) : base("svg", content)
  {
  }

  public Svg(params Tag[] content) : base("svg", null, content)
  {
  }
    public Svg Height(string value) => this.Attr("height", value);

    public Svg Height(int value) => this.Attr("height", value);

    public Svg Width(string value) => this.Attr("width", value);

    public Svg Width(int value) => this.Attr("width", value);


}
}
