using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackOverflow.Model
{
    public class Entities
    {
        private const string _dataFilePath = @"C:\Users\bstahl\Source\Repos\SimpleAPI\StackOverflow\Data.xml";

        private List<Post> _posts;
        public IQueryable<Post> Posts
        {
            get { return _posts.AsQueryable(); }
        }

        public Entities()
        {
            using (var reader = System.Xml.XmlReader.Create(_dataFilePath))
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<StackOverflow.Model.Post>));
                _posts = (List<Post>)serializer.Deserialize(reader);
                UpdatePostDates(_posts);
            }
        }

        private void UpdatePostDates(IEnumerable<Post> posts)
        {
            var lastDate = posts.Max(p => p.CreationDate);
            var daysToAdd = DateTime.Now.Subtract(lastDate).TotalDays;

            foreach (var post in posts)
            {
                post.CreationDate = post.CreationDate.AddDays(daysToAdd);
            }
        }

    }
}