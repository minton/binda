using System.Collections.Generic;
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
                    PublishStates = new BindingList<PublishState>(),
                    Comments = new List<Comment>(),
                    Categories = new List<KeyValuePair<int, string>>()
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
                PublishStates = new BindingList<PublishState>(),
                HitCount = 42m
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

        public static MySamplePrefixForm CreatePrefixForm()
        {
            return new MySamplePrefixForm
            {
                txtTitle = { Text = TestVariables.Title },
                txtAuthor = { Text = TestVariables.Author },
                dpDate = { Value = TestVariables.Posted },
                txtBody = { Text = TestVariables.Body }
            };
        }

        public static IEnumerable<Comment> GenerateComments()
        {
            var comment1 = new Comment("Tom", "I love this post!");
            var replyToComment1 = new Comment("Jim", "Tom, I know right!");
            replyToComment1.Comments.Add(new Comment("John", "You guys are easily amused."));
            comment1.Comments.Add(replyToComment1);
            var comment2 = new Comment("Sam", "This post is lol.");
            comment2.Comments.Add(new Comment("Amy", "Sam your face is lol!"));
            return new[] { comment1, comment2 };
        }
    }
}