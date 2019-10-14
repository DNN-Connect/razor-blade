using System;
using Connect.Razor.Blade.HtmlTags;
// ****
// ****
// This is auto-generated code - don't modify
// Re-run the generation program to recreate
// Created 14.10.2019 19:38
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

  public Caption(params object[] content) : base("caption", content)
  {
  }

  public Caption(Action<Caption> innerAction) : this()
  {
    innerAction?.Invoke(this);
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

  public Col(params object[] content) : base("col", content)
  {
  }

  public Col(Action<Col> innerAction) : this()
  {
    innerAction?.Invoke(this);
  }
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

  public Colgroup(params object[] content) : base("colgroup", content)
  {
  }

  public Colgroup(Action<Colgroup> innerAction) : this()
  {
    innerAction?.Invoke(this);
  }
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

  public Table(params object[] content) : base("table", content)
  {
  }

  public Table(Action<Table> innerAction) : this()
  {
    innerAction?.Invoke(this);
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

  public Tbody(params object[] content) : base("tbody", content)
  {
  }

  public Tbody(Action<Tbody> innerAction) : this()
  {
    innerAction?.Invoke(this);
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

  public Td(params object[] content) : base("td", content)
  {
  }

  public Td(Action<Td> innerAction) : this()
  {
    innerAction?.Invoke(this);
  }
    public Td Colspan(int value) => this.Attr("colspan", value);

    public Td Headers(string value) => this.Attr("headers", value);

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

  public Tfoot(params object[] content) : base("tfoot", content)
  {
  }

  public Tfoot(Action<Tfoot> innerAction) : this()
  {
    innerAction?.Invoke(this);
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

  public Th(params object[] content) : base("th", content)
  {
  }

  public Th(Action<Th> innerAction) : this()
  {
    innerAction?.Invoke(this);
  }
    public Th Abbr(string value) => this.Attr("abbr", value);

    public Th Colspan(int value) => this.Attr("colspan", value);

    public Th Headers(string value) => this.Attr("headers", value);

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

  public Thead(params object[] content) : base("thead", content)
  {
  }

  public Thead(Action<Thead> innerAction) : this()
  {
    innerAction?.Invoke(this);
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

  public Tr(params object[] content) : base("tr", content)
  {
  }

  public Tr(Action<Tr> innerAction) : this()
  {
    innerAction?.Invoke(this);
  }

}
}
