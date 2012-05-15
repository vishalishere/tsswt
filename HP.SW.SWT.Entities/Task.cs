using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HP.SW.SWT.Entities
{
    public class Task
    {
        public string Description { get; set; }
        public decimal? EstimatedHours { get; set; }
        public int? DonePercentage { get; set; }

        public decimal PendingHours
        {
            get
            {
                decimal res = (EstimatedHours ?? 0) * (100 - (DonePercentage ?? 0)) / 100;

                // El calculo Round(res * 2,0) / 2 es para que este campo siempre devuelva multiplos de 0,5.
                return Math.Round(res * 2, 0) / 2;
            }
        }
    }
}