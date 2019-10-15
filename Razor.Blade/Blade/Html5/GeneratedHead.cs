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
  /// Generate a standard base tag
  /// </summary>
public partial class Base : Tag
{

  public Base() : base("base", new TagOptions { Close = false })
  {
  }

  public Base(params object[] content) : base("base", new TagOptions { Close = false }, content)
  {
  }
    public Base Href(string value) => this.Attr("href", value);



    public Base Target(string value) => this.Attr("target", value);




}

  /// <summary>
  /// Generate a standard head tag
  /// </summary>
public partial class Head : Tag
{

  public Head(object content = null) : base("head", content)
  {
  }

  public Head(params object[] content) : base("head", null, content)
  {
  }

}

  /// <summary>
  /// Generate a standard meta tag
  /// </summary>
public partial class Meta : Tag
{

  public Meta() : base("meta", new TagOptions { Close = false })
  {
  }

  public Meta(params object[] content) : base("meta", new TagOptions { Close = false }, content)
  {
  }
    public Meta Charset(string value) => this.Attr("charset", value);



    public Meta Content(string value) => this.Attr("content", value);



    public Meta HttpEquiv(string value) => this.Attr("http-equiv", value);



    public Meta Name(string value) => this.Attr("name", value);




}
}
