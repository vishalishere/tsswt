using System;
using System.Linq.Expressions;

namespace HP.SW.SWT.Entities
{
    public class PagingOptions
    {
        public int Page { get; set; }
        public int SortColumn { get; set; }
        public bool Ascending { get; set; }

        public Expression GetExpression()
        {
            throw new NotImplementedException();
        }
    }
}
