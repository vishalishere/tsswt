﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HP.SW.SWT.Entities
{
    public class ResourceAssignmentDay
    {
        public DateTime Date { get; set; }

        [DisplayFormatAttribute(DataFormatString="{0:F1}")]
        public decimal Hours { get; set; }
    }
}