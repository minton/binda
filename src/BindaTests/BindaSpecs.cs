using System;
using System.Collections.Generic;
using BindaTests.NeededObjects;
using Machine.Specifications;
using Binda;
using Test;

namespace BindaTests
{
    [Subject(typeof(Binder))]
    public class When_binding_an_object_to_a_form
    {
        Establish context = () =>
                                {
                                    _binder = new Binder();
                                    _form = new MySampleForm();
                                    _post = NeededObjectsFactory.CreatePost();
                                };

        Because of = () => _binder.Bind(_post, _form);

        It should_take_matching_properties_from_the_object_and_set_them_on_the_form = () =>
                                                                                        {
                                                                                            _form.Title.Text.ShouldEqual(TestVariables.Title);
                                                                                            _form.Author.Text.ShouldEqual(TestVariables.Author);
                                                                                            _form.Date.Value.ShouldEqual(TestVariables.Posted);
                                                                                            _form.Body.Text.ShouldEqual(TestVariables.Body);
                                                                                        };
        static Binder _binder;
        static MySampleForm _form;
        static Post _post;
    }
    [Subject(typeof(Binder))]
    public class When_binding_an_oject_to_a_form_with_custom_registrations
    {
        Establish context = () =>
                                {
                                    _binder = new Binder();
                                    _binder.AddRegistration(typeof(FluxCapacitor), "Radiation", typeof(decimal?));
                                    _form = new MySampleForm();
                                    _post = NeededObjectsFactory.CreatePost();
                                    _post.Radiation = TestVariables.Radiation;
                                };

        Because of = () => _binder.Bind(_post, _form);

        It should_take_matching_properties_from_the_object_and_set_them_on_the_form = () =>
                                                                                        {
                                                                                            _form.Title.Text.ShouldEqual(TestVariables.Title);
                                                                                            _form.Author.Text.ShouldEqual(TestVariables.Author);
                                                                                            _form.Date.Value.ShouldEqual(TestVariables.Posted);
                                                                                            _form.Body.Text.ShouldEqual(TestVariables.Body);
                                                                                            _form.Radiation.Radiation.ShouldEqual(TestVariables.Radiation);
                                                                                        };
        static Binder _binder;
        static MySampleForm _form;
        static Post _post;
    }
    [Subject(typeof(Binder))]
    public class When_binding_an_object_to_a_form_with_aliases
    {
        Establish context = () =>
        {
            _binder = new Binder();
            _form = new MySampleForm();
            _aliases = new List<BindaAlias> { new BindaAlias("Location", "PostLocation") };
            _post = NeededObjectsFactory.CreatePost();
        };

        Because of = () => _binder.Bind(_post, _form, _aliases);

        It should_take_matching_properties_from_the_object_and_set_them_on_the_form = () =>
                                                                                        {
                                                                                            _form.Title.Text.ShouldEqual(TestVariables.Title);
                                                                                            _form.Author.Text.ShouldEqual(TestVariables.Author);
                                                                                            _form.Date.Value.ShouldEqual(TestVariables.Posted);
                                                                                            _form.Body.Text.ShouldEqual(TestVariables.Body);
                                                                                            _form.PostLocation.Text.ShouldEqual(TestVariables.Location);
                                                                                        };
        static Binder _binder;
        static MySampleForm _form;
        static Post _post;
        static List<BindaAlias> _aliases;
    }
    [Subject(typeof(Binder))]
    public class When_binding_a_form_to_an_object
    {
        Establish context = () =>
        {
            _binder = new Binder();
            _form = NeededObjectsFactory.CreateForm();
            _post = new Post();
        };

        Because of = () => _binder.Bind(_form, _post);

        It should_take_matching_properties_from_the_form_and_set_them_on_the_object = () =>
                                                                                          {
                                                                                              _post.Title.ShouldEqual(TestVariables.Title);
                                                                                              _post.Author.ShouldEqual(TestVariables.Author);
                                                                                              _post.Date.ShouldEqual(TestVariables.Posted);
                                                                                              _post.Body.ShouldEqual(TestVariables.Body);
                                                                                          };
        static Binder _binder;
        static MySampleForm _form;
        static Post _post;
    }
    [Subject(typeof(Binder))]
    public class When_binding_a_form_to_an_object_with_custom_registrations
    {
        Establish context = () =>
        {
            _binder = new Binder();
            _binder.AddRegistration(typeof(FluxCapacitor), "Radiation", typeof(decimal?));
            _form = NeededObjectsFactory.CreateForm();
            _form.Radiation.Radiation = TestVariables.Radiation;
            _post = new Post();
        };

        Because of = () => _binder.Bind(_form, _post);

        It should_take_matching_properties_from_the_post_and_set_them_on_the_form = () =>
                                                                                        {
                                                                                            _post.Title.ShouldEqual(TestVariables.Title);
                                                                                            _post.Author.ShouldEqual(TestVariables.Author);
                                                                                            _post.Date.ShouldEqual(TestVariables.Posted);
                                                                                            _post.Body.ShouldEqual(TestVariables.Body);
                                                                                            _post.Radiation.ShouldEqual(TestVariables.Radiation);
                                                                                        };
        static Binder _binder;
        static MySampleForm _form;
        static Post _post;
    }
    [Subject(typeof(Binder))]
    public class When_binding_a_form_to_an_object_with_aliases
    {
        Establish context = () =>
                                {
                                    _binder = new Binder();
                                    _aliases = new List<BindaAlias> { new BindaAlias("Location", "PostLocation") };
                                    _form = NeededObjectsFactory.CreateForm();
                                    _form.PostLocation.Text = TestVariables.Location;
                                    _post = new Post();
                                };

        Because of = () => _binder.Bind(_form, _post, _aliases);

        It should_take_matching_properties_from_the_form_and_set_them_on_the_object = () =>
                                                                                          {
                                                                                              _post.Title.ShouldEqual(TestVariables.Title);
                                                                                              _post.Author.ShouldEqual(TestVariables.Author);
                                                                                              _post.Date.ShouldEqual(TestVariables.Posted);
                                                                                              _post.Body.ShouldEqual(TestVariables.Body);
                                                                                              _post.Location.ShouldEqual(TestVariables.Location);
                                                                                          };
        static Binder _binder;
        static MySampleForm _form;
        static Post _post;
        static List<BindaAlias> _aliases;
    }
    [Subject(typeof(Binder))]
    public class When_binding_an_object_to_a_form_where_the_object_is_null
    {
        Establish context = () =>
        {
            _binder = new Binder();
            _form = new MySampleForm();
            _post = null;
        };

        Because of = () => _exception = Catch.Exception(() => _binder.Bind(_post, _form));

        It should_fail = () => _exception.ShouldBeOfType<ArgumentNullException>();

        static Binder _binder;
        static MySampleForm _form;
        static Post _post;
        static Exception _exception;
    }
    [Subject(typeof(Binder))]
    public class When_binding_an_object_to_a_form_where_the_form_is_null
    {
        Establish context = () =>
        {
            _binder = new Binder();
            _form = null;
            _post = NeededObjectsFactory.CreatePost();
        };

        Because of = () => _exception = Catch.Exception(() => _binder.Bind(_post, _form));

        It should_fail = () => _exception.ShouldBeOfType<ArgumentNullException>();

        static Binder _binder;
        static MySampleForm _form;
        static Post _post;
        static Exception _exception;
    }
    [Subject(typeof(Binder))]
    public class When_binding_a_form_to_an_object_where_the_object_is_null
    {
        Establish context = () =>
        {
            _binder = new Binder();
            _form = NeededObjectsFactory.CreateForm();
            _post = null;
        };

        Because of = () => _exception = Catch.Exception(() => _binder.Bind(_form, _post));

        It should_fail = () => _exception.ShouldBeOfType<ArgumentNullException>();

        static Binder _binder;
        static MySampleForm _form;
        static Post _post;
        static Exception _exception;
    }
    [Subject(typeof(Binder))]
    public class When_binding_a_form_to_an_object_where_the_form_is_null
    {
        Establish context = () =>
        {
            _binder = new Binder();
            _form = null;
            _post = NeededObjectsFactory.CreatePost();
        };

        Because of = () => _exception = Catch.Exception(() => _binder.Bind(_form, _post));

        It should_fail = () => _exception.ShouldBeOfType<ArgumentNullException>();

        static Binder _binder;
        static MySampleForm _form;
        static Post _post;
        static Exception _exception;
    }
}