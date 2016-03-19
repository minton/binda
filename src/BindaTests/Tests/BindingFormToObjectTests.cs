using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Binda;
using BindaTests.NeededObjects;
using NUnit.Framework;
using Test;

namespace BindaTests.Tests
{
    [TestFixture]
    public class BindingFormToObjectTests
    {
        [Test]
        public void When_binding_a_form_to_an_object()
        {
            var binder = new Binder();
            var form = NeededObjectsFactory.CreateForm();
            var post = new Post();

            binder.Bind(form, post);

            Assert.That(post.Title, Is.EqualTo(TestVariables.Title));
            Assert.That(post.Author, Is.EqualTo(TestVariables.Author));
            Assert.That(post.Date, Is.EqualTo(TestVariables.Posted));
            Assert.That(post.Body, Is.EqualTo(TestVariables.Body));
        }

        [Test]
        public void When_binding_a_form_to_an_object_with_custom_registrations()
        {
            var binder = new Binder();
            binder.AddRegistration(typeof(FluxCapacitor), "PopularityRanking");
            var form = NeededObjectsFactory.CreateForm();
            form.PopularityRanking.PopularityRanking = TestVariables.PopularityRanking;
            var post = new Post();

            binder.Bind(form, post);


            Assert.That(post.Title, Is.EqualTo(TestVariables.Title));
            Assert.That(post.Author, Is.EqualTo(TestVariables.Author));
            Assert.That(post.Date, Is.EqualTo(TestVariables.Posted));
            Assert.That(post.Body, Is.EqualTo(TestVariables.Body));
            Assert.That(post.PopularityRanking, Is.EqualTo(TestVariables.PopularityRanking));
        }

        [Test]
        public void When_binding_a_form_to_an_object_with_aliases()
        {
            var binder = new Binder();
            var aliases = new List<BindaAlias> { new BindaAlias("Location", "PostLocation") };
            var form = NeededObjectsFactory.CreateForm();
            form.PostLocation.Text = TestVariables.Location;
            var post = new Post();

            binder.Bind(form, post, aliases);

            Assert.That(post.Title, Is.EqualTo(TestVariables.Title));
            Assert.That(post.Author, Is.EqualTo(TestVariables.Author));
            Assert.That(post.Date, Is.EqualTo(TestVariables.Posted));
            Assert.That(post.Body, Is.EqualTo(TestVariables.Body));
            Assert.That(post.Location, Is.EqualTo(TestVariables.Location));
        }

        [Test]
        public void When_binding_a_prefix_form_to_an_object()
        {
            var binder = new Binder();
            binder.AddControlPrefix(new HungarianNotationControlPrefix());
            var form = NeededObjectsFactory.CreatePrefixForm();
            var post = new Post();

            binder.Bind(form, post);

            Assert.That(post.Title, Is.EqualTo(TestVariables.Title));
            Assert.That(post.Author, Is.EqualTo(TestVariables.Author));
            Assert.That(post.Date, Is.EqualTo(TestVariables.Posted));
            Assert.That(post.Body, Is.EqualTo(TestVariables.Body));
        }

        [Test]
        public void When_binding_a_prefix_form_to_an_object_with_custom_registrations()
        {
            var binder = new Binder();
            binder.AddControlPrefix(new HungarianNotationControlPrefix());
            binder.AddRegistration(typeof(FluxCapacitor), "PopularityRanking");
            var form = NeededObjectsFactory.CreatePrefixForm();
            form.fcPopularityRanking.PopularityRanking = TestVariables.PopularityRanking;
            var post = new Post();

            binder.Bind(form, post);

            Assert.That(post.Title, Is.EqualTo(TestVariables.Title));
            Assert.That(post.Author, Is.EqualTo(TestVariables.Author));
            Assert.That(post.Date, Is.EqualTo(TestVariables.Posted));
            Assert.That(post.Body, Is.EqualTo(TestVariables.Body));
            Assert.That(post.PopularityRanking, Is.EqualTo(TestVariables.PopularityRanking));
        }

        [Test]
        public void When_binding_a_prefix_form_to_an_object_with_aliases()
        {
            var binder = new Binder();
            binder.AddControlPrefix(new HungarianNotationControlPrefix());
            var aliases = new List<BindaAlias> { new BindaAlias("Location", "PostLocation") };
            var form = NeededObjectsFactory.CreatePrefixForm();
            form.txtPostLocation.Text = TestVariables.Location;
            var post = new Post();

            binder.Bind(form, post, aliases);

            Assert.That(post.Title, Is.EqualTo(TestVariables.Title));
            Assert.That(post.Author, Is.EqualTo(TestVariables.Author));
            Assert.That(post.Date, Is.EqualTo(TestVariables.Posted));
            Assert.That(post.Body, Is.EqualTo(TestVariables.Body));
            Assert.That(post.Location, Is.EqualTo(TestVariables.Location));
        }

        [Test]
        public void When_binding_a_prefix_form_to_an_object_with_aliases_and_custom_registrations()
        {
            var binder = new Binder();
            binder.AddControlPrefix(new HungarianNotationControlPrefix());
            binder.AddRegistration(typeof(FluxCapacitor), "PopularityRanking");
            var aliases = new List<BindaAlias> { new BindaAlias("Location", "PostLocation") };
            var form = NeededObjectsFactory.CreatePrefixForm();
            form.fcPopularityRanking.PopularityRanking = TestVariables.PopularityRanking;
            form.txtPostLocation.Text = TestVariables.Location;
            var post = new Post();

            binder.Bind(form, post, aliases);

            Assert.That(post.Title, Is.EqualTo(TestVariables.Title));
            Assert.That(post.Author, Is.EqualTo(TestVariables.Author));
            Assert.That(post.Date, Is.EqualTo(TestVariables.Posted));
            Assert.That(post.Body, Is.EqualTo(TestVariables.Body));
            Assert.That(post.Location, Is.EqualTo(TestVariables.Location));
            Assert.That(post.PopularityRanking, Is.EqualTo(TestVariables.PopularityRanking));
        }

        [Test]
        public void When_binding_a_form_to_an_object_where_the_object_is_null()
        {
            var binder = new Binder();
            var form = NeededObjectsFactory.CreateForm();

            Assert.Throws<ArgumentNullException>(() => binder.Bind(form, (Post)null));
        }

        [Test]
        public void When_binding_a_form_to_an_object_where_the_form_is_null()
        {
            var binder = new Binder();
            var post = NeededObjectsFactory.CreatePost();

            Assert.Throws<ArgumentNullException>(() => binder.Bind((MySampleForm)null, post));

        }

        [Test]
        public void When_binding_a_form_to_an_object_with_a_collection_and_item_bound_to_a_list_control()
        {
            var binder = new Binder();
            var form = new PostWithOptionsForm();
            var post = NeededObjectsFactory.CreatePost();
            post.PublishStates.Add(new PublishState { State = "Published" });
            post.PublishStates.Add(new PublishState { State = "Reviewed" });
            post.PublishStates.Add(new PublishState { State = "Pending Review" });
            post.PublishStates.Add(new PublishState { State = "Draft" });
            post.PublishState = post.PublishStates[2];
            binder.Bind(post, form);
            var newState = post.PublishStates[0];
            form.PublishState.SelectedItem = newState;

            binder.Bind(form, post);

            Assert.That(post.PublishState, Is.EqualTo(newState));
        }

        [Test]
        public void When_binding_a_form_to_an_object_that_implements_inotifypropertychanged_and_the_form_data_changes()
        {
            var binder = new Binder();
            var form = new PostWithOptionsForm();
            var post = NeededObjectsFactory.CreateNotifyingPost();
            post.PublishStates.Add(new PublishState { State = "Published" });
            post.PublishStates.Add(new PublishState { State = "Reviewed" });
            post.PublishStates.Add(new PublishState { State = "Pending Review" });
            post.PublishStates.Add(new PublishState { State = "Draft" });
            post.PublishState = post.PublishStates[2];
            binder.Bind(post, form, new[] { new BindaAlias("Location", "PostLocation") });
            CreateControl(form);

            form.Title.Text = "New Title";
            form.Author.Text = "New Author";
            form.PostLocation.Text = "New Location";
            form.Body.Text = "New Body";
            form.Date.Value = new DateTime(1979, 12, 31);
            form.PublishState.SelectedItem = post.PublishStates[3];
            form.HitCount.Value = (decimal)Math.Round(Math.PI, 12);

            Assert.That(post.Title, Is.EqualTo("New Title"));
            Assert.That(post.Author, Is.EqualTo("New Author"));
            Assert.That(post.Location, Is.EqualTo("New Location"));
            Assert.That(post.Body, Is.EqualTo("New Body"));
            Assert.That(post.Date, Is.EqualTo(new DateTime(1979, 12, 31)));
            Assert.That(post.PublishState, Is.EqualTo(post.PublishStates[3]));
            Assert.That(post.HitCount, Is.EqualTo((decimal)Math.Round(Math.PI, 12)));
        }

        private static void CreateControl(Control control)
        {
            var method = control.GetType().GetMethod("CreateControl", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            method.Invoke(control, new object[] { true });
        }

        [Test]
        public void When_binding_a_form_to_a_tree_view()
        {
            var binder = new Binder();
            var form = new PostWithOptionsForm();
            var post = NeededObjectsFactory.CreatePost();
            var comments = NeededObjectsFactory.GenerateComments();
            post.Comments.AddRange(comments);
            binder.Bind(post, form);
            post = new Post();

            binder.Bind(form, post);

            Assert.That(post.Comments.Count, Is.EqualTo(2));
            Assert.That(post.Comments.GetCommentByAuthor("Tom").Comments.Count, Is.EqualTo(1));
            Assert.That(post.Comments.GetCommentByAuthor("Tom").Comments[0].Comments.Count, Is.EqualTo(1));
            Assert.That(post.Comments.GetCommentByAuthor("Sam").Comments.Count, Is.EqualTo(1));
        }

    }
}