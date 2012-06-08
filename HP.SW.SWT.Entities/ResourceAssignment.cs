using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HP.SW.SWT.Entities
{
    public class ResourceAssignment
    {
        public int ID { get; set; }
        public Period Period { get; set; }
        public Resource Resource { get; set; }
        public decimal HoursPerDay { get; set; }
    }
}
