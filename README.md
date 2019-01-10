
<img src="assets/razor-blade-logo.png" width="100%">

# Razor Blade v0.1 beta

A library of common functions for Razor, to lighten Razor templates and make work easier.

The goal is to provide helpers for very common code snippets or functions, which would lighten the load. Here some common examples...

_Sometimes you need the first 100 characters followed by an ellipsis (if truncated), but umlauts like `&uuml;` will mess up your count or might even be cut off. This is automatically handled by:_

```razor
  @Text.Crop(someText, 100)
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
  @Text.First(firstName, "John");

  @Text.First(nameFromDb, nameFromProfile, defaultNameForThisCountry, "unknown")
```

_Note that HTML whitespace like `&nbsp;` will also be treated as empty, unless you add `false` as a last parameter. But RazorBlade does more than just skip empty texts, here some more examples:_

```razor
  @* remove html from a wysiwyg-string *@
  @Tags.Remove(formattedText)

  @* truncate a text and if necessary, add ellipsis character *@
  @Text.Ellipsis(longText, 100)

  @* the same with a custom ending *@
  @Text.Ellipsis(longText, 100, "...more")

  @* an it won't cut off in the middle of &auml; *@
  @Text.Ellipsis("Visit M&uuml;nchen", 10)

```

## Using Razor Blade

First, install the DNN-module from the [releases on Github](https://github.com/DNN-Connect/razor-blade/releases).

In your c# code, add the following line to then have access to all the commands:

```razor
@using Connect.Razor.Blade;
```

## Quick Command Reference Sheet v0.1

This is a short summary of the most used variations of the helpers. Further details and syntaxes are listed further down. 

1. **Tags**
    1. `Tags.Br2Nl(text)`
    1. `Tags.Br2Space(text)`
    1. `Tags.Nl2Br(text)`
    1. `Tags.Remove(text)`
1. **Text**
    1. `Text.Crop(string, length)`
    1. `Text.Ellipsis(value, length)`
    1. `Text.Has(value)`
    1. `Text.First(value, value[, moreValues, ...])`

## Commands in v0.1 to Shorten Texts Correctly

1. `Text.Crop(value, length)` - will cut off the text at the best place, but maximum length as specified. Special behavior is that html-entities and umlauts (like `&nbsp;` or `&uuml;`) are treated as one character, and it will try to not cut off a word in the middle of the word, but backtrack to the previous space.

1. `Text.Ellipsis(value, length)` - will show value, and if it's longer than max-length, will go add an "..."-character (`&hellip;`) instead

1. `Text.Ellipsis(value, length, suffix)` - same as the simple one, but you can specify what should be added

### Commands to Check for Real Text-Contents

1. `Text.Has(someObjectOrString)` - true if it has real text, false if it's null, not a string, an empty string or a string containing just whitespace and/or html-whitespaces like `&nbsp;` or `&#160;`

1. `Text.Has(someObjectOrString, false)` - true if it has real text, false if it's null, not a string, an empty string or a string containing just whitespace. Html-Whitespace is treated as real text in this case.

1. `Text.First(intendedValue, fallbackIfEmpty)` - returns the first text if it has content, otherwise the fallback. Will treat html-whitespace like `&nbsp;` as a space (empty)

1. `Text.First(intendedValue, fallbackIfEmpty, false)` - same as before, but will treat html-whitespace as real text

1. `Text.First(intendedValue, next-value, next-value, [up to 5 values])` - same behavior as above, values will be checked in the order given.

1. `Text.First(intendedValue, next-value, next-value, [up to 5 values], false)` - same behavior as above, values will be checked in the order given. By ending with `false` html-whitespace will not be cleaned but treated as text.

## Commands in v0.1 to Convert Html to Text or Back

1. `Tags.Remove(htmlText)` - strips the html from an string, ensuring that all tags will cause 1 spaces between words, but only one (multiple spaces are shortened to 1 again)

1. `Tags.Br2Nl(text)` - replaces all kinds of `<br>` tags with new-line `\n`

1. `Tags.Br2Space(text)` - replaces all kinds of `<br>` with spaces

1. `Tags.Nl2Br(text)` - replaces all kinds of new-line (`\n`, `\r`) with `<br>`

## Ideas to discuss

1. `Tags.Remove(htmlText, csvListOfTagsToRemove)`
1. `Tags.Replace(htmlText, listOfTags, replacementTag)`
1. (place other wishes into issues for discussion)
1. `Dic.ToDynamic(dictionary)` - converts a Dictionary to an expando object, so you can write obj.Property instead of obj["Property"]; would return null if a property would not be found.

## Namespace Conventions

We want to be sure that this is super easy to use, but that as the library grows, we can "fix" mistakes made in previous versions. For example, assume we called a method `ToDynamic(...)` and later found out that this is confusing, and wanted to rename it to `DynamicDictionary(...)`. Within a short time we would have a lot of confusing commands and names, or otherwise updates would break something. So the basic idea is as follows:

1. The initial release is in the Namespace `Connect.Razor.Blade` with static classes like `Text` or `Tags`. When using this, a developer will have a using-statement `@using Connect.Razor.Blade;` and just write `@Tags.Remove(...)`.

1. New commands etc. would be added, enhanced and if everything works well, we'll stay on V1 forever.

1. If one day the inconsistencies become too confusing, we'll create a `Connect.Razor.Blade2` with newer, cleaned up command names.

1. This setup should allow us deploy multiple APIs side-by-side and grow new features, without breaking old stuff.

## Naming Conventions

This library should grow, so we must think ahead how we name our methods to ensure that they are consistent. Here are the guidelines as of now:

1. Abbreviations like HTML are written as Html
1. Most commands will be a object.verb or object.question, for example
    * Text.Crop
    * Tags.Remove

## Testing Conventions

We want to deliver something super-reliable, so every method must have tests to validate them, and ensure that edge cases are also handled. 