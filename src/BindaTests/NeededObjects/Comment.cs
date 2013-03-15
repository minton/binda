using System.Collections.Generic;

namespace BindaTests.NeededObjects
{
    public class Comment
    {
        public Comment(string author, string body)
        {
            Author = author;
            Body = body;
            Comments = new List<Comment>();
        }

        public string Author { get; set; }
        public string Body { get; set; }
        public List<Comment> Comments { get; set; }
        public override string ToString()
        {
            return string.Format("{0} : {1}", Author, Body);
        }
    }
}