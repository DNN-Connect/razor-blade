<img src="assets/razor-blade-logo.png" width="100%">

# Razor Blade Html API _new in 1.2_

_return to [overview](https://github.com/DNN-Connect/razor-blade)_

## Introduction to the Html API

Building valid HTML can be difficult, especially when you have attributes containing dangerous characters like `'` and `"`, which is common both in JSON attributes as well as when you need attributes based on content added by editors. So we created an extensive API to generate safe html and encode things optimally - this is what this is for. Here's a basic example:

```razor
@using Connect.Razor.Blade.Html;
@{
  var wrapper = new Div { Classes="box" };
}
@wrapper.Open
  Nice content
@wrapper.Close
```

_Note: If you're looking for the API to manipulate html strings, like for stripping away all tags or encoding/decoding Html, check out the [Tags API](tags.md)_

## Using the Html API

Html is a namespace, so to start using it, you'll need to add  
`using Connect.Razor.Blade.Html;`  
into your razor file

## Generate Html Attributes _(new in 1.2)_

The following commands may seem unnecessary, but there are many cases where your code needs to _build_ html tags safely, and ensure that attributes etc. are encoded just right as an _HtmlString_. So you might just use `<div @Tags.Attribute(...)>` or all of these as you need.

1. `Tags.Attribute(name, value, [options])` _HtmlString_ - generate a correctly encoded and prepared attribute, for something like `<div @Tags.Attribute("data", "doesn't this value cause trouble with apos?")>`. Note that it will by default place attributes in single-quote values (`name='value'`) because this shortens json-data, which is fairly common in attributes. _v1.2_
   1. `name` _string_  
   attribute name
   1. `value` _string | object_  
   attribute value; objects will be serialized to json
   1. `options (AttributeOptions)` (optional)  
   read more about this below

2. `Tags.Attributes(attributes, [options])` _HtmlString_ - generate a string for a list of attributes.  Also read about the optional `AttributeOptions` below. _v1.2_
   1. `attributes (IEnumerable<KeyValuePair<string, string | object>>)`  
   list of attributes, objects are json-serialized  
   you'll usually pass in a `Dictionary`
   1. `options (AttributeOptions)` (optional)  
   read more about this below


## Generate Html Tags _(new in 1.2)_

1. `Tags.Tag(name, [...])` _HtmlString_ - generate an html-tag. Uses `Tags.Open(...)` and `Tags.Close(...)` internally. _v1.2_

   1. `string name` - tag name
   2. **Blocking parameter** - this one is not important, but it forces you to name all optional parameters which follow, to ensure all parameters are written like `content: "xyz"` which will allow us to update the parameters (method signature) as needed in future.
   3. `attributes (string or IEnumerable<KeyValuePair<string, string | object>>)` (optional) - attributes for this tag, as a string or dictionary
   4. `content` _string, optional_ - content between opening and closing tag
   5. `options (TagOptions)` (optional) - read more about this below

2. `Tags.Open(name, [...])` _HtmlString_ - generate only an opening html-tag, for example when creating tags which don't need a close or when you want to have more control over what's happening. Also read about the optional `AttributeOptions` below. _v1.2_
   1. `string name` - tag name
   2. **Blocking parameter** - this one is not important, but it forces you to name all optional parameters which follow, to ensure all parameters are written like `content: "xyz"` which will allow us to update the parameters (method signature) as needed in future.
   3. `attributes (string or IEnumerable<KeyValuePair<string, string>>)` (optional) - attributes for this tag, as a string or dictionary
   4. `options` _TagOptions, optional_ - read more about this below

3. `Tags.Close(string name)` _HtmlString_ - generate a close tag  _v1.2_


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