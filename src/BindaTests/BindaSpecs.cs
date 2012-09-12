using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using BindaTests.NeededObjects;
using Machine.Specifications;
using Binda;
using Test;
using Binder = Binda.Binder;

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

    [Subject(typeof(Binder))]
    public class When_binding_an_form_to_an_object_with_a_property_and_a_collection_with_a_pluralized_name_of_the_property
    {
        Establish context = () =>
            {
                _binder = new Binder();
                _form = new PostWithOptionsForm();
                _post = NeededObjectsFactory.CreatePost();
                _post.PublishStates.Add(new PublishState {State = "Published"});
                _post.PublishStates.Add(new PublishState {State = "Reviewed"});
                _post.PublishStates.Add(new PublishState {State = "Pending Review"});
                _post.PublishStates.Add(new PublishState {State = "Draft"});
                _post.PublishState = _post.PublishStates[2];
            };

        Because of = () => _binder.Bind(_post, _form);

        It should_set_the_data_source_on_the_matching_control_to_the_corresponding_collection =
            () => _form.PublishState.DataSource.ShouldBeTheSameAs(_post.PublishStates);

        It should_set_the_selected_item_on_the_matching_control_to_the_correct_value =
            () => _form.PublishState.SelectedItem.ShouldBeTheSameAs(_post.PublishState);

        static Binder _binder;
        static PostWithOptionsForm _form;
        static Post _post;
    }

	[Subject(typeof(Binder))]
	public class When_extracting_data_from_the_form_back_the_model_with_a_collection_and_item_bound_to_a_list_control
	{
		Establish context = () => {
			_binder = new Binder();
			_form = new PostWithOptionsForm();
			_post = NeededObjectsFactory.CreatePost();
			_post.PublishStates.Add(new PublishState {State = "Published"});
			_post.PublishStates.Add(new PublishState {State = "Reviewed"});
			_post.PublishStates.Add(new PublishState {State = "Pending Review"});
			_post.PublishStates.Add(new PublishState {State = "Draft"});
			_post.PublishState = _post.PublishStates[2];
			_binder.Bind(_post, _form);
			_newState = _post.PublishStates [0];
			_form.PublishState.SelectedItem = _newState;
		};

		Because of = () => _binder.Bind(_form, _post);

		It should_update_the_model_with_the_new_selected_option = () => _post.PublishState.ShouldBeTheSameAs(_newState);

		static Binder _binder;
		static PostWithOptionsForm _form;
		static Post _post;
		static PublishState _newState;
	}

    [Subject(typeof(Binder))]
    public class When_binding_a_form_to_an_object_that_implements_inotifypropertychanged_and_the_form_data_changes
    {
        Establish context = () =>
        {
            _binder = new Binder();
            _form = new PostWithOptionsForm();
            _post = NeededObjectsFactory.CreateNotifyingPost();
            _post.PublishStates.Add(new PublishState { State = "Published" });
            _post.PublishStates.Add(new PublishState { State = "Reviewed" });
            _post.PublishStates.Add(new PublishState { State = "Pending Review" });
            _post.PublishStates.Add(new PublishState { State = "Draft" });
            _post.PublishState = _post.PublishStates[2];
            _binder.Bind(_post, _form, new[] { new BindaAlias("Location", "PostLocation") });
            CreateControl(_form);
        };

        Because of = () =>
        {
            _form.Title.Text = "New Title";
            _form.Author.Text = "New Author";
            _form.PostLocation.Text = "New Location";
            _form.Body.Text = "New Body";
            _form.Date.Value = new DateTime(1979, 12, 31);
            _form.PublishState.SelectedItem = _post.PublishStates[3];
        };

        It should_synchronize_the_title_to_the_model = () => _post.Title.ShouldEqual("New Title");
        It should_synchronize_the_author_to_the_model = () => _post.Author.ShouldEqual("New Author");
        It should_synchronize_the_location_to_the_model = () => _post.Location.ShouldEqual("New Location");
        It should_synchronize_the_body_to_the_model = () => _post.Body.ShouldEqual("New Body");
        It should_synchronize_the_date_to_the_model = () => _post.Date.ShouldEqual(new DateTime(1979, 12, 31));
        It should_synchronize_the_publishstate_to_the_model = () => _post.PublishState.ShouldEqual(_post.PublishStates[3]);

        static void CreateControl(Control control)
        {
            var method = control.GetType().GetMethod("CreateControl", BindingFlags.Instance | BindingFlags.NonPublic);
            method.Invoke(control, new object[] { true });
        }

        static Binder _binder;
        static PostWithOptionsForm _form;
        static NotifyingPost _post;
    }
}