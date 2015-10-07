using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackOverflow.Model;

namespace Bss.EnumerableStack.Data
{
    public class EnumerableStack
    {
        public IQueryable<Post> Posts
        {
            get
            {
                return (new StackOverflow.Model.Entities()).Posts;
            }
        }

        public IQueryable<Post> Questions
        {
            get
            {
                return this.Posts.Questions();
            }
        }
    }
}
