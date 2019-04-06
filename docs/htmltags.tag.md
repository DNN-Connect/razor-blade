<img src="assets/razor-blade-logo.png" width="100%">

# Razor Blade Tag Object _new in 1.3_

_return to [overview](https://github.com/DNN-Connect/razor-blade)_

## The `Tag` Object

The `Tag` object is the engine which generates HtmlTags inside _RazorBlade_ and a powerfull API will let you build html from code. These docs will give you what you need to leverage the object. Here you'll find

1. a Quick-Reference for the common API
2. more instructions for doing specific things
3. advanced API for special stuff

To see this in action with many examples, visit the [RazorBlade Tutorials](https://2sxc.org/dnn-tutorials/en/razor/blade/home) on [2sxc.org](https://2sxc.org/).

## Quick-Reference: Fluent `Tag` Methods with Chaining

All these methods below change the object, and return the object itself again. This fluent-API allows chaining them together, like `myImg.Id("someId").Class("float-right")`. Remember that you will need to include this namespace:  
`@using Connect.Razor.Blade.HtmlTags;`

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
1. `Data(name, [value])`  
will add a `data-{name}='value'` attribute.
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

## Advanced `HtmlTags.Tag` API

The `Tag` object lies in the `Connect.Razor.Blade.HtmlTags`  namespace, so to start using it, you'll need to add  
`using Connect.Razor.Blade.HtmlTags;`.

## `Tag` Constructors

In most cases you'll use `Tags.Tag(...)` ([more](tags.md)) to create a tag, since it's nicer. But for advanced cases, you can use one of these constructors:

1. `new Tag(name)`  
1. `new Tag(name, content)`  
1. `new Tag(name, options)`  
1. `new Tag(name, content, options)`  

The parameters in the constructors are:

* `name` _`string`_  
Tag name, usually `"div"` or similar, but you can also supply a full tag like `<!-- xyz -->` in which case this is treated as a _verbatim_ tag and it will simply ignore any attributes/content added to it.
* `content` _`string | Tag | IEnumerable<Tag>`_  
Stuff to put inside the tag, which can be more tags, text or anything.
* `options` _`TagOptions`_  
Options which affect how the tag will be rendered - usually you won't need this.

### `Tag` Properties (beta)

These properties are for doing advanced stuff and not to be treated as final. We prefixed all the names with _Tag_ so the tag name is _not_ Name, but `TagName`. This ensuresinheriting objects (like `Meta`) can still have a property _Name_ without running into conflicts.

1. `TagAttributes` _`AttributeList`_ - all the attributes in this tag
2. `TagChildren` _`TagList`_ - all the child nodes of this tag
3. `TagContents` _`string` get/set_ - if you get it, it will return the serialized content of the tag, if you set it, it will replace everything that's already in this tag.
4. `TagName` _`string` get/set_
5. `TagOverride` _`string` get/set, default `null`_ if not null will be rendered instead of what's normally in the tag. This is used for _verbatim_ tags like comments.

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


## Options When Generating Attributes and Tags

Options like `AttributeOptions` and `TagOptions` are an optional parameter in all generator-commands. It allows you to change how attributes are generated, but remember that the default is well thought through, so you usually won't need to use it.

### AttributeOptions _(new in 1.3)_

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