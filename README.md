# Binda

**Noun**
>  \ ˈbīn-dā- \

[![binda](https://img.shields.io/nuget/v/Binda.svg)](https://www.nuget.org/packages/Binda/)

Simple Data Binding for WinForms. It provides a easy way to get data from any [POCO](http://en.wikipedia.org/wiki/Plain_Old_CLR_Object) into a `Form` and back.

# Features

* Bind the public properties of an object to controls with a matching name and data type on a `Form`.
* Ability to declare property aliases.
* Ability to register custom .NET control types.

# Planned Features

* Support for complex controls (`Combobox`, `DataGrid`, etc.) that represent a composite `object`.

# How do I get it?

## Via NuGet
```bash
PM> Install-Package Binda
```
## Via Source
```bash
git clone git://github.com/minton/Binda.git
```
# How do I use it?

## Basic example

    var binda = new Binder();
    binda.Bind(myObject, myForm);

## More examples

Check out the [Wiki](https://github.com/minton/Binda/wiki#examples) for more examples.

# How do I run the tests?

I used [NUnit](http://www.nunit.org/) for testing and the [Test Runner](http://www.jetbrains.com/resharper/features/unit_testing.html) in [Resharper](http://www.jetbrains.com/resharper/). If you don't have Resharper I recommend you get it. If that's not an option you can still run the tests manually via the [NUnit Console Runner](https://github.com/nunit/docs/wiki/Console-Runner).

# Have an issue?

Submit an [issue](http://github.com/minton/Binda/issues) directly on GitHub and we'll take a look.

# Why WinForms?

A lot of developers, myself included, are still actively working with legacy code on platforms where there is weak support for data binding. Binda in combination with an ORM like [Dapper](https://github.com/SamSaffron/dapper-dot-net) will make working with WinForms much less tedious.

# Credit

Binda began as a quick spike by [Michael Minton](https://twitter.com/minton) to bind POCO to WinForms and has since evolved into something useful thanks to the contributions from [Will Green](http://hotgazpacho.org/) and [bryce](https://github.com/brycekbargar).

# How to contribute?

All contributions to the project are welcome. If you have a great idea how to make Binda even better submit a [Pull Request](https://help.github.com/articles/using-pull-requests).

