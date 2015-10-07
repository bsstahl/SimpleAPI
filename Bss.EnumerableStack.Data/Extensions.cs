using StackOverflow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bss.EnumerableStack.Data
{
    public static class Extensions
    {
        public static IQueryable<Post> Questions(this IQueryable<Post> posts)
        {
            return posts.Where(p => p.Parent == null);
        }

        public static IQueryable<Post> WithAcceptedAnswer(this IQueryable<Post> posts)
        {
            return posts.Where(p => p.AcceptedAnswerId != null);
        }

        public static IQueryable<Post> TaggedWith(this IQueryable<Post> posts, string tag)
        {
            string tagValue = string.Format("<{0}>", tag);
            return posts.Where(p => p.Tags.Contains(tagValue));
        }

        public static TimeSpan Days(this int value)
        {
            return TimeSpan.FromDays(value);
        }
    }
}
