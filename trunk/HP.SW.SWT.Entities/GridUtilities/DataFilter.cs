using System.Linq.Expressions;

namespace HP.SW.SWT.Entities
{
    public abstract class DataFilter
    {
        public abstract Expression GetExpression();
    }
}
