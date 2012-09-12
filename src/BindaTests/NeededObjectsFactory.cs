using System.ComponentModel;
using BindaTests.NeededObjects;
using Test;

namespace BindaTests
{
    public static class NeededObjectsFactory
    {
        public static Post CreatePost()
        {
            return new Post
            {
                Title = TestVariables.Title,
                Author = TestVariables.Author,
                Date = TestVariables.Posted,
                Body = TestVariables.Body,
                Location = TestVariables.Location,
                PublishStates = new BindingList<PublishState>()
            };
        }

        public static NotifyingPost CreateNotifyingPost()
        {
            return new NotifyingPost
            {
                Title = TestVariables.Title,
                Author = TestVariables.Author,
                Date = TestVariables.Posted,
                Body = TestVariables.Body,
                Location = TestVariables.Location,
                PublishStates = new BindingList<PublishState>()
            };
        }

        public static MySampleForm CreateForm()
        {
           return new MySampleForm
            {
                Title = { Text = TestVariables.Title },
                Author = { Text = TestVariables.Author },
                Date = { Value = TestVariables.Posted },
                Body = { Text = TestVariables.Body }
            };
        }
    }
}