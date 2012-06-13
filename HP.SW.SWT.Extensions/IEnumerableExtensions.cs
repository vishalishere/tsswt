using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HP.SW.SWT.Extensions
{
    public static class IEnumerableExtensions
    {
        public static decimal SumOrZero(this IQueryable<decimal> e)
        {
            return e.Count() == 0 ? 0 : e.Sum();
        }

        public static decimal SumOrZero(this IQueryable<decimal?> e)
        {
            return e.Count() == 0 ? 0 : (e.Sum() ?? 0);
        }

        public static decimal SumOrZero<TSource>(this IQueryable<TSource> e, Expression<Func<TSource, decimal>> selector)
        {
            return e.Count() == 0 ? 0 : e.Sum(selector);
        }

        //public static decimal SumOrZero<TSource>(this IEnumerable<TSource> e, Func<TSource, decimal> selector)
        //{
        //    return e.Count() == 0 ? 0 : e.Sum(selector);
        //}
    }
}