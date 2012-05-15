using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HP.SW.SWT.Entities
{
    public class ExcelRow
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartHour { get; set; }
        public DateTime? EndHour { get; set; }
        public decimal? Hours
        {
            get
            {
                return EndHour.HasValue ? (decimal)(EndHour.Value - StartHour).TotalHours : (decimal?)null;
            }
        }
        public string Ticket { get; set; }
        public string Description { get; set; }
        public string Cluster { get; set; }

        //public bool SCPCharged { get; set; }
        public sbyte SCPCharged { get; set; }
        public decimal? SCPHours { get; set; }
        public string SCPTicket { get; set; }
        public string SCPT { get; set; }
    }
}
