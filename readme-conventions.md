<img src="assets/razor-blade-logo.png" width="100%">

# Razor Blade Conventions

> There are two hard things in computer science: cache invalidation, naming things, and off-by-one errors.
> - Phil Karlton and others

To keep the naming convention stable, we've added this guide regarding conventions. Here are the rules:

## Namespace Conventions

We want to be sure that this is super easy to use, but that as the library grows, we can "fix" mistakes made in previous versions. For example, assume we called a method `ToDynamic(...)` and later found out that this is confusing, and wanted to rename it to `DynamicDictionary(...)`. Within a short time we would have a lot of confusing commands and names, or otherwise updates would break something. So the basic idea is as follows:

1. The initial release is in the Namespace `Connect.Razor.Blade` with static classes like `Text` or `Tags`. When using this, a developer will have a using-statement `@using Connect.Razor.Blade;` and just write `@Tags.Strip(...)`.

1. New commands etc. would be added, enhanced and if everything works well, we'll stay on V1 forever.

1. If one day the inconsistencies become too confusing, we'll create a `Connect.Razor.Blade2` with newer, cleaned up command names.

1. This setup should allow us deploy multiple APIs side-by-side and grow new features, without breaking old stuff.

## Naming Conventions

This library should grow, so we must think ahead how we name our methods to ensure that they are consistent. Here are the guidelines as of now:

1. Abbreviations like HTML are written as Html
1. Most commands will be a object.verb or object.question, for example
    * Text.Crop
    * Text.Has
    * Tags.Strip

## Testing Conventions

We want to deliver something super-reliable, so every method must have various tests to validate them, and ensure that edge cases are also handled.