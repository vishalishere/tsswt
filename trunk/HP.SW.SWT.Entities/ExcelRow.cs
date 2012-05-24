using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HP.SW.SWT.Entities
{
    public class ExcelRow
    {
        [DisplayName("ID")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Fecha")]
        [Required]
        public DateTime Date { get; set; }

        [DisplayName("Hora de inicio")]
        [Required]
        public DateTime StartHour { get; set; }

        [DisplayName("Hora de fin")]
        public DateTime? EndHour { get; set; }

        [DisplayName("Horas")]
        public decimal? Hours
        {
            get
            {
                return EndHour.HasValue ? (decimal)(EndHour.Value - StartHour).TotalHours : (decimal?)null;
            }
        }

        [DisplayName("Ticket")]
        [Required]
        public string Ticket { get; set; }

        [DisplayName("Descripción")]
        [Required]
        public string Description { get; set; }

        [DisplayName("Cluster")]
        [Required]
        public string Cluster { get; set; }

        [DisplayName("Recurso")]
        [Required]
        public Resource Resource { get; set; }

        [DisplayName("¿Cargadas?")]
        [Required]
        public sbyte SCPCharged { get; set; }

        [DisplayName("Horas cargadas")]
        public decimal? SCPHours { get; set; }

        [DisplayName("Cargadas al Ticket")]
        public string SCPTicket { get; set; }

        [DisplayName("Cargadas al usuario")]
        public string SCPT { get; set; }        
    }
}