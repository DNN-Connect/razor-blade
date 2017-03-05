# Razor Helpers
A library of helpers for Razor, to lighten Razor templates and make work easier. 

The goal is to provide helpers for very common code snippets or functions, which would lighten the load. Here's an example:

Write this:
```razor
@using Connect.RazorHelpers;
<div>
  @Fallback(firstName, "nothing found");
</div>
```

Instead of this:
```razor
<div>
  @if(String.IsNullOrWhiteSpace(firstName)) {
    @"nothing found"
  } else {
    @firstName
  }
</div>
```

Here are the commands so far:

1. `HasText(someObjectOrString)` - true if it has real text, basically a reversed shorthand for IsNullOrWhiteSpace
1. `Fallback(intendedValue, fallbackIfEmpty)`
1. `Fallback(intendedValue, fallbackIfEmpty, nextFallback, (optional) nextFallback, (optional) nextFallback, (optional) nextFallback)`
1. `Ellipsis(valToShow, maxLength)` - will show val
1. `Ellipsis(valToShow, maxLength, customEllipsis)`

WIP
1. StripHtml(html)
1. MakeDynamic(dictionary)