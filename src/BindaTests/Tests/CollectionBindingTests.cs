using System.Collections.Generic;
using System.Windows.Forms;
using Binda;
using BindaTests.NeededObjects;
using NUnit.Framework;
using Test;

namespace BindaTests.Tests
{
    public class CollectionBindingTests
    {
        [Test]
        public void When_binding_an_object_to_a_form_with_a_property_and_a_collection_with_a_pluralized_name_of_the_property()
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

            Assert.That(form.PublishState.DataSource, Is.SameAs(post.PublishStates));
            Assert.That(form.PublishState.SelectedItem, Is.SameAs(post.PublishState));
        }

        [Test]
        public void When_binding_an_object_to_a_form_with_a_property_and_a_key_value_pair_collection()
        {
            var binder = new Binder();
            binder.AddControlPrefix(new HungarianNotationControlPrefix());

            var post = NeededObjectsFactory.CreatePost();
            post.Categories.Add(new KeyValuePair<int, string>(123, "Toast"));
            post.Categories.Add(new KeyValuePair<int, string>(8915, "Waffles"));
            post.Categories.Add(new KeyValuePair<int, string>(56123, "Pizza"));
            post.Category = 56123;

            var form = new PostWithOptionsPrefixForm();
            binder.AddRegistration(new KeyValueListStrategy(), form.cboCategory);
            binder.Bind(post, form);

            Assert.That(form.cboCategory.DataSource, Is.SameAs(post.Categories));
            Assert.That(form.cboCategory.SelectedValue, Is.EqualTo(post.Category));
        }


        [Test]
        public void When_binding_an_object_to_a_form_with_a_property_and_a_collection_with_a_pluralized_name_of_the_property_using_prefixes()
        {
            var binder = new Binder();
            binder.AddControlPrefix(new HungarianNotationControlPrefix());
            var form = new PostWithOptionsPrefixForm();
            var post = NeededObjectsFactory.CreatePost();
            post.PublishStates.Add(new PublishState { State = "Published" });
            post.PublishStates.Add(new PublishState { State = "Reviewed" });
            post.PublishStates.Add(new PublishState { State = "Pending Review" });
            post.PublishStates.Add(new PublishState { State = "Draft" });
            post.PublishState = post.PublishStates[2];

            binder.Bind(post, form);

            Assert.That(form.cbPublishState.DataSource, Is.SameAs(post.PublishStates));
            Assert.That(form.cbPublishState.SelectedItem, Is.SameAs(post.PublishState));
        }


        [Test]
        public void When_binding_an_object_to_a_form_with_a_property_and_a_collection_with_a_pluralized_name_of_the_property_using_prefixes_and_aliases()
        {
            var binder = new Binder();
            binder.AddControlPrefix(new HungarianNotationControlPrefix());
            var aliases = new List<BindaAlias> { new BindaAlias("Location", "PostLocation") };
            var form = new PostWithOptionsPrefixForm();
            var post = NeededObjectsFactory.CreatePost();
            post.PublishStates.Add(new PublishState { State = "Published" });
            post.PublishStates.Add(new PublishState { State = "Reviewed" });
            post.PublishStates.Add(new PublishState { State = "Pending Review" });
            post.PublishStates.Add(new PublishState { State = "Draft" });
            post.PublishState = post.PublishStates[2];

            binder.Bind(post, form, aliases);

            Assert.That(form.cbPublishState.DataSource, Is.SameAs(post.PublishStates));
            Assert.That(form.cbPublishState.SelectedItem, Is.SameAs(post.PublishState));
            Assert.That(form.txtTitle.Text, Is.EqualTo(TestVariables.Title));
            Assert.That(form.txtAuthor.Text, Is.EqualTo(TestVariables.Author));
            Assert.That(form.dpDate.Value, Is.EqualTo(TestVariables.Posted));
            Assert.That(form.txtBody.Text, Is.EqualTo(TestVariables.Body));
            Assert.That(form.txtPostLocation.Text, Is.EqualTo(TestVariables.Location));
        }


        [Test]
        public void When_binding_an_object_to_a_form_with_a_property_and_a_collection_with_a_pluralized_name_of_the_property_using_prefixes_aliases_and_with_custom_registrations()
        {
            var binder = new Binder();
            binder.AddControlPrefix(new HungarianNotationControlPrefix());
            binder.AddRegistration(typeof(FluxCapacitor), "PopularityRanking");
            var aliases = new List<BindaAlias> { new BindaAlias("Location", "PostLocation") };
            var form = new PostWithOptionsPrefixForm();
            var post = NeededObjectsFactory.CreatePost();
            post.PopularityRanking = TestVariables.PopularityRanking;
            post.PublishStates.Add(new PublishState { State = "Published" });
            post.PublishStates.Add(new PublishState { State = "Reviewed" });
            post.PublishStates.Add(new PublishState { State = "Pending Review" });
            post.PublishStates.Add(new PublishState { State = "Draft" });
            post.PublishState = post.PublishStates[2];

            binder.Bind(post, form, aliases);

            Assert.That(form.cbPublishState.DataSource, Is.SameAs(post.PublishStates));
            Assert.That(form.cbPublishState.SelectedItem, Is.SameAs(post.PublishState));
            Assert.That(form.txtTitle.Text, Is.EqualTo(TestVariables.Title));
            Assert.That(form.txtAuthor.Text, Is.EqualTo(TestVariables.Author));
            Assert.That(form.dpDate.Value, Is.EqualTo(TestVariables.Posted));
            Assert.That(form.txtBody.Text, Is.EqualTo(TestVariables.Body));
            Assert.That(form.txtPostLocation.Text, Is.EqualTo(TestVariables.Location));
            Assert.That(form.fcPopularityRanking.PopularityRanking, Is.EqualTo(TestVariables.PopularityRanking));
        }
    }
}