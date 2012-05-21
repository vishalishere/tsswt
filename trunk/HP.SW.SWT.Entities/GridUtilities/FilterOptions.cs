using System;
using System.Linq.Expressions;

namespace HP.SW.SWT.Entities
{
    public abstract class FilterOptions
    {
        public abstract Expression GetExpression();
    }
}
