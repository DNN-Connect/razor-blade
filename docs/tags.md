<img src="assets/razor-blade-logo.png" width="100%">

# Razor Blade Tags API

_return to [overview](/DNN-Connect/razor-blade)_

## Commands to Convert Html to Text or Back

1. `Tags.Strip(htmlText)` - strips the html from an string, ensuring that all tags will cause 1 spaces between words, but only one (multiple spaces are shortened to 1 again)

1. `Tags.Br2Nl(text)` - replaces all kinds of `<br>` tags with new-line `\n`

1. `Tags.Br2Space(text)` - replaces all kinds of `<br>` with spaces

1. `Tags.Nl2Br(text)` - replaces all kinds of new-line (`\n`, `\r`) with `<br>`
