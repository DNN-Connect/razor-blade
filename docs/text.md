<img src="assets/razor-blade-logo.png" width="100%">

# RazorBlade has moved!

RazorBlade 3.0 was just released, and the git repo has been moved to [RazorBlade](https://github.com/2sic/razor-blade) together with some large changes. 
Please use that from now on. 

---

# Razor Blade Text API

_return to [overview](https://github.com/DNN-Connect/razor-blade)_

## Commands to Shorten Texts Correctly

1. `Text.Crop(value, length)` - will cut off the text at the best place, but maximum length as specified. Special behavior is that html-entities and umlauts (like `&nbsp;` or `&uuml;`) are treated as one character, and it will try to not cut off a word in the middle of the word, but backtrack to the previous space.

1. `Text.Ellipsis(value, length)` - will show value, and if it's longer than max-length, will go add an "..."-character (`&hellip;`) instead

1. `Text.Ellipsis(value, length, suffix)` - same as the simple one, but you can specify what should be added

## Commands to Check for Real Text-Contents

1. `Text.Has(someObjectOrString)` - true if it has real text, false if it's null, not a string, an empty string or a string containing just whitespace and/or html-whitespaces like `&nbsp;` or `&#160;`

1. `Text.Has(someObjectOrString, false)` - true if it has real text, false if it's null, not a string, an empty string or a string containing just whitespace. Html-Whitespace is treated as real text in this case.

1. `Text.First(intendedValue, fallbackIfEmpty)` - returns the first text if it has content, otherwise the fallback. Will treat html-whitespace like `&nbsp;` as a space (empty)

1. `Text.First(intendedValue, fallbackIfEmpty, false)` - same as before, but will treat html-whitespace as real text

1. `Text.First(intendedValue, next-value, next-value, [up to 5 values])` - same behavior as above, values will be checked in the order given.

1. `Text.First(intendedValue, next-value, next-value, [up to 5 values], false)` - same behavior as above, values will be checked in the order given. By ending with `false` html-whitespace will not be cleaned but treated as text.

## Commands to Clean up Text

1. `Text.Zip(value)` will remove line-breaks and shrink all multiple-spaces into one single space.