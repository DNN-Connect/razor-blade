# Razor Helpers
A library of helpers for Razor, to lighten Razor templates and make work easier. 

The goal is to provide helpers for very common code snippets or functions, which would lighten the load. Here's an example:

Write this:
```razor
@using Connect.RazorHelpers;
<div>
  @IsNoE(firstName, "nothing found");
</div>
```

Instead of this:
```razor
<div>
  @if(String.IsNullOrEmpty(firstName)) {
    @"nothing found"
  } else {
    @firstName
  }
</div>
```
