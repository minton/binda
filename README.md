#Binda

Simple Data Binding for WinForms. It provides a easy way to get data from any [POCO](http://en.wikipedia.org/wiki/Plain_Old_CLR_Object) into a `Form` and back.

# Features

* Bind the public properties of an object to controls with a matching name and data type on a Windows Form.
* Ability to declare property aliases.
* Ability to register custom .NET control types.

# Planned Features

* Support for complex controls (`Combobox`, `DataGrid`, etc.) that represent a composite `object`.

# How do I get it?

## Via NuGet

    PM> Install-Package Binda

## Via Source

    git clone git://github.com/minton/Binda.git

# How do I use it?

## Basic example

    var binda = new Binder();
    binda.Bind(myObject, myForm);

## Using property aliases

    var binda = new Binder();
    var aliases = new List<BindaAlias> { new BindaAlias("MyPropertyName", "MyPropertyAliasName") };
    binda.Bind(myObject, myForm);

## Using custom .NET controls

    var binda = new Binder();
    _binder.AddRegistration(typeof(PersonControl), "FirstName", typeof(string));
    binda.Bind(myObject, myForm);

# How do I run the tests?

We use [MSpec](https://github.com/machine/machine.specifications) for test and the [Test Runner](http://www.jetbrains.com/resharper/features/unit_testing.html) in [Resharper](http://www.jetbrains.com/resharper/). If you don't have Resharper I recommend you get it. If that's not an option you can still run the tests manually via the MSpec command-line runner like this:

    mspec.exe BindaTests.dll

# Why WinForms?

A lot of developers, myself included, are still actively working with legacy code bases where there is weak support for data binding. Binda in combination with an ORM like [Dapper](https://github.com/SamSaffron/dapper-dot-net) will make working with WinForms much less tedious.