using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HP.SW.SWT.Entities
{
    public class Task
    {
        [DisplayName("Descripción")]
        [Required]
        public string Description { get; set; }
        
        [DisplayName("Horas estimadas")]
        [Required]
        public decimal EstimatedHours { get; set; }

        [DisplayName("Porcentaje de avance")]
        [Required]
        public int DonePercentage { get; set; }

        [DisplayName("Horas pendientes")]
        public decimal PendingHours
        {
            get
            {
                decimal res = EstimatedHours * (100 - DonePercentage) / 100;

                // El calculo Round(res * 2,0) / 2 es para que este campo siempre devuelva multiplos de 0,5.
                return Math.Round(res * 2, 0) / 2;
            }
        }
    }
}