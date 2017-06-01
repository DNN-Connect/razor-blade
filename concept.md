# Razor Blade Concept
This document is an attempt to define what should be in this library, and what not. It also tries to provide a guide on how to name functions etc. 


## Commands to Add
Commands should fairly useful for people creating Razor templates. So the commands should relate to generating HTML or modifying data for use in generating HTML. 


### Do add
1. common string/text processing actions
1. common html processing actions
1. common helpers for working with dynamic data
1. common value-checking like null-checks


### Don't add
1. data / sql things
1. interfaces to other systems
1. actions-processing code like mail-generation helpers


## Naming of Methods / Commands
1. Commands should say what they do, or at least suggest what it does
1. Commands should be easy to read in Razor code
2. Commands should be fairly short
3. If someone doesn't know what a command in the code does, he should be able to guess it
4. Names 

We don't want to group commands into sets, so please avoid grouping or type prefixes like `StringStripHtml`. 




## Important Paradigms
### Use Static Methods
All the commands we create should be easy to use within a simple line of code, like
```
@StripHtml(body)
```
### Don't use Extension Methods
Do _not_ create extension methods. These are methods which look like they are part of an object. The _would_ allow you to write things like:
```
var x = "<h1>title</h1>";
var y = x.StripHtml();
```
Such methods are syntactic sugar, but often causes problems in Razor because we have many variables which are dynamic - and in these cases Razor will need manual typing - making it nasty to read. So if your helper was a static method with an object of unclear type, the user would have to cast it first, resulting in nasty code like
```
var y = (x as string).StripHtml();
```
Since these helpers are meant for less technical front-end people, forcing them into such patterns would beat the purpose. This is why we want non extensions only, as it results in consistent code. 
