
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

## Here are the commands so far:

1. `HasText(someObjectOrString)` - true if it has real text, basically a reversed shorthand for IsNullOrWhiteSpace with type-check for non-strings
1. `ShowText(intendedValue, fallbackIfEmpty)`
1. `ShowText(intendedValue, next-value, next-value, ..., fallbackIfEmpty)`
1. `Ellipsis(valToShow, maxLength)` - will show value, and if it's longer than max-length, will go add an "..."-character instead
1. `Ellipsis(valToShow, maxLength, customEllipsis)` - same as the simple one, but you can specify what should be added
1. `StripHtml(html)` - strips the html from an string
1. `ToDynamic(dictionary)` - converts a Dictionary to an expando object, so you can write obj.Property instead of obj["Property"]

## WIP
1. `@If(condition, value)` - nicer shorthand for @(condition ? value : "")
1. `@If(condition, value, otherwise)` - nicer shorthand for @(condition ? value : otherwise)
2. `@Switch...