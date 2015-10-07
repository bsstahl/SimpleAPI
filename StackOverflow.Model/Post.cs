using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackOverflow.Model
{
    public class Post
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public int? AcceptedAnswerId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Body { get; set; }
        public string Tags { get; set;}

        public Post Parent
        {
            get 
            {
                if (this.ParentId.HasValue)
                    return new Entities().Posts.SingleOrDefault(p => p.ID == this.ParentId);
                else
                    return null;
            }
        }

        public Post() {}

        public Post(int id, string title, int? parentId, int? acceptedAnswerId, DateTime creationDate, string body, string tags)
        {
            this.ID = id;
            this.Title = title;
            this.ParentId = parentId;
            this.AcceptedAnswerId = acceptedAnswerId;
            this.CreationDate = creationDate;
            this.Body = body;
            this.Tags = tags;
        }
    }
}