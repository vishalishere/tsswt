using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HP.SW.SWT.Entities
{
    public class ResourceRealDay
    {
        public DateTime Date { get; set; }

        public bool IsReal { get; set; }

        [DisplayFormatAttribute(DataFormatString="{0:F1}")]
        public decimal HoursInDay { get; set; }
    }
}