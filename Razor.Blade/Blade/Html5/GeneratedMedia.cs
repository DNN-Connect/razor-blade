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
  /// Generate a standard audio tag
  /// </summary>
public partial class Audio : Tag
{

  public Audio(object content = null) : base("audio", content)
  {
  }

  public Audio(params object[] content) : base("audio", null, content)
  {
  }
    public Audio Autoplay(string value) => this.Attr("autoplay", value);



    public Audio Autoplay() => this.Attr("autoplay");

    public Audio Controls(string value) => this.Attr("controls", value);



    public Audio Controls() => this.Attr("controls");

    public Audio Loop(string value) => this.Attr("loop", value);



    public Audio Loop() => this.Attr("loop");

    public Audio Muted(string value) => this.Attr("muted", value);



    public Audio Muted() => this.Attr("muted");

    public Audio Preload(string value) => this.Attr("preload", value);



    public Audio Src(string value) => this.Attr("src", value);




}

  /// <summary>
  /// Generate a standard source tag
  /// </summary>
public partial class Source : Tag
{

  public Source() : base("source", new TagOptions { Close = false })
  {
  }

  public Source(params object[] content) : base("source", new TagOptions { Close = false }, content)
  {
  }
    public Source Src(string value) => this.Attr("src", value);



    public Source Srcset(string value) => this.Attr("srcset", value, ",");



    public Source Srcset(int multiplier, string name) => Srcset(name + " " + multiplier + (multiplier > 8 ? "w" : "x"));

    public Source Media(string value) => this.Attr("media", value);



    public Source Sizes(string value) => this.Attr("sizes", value);



    public Source Type(string value) => this.Attr("type", value);




}

  /// <summary>
  /// Generate a standard track tag
  /// </summary>
public partial class Track : Tag
{

  public Track() : base("track", new TagOptions { Close = false })
  {
  }

  public Track(params object[] content) : base("track", new TagOptions { Close = false }, content)
  {
  }
    public Track Default(string value) => this.Attr("default", value);



    public Track Default() => this.Attr("default");

    public Track Kind(string value) => this.Attr("kind", value);



    public Track Label(string value) => this.Attr("label", value);



    public Track Src(string value) => this.Attr("src", value);



    public Track Srclang(string value) => this.Attr("srclang", value);




}

  /// <summary>
  /// Generate a standard video tag
  /// </summary>
public partial class Video : Tag
{

  public Video(object content = null) : base("video", content)
  {
  }

  public Video(params object[] content) : base("video", null, content)
  {
  }
    public Video Autoplay(string value) => this.Attr("autoplay", value);



    public Video Autoplay() => this.Attr("autoplay");

    public Video Controls(string value) => this.Attr("controls", value);



    public Video Controls() => this.Attr("controls");

    public Video Height(string value) => this.Attr("height", value);

    public Video Height(int value) => this.Attr("height", value);

    public Video Loop(string value) => this.Attr("loop", value);



    public Video Loop() => this.Attr("loop");

    public Video Muted(string value) => this.Attr("muted", value);



    public Video Muted() => this.Attr("muted");

    public Video Poster(string value) => this.Attr("poster", value);



    public Video Preload(string value) => this.Attr("preload", value);



    public Video Src(string value) => this.Attr("src", value);



    public Video Width(string value) => this.Attr("width", value);

    public Video Width(int value) => this.Attr("width", value);


}
}
