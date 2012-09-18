#Binda

Simple Data Binding for WinForms. It provides a easy way to get data from any [POCO](http://en.wikipedia.org/wiki/Plain_Old_CLR_Object) into a `Form` and back.

# Features

* Bind the public properties of an object to controls with a matching name and data type on a `Form`.
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

## Binding a Collection and Item to a ListControl

Binda supports binding a Collection and Item to a ListControl, like a ComboBox.
Suppose you have a model like so:

    public class Post
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Location { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
		 public PublishState PublishState { get; set; }
        public BindingList<PublishState> PublishStates { get; set; }
    }

    public class PublishState
    {
        public string State { get; set; }

        public override string ToString()
        {
            return State;
        }
    }

If you have a ComboBox named PublishState on your form, then Binda will assign the PublishStates property to the ComboBox's DataSource property, and the PublishState property to the SelectedItem property.
This works for any collection that implements IList. Binda assumes that the collection property name will be the plural form of the selected item property name. We use [Inflector](https://github.com/markrendle/Inflector) to accomplish this.

## Using property aliases

    var binda = new Binder();
    var aliases = new List<BindaAlias> { new BindaAlias("MyPropertyName", "MyPropertyAliasName") };
    binda.Bind(myObject, myForm);

## Using custom .NET controls

    var binda = new Binder();
    _binder.AddRegistration(typeof(PersonControl), "FirstName");
    binda.Bind(myObject, myForm);

# How do I run the tests?

I used [MSpec](https://github.com/machine/machine.specifications) for testing and the [Test Runner](http://www.jetbrains.com/resharper/features/unit_testing.html) in [Resharper](http://www.jetbrains.com/resharper/). If you don't have Resharper I recommend you get it. If that's not an option you can still run the tests manually via the MSpec command-line runner like this:

    mspec.exe BindaTests.dll

# Why WinForms?

A lot of developers, myself included, are still actively working with legacy code on platforms where there is weak support for data binding. Binda in combination with an ORM like [Dapper](https://github.com/SamSaffron/dapper-dot-net) will make working with WinForms much less tedious.

# Credit

Binda began as a quick spike by Michael Minton to bind POCO to WinForms and has since evolved into something useful thanks to the contributions from Will Green.

# License

Copyright (c) 2012, Michael Minton

Permission to use, copy, modify, and/or distribute this software for any purpose with or without fee is hereby granted, provided that the above copyright notice and this permission notice appear in full in all copies.

THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.