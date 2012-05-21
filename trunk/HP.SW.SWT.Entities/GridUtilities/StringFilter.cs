using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace HP.SW.SWT.Entities
{
    public class StringFilter : DataFilter
    {
        public string Equal { get; set; }
        public string Like { get; set; }

        public override Expression GetExpression()
        {
            throw new NotImplementedException();
        }
    }
}
