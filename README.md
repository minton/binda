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

## Binding a Collection and Item to a ListControl

Binda supports binding a Collection and Item to a ListControl, like a ComboBox.
Suppose you have a model like so:
```c#
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
```

If you have a ComboBox named PublishState on your form, then Binda will assign the PublishStates property to the ComboBox's DataSource property, and the PublishState property to the SelectedItem property.
This works for any collection that implements IList. Binda assumes that the collection property name will be the plural form of the selected item property name. We use [Inflector](https://github.com/markrendle/Inflector) to accomplish this.

## Using property aliases
```c#
var binda = new Binder();
var aliases = new List<BindaAlias> { new BindaAlias("MyPropertyName", "MyPropertyAliasName") };
binda.Bind(myObject, myForm);
```
## Using custom .NET controls
```c#
var binda = new Binder();
binda.AddRegistration(typeof(PersonControl), "FirstName");
binda.Bind(myObject, myForm);
```

## Binding to a TreeView

TreeView binding expects your source to have an IEnumerable<T> property with a name that matches a TreeView control on your form.
Suppose you have a model and a form like so:
```c#
public class Post
{
    public string Title { get; set; }
    public string Author { get; set; }
    public List<Comment> Comments { get; set; }
}

public class Comment
{
    public string Author { get; set; }
    public string Body { get; set; }
    public List<Comment> Comments { get; set; }
    public override string ToString()
    {
        return string.Format("{0}: {1}", Author, Body);
    }
}

partial class MyForm
{
  //...ommited
  private void InitializeComponent()
        {
            this.Comments = new System.Windows.Forms.TreeView();
            this.Comments.Name = "Comments";
            this.Controls.Add(this.Comments);            
        }
  internal System.Windows.Forms.TreeView Comments;
  //...ommited
}
```

When you attempt to bind the `Post` model to the form it will find a matching `TreeView` and `IEnumerable<T>` based on name. It will then create a `TreeNode` for each `T` with the `Text` set to `T.ToString()` and `Tag` set to `T`. It will also look to see if `T` has an `IEnumerable<T>` property by the same name. If it does it will create child `TreeNodes` for each of those recursively.

Using our example model and form:

```c#
var post = new Post();
var comment1 = new Comment("Tom", "I love this post!");
var replyToComment1 = new Comment("Jim", "Tom, I know right!");
replyToComment1.Comments.Add(new Comment("John", "You guys are easily amused."));
comment1.Comments.Add(replyToComment1);
var comment2 = new Comment("Sam", "This post is lol.");
comment2.Comments.Add(new Comment("Amy", "Sam your face is lol!"));
post.Comments.AddRange(new[] { comment1, comment2 });

var binda = new Binder();
binda.Bind(post, myForm);
```

Your TreeView will look like 

    TreeView.Nodes
                 |
                 TreeNode {"Tom: I love this post!"}
                        |
                        TreeNode {"Jim: Tom, I know right!"}
                               |
                               TreeNode {"John: You guys are easily amused."}
                 TreeNode {"Sam: This post is lol."}
                        |
                        TreeNode {"Amy: Sam your face is lol!"}

Binda also conveniently sets the `Tag` property of each `TreeNode` to the `Comment` it represents.

When reverse binding the form to the model it will use the `Tag` property of each `TreeNode` to recreate the model.

# How do I run the tests?

I used [MSpec](https://github.com/machine/machine.specifications) for testing and the [Test Runner](http://www.jetbrains.com/resharper/features/unit_testing.html) in [Resharper](http://www.jetbrains.com/resharper/). If you don't have Resharper I recommend you get it. If that's not an option you can still run the tests manually via the MSpec command-line runner like this:
```bash
mspec.exe BindaTests.dll
```
# Have an issue?

Submit an [issue](http://github.com/minton/Binda/issues) directly on GitHub and we'll take a look.

# Why WinForms?

A lot of developers, myself included, are still actively working with legacy code on platforms where there is weak support for data binding. Binda in combination with an ORM like [Dapper](https://github.com/SamSaffron/dapper-dot-net) will make working with WinForms much less tedious.

# Credit

Binda began as a quick spike by [Michael Minton](http://michaelminton.com) to bind POCO to WinForms and has since evolved into something useful thanks to the contributions from [Will Green](http://hotgazpacho.org/).

# How to contribute?

All contributions to the project are welcome. If you have a great idea how to make Binda even better submit a [Pull Request](https://help.github.com/articles/using-pull-requests).

# License

Copyright (c) 2012, [Michael Minton](http://michaelminton.com)

Binda is provided under the [Apache 2.0 License](http://www.apache.org/licenses/LICENSE-2.0). Commercial use requires attribution.

THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.
