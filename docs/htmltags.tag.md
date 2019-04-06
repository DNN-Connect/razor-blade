<img src="assets/razor-blade-logo.png" width="100%">

# Razor Blade Tag Object _new in 1.3_

_return to [overview](https://github.com/DNN-Connect/razor-blade)_

## The `Tag` Object

The `Tag` object is the engine which generates HtmlTags inside _RazorBlade_ and a powerfull API will let you build html from code. These docs will give you what you need to leverage the object. Here you'll find

1. a Quick-Reference for the common API
2. more instructions for doing specific things
3. advanced API for special stuff

## Quick-Reference: `Tag` Methods with Chaining

All these methods below change the object, and return the object itself again. This allows chaining them together, like `myImg.Id("someId").Class("float-right").`

### Modifying Tag Attributes

1. `Attr(name, [value], [separator])`  
add an attribute - if it already exists, it will append the value to the existing attribute.
     * `name` _`string`, required_
     * `value` _`string` | `object` | `null`, optional_  
     `Objects` will be JSON serialized; `null` will result in the attribute being added without a value, like `disabled`
     * `separator` _`string`, default is ""_  
     Separation character if we have to append to an existing value. If null, will replace instead of append.
1. `Class(value)`  
set / add a class to the tag; if called multiple times, will append with a space between the original and new value. When calling with null, will reset the class to empty.
1. `Id(value)`  
set the id attribute - if called multiple times, will always replace previous id
1. `Style(value)`  
set / add a class to the tag; if called multiple times, will append with a semicolon `;` between the original and new value. When calling with null, will reset the id to empty.
1. `Title(value)`  
set the title attribute - if called multiple times, will always replace previous title

### Modifying the Tag Contents

1. `Add(value)`  
Add something to contents - at the end of existing content.
    * `value` _string | `Tag` | `IEnumerable<Tag>`_
1. `Wrap(value)`  
Replaces the content
    * `value` _string | `Tag` | `IEnumerable<Tag>`_

### Output/Render API

1. `@myTag`  
will render the tag into the html. Implements IHtmlString and will not be encoded.
2. `@myTag.Open`  
will render the opening tag to html. Implements IHtmlString and will not be encoded.
3. `myTag.Close`  
will render the close-tag to html. Implements IHtmlString and will not be encoded.

## How to do Common Things

### How to get Tag Objects

The following APIs will get you `Tag` objects:

1. `Tags.Tag(...)` in `Connect.Razor.Blade` ([more](tags.md))
2. `new Tag(...)` in `Connect.Razor.Blade.HtmlTags` ([more](htmltags.md))
3. `new ***(...)` in `Connect.Razor.Blade.HtmlTags` ([more](htmltags.md))

### How to Render (output) Tag Objects

All `Tag` Objects will directly output to Html since it implements `IHtmlString` both in .net 4 and .net core, so all you need is `@myTag` to render it. If you need to have the open/close tag separately, you can also use `@myTag.Open` or `@myTag.Close`. Here's an example:

```razor
@using Connect.Razor.Blade;
@Tags.Tag("br")
@Tags.Tag("div").Wrap("this is my message")
@{
  var myStyle = Tags.Tag("style");
}
@myStyle.Open
  .red { color: red};
@myStyle.Close
```

TODO CONTINUE HERE


## Using the HtmlTags API

HtmlTags is a namespace, so to start using it, you'll need to add  
`using Connect.Razor.Blade.HtmlTags;`  
into your razor file


## Tag Objects in HtmlTags _(new in 1.2)_

Note that all these tag objects are of type `Tag`, so you can do further manipulation to them as explained below:

### Basic Tags

Note that when you see `[content]`, this means you can pass in optional content into the tag. This can be a string, or another tag.

1. `Br()`
2. `Comment([content])`
3. `Div([content]`
4. `H1([content])` through `H6([content])`
5. `Hr()`
6. `P([content])`
7. `Span([content])`



### Heading Tags

1. `Meta(name, content)`
2. `MetaOg(property, content)`
3. `Icon(path [, rel, size, type])`


### WIP

1. `Script`
2. `Img`
3. `Picture`
4. etc.

## Generate Html Tags _(new in 1.2)_

1. `Tag(name, [...])` _HtmlString_ - generate an html-tag. Uses `Tags.Open(...)` and `Tags.Close(...)` internally. _v1.2_

   1. `string name` - tag name
   2. **Blocking parameter** - this one is not important, but it forces you to name all optional parameters which follow, to ensure all parameters are written like `content: "xyz"` which will allow us to update the parameters (method signature) as needed in future.
   3. `attributes (string or IEnumerable<KeyValuePair<string, string | object>>)` (optional) - attributes for this tag, as a string or dictionary
   4. `content` _string, optional_ - content between opening and closing tag
   5. `options (TagOptions)` (optional) - read more about this below

2. `.Open` _HtmlString_ - generate only an opening html-tag, for example when creating tags which don't need a close or when you want to have more control over what's happening. Also read about the optional `AttributeOptions` below. _v1.2_
   1. `string name` - tag name
   2. **Blocking parameter** - this one is not important, but it forces you to name all optional parameters which follow, to ensure all parameters are written like `content: "xyz"` which will allow us to update the parameters (method signature) as needed in future.
   3. `attributes (string or IEnumerable<KeyValuePair<string, string>>)` (optional) - attributes for this tag, as a string or dictionary
   4. `options` _TagOptions, optional_ - read more about this below

3. `.Close` _HtmlString_ - generate a close tag  _v1.2_


## Convert Html to Text or Back

1. `Tags.Strip(htmlText)` - strips the html from an string, ensuring that all tags will cause 1 spaces between words, but only one (multiple spaces are shortened to 1 again)

2. `Tags.Br2Nl(text)` - replaces all kinds of `<br>` tags with new-line `\n`

3. `Tags.Br2Space(text)` - replaces all kinds of `<br>` with spaces

4. `Tags.Nl2Br(text)` - replaces all kinds of new-line (`\n`, `\r`) with `<br>`



## Options When Generating Attributes and Tags

Options like `AttributeOptions` and `TagOptions` are an optional parameter in all generator-commands. It allows you to change how attributes are generated, but remember that the default is well thought through, so you usually won't need to use it.

### AttributeOptions _(new in 1.2)_

The object has the following properties and defaults:

1. `Quote` _string, default=`_ - the quote character used for wrapping values. The single-quote is the default, as it allows you to place json (which has double-quotes) in the value without having to encode the double quotes

2. `EncodeQuotes` _boolean, default=false_ - determines if quote-characters inside the value should be encoded when not necessary. So by default `data='{"key":"value"}` is what you get, but if you set it to true, you get `data='{&quot;key&quot;:&quot;value&quot;}`.

3. `KeepEmpty` _boolean, default=true_ - determines if empty attributes like `data` in `<div data=''></div>` are actually placed in the html, or filtered out.

This is how you would use these:

```razor
@* Example without options *@
<div @Attribute("data", "45")>...</div>

@* Example with options directly *@
<div @Attribute("data", "45", new AttributeOptions { KeepEmpty = false })>

@* Example with using options multiple times *@
@{
  var options = new AttributeOptions {
    Quotes = "\"",
    EncodeQuotes = false
  };
}
<div @Attribute("data", "45", options)></div>
```

### TagOptions _(new in 1.2)_ - todo!