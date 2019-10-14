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
  /// Generate a standard a tag
  /// </summary>
public partial class A : Tag
{

  public A(object content = null) : base("a", content)
  {
  }

  public A(params object[] content) : base("a", null, content)
  {
  }
    public A Download(string value) => this.Attr("download", value);



    public A Href(string value) => this.Attr("href", value);



    public A Hreflang(string value) => this.Attr("hreflang", value);



    public A Media(string value) => this.Attr("media", value);



    public A Ping(string value) => this.Attr("ping", value);



    public A Rel(string value) => this.Attr("rel", value);



    public A Target(string value) => this.Attr("target", value);



    public A Type(string value) => this.Attr("type", value);




}

  /// <summary>
  /// Generate a standard link tag
  /// </summary>
public partial class Link : Tag
{

  public Link() : base("link", new TagOptions { Close = false })
  {
  }

  public Link(params object[] content) : base("link", new TagOptions { Close = false }, content)
  {
  }
    public Link Crossorigin(string value) => this.Attr("crossorigin", value);



    public Link Href(string value) => this.Attr("href", value);



    public Link Hreflang(string value) => this.Attr("hreflang", value);



    public Link Media(string value) => this.Attr("media", value);



    public Link Rel(string value) => this.Attr("rel", value);



    public Link Type(string value) => this.Attr("type", value);




}

  /// <summary>
  /// Generate a standard nav tag
  /// </summary>
public partial class Nav : Tag
{

  public Nav(object content = null) : base("nav", content)
  {
  }

  public Nav(params object[] content) : base("nav", null, content)
  {
  }

}
}
