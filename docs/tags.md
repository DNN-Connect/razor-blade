<img src="assets/razor-blade-logo.png" width="100%">

_return to [overview](https://github.com/DNN-Connect/razor-blade)_

# Razor Blade Tags API

The Tags-API is for manipulating strings which contain html or should contain html - like stripping away tags, converting `<br>` tags to new-lines and similar.

## Convert Html to Text or Back

1. `Tags.Strip(htmlText)` _string_ - strips the html from an string, ensuring that all tags will cause 1 spaces between words, but only one (multiple spaces are shortened to 1 again)

1. `Tags.Br2Nl(text)` _string_ - replaces all kinds of `<br>` tags with new-line `\n`

1. `Tags.Br2Space(text)` _string_ - replaces all kinds of `<br>` with spaces

1. `Tags.Nl2Br(text)` _string_ - replaces all kinds of new-line (`\n`, `\r`) with `<br>`

1. `Tags.Encode(string value)` _string_ - html-encodes a string _v1.2_

1. `Tags.Decode(string value)` _string_ - html-decodes a string _v1.2_

## Generate Html Attributes and Tags _(new in 2.0)_

The following commands may seem unnecessary, but there are many cases where your code needs to _build_ html tags safely, and ensure that attributes etc. are encoded just right as an `Html.Attribute` which is also an `IHtmlString`. So you might just use `<div @Tags.Attribute(...)>` or all of these as you need.

1. `Tags.Attribute(name, value, [options])` _[Html.Attribute : IHtmlString](html.md)_ - generate a correctly encoded and prepared attribute, for something like `<div @Tags.Attribute("data", "doesn't this value cause trouble with apos?")>`. Note that it will by default place attributes in single-quote values (`name='value'`) because this shortens json-data, which is fairly common in attributes. _v1.2_
   1. `name` _string_  
   attribute name
   1. `value` _string | object_  
   attribute value; objects will be serialized to json
   1. `options (Html.AttributeOptions)` (optional)  
   [read more](html.md)

<!-- 2. `Tags.Attributes(attributes, [options])` _[Html.AttributeList : IHtmlString](html.md)_ - generate a string for a list of attributes.  Also read about the optional `AttributeOptions` below. _v1.2_
   1. `attributes (IEnumerable<KeyValuePair<string, string | object>>)`  
   list of attributes, objects are json-serialized  
   you'll usually pass in a `Dictionary<string, string>`
   1. `options (Html.AttributeOptions)` (optional)  
   [read more](html.md) -->

2. `Tags.Tag(name, [content])`  
generate a [Tag](htmltags.tag.md) object which can be used like these brief examples ([more](htmltags.tag.md)):  
`@Tags.Tag("div")`  
`@Tags.Tag("div", "inner content")`  
`@Tags.Tag("div").Id("box").Wrap("inner message")`  
    * `name` _`string`_ tag name
    * `content` _`string | object | null`_ what's inside the tag