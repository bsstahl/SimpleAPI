using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bss.FluentStack.Data.Odata
{
    public static class PostExtensions
    {
        public static IQueryable<StackOverflowService.Post> Questions(this IQueryable<StackOverflowService.Post> posts)
        {
            return posts.Where(p => p.Parent == null);
        }

        public static IQueryable<StackOverflowService.Post> WithAcceptedAnswer(this IQueryable<StackOverflowService.Post> posts)
        {
            return posts.Where(p => p.AcceptedAnswerId != null);
        }

        public static IQueryable<StackOverflowService.Post> TaggedWith(this IQueryable<StackOverflowService.Post> posts, string tag)
        {
            string tagValue = string.Format("<{0}>", tag);
            return posts.Where(p => p.Tags.Contains(tagValue));
        }
    }
}
