using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HP.SW.SWT.Entities
{
    public enum TaskPhase
    {
        Preparacion,
        Analisis,
        Desarrollo,
        Pruebas,
        Entrega,
    }

    public class Task
    {
        public int ID { get; set; }
        public string TicketNumber { get; set; }
        public int Number { get; set; }

        [DisplayName("Etapa")]
        [Required]
        public TaskPhase Phase { get; set; }

        [DisplayName("Descripción")]
        [Required]
        public string Description { get; set; }

        [DisplayName("Horas estimadas")]
        public decimal? EstimatedHours { get; set; }

        [DisplayName("Porcentaje de avance")]
        public int? DonePercentage { get; set; }

        [DisplayName("Horas pendientes")]
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