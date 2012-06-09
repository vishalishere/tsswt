using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HP.SW.SWT.Entities
{
    public class ResourceAssignmentDay
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public Resource Resource { get; set; }

        [DisplayFormatAttribute(DataFormatString="{0:F1}")]
        public decimal HoursPerDay { get; set; }
    }
}