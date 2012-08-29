using System;
using System.ComponentModel;

namespace BindaTests.NeededObjects
{
    public class Post
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Location { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public Decimal? Radiation { get; set; }
        public PublishState PublishState { get; set; }
        public BindingList<PublishState> PublishStates { get; set; }
    }

    public class PublishState
    {
        public string State { get; set; }
    }
}