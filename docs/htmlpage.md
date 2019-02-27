<img src="assets/razor-blade-logo.png" width="100%">

# Razor Blade HtmlPage API

_return to [overview](https://github.com/DNN-Connect/razor-blade)_

## Properties To Change Title, Description, Keywords

1. `HtmlPage.Description` (get/set) - Read/Write the page description. _v1.1_

1. `HtmlPage.Keywords` (get/set) - Read/Write the page keywords. _v1.1_

1. `HtmlPage.Title` (get/set) - Read/Write the page title. _v1.1_

## Commands to Add Headers

1. `HtmlPage.AddMeta(name, content)` - Adds a meta-tag with this name and content to the header. _v1.1_

1. `AddJsonLd(...)` create a [JSON-LD (linked data) header](https://en.wikipedia.org/wiki/JSON-LD) see also [google guideline](https://developers.google.com/search/docs/guides/intro-structured-data) and [Schema.org](https://schema.org/). _v1.1_
    1. `AddToJsonLd(string)` - uses a string, which should already be a valid json
    1. `AddToJsonLd(object)` - will JSON-serialize whatever you pass into it. For now, we recommend using `Dictionary<string, object>` to prepare the data you want to add. 

1. `AddOpenGraph(property, content)` add an [open-graph tag](http://ogp.me/) to the header for facebook, twitter and co. _v1.1_

1. `HtmlPage.AddToHead(string)` - Add anything to the `<head>` section of the page. The string should usually contain a meta, link or script tag. _v1.1_

## Performance Optimizations

The commands above are available for comfortable use. Internally, each command finds the page object and manipulates it. If you would like to optimize the code a bit, the `GetPage()` command gives you an object with the same features, but will run a few percent faster. So you can also do this:

```razor
var p = HtmlPage.GetPage();
p.Title = "...";
p.Keywords = "...;
```