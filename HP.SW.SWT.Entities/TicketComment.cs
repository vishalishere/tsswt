using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HP.SW.SWT.Entities
{
    public class TicketComment
    {
        public string Comment { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
    }
}