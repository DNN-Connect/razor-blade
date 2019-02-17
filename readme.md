<img src="assets/razor-blade-logo.png" width="100%">

# Razor Blade v1.0 stable

A library of common functions for Razor, to lighten Razor templates and make work easier.

The goal is to provide helpers for very common code snippets or functions, which would lighten the load. Here some common examples...

_Sometimes you need the first 100 characters followed by an ellipsis (if truncated), but umlauts like `&uuml;` will mess up your count or might even be cut off. This is automatically handled by:_

```razor
  @* just cut it off at the visible character count, not splitting words *@
  @Text.Crop(someText, 100)

  @* truncate a text and if necessary, add ellipsis character *@
  @Text.Ellipsis(longText, 100)
```

_Or sometimes you need a value, but if it's empty, you need another one. So instead of writing:_

```razor
  @if(String.IsNullOrWhiteSpace(firstName as string)) {
    @"nothing found"
  } else {
    @firstName
  }
```

_You can write this, or below it the example with even more values:_

```razor
  @Text.First(firstName, "nothing found");

  @Text.First(nameFromDb, nameFromProfile, defaultNameForThisCountry, "unknown")
```

_Note that HTML whitespace like `&nbsp;` will also be treated as empty, unless you add `false` as a last parameter. But RazorBlade does more than just skip empty texts, here some more examples:_

```razor
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

1. **Tags** - see [detailed docs](readme-tags.md)
    1. `Tags.Br2Nl(text)`
    1. `Tags.Br2Space(text)`
    1. `Tags.Nl2Br(text)`
    1. `Tags.Strip(text)`
1. **Text** - see [detailed docs](readme-text.md)
    1. `Text.Crop(string, length)`
    1. `Text.Ellipsis(value, length)`
    1. `Text.Has(value)`
    1. `Text.First(value, value[, moreValues, ...])`
    1. `Text.Zip(value)`

## Ideas to discuss

1. `Tags.Strip(htmlText, csvListOfTagsToStrip)`
1. `Tags.Replace(htmlText, listOfTags, replacementTag)`
1. (place other wishes into issues for discussion)
1. `Dic.ToDynamic(dictionary)` - converts a Dictionary to an expando object, so you can write obj.Property instead of obj["Property"]; would return null if a property would not be found.

## Contributions

1. Any tests and bugfixes are always welcome and will be processed quickly by iJungleboy.
1. New commands / overloads / features should be discussed in issues before adding to this library, to ensure that it's inline with the overal purpose of this library.

Please also read the [conventions](readme-conventions.md) so we can work on this together. 