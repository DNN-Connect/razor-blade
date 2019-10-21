<img src="assets/razor-blade-logo.png" width="100%">

# RazorBlade has moved!

RazorBlade 3.0 was just released, and the git repo has been moved to [RazorBlade](https://github.com/2sic/razor-blade) together with some large changes. 
Please use that from now on. 

---

# Razor Blade HtmlPage API

_return to [overview](https://github.com/DNN-Connect/razor-blade)_

## Properties To Change Title, Description, Keywords

1. `HtmlPage.Description` (get/set) - Read/Write the page description. _v1.1_

1. `HtmlPage.Keywords` (get/set) - Read/Write the page keywords. _v1.1_

1. `HtmlPage.Title` (get/set) - Read/Write the page title. _v1.1_

## Commands to Add Headers

1. `HtmlPage.AddMeta(name, content)` - Adds a meta-tag with this name and content to the header. _v1.1_

1. `HtmlPage.AddJsonLd(...)` create a [JSON-LD (linked data) header](https://en.wikipedia.org/wiki/JSON-LD) see also [google guideline](https://developers.google.com/search/docs/guides/intro-structured-data) and [Schema.org](https://schema.org/). _v1.1_
    1. `HtmlPage.AddToJsonLd(string)` - uses a string, which should already be a valid json
    1. `HtmlPage.AddToJsonLd(object)` - will JSON-serialize whatever you pass into it. For now, we recommend using `Dictionary<string, object>` to prepare the data you want to add. 

1. `HtmlPage.AddOpenGraph(property, content)` add an [open-graph tag](http://ogp.me/) to the header for facebook, twitter and co. _v1.1_

1. `HtmlPage.AddToHead(string)` - Add anything to the `<head>` section of the page. The string should usually contain a meta, link or script tag. _v1.1_

1. `HtmlPage.AddIcon(path)` add an icon (favicon) to the page _v2.1_
    1. `...AddIcon(path, rel: string, size: int, type: string)` - all optional parameters to specify things like
        * `rel`: the rel-text, default is 'icon'. common terms are also 'shortcut icon' or 'apple-touch-icon
        * `size`: will be used in size='#x#' tag; only relevant if you want to provide multiple separate sizes
        * `type`: optional type, if not provided, will be auto-detected from known types or remain empty
1. `HtmlPage.AddIconSet(path)` add a few icon headers to the page according to best practices _v2.1_
    1. `...AddIconSet(path, favicon: bool|string, rels: IEnumerable<string>, sizes: IEnumerable<int>)` - all optional parameters to specify things like
        * `favicon`: boolean - auto-add a default favicon tag (or not)
        * `favicon`: string - use this url for the favicon tag
        * `rels`: list/array of rel-texts (a separate icon tag will be generated for each rel)
        * `sizes`: list/array of sizes (a separate icon tag will be generate for each size)  
        _note: if you supply `rels` and `sizes`, then all combinations of icon tags will be added_  
        _note: you can't specify the type, as each one could be different - the auto-detection will take care of this for you_


## Performance Optimizations

The commands above are available for comfortable use. Internally, each command finds the page object and manipulates it. If you would like to optimize the code a bit, the `GetPage()` command gives you an object with the same features, but will run a few percent faster. So you can also do this:

```razor
var p = HtmlPage.GetPage();
p.Title = "...";
p.Keywords = "...;
```

## WIP - Icon Headers

This is fully work-in-progress, and we're trying to define in this document, how the API would be for Favicons. This does not work yet! This is based on information from sources like

* https://github.com/audreyr/favicon-cheat-sheet

Goal: Create a simple command for the default use case, and provide more complex options for advanced stuff.

### Basic Default Use Case

The default use case should

1. Take just 1 PNG image - to keep it simple. Ideally it could also contain placeholders like {h} & {w} or similar, which if provided would add the size properties to the url, for scenarios where you have an image resizer. This would allow you to do both:
   1. "/portals/0/favicon.png"
   1. "/portals/0/favicon.png?h={h}&w={w}" for ImageResizer.net
   1. "/portals/0/favicon.png?height={h}&width={w}" for Thorstons image resizer
   1. "/portals/0/favicons/icon-{h}x{w}.png" for pre-resized images

2. Generate the important headers, but not bloat the header with all possible sizes and variations. These would be:
   1. favicon for IE 11 - rel="shortcut icon", as png (supported in IE 11)  
      This will cover any IE11 favicon when an html-page is shown. Note that when the browser shows a pdf/image only, it doesn't have html to tell it about favicons, so that will still pick up favicon.ico in the root.

   2. general icon - rel="icon", as png, ideally at least 250x250
      this is for the general case, but actually I'm not even sure what case that is...

   3. touch-icons for mobile devices rel="apple-touch-icon" for 196x196  
      this supposedly works for iOS and Android.

3. Specifically, we would NOT support the following for now
   1. IE 6-10, as these are fully deprecated
   2. Mac Desktop icons
   3. Windows 10 desktop icons
   4. we won't implement rel="apple-touch-icon-precomposed" as that's only for ios 6 and below

So basically it would probably be a command like:

```c#
HtmlPage.AddIcon("/portals/0/favicon.png")
```

### Advanced Use Cases

Advanced use cases should allow the following customizations, which limits or extends the icons added. 

* specific list of sizes
* specific list of known types (icon, shortcut icon, apple-touch...)

### Not Supported Use Cases

Basically anybody can always add more headers to the page using `HtmlPage.AddHeader(...)`, so it's not necessary to support every exotic variation. This command should make the 80% use cases super easy (just mention 1 file name) and the remaining 15% easy (with addition of parameters), but exotic stuff should not be covered until it's a common standard. These are things probably not supported in the basic API

* meta tag for msapplication-TileColor and msapplication-TileImage
* rel="apple-touch-icon-precomposed" as this is for older iOS and iOS devices usually update very often - see also https://mathiasbynens.be/notes/touch-icons

