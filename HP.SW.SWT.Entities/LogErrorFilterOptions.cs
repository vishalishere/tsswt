using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace HP.SW.SWT.Entities
{
    public class LogErrorFilterOptions
    {
        [DisplayName("Código")]
        public int? Id { get; set; }

        [DisplayName("Fecha desde")]
        public DateTime? DateFrom { get; set; }

        [DisplayName("Fecha hasta")]
        public DateTime? DateTo { get; set; }
    }
}
