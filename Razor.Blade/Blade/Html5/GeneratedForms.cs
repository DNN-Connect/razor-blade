using System;
using Connect.Razor.Blade.HtmlTags;
// ****
// ****
// This is auto-generated code - don't modify
// Re-run the generation program to recreate
// Created 15.10.2019 10:17
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
  /// Generate a standard button tag
  /// </summary>
public partial class Button : Tag
{

  public Button(object content = null) : base("button", content)
  {
  }

  public Button(params object[] content) : base("button", null, content)
  {
  }
    public Button Autofocus(string value) => this.Attr("autofocus", value);



    public Button Autofocus() => this.Attr("autofocus");

    public Button Disabled(string value) => this.Attr("disabled", value);



    public Button Disabled() => this.Attr("disabled");

    public Button Form(string value) => this.Attr("form", value);



    public Button Formaction(string value) => this.Attr("formaction", value);



    public Button Formenctype(string value) => this.Attr("formenctype", value);



    public Button Formmethod(string value) => this.Attr("formmethod", value);



    public Button Formnovalidate(string value) => this.Attr("formnovalidate", value);



    public Button Formnovalidate() => this.Attr("formnovalidate");

    public Button Formtarget(string value) => this.Attr("formtarget", value);



    public Button Name(string value) => this.Attr("name", value);



    public Button Type(string value) => this.Attr("type", value);



    public Button Value(string value) => this.Attr("value", value);




}

  /// <summary>
  /// Generate a standard datalist tag
  /// </summary>
public partial class Datalist : Tag
{

  public Datalist(object content = null) : base("datalist", content)
  {
  }

  public Datalist(params object[] content) : base("datalist", null, content)
  {
  }

}

  /// <summary>
  /// Generate a standard fieldset tag
  /// </summary>
public partial class Fieldset : Tag
{

  public Fieldset(object content = null) : base("fieldset", content)
  {
  }

  public Fieldset(params object[] content) : base("fieldset", null, content)
  {
  }
    public Fieldset Disabled(string value) => this.Attr("disabled", value);



    public Fieldset Disabled() => this.Attr("disabled");

    public Fieldset Form(string value) => this.Attr("form", value);



    public Fieldset Name(string value) => this.Attr("name", value);




}

  /// <summary>
  /// Generate a standard form tag
  /// </summary>
public partial class Form : Tag
{

  public Form(object content = null) : base("form", content)
  {
  }

  public Form(params object[] content) : base("form", null, content)
  {
  }
    public Form AcceptCharset(string value) => this.Attr("accept-charset", value);



    public Form Action(string value) => this.Attr("action", value);



    public Form Autocomplete(string value) => this.Attr("autocomplete", value);



    public Form Enctype(string value) => this.Attr("enctype", value);



    public Form Method(string value) => this.Attr("method", value);



    public Form Name(string value) => this.Attr("name", value);



    public Form Novalidate(string value) => this.Attr("novalidate", value);



    public Form Novalidate() => this.Attr("novalidate");

    public Form Target(string value) => this.Attr("target", value);




}

  /// <summary>
  /// Generate a standard input tag
  /// </summary>
public partial class Input : Tag
{

  public Input() : base("input", new TagOptions { Close = false })
  {
  }

  public Input(params object[] content) : base("input", new TagOptions { Close = false }, content)
  {
  }
    public Input Accept(string value) => this.Attr("accept", value);



    public Input Alt(string value) => this.Attr("alt", value);



    public Input Autocomplete(string value) => this.Attr("autocomplete", value);



    public Input Autofocus(string value) => this.Attr("autofocus", value);



    public Input Autofocus() => this.Attr("autofocus");

    public Input Checked(string value) => this.Attr("checked", value);



    public Input Checked() => this.Attr("checked");

    public Input Dirname(string value) => this.Attr("dirname", value);



    public Input Disabled(string value) => this.Attr("disabled", value);



    public Input Disabled() => this.Attr("disabled");

    public Input Form(string value) => this.Attr("form", value);



    public Input Formaction(string value) => this.Attr("formaction", value);



    public Input Formenctype(string value) => this.Attr("formenctype", value);



    public Input Formmethod(string value) => this.Attr("formmethod", value);



    public Input Formnovalidate(string value) => this.Attr("formnovalidate", value);



    public Input Formnovalidate() => this.Attr("formnovalidate");

    public Input Formtarget(string value) => this.Attr("formtarget", value);



    public Input Height(string value) => this.Attr("height", value);



    public Input List(string value) => this.Attr("list", value);



    public Input Max(string value) => this.Attr("max", value);



    public Input Maxlength(string value) => this.Attr("maxlength", value);



    public Input Min(string value) => this.Attr("min", value);



    public Input Multiple(string value) => this.Attr("multiple", value);



    public Input Multiple() => this.Attr("multiple");

    public Input Name(string value) => this.Attr("name", value);



    public Input Pattern(string value) => this.Attr("pattern", value);



    public Input Placeholder(string value) => this.Attr("placeholder", value);



    public Input Readonly(string value) => this.Attr("readonly", value);



    public Input Readonly() => this.Attr("readonly");

    public Input Required(string value) => this.Attr("required", value);



    public Input Required() => this.Attr("required");

    public Input Size(string value) => this.Attr("size", value);



    public Input Src(string value) => this.Attr("src", value);



    public Input Step(string value) => this.Attr("step", value);



    public Input Type(string value) => this.Attr("type", value);



    public Input Value(string value) => this.Attr("value", value);



    public Input Width(string value) => this.Attr("width", value);




}

  /// <summary>
  /// Generate a standard label tag
  /// </summary>
public partial class Label : Tag
{

  public Label(object content = null) : base("label", content)
  {
  }

  public Label(params object[] content) : base("label", null, content)
  {
  }
    public Label For(string value) => this.Attr("for", value);



    public Label Form(string value) => this.Attr("form", value);




}

  /// <summary>
  /// Generate a standard legend tag
  /// </summary>
public partial class Legend : Tag
{

  public Legend(object content = null) : base("legend", content)
  {
  }

  public Legend(params object[] content) : base("legend", null, content)
  {
  }

}

  /// <summary>
  /// Generate a standard optgroup tag
  /// </summary>
public partial class Optgroup : Tag
{

  public Optgroup(object content = null) : base("optgroup", content)
  {
  }

  public Optgroup(params object[] content) : base("optgroup", null, content)
  {
  }
    public Optgroup Disabled(string value) => this.Attr("disabled", value);



    public Optgroup Disabled() => this.Attr("disabled");

    public Optgroup Label(string value) => this.Attr("label", value);




}

  /// <summary>
  /// Generate a standard option tag
  /// </summary>
public partial class Option : Tag
{

  public Option(object content = null) : base("option", content)
  {
  }

  public Option(params object[] content) : base("option", null, content)
  {
  }
    public Option Disabled(string value) => this.Attr("disabled", value);



    public Option Disabled() => this.Attr("disabled");

    public Option Label(string value) => this.Attr("label", value);



    public Option Selected(string value) => this.Attr("selected", value);



    public Option Selected() => this.Attr("selected");

    public Option Value(string value) => this.Attr("value", value);




}

  /// <summary>
  /// Generate a standard output tag
  /// </summary>
public partial class Output : Tag
{

  public Output(object content = null) : base("output", content)
  {
  }

  public Output(params object[] content) : base("output", null, content)
  {
  }
    public Output For(string value) => this.Attr("for", value);



    public Output Form(string value) => this.Attr("form", value);



    public Output Name(string value) => this.Attr("name", value);




}

  /// <summary>
  /// Generate a standard select tag
  /// </summary>
public partial class Select : Tag
{

  public Select(object content = null) : base("select", content)
  {
  }

  public Select(params object[] content) : base("select", null, content)
  {
  }
    public Select Autofocus(string value) => this.Attr("autofocus", value);



    public Select Autofocus() => this.Attr("autofocus");

    public Select Disabled(string value) => this.Attr("disabled", value);



    public Select Disabled() => this.Attr("disabled");

    public Select Form(string value) => this.Attr("form", value);



    public Select Multiple(string value) => this.Attr("multiple", value);



    public Select Multiple() => this.Attr("multiple");

    public Select Name(string value) => this.Attr("name", value);



    public Select Required(string value) => this.Attr("required", value);



    public Select Required() => this.Attr("required");

    public Select Size(string value) => this.Attr("size", value);




}

  /// <summary>
  /// Generate a standard textarea tag
  /// </summary>
public partial class Textarea : Tag
{

  public Textarea(object content = null) : base("textarea", content)
  {
  }

  public Textarea(params object[] content) : base("textarea", null, content)
  {
  }
    public Textarea Autofocus(string value) => this.Attr("autofocus", value);



    public Textarea Autofocus() => this.Attr("autofocus");

    public Textarea Cols(string value) => this.Attr("cols", value);



    public Textarea Dirname(string value) => this.Attr("dirname", value);



    public Textarea Disabled(string value) => this.Attr("disabled", value);



    public Textarea Disabled() => this.Attr("disabled");

    public Textarea Form(string value) => this.Attr("form", value);



    public Textarea Maxlength(string value) => this.Attr("maxlength", value);



    public Textarea Name(string value) => this.Attr("name", value);



    public Textarea Placeholder(string value) => this.Attr("placeholder", value);



    public Textarea Readonly(string value) => this.Attr("readonly", value);



    public Textarea Readonly() => this.Attr("readonly");

    public Textarea Required(string value) => this.Attr("required", value);



    public Textarea Required() => this.Attr("required");

    public Textarea Rows(string value) => this.Attr("rows", value);



    public Textarea Wrap(string value) => this.Attr("wrap", value);




}
}
