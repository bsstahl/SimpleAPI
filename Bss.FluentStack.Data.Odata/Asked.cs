using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Bss.FluentStack.Data.Odata
{
    public static class Asked
    {
        public static Expression<Func<StackOverflowService.Post, bool>> InLast(TimeSpan timespan)
        {
            return p => p.CreationDate > DateTime.UtcNow.Subtract(timespan);
        }
    }
}
