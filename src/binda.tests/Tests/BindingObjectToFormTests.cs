using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Binda;
using BindaTests.Helpers;
using BindaTests.NeededObjects;
using NUnit.Framework;
using Test;

namespace BindaTests.Tests
{
    [TestFixture]
    public class BindingObjectToFormTests
    {
        [Test]
        public void When_binding_an_object_to_aform()
        {
            var binder = new Binder();
            var form = new MySampleForm();
            var post = NeededObjectsFactory.CreatePost();

            binder.Bind(post, form);

            Assert.That(form.Title.Text, Is.EqualTo(TestVariables.Title));
            Assert.That(form.Author.Text, Is.EqualTo(TestVariables.Author));
            Assert.That(form.Date.Value, Is.EqualTo(TestVariables.Posted));
            Assert.That(form.Body.Text, Is.EqualTo(TestVariables.Body));
        }


        [Test]
        public void When_binding_an_oject_to_aform_with_custom_registrations()
        {
            var binder = new Binder();
            binder.AddRegistration(typeof (FluxCapacitor), "PopularityRanking");
            var form = new MySampleForm();
            var post = NeededObjectsFactory.CreatePost();
            post.PopularityRanking = TestVariables.PopularityRanking;

            binder.Bind(post, form);

            Assert.That(form.Title.Text, Is.EqualTo(TestVariables.Title));
            Assert.That(form.Author.Text, Is.EqualTo(TestVariables.Author));
            Assert.That(form.Date.Value, Is.EqualTo(TestVariables.Posted));
            Assert.That(form.Body.Text, Is.EqualTo(TestVariables.Body));
            Assert.That(form.PopularityRanking.PopularityRanking, Is.EqualTo(TestVariables.PopularityRanking));
        }

        [Test]
        public void When_binding_an_object_to_a_form_with_custom_control_registrations()
        {
            var binder = new Binder();
            var form = new MySampleForm();
            var strategy = new TestBindaStrategy();

            binder.AddRegistration(strategy, form.Title);
            binder.AddRegistration(typeof (TextBox), "Text");

            var post = NeededObjectsFactory.CreatePost();
            binder.Bind(post, form);

            Assert.IsTrue(strategy.WasSet);
        }

        [Test]
        public void When_binding_an_object_to_aform_withaliases()
        {
            var binder = new Binder();
            var form = new MySampleForm();
            var aliases = new List<BindaAlias> {new BindaAlias("Location", "PostLocation")};
            var post = NeededObjectsFactory.CreatePost();

            binder.Bind(post, form, aliases);

            Assert.That(form.Title.Text, Is.EqualTo(TestVariables.Title));
            Assert.That(form.Author.Text, Is.EqualTo(TestVariables.Author));
            Assert.That(form.Date.Value, Is.EqualTo(TestVariables.Posted));
            Assert.That(form.Body.Text, Is.EqualTo(TestVariables.Body));
            Assert.That(form.PostLocation.Text,Is.EqualTo(TestVariables.Location));
        }


        [Test]
        public void When_binding_an_object_to_aform_using_prefixes_withaliases()
        {
            var binder = new Binder();
            binder.AddControlPrefix(new HungarianNotationControlPrefix());
            var form = new MySamplePrefixForm();
            var aliases = new List<BindaAlias> {new BindaAlias("Location", "PostLocation")};
            var post = NeededObjectsFactory.CreatePost();

            binder.Bind(post, form, aliases);

            Assert.That(form.txtTitle.Text, Is.EqualTo(TestVariables.Title));
            Assert.That(form.txtAuthor.Text, Is.EqualTo(TestVariables.Author));
            Assert.That(form.dpDate.Value, Is.EqualTo(TestVariables.Posted));
            Assert.That(form.txtBody.Text, Is.EqualTo(TestVariables.Body));
            Assert.That(form.txtPostLocation.Text, Is.EqualTo(TestVariables.Location));
        }


        [Test]
        public void When_binding_an_oject_to_aform_using_prefixes_with_custom_registrations()
        {
            var binder = new Binder();
            binder.AddControlPrefix(new HungarianNotationControlPrefix());
            binder.AddRegistration(typeof (FluxCapacitor), "PopularityRanking");
            var form = new MySamplePrefixForm();
            var post = NeededObjectsFactory.CreatePost();
            post.PopularityRanking = TestVariables.PopularityRanking;

            binder.Bind(post, form);

            Assert.That(form.txtTitle.Text, Is.EqualTo(TestVariables.Title));
            Assert.That(form.txtAuthor.Text, Is.EqualTo(TestVariables.Author));
            Assert.That(form.dpDate.Value, Is.EqualTo(TestVariables.Posted));
            Assert.That(form.txtBody.Text, Is.EqualTo(TestVariables.Body));
            Assert.That(form.fcPopularityRanking.PopularityRanking, Is.EqualTo(TestVariables.PopularityRanking));
        }


        [Test]
        public void When_binding_an_oject_to_aform_using_prefixesaliases_and_custom_registrations()
        {
            var binder = new Binder();
            binder.AddControlPrefix(new HungarianNotationControlPrefix());
            binder.AddRegistration(typeof (FluxCapacitor), "PopularityRanking");
            var aliases = new List<BindaAlias> {new BindaAlias("Location", "PostLocation")};
            var form = new MySamplePrefixForm();
            var post = NeededObjectsFactory.CreatePost();
            post.PopularityRanking = TestVariables.PopularityRanking;

            binder.Bind(post, form, aliases);

            Assert.That(form.txtTitle.Text, Is.EqualTo(TestVariables.Title));
            Assert.That(form.txtAuthor.Text, Is.EqualTo(TestVariables.Author));
            Assert.That(form.dpDate.Value, Is.EqualTo(TestVariables.Posted));
            Assert.That(form.txtBody.Text, Is.EqualTo(TestVariables.Body));
            Assert.That(form.txtPostLocation.Text, Is.EqualTo(TestVariables.Location));
            Assert.That(form.fcPopularityRanking.PopularityRanking, Is.EqualTo(TestVariables.PopularityRanking));
        }


        [Test]
        public void When_binding_an_object_to_aform_where_the_object_is_null()
        {
            var binder = new Binder();
            var form = new MySampleForm();

            Assert.Throws<ArgumentNullException>(() => binder.Bind((Post) null, form));
        }


        [Test]
        public void When_binding_an_object_to_aform_where_theform_is_null()
        {
            var binder = new Binder();
            var post = NeededObjectsFactory.CreatePost();

            Assert.Throws<ArgumentNullException>(() => binder.Bind(post, (MySampleForm)null));
        }

        [Test]
        public void When_binding_a_tree_view_to_aform()
        {
            var binder = new Binder();
            var form = new PostWithOptionsForm();
            var post = NeededObjectsFactory.CreatePost();
            var comments = NeededObjectsFactory.GenerateComments();
            post.Comments.AddRange(comments);

            binder.Bind(post, form);

            var allNodes = form.Comments.GetAllNodesRecursive();
            var tags = allNodes.Select(x => x.Tag);
            CollectionAssert.AllItemsAreNotNull(tags);
            Assert.That(form.Comments.Nodes.Count, Is.EqualTo(2));
            Assert.That(allNodes.GetNodeCommentByAuthor("Tom").Nodes.Count, Is.EqualTo(1));
            Assert.That(allNodes.GetNodeCommentByAuthor("Tom").Nodes[0].Nodes.Count, Is.EqualTo(1));
            Assert.That(allNodes.GetNodeCommentByAuthor("Sam").Nodes.Count, Is.EqualTo(1));
        }
    }
}