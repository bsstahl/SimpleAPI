using StackOverflow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bss.EnumerableStack.Data
{
    public static class Asked
    {
        public static Expression<Func<Post, bool>> InLast(TimeSpan span)
        {
            return p => p.CreationDate > DateTime.UtcNow.Subtract(span);
        }
    }
}
