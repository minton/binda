using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Binda;
using BindaTests.NeededObjects;
using Machine.Specifications;
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
            _binder.AddRegistration(typeof(FluxCapacitor), "PopularityRanking", typeof(decimal?));
            _form = new MySampleForm();
            _post = NeededObjectsFactory.CreatePost();
            _post.PopularityRanking = TestVariables.PopularityRanking;
        };

        Because of = () => _binder.Bind(_post, _form);

        It should_take_matching_properties_from_the_object_and_set_them_on_the_form = () =>
        {
            _form.Title.Text.ShouldEqual(TestVariables.Title);
            _form.Author.Text.ShouldEqual(TestVariables.Author);
            _form.Date.Value.ShouldEqual(TestVariables.Posted);
            _form.Body.Text.ShouldEqual(TestVariables.Body);
            _form.PopularityRanking.PopularityRanking.ShouldEqual(TestVariables.PopularityRanking);
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
    public class When_binding_an_object_to_a_form_using_prefixes_with_aliases
    {
        Establish context = () =>
        {
            _binder = new Binder();
            _binder.AddControlPrefix(new HungarianNotationControlPrefix());
            _form = new MySamplePrefixForm();
            _aliases = new List<BindaAlias> { new BindaAlias("Location", "PostLocation") };
            _post = NeededObjectsFactory.CreatePost();
        };

        Because of = () => _binder.Bind(_post, _form, _aliases);

        It should_take_matching_properties_from_the_object_and_set_them_on_the_form = () =>
        {
            _form.txtTitle.Text.ShouldEqual(TestVariables.Title);
            _form.txtAuthor.Text.ShouldEqual(TestVariables.Author);
            _form.dpDate.Value.ShouldEqual(TestVariables.Posted);
            _form.txtBody.Text.ShouldEqual(TestVariables.Body);
            _form.txtPostLocation.Text.ShouldEqual(TestVariables.Location);
        };
        static Binder _binder;
        static MySamplePrefixForm _form;
        static Post _post;
        static List<BindaAlias> _aliases;
    }

    [Subject(typeof(Binder))]
    public class When_binding_an_oject_to_a_form_using_prefixes_with_custom_registrations
    {
        Establish context = () =>
        {
            _binder = new Binder();
            _binder.AddControlPrefix(new HungarianNotationControlPrefix());
            _binder.AddRegistration(typeof(FluxCapacitor), "PopularityRanking", typeof(decimal?));
            _form = new MySamplePrefixForm();
            _post = NeededObjectsFactory.CreatePost();
            _post.PopularityRanking = TestVariables.PopularityRanking;
        };

        Because of = () => _binder.Bind(_post, _form);

        It should_take_matching_properties_from_the_object_and_set_them_on_the_form = () =>
        {
            _form.txtTitle.Text.ShouldEqual(TestVariables.Title);
            _form.txtAuthor.Text.ShouldEqual(TestVariables.Author);
            _form.dpDate.Value.ShouldEqual(TestVariables.Posted);
            _form.txtBody.Text.ShouldEqual(TestVariables.Body);
            _form.fcPopularityRanking.PopularityRanking.ShouldEqual(TestVariables.PopularityRanking);
        };
        static Binder _binder;
        static MySamplePrefixForm _form;
        static Post _post;
    }

    [Subject(typeof(Binder))]
    public class When_binding_an_oject_to_a_form_using_prefixes_aliases_and_custom_registrations
    {
        Establish context = () =>
        {
            _binder = new Binder();
            _binder.AddControlPrefix(new HungarianNotationControlPrefix());
            _binder.AddRegistration(typeof(FluxCapacitor), "PopularityRanking", typeof(decimal?));
            _aliases = new List<BindaAlias> { new BindaAlias("Location", "PostLocation") };
            _form = new MySamplePrefixForm();
            _post = NeededObjectsFactory.CreatePost();
            _post.PopularityRanking = TestVariables.PopularityRanking;
        };

        Because of = () => _binder.Bind(_post, _form, _aliases);

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
        static MySamplePrefixForm _form;
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
    public class When_binding_a_tree_view_to_a_form
    {
        Establish context = () =>
        {
            _binder = new Binder();
            _form = new PostWithOptionsForm();
            _post = NeededObjectsFactory.CreatePost();
            var comments = NeededObjectsFactory.GenerateComments();
            _post.Comments.AddRange(comments);
        };

        Because of = () =>
        {
            _binder.Bind(_post, _form);
            _allNodes = _form.Comments.GetAllNodesRecursive();
        };

        It should_set_the_tag_on_all_nodes = () => _allNodes.ShouldEachConformTo(x => x.Tag != null);
        It should_create_two_root_nodes = () => _form.Comments.Nodes.Count.ShouldEqual(2);
        It should_have_one_reply_to_the_first_comment = () => _allNodes.GetNodeCommentByAuthor("Tom").Nodes.Count.ShouldEqual(1);
        It should_have_one_reply_to_the_first_comments_reply = () => _allNodes.GetNodeCommentByAuthor("Tom").Nodes[0].Nodes.Count.ShouldEqual(1);
        It should_have_one_reply_to_the_second_comment = () => _allNodes.GetNodeCommentByAuthor("Sam").Nodes.Count.ShouldEqual(1);

        static Binder _binder;
        static PostWithOptionsForm _form;
        static Post _post;
        static IEnumerable<TreeNode> _allNodes;
    }
}