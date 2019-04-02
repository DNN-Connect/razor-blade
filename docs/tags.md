<img src="assets/razor-blade-logo.png" width="100%">

# Razor Blade Tags API

_return to [overview](https://github.com/DNN-Connect/razor-blade)_

## Encode/Decode Html _(new in 1.2)_

1. `Tags.Encode(string value)` _string_ - html-encodes a string _v1.2_

1. `Tags.Decode(string value)` _string_ - html-decodes a string _v1.2_

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