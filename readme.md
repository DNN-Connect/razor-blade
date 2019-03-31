<img src="docs/assets/razor-blade-logo.png" width="100%">

# Razor Blade v1.1 stable

A library of common functions for Razor, to lighten Razor templates and make work easier. Some examples:

_You need to change the page title and some headers from a razor template:_

```razor
@using Connect.Razor.Blade;
HtmlPage.Title = "Title changed using Razor Blade! original";
HtmlPage.Description = "Learn to use Razor Blade " + HtmlPage.Description;
HtmlPage.Keywords = "Tutorial, Razor, Blade" + HtmlPage.Keywords;
HtmlPage.AddMeta("somename", "somevalue");
```

_You need the first 100 characters followed by an ellipsis (if truncated), but umlauts like `&uuml;` will mess up your count or might even be cut off. This is automatically handled by:_

```razor
  @* just cut it off at the visible character count, not splitting words *@
  @Text.Crop(someText, 100)

  @* truncate a text and if necessary, add ellipsis character *@
  @Text.Ellipsis(longText, 100)

  @* now the same thing, with text having html-tags *@
  @Text.Ellipsis(Tags.Strip(longText), 100)
```

_You need a value, but if it's empty (null, spaces, line-breaks, `&nbsp;` etc.), you need another one:_

```razor
  @* Do this *@
  @Text.First(firstName, "nothing found");

  @* instead of this *@
  @if(String.IsNullOrWhiteSpace(firstName as string)) {
    @"nothing found"
  } else {
    @firstName
  }
```

_Note that HTML whitespace like `&nbsp;` will also be treated as empty, unless you add `false` as a last parameter. But RazorBlade does more than just skip empty texts, here some more examples:_

```razor
  @* First non-empty of many possible values *@
  @Text.First(nameFromDb, nameFromProfile, defaultNameForThisCountry, "unknown")

  @* remove html from a wysiwyg-string *@
  @Tags.Strip(formattedText)

  @* the same with a custom ending *@
  @Text.Ellipsis(longText, 100, "...more")

  @* an it won't cut off in the middle of &auml; *@
  @Text.Ellipsis("Visit M&uuml;nchen", 10)

```

## Using Razor Blade

You can use **Razor Blade** with any asp.net project, just by including the DLLs, or if you're using DNN, you can install the extension from the [releases on Github](https://github.com/DNN-Connect/razor-blade/releases). Note that if you are have [2sxc](https://github.com/2sic/2sxc) 9.40+ installed, it will automatically also install Razor Blade.

In your c# code, add the following line to then have access to all the commands:

```razor
@using Connect.Razor.Blade;
```

We have also created a [Razor Blade tutorial app](https://github.com/DNN-Connect/razor-blade-tutorial-app).

## Quick Command Reference Sheet

This is a short summary of the most used variations of the helpers. Further details and syntaxes are listed further down.

1. **Tags** - see [detailed docs](docs/tags.md)
    1. Basic tag generation helpers _(new in 1.2)_
       1. `Tags.Attribute(name, value, [options])`
       1. `Tags.Attributes(attributesList, [options])`
       1. `Tags.Open(name, [...])`
       1. `Tags.Close(name)`
       1. `Tags.Tag(name, [...])`
    1. Html Encoding / Decoding
       1. `Tags.Encode(value)`
       1. `Tags.Decode(value)`
    1. Working with spaces and similar
       1. `Tags.Br2Nl(text)`
       2. `Tags.Br2Space(text)`
       3. `Tags.Nl2Br(text)`
       4. `Tags.Strip(text)`
    1. `Tags.Page` (better performance if used many times)
2. **Text** - see [detailed docs](docs/text.md)
    1. `Text.Crop(string, length)`
    2. `Text.Ellipsis(value, length)`
    3. `Text.Has(value)`
    4. `Text.First(value, value[, moreValues, ...])`
    5. `Text.Zip(value)`
3. **HtmlPage** - for v1.1 see [detailed docs](docs/htmlpage.md)
    1. `HtmlPage.Title` get-set property
    2. `HtmlPage.Description` get-set property
    3. `HtmlPage.Keywords` get-set property
    4. `HtmlPage.AddMeta(name, content)` add a meta-tag to the header
    5. `HtmlPage.AddJsonLd(string|object)` create a [Json-LD header](https://en.wikipedia.org/wiki/JSON-LD) see also [google guideline](https://developers.google.com/search/docs/guides/intro-structured-data)
    6. `AddOpenGraph(property, content)` add an [open-graph tag](http://ogp.me/) to the header for facebook, twitter and co.
    7. `AddToHead(tagString)` add any tag string into the page `<head>` section
    8. `GetPage()` (WIP)


## Work in Progress v1.1 (WIP / in discussion)

1. **Url**
    1. SeoFragment(string) - in discussion, would take a string and save-convert it so it can be added to a url for SEO.
    1. AddParameters(...) - would add more url-parameters, and ensure that it only has one ? etc.

## Ideas to discuss

1. `Tags.Strip(htmlText, tagName)`
1. `Tags.Strip(htmlText, csvListOfTagsToStrip)`
1. `Tags.Wrap(tagName, content, id, cls, attr)` - something which puts a tag (like a div, span, p) around some content
1. `Tags.Replace(htmlText, listOfTags, replacementTag)`
1. (place other wishes into issues for discussion)
1. `Dic.ToDynamic(dictionary)` - converts a Dictionary to an expando object, so you can write `obj.Property` instead of `obj["Property"]`; would return null if a property would not be found.
1. `Mail.Generate(pathToRazor, objValues)` - uses a razor template to generate a mail.

Here you can also find [scrapped ideas](docs/scrapped.md).

## Your Contributions

1. Any tests and bugfixes are always welcome and will be processed quickly by iJungleboy.
1. New commands / overloads / features should be discussed in issues before adding to this library, to ensure that it's inline with the overal purpose of this library.

Please also read the [conventions](docs/conventions.md) so we can work on this together.