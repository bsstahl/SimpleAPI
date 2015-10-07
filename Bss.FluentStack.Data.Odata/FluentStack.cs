using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bss.FluentStack.Data.Odata
{
    public class FluentStack
    {
        private const string _stackoverflowServiceRoot = "http://localhost:54290/StackOverflowData.svc/";

        public IQueryable<StackOverflowService.Post> Posts
        {
            get
            {
                return (new StackOverflowService.Entities(new Uri(_stackoverflowServiceRoot))).Posts;
            }
        }

        public IQueryable<StackOverflowService.Post> Questions
        {
            get
            {
                return this.Posts.Questions();
            }
        }


    }
}
