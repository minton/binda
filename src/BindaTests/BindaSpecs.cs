using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BindaTests.NeededObjects;
using Machine.Specifications;
using Binda;

namespace Test
{
    [Subject(typeof(Binder))]
    public class When_binding_windows_form
    {
        Establish context = () =>
                                {
                                    _binder = new Binder();
                                    _form = new MySampleForm();
                                    _post = new Post
                                                {
                                                    Title = _title,
                                                    Author = _author,
                                                    Date = SkeetEpoch,
                                                    Body = _body
                                                };
                                };

        Because of = () => _binder.Bind(_post, _form);

        It should_take_matching_properties_from_the_post_and_set_them_on_the_form = () =>
                                                                                        {
                                                                                            _form.Title.Text.ShouldEqual(_title);
                                                                                            _form.Author.Text.ShouldEqual(_author);
                                                                                            _form.Date.Value.ShouldEqual(SkeetEpoch);
                                                                                            _form.Body.Text.ShouldEqual(_body);
                                                                                        };

        static Binder _binder;
        static MySampleForm _form;
        static Post _post;
        static DateTime SkeetEpoch = DateTime.Parse("6/19/1965");
        static readonly string _body = "Invizible evrybody bere carz bukket flowerz. Nozzing sheeze ghoast funnae cheezeburger scratchin funnae samez apwn. Evrybody ghoast not pour nozbody compewter dum bere. Hunnae how hoi nozzing not luv. Not nozzing samez hoi notise graet bere wtf. Hunnae nom winz evrybody. Partay gravy flowerz evrybody compewters noze. Samez apwn I partay luv sink cheezeburger. Wut nom noze do hoi flowerz partay. Yu bukket saiz teh. Scratchin haz evrybody not evrybody compewters. Nuthing ghoast compewters u thx ya.";
        static readonly string _author = "Dr. Anderson Silva";
        static readonly string _title = "Why Medical Unit Tests Fail";
    }
    [Subject(typeof(Binder))]
    public class When_binding_a_windows_form_with_custom_registrations
    {
        Establish context = () =>
                                {
                                    _binder = new Binder();
                                    _binder.AddRegistration(typeof (FluxCapacitor), "Radiation", typeof (decimal?));
                                    _form = new MySampleForm();
                                    _post = new Post
                                                {
                                                    Title = _title,
                                                    Author = _author,
                                                    Date = SkeetEpoch,
                                                    Body = _body,
                                                    Radiation = _radiation
                                                };
                                };

        Because of = () => _binder.Bind(_post, _form);

        It should_take_matching_properties_from_the_post_and_set_them_on_the_form = () =>
                                                                                        {
                                                                                            _form.Title.Text.ShouldEqual(_title);
                                                                                            _form.Author.Text.ShouldEqual(_author);
                                                                                            _form.Date.Value.ShouldEqual(SkeetEpoch);
                                                                                            _form.Body.Text.ShouldEqual(_body);
                                                                                            _form.Radiation.Radiation.ShouldEqual(_radiation);
                                                                                        };

        static Binder _binder;
        static MySampleForm _form;
        static Post _post;
        static DateTime SkeetEpoch = DateTime.Parse("6/19/1965");
        static readonly string _body = "Invizible evrybody bere carz bukket flowerz. Nozzing sheeze ghoast funnae cheezeburger scratchin funnae samez apwn. Evrybody ghoast not pour nozbody compewter dum bere. Hunnae how hoi nozzing not luv. Not nozzing samez hoi notise graet bere wtf. Hunnae nom winz evrybody. Partay gravy flowerz evrybody compewters noze. Samez apwn I partay luv sink cheezeburger. Wut nom noze do hoi flowerz partay. Yu bukket saiz teh. Scratchin haz evrybody not evrybody compewters. Nuthing ghoast compewters u thx ya.";
        static readonly string _author = "Dr. Anderson Silva";
        static readonly string _title = "Why Medical Unit Tests Fail";
        static readonly decimal? _radiation = 42.314m;
    }
    [Subject(typeof(Binder))]
    public class When_binding_a_windows_form_with_aliases
    {
        Establish context = () =>
        {
            _binder = new Binder();
            _form = new MySampleForm();
            Aliases.Add(new BindaAlias("Location", "PostLocation"));
            _post = new Post
            {
                Title = Title,
                Author = Author,
                Date = SkeetEpoch,
                Body = Body,
                Location = Location
            };
        };

        Because of = () => _binder.Bind(_post, _form, Aliases);

        It should_take_matching_properties_from_the_post_and_set_them_on_the_form = () =>
                                                                                        {
                                                                                            _form.Title.Text.ShouldEqual(Title);
                                                                                            _form.Author.Text.ShouldEqual(Author);
                                                                                            _form.Date.Value.ShouldEqual(SkeetEpoch);
                                                                                            _form.Body.Text.ShouldEqual(Body);
                                                                                            _form.PostLocation.Text.ShouldEqual(Location);
                                                                                        };

        static Binder _binder;
        static MySampleForm _form;
        static Post _post;
        static readonly DateTime SkeetEpoch = DateTime.Parse("6/19/1965");
        const string Body = "Invizible evrybody bere carz bukket flowerz. Nozzing sheeze ghoast funnae cheezeburger scratchin funnae samez apwn. Evrybody ghoast not pour nozbody compewter dum bere. Hunnae how hoi nozzing not luv. Not nozzing samez hoi notise graet bere wtf. Hunnae nom winz evrybody. Partay gravy flowerz evrybody compewters noze. Samez apwn I partay luv sink cheezeburger. Wut nom noze do hoi flowerz partay. Yu bukket saiz teh. Scratchin haz evrybody not evrybody compewters. Nuthing ghoast compewters u thx ya.";
        const string Author = "Dr. Anderson Silva";
        const string Title = "Why Medical Unit Tests Fail";
        const string Location = "Tampa, FL";
        static readonly List<BindaAlias> Aliases = new List<BindaAlias>();
    }
}