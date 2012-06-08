﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HP.SW.SWT.Entities
{
    public class ResourceAssignmentDay
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public Resource Resource { get; set; }
        public decimal HoursPerDay { get; set; }
    }
}