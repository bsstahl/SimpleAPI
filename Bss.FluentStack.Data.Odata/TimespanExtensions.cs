using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bss.FluentStack.Data.Odata
{
    public static class TimespanExtensions
    {
        public static TimeSpan Days(this int days)
        {
            return TimeSpan.FromDays(days);
        }
    }
}
