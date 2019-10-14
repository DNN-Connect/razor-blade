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
  /// Generate a standard caption tag
  /// </summary>
public partial class Caption : Tag
{

  public Caption(object content = null) : base("caption", content)
  {
  }

  public Caption(params Tag[] content) : base("caption", null, content)
  {
  }

}

  /// <summary>
  /// Generate a standard col tag
  /// </summary>
public partial class Col : Tag
{

  public Col(object content = null) : base("col", content)
  {
  }

  public Col(params Tag[] content) : base("col", null, content)
  {
  }
    public Col Span(string value) => this.Attr("span", value);

    public Col Span(int value) => this.Attr("span", value);


}

  /// <summary>
  /// Generate a standard colgroup tag
  /// </summary>
public partial class Colgroup : Tag
{

  public Colgroup(object content = null) : base("colgroup", content)
  {
  }

  public Colgroup(params Tag[] content) : base("colgroup", null, content)
  {
  }
    public Colgroup Span(string value) => this.Attr("span", value);

    public Colgroup Span(int value) => this.Attr("span", value);


}

  /// <summary>
  /// Generate a standard table tag
  /// </summary>
public partial class Table : Tag
{

  public Table(object content = null) : base("table", content)
  {
  }

  public Table(params Tag[] content) : base("table", null, content)
  {
  }

}

  /// <summary>
  /// Generate a standard tbody tag
  /// </summary>
public partial class Tbody : Tag
{

  public Tbody(object content = null) : base("tbody", content)
  {
  }

  public Tbody(params Tag[] content) : base("tbody", null, content)
  {
  }

}

  /// <summary>
  /// Generate a standard td tag
  /// </summary>
public partial class Td : Tag
{

  public Td(object content = null) : base("td", content)
  {
  }

  public Td(params Tag[] content) : base("td", null, content)
  {
  }
    public Td Colspan(string value) => this.Attr("colspan", value);

    public Td Colspan(int value) => this.Attr("colspan", value);

    public Td Headers(string value) => this.Attr("headers", value);



    public Td Rowspan(string value) => this.Attr("rowspan", value);

    public Td Rowspan(int value) => this.Attr("rowspan", value);


}

  /// <summary>
  /// Generate a standard tfoot tag
  /// </summary>
public partial class Tfoot : Tag
{

  public Tfoot(object content = null) : base("tfoot", content)
  {
  }

  public Tfoot(params Tag[] content) : base("tfoot", null, content)
  {
  }

}

  /// <summary>
  /// Generate a standard th tag
  /// </summary>
public partial class Th : Tag
{

  public Th(object content = null) : base("th", content)
  {
  }

  public Th(params Tag[] content) : base("th", null, content)
  {
  }
    public Th Abbr(string value) => this.Attr("abbr", value);



    public Th Colspan(string value) => this.Attr("colspan", value);

    public Th Colspan(int value) => this.Attr("colspan", value);

    public Th Headers(string value) => this.Attr("headers", value);



    public Th Rowspan(string value) => this.Attr("rowspan", value);

    public Th Rowspan(int value) => this.Attr("rowspan", value);

    public Th Scope(string value) => this.Attr("scope", value);



    public Th Sorted(string value) => this.Attr("sorted", value);




}

  /// <summary>
  /// Generate a standard thead tag
  /// </summary>
public partial class Thead : Tag
{

  public Thead(object content = null) : base("thead", content)
  {
  }

  public Thead(params Tag[] content) : base("thead", null, content)
  {
  }

}

  /// <summary>
  /// Generate a standard tr tag
  /// </summary>
public partial class Tr : Tag
{

  public Tr(object content = null) : base("tr", content)
  {
  }

  public Tr(params Tag[] content) : base("tr", null, content)
  {
  }

}
}
