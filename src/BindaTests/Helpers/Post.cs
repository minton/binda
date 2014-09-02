using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BindaTests.NeededObjects
{
    public class Post
    {
        public Post()
        {
            Comments = new List<Comment>();
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Location { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public Decimal? PopularityRanking { get; set; }
        public PublishState PublishState { get; set; }
        public BindingList<PublishState> PublishStates { get; set; }
        public List<Comment> Comments { get; set; }
    }

    public class PublishState
    {
        public string State { get; set; }

        public override string ToString()
        {
            return State;
        }
    }

    public class NotifyingPost : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Title { get; set; }
        public string Author { get; set; }
        public string Location { get; set; }
        public string Body { get; set; }
        public decimal HitCount { get; set; }
        public DateTime Date { get; set; }
        public Decimal? PopularityRanking { get; set; }
        public PublishState PublishState { get; set; }
        public BindingList<PublishState> PublishStates { get; set; }
    }
}