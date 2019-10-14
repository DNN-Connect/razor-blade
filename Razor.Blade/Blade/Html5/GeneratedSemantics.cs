using System;
using Connect.Razor.Blade.HtmlTags;
// ****
// ****
// This is auto-generated code - don't modify
// Re-run the generation program to recreate
// Created 15.10.2019 00:42
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
  /// Generate a standard article tag
  /// </summary>
public partial class Article : Tag
{

  public Article(object content = null) : base("article", content)
  {
  }

  public Article(params object[] content) : base("article", null, content)
  {
  }

}

  /// <summary>
  /// Generate a standard aside tag
  /// </summary>
public partial class Aside : Tag
{

  public Aside(object content = null) : base("aside", content)
  {
  }

  public Aside(params object[] content) : base("aside", null, content)
  {
  }

}

  /// <summary>
  /// Generate a standard data tag
  /// </summary>
public partial class Data : Tag
{

  public Data(object content = null) : base("data", content)
  {
  }

  public Data(params object[] content) : base("data", null, content)
  {
  }
    public Data Open(string value) => this.Attr("open", value);



    public Data Open() => this.Attr("open");


}

  /// <summary>
  /// Generate a standard details tag
  /// </summary>
public partial class Details : Tag
{

  public Details(object content = null) : base("details", content)
  {
  }

  public Details(params object[] content) : base("details", null, content)
  {
  }
    public Details Open(string value) => this.Attr("open", value);



    public Details Open() => this.Attr("open");


}

  /// <summary>
  /// Generate a standard dialog tag
  /// </summary>
public partial class Dialog : Tag
{

  public Dialog(object content = null) : base("dialog", content)
  {
  }

  public Dialog(params object[] content) : base("dialog", null, content)
  {
  }
    public Dialog Open(string value) => this.Attr("open", value);



    public Dialog Open() => this.Attr("open");


}

  /// <summary>
  /// Generate a standard div tag
  /// </summary>
public partial class Div : Tag
{

  public Div(object content = null) : base("div", content)
  {
  }

  public Div(params object[] content) : base("div", null, content)
  {
  }

}

  /// <summary>
  /// Generate a standard footer tag
  /// </summary>
public partial class Footer : Tag
{

  public Footer(object content = null) : base("footer", content)
  {
  }

  public Footer(params object[] content) : base("footer", null, content)
  {
  }

}

  /// <summary>
  /// Generate a standard header tag
  /// </summary>
public partial class Header : Tag
{

  public Header(object content = null) : base("header", content)
  {
  }

  public Header(params object[] content) : base("header", null, content)
  {
  }

}

  /// <summary>
  /// Generate a standard main tag
  /// </summary>
public partial class Main : Tag
{

  public Main(object content = null) : base("main", content)
  {
  }

  public Main(params object[] content) : base("main", null, content)
  {
  }

}

  /// <summary>
  /// Generate a standard section tag
  /// </summary>
public partial class Section : Tag
{

  public Section(object content = null) : base("section", content)
  {
  }

  public Section(params object[] content) : base("section", null, content)
  {
  }

}

  /// <summary>
  /// Generate a standard span tag
  /// </summary>
public partial class Span : Tag
{

  public Span(object content = null) : base("span", content)
  {
  }

  public Span(params object[] content) : base("span", null, content)
  {
  }

}

  /// <summary>
  /// Generate a standard style tag
  /// </summary>
public partial class Style : Tag
{

  public Style(object content = null) : base("style", content)
  {
  }

  public Style(params object[] content) : base("style", null, content)
  {
  }
    public Style Media(string value) => this.Attr("media", value);



    public Style Type(string value) => this.Attr("type", value);




}

  /// <summary>
  /// Generate a standard summary tag
  /// </summary>
public partial class Summary : Tag
{

  public Summary(object content = null) : base("summary", content)
  {
  }

  public Summary(params object[] content) : base("summary", null, content)
  {
  }

}
}
