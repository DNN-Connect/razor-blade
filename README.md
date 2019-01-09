
<img src="assets/razor-blade-logo.png" width="100%">

# Razor Blade

A library of common functions for Razor, to lighten Razor templates and make work easier. 

The goal is to provide helpers for very common code snippets or functions, which would lighten the load. Here's an example:

Write this:

```razor
  @Fallback(firstName, "nothing found");
```

Instead of this:

```razor
  @if(String.IsNullOrWhiteSpace(firstName as string)) {
    @"nothing found"
  } else {
    @firstName
  }
```

## Using Razor Blade

In your c# code, add the following line to then have access to all the commands in V1:

```razor
@using Connect.Razor.V1.Blade;
```

## Commands in V1

1. `HasText(someObjectOrString)` - true if it has real text, false if it's null, not a string, an empty string or a string containing just whitespace and/or html-whitespaces like `&nbsp;` or `&#160;`

1. `HasText(someObjectOrString, false)` - true if it has real text, false if it's null, not a string, an empty string or a string containing just whitespace. Html-Whitespace is treated as real text in this case
1. `FirstText(intendedValue, fallbackIfEmpty)` - returns the first text if it has content, otherwise the fallback. Will treat html-whitespace like `&nbsp;` as a space (empty)
1. `FirstText(intendedValue, fallbackIfEmpty, false)` - same as before, but will treat html-whitespace as real text
1. `FirstText(intendedValue, next-value, next-value, [up to 5 values], false)` - same behavior as above, values will be checked in the order given. By ending with `false` html-whitespace will not be cleaned but treated as text.

1. `FirstText(intendedValue, next-value, next-value, [up to 5 values])` - same behavior as above, values will be checked in the order given.
1. `Ellipsis(valToShow, maxLength)` - will show value, and if it's longer than max-length, will go add an "..."-character instead
1. `Ellipsis(valToShow, maxLength, customEllipsis)` - same as the simple one, but you can specify what should be added
1. `StripHtml(html)` - strips the html from an string
1. `ToDynamic(dictionary)` - converts a Dictionary to an expando object, so you can write obj.Property instead of obj["Property"]

## WIP

1. `@If(condition, value)` - nicer shorthand for @(condition ? value : "")
1. `@If(condition, value, otherwise)` - nicer shorthand for @(condition ? value : otherwise)
1. `@Switch...`

## Namespace Conventions

We want to be sure that this is super easy to use, but that as the library grows, we can "fix" mistakes made in previous versions. For example, assume we called a method `ToDynamic(...)` and later found out that this is confusing, and wanted to rename it to `DynamicDictionary(...)`. Within a short time we would have a lot of confusing commands and names, or otherwise updates would break something. So the basic idea is as follows:

1. The initial release is in the Namespace `Connect.Razor.V1` with the static class `Blade`. When using this, a developer can either have a using-statement `@using Connect.Razor.V1.Blade;` and just write `@StripHtml(...)` _or_ they could have a `@using Connect.Razor.V1;` and then write `@Blade.StripHTML(...)`.
1. New commands etc. would be added, enhanced and if everything works well, we'll stay on V1 forever.
1. If one day the inconsistencies become too confusing, we'll create a `Connect.Razor.V2` with newer, cleaned up command names.
1. This setup should allow us deploy multiple APIs side-by-side and grow new features, without breaking old stuff. 

## Naming Conventions

This library should grow, so we must think ahead how we name our methods to ensure that they are consistent. Here are the guidelines as of now:

1. Abbreviations like HTML are written as Html
1. Most commands will be a verb-object or a question-object combination, for example
    * SplitText
    * StripHtml
    * HasHtml
1. The verbs / questions currently recommended are
    * Has...
    * Get...
1. The object terms currently recommended are
    * ...Text - this means real text-contents, so a null-string on `HasText(someString)` will report as `false`.
