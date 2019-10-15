using System;
using Connect.Razor.Blade.HtmlTags;
// ****
// ****
// This is auto-generated code - don't modify
// Re-run the generation program to recreate
// Created 15.10.2019 09:40
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
  /// Generate a standard embed tag
  /// </summary>
public partial class Embed : Tag
{

  public Embed(object content = null) : base("embed", content)
  {
  }

  public Embed(params object[] content) : base("embed", null, content)
  {
  }
    public Embed Height(string value) => this.Attr("height", value);

    public Embed Height(int value) => this.Attr("height", value);

    public Embed Src(string value) => this.Attr("src", value);



    public Embed Type(string value) => this.Attr("type", value);



    public Embed Width(string value) => this.Attr("width", value);

    public Embed Width(int value) => this.Attr("width", value);


}

  /// <summary>
  /// Generate a standard noscript tag
  /// </summary>
public partial class Noscript : Tag
{

  public Noscript(object content = null) : base("noscript", content)
  {
  }

  public Noscript(params object[] content) : base("noscript", null, content)
  {
  }

}

  /// <summary>
  /// Generate a standard object tag
  /// </summary>
public partial class Object : Tag
{

  public Object(object content = null) : base("object", content)
  {
  }

  public Object(params object[] content) : base("object", null, content)
  {
  }
    public Object Data(string value) => this.Attr("data", value);



    public Object Form(string value) => this.Attr("form", value);



    public Object Height(string value) => this.Attr("height", value);

    public Object Height(int value) => this.Attr("height", value);

    public Object Name(string value) => this.Attr("name", value);



    public Object Type(string value) => this.Attr("type", value);



    public Object Usemap(string value) => this.Attr("usemap", value);



    public Object Width(string value) => this.Attr("width", value);

    public Object Width(int value) => this.Attr("width", value);


}

  /// <summary>
  /// Generate a standard param tag
  /// </summary>
public partial class Param : Tag
{

  public Param(object content = null) : base("param", content)
  {
  }

  public Param(params object[] content) : base("param", null, content)
  {
  }
    public Param Name(string value) => this.Attr("name", value);



    public Param Value(string value) => this.Attr("value", value);




}

  /// <summary>
  /// Generate a standard script tag
  /// </summary>
public partial class Script : Tag
{

  public Script(object content = null) : base("script", content)
  {
  }

  public Script(params object[] content) : base("script", null, content)
  {
  }
    public Script Async(string value) => this.Attr("async", value);



    public Script Async() => this.Attr("async");

    public Script Charset(string value) => this.Attr("charset", value);



    public Script Defer(string value) => this.Attr("defer", value);



    public Script Defer() => this.Attr("defer");

    public Script Src(string value) => this.Attr("src", value);



    public Script Type(string value) => this.Attr("type", value);




}
}
