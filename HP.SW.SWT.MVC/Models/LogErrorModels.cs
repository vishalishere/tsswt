using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HP.SW.SWT.MVC.Models
{
    public class LogErrorIndexModel
    {
        public Entities.LogErrorFilterOptions Filter { get; set; }

        public IEnumerable<Entities.LogError> Data { get; set; }
    }
}