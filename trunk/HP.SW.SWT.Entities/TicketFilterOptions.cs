using System;
using System.Linq.Expressions;

namespace HP.SW.SWT.Entities
{
    public class TicketFilterOptions : FilterOptions
    {
        public StringFilter Number { get; set; }
        public StringFilter T { get; set; }
        public StringFilter Cluster { get; set; }
        public TicketStatus Status { get; set; }
        public DatetimeFilter StartDate { get; set; }
        public DatetimeFilter DeliveryDate { get; set; }
        public NumberFilter DonePercentage { get; set; }

        public override Expression GetExpression()
        {
            return null;
        }
    }
}
