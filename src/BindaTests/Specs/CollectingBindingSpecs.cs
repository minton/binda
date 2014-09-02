using System.Collections.Generic;
using Binda;
using BindaTests.NeededObjects;
using Machine.Specifications;
using Test;

namespace BindaTests
{
    [Subject(typeof(Binder))]
    public class When_binding_an_object_to_a_form_with_a_property_and_a_collection_with_a_pluralized_name_of_the_property
    {
        Establish context = () =>
        {
            _binder = new Binder();
            _form = new PostWithOptionsForm();
            _post = NeededObjectsFactory.CreatePost();
            _post.PublishStates.Add(new PublishState { State = "Published" });
            _post.PublishStates.Add(new PublishState { State = "Reviewed" });
            _post.PublishStates.Add(new PublishState { State = "Pending Review" });
            _post.PublishStates.Add(new PublishState { State = "Draft" });
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
    public class When_binding_an_object_to_a_form_with_a_property_and_a_collection_with_a_pluralized_name_of_the_property_using_prefixes
    {
        Establish context = () =>
        {
            _binder = new Binder();
            _binder.AddControlPrefix(new HungarianNotationControlPrefix());
            _form = new PostWithOptionsPrefixForm();
            _post = NeededObjectsFactory.CreatePost();
            _post.PublishStates.Add(new PublishState { State = "Published" });
            _post.PublishStates.Add(new PublishState { State = "Reviewed" });
            _post.PublishStates.Add(new PublishState { State = "Pending Review" });
            _post.PublishStates.Add(new PublishState { State = "Draft" });
            _post.PublishState = _post.PublishStates[2];
        };

        Because of = () => _binder.Bind(_post, _form);

        It should_set_the_data_source_on_the_matching_control_to_the_corresponding_collection =
            () => _form.cbPublishState.DataSource.ShouldBeTheSameAs(_post.PublishStates);

        It should_set_the_selected_item_on_the_matching_control_to_the_correct_value =
            () => _form.cbPublishState.SelectedItem.ShouldBeTheSameAs(_post.PublishState);

        static Binder _binder;
        static PostWithOptionsPrefixForm _form;
        static Post _post;
    }

    [Subject(typeof(Binder))]
    public class When_binding_an_object_to_a_form_with_a_property_and_a_collection_with_a_pluralized_name_of_the_property_using_prefixes_and_aliases
    {
        Establish context = () =>
        {
            _binder = new Binder();
            _binder.AddControlPrefix(new HungarianNotationControlPrefix());
            _aliases = new List<BindaAlias> { new BindaAlias("Location", "PostLocation") };
            _form = new PostWithOptionsPrefixForm();
            _post = NeededObjectsFactory.CreatePost();
            _post.PublishStates.Add(new PublishState { State = "Published" });
            _post.PublishStates.Add(new PublishState { State = "Reviewed" });
            _post.PublishStates.Add(new PublishState { State = "Pending Review" });
            _post.PublishStates.Add(new PublishState { State = "Draft" });
            _post.PublishState = _post.PublishStates[2];
        };

        Because of = () => _binder.Bind(_post, _form, _aliases);

        It should_set_the_data_source_on_the_matching_control_to_the_corresponding_collection = () => _form.cbPublishState.DataSource.ShouldBeTheSameAs(_post.PublishStates);

        It should_set_the_selected_item_on_the_matching_control_to_the_correct_value = () => _form.cbPublishState.SelectedItem.ShouldBeTheSameAs(_post.PublishState);
        It should_take_matching_properties_from_the_object_and_set_them_on_the_form = () =>
        {
            _form.txtTitle.Text.ShouldEqual(TestVariables.Title);
            _form.txtAuthor.Text.ShouldEqual(TestVariables.Author);
            _form.dpDate.Value.ShouldEqual(TestVariables.Posted);
            _form.txtBody.Text.ShouldEqual(TestVariables.Body);
            _form.txtPostLocation.Text.ShouldEqual(TestVariables.Location);
        };

        static Binder _binder;
        static PostWithOptionsPrefixForm _form;
        static Post _post;
        static List<BindaAlias> _aliases;
    }

    [Subject(typeof(Binder))]
    public class When_binding_an_object_to_a_form_with_a_property_and_a_collection_with_a_pluralized_name_of_the_property_using_prefixes_aliases_and_with_custom_registrations
    {
        Establish context = () =>
        {
            _binder = new Binder();
            _binder.AddControlPrefix(new HungarianNotationControlPrefix());
            _binder.AddRegistration(typeof(FluxCapacitor), "PopularityRanking", typeof(decimal?));
            _aliases = new List<BindaAlias> { new BindaAlias("Location", "PostLocation") };
            _form = new PostWithOptionsPrefixForm();
            _post = NeededObjectsFactory.CreatePost();
            _post.PopularityRanking = TestVariables.PopularityRanking;
            _post.PublishStates.Add(new PublishState { State = "Published" });
            _post.PublishStates.Add(new PublishState { State = "Reviewed" });
            _post.PublishStates.Add(new PublishState { State = "Pending Review" });
            _post.PublishStates.Add(new PublishState { State = "Draft" });
            _post.PublishState = _post.PublishStates[2];
        };

        Because of = () => _binder.Bind(_post, _form, _aliases);

        It should_set_the_data_source_on_the_matching_control_to_the_corresponding_collection = () => _form.cbPublishState.DataSource.ShouldBeTheSameAs(_post.PublishStates);

        It should_set_the_selected_item_on_the_matching_control_to_the_correct_value = () => _form.cbPublishState.SelectedItem.ShouldBeTheSameAs(_post.PublishState);
        It should_take_matching_properties_from_the_object_and_set_them_on_the_form = () =>
        {
            _form.txtTitle.Text.ShouldEqual(TestVariables.Title);
            _form.txtAuthor.Text.ShouldEqual(TestVariables.Author);
            _form.dpDate.Value.ShouldEqual(TestVariables.Posted);
            _form.txtBody.Text.ShouldEqual(TestVariables.Body);
            _form.txtPostLocation.Text.ShouldEqual(TestVariables.Location);
            _form.fcPopularityRanking.PopularityRanking.ShouldEqual(TestVariables.PopularityRanking);
        };

        static Binder _binder;
        static PostWithOptionsPrefixForm _form;
        static Post _post;
        static List<BindaAlias> _aliases;
    }
}