using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HP.SW.SWT.Entities
{
    public enum TicketStatus
    {
        Recibido,
        EnAnalisis,
        Estimado,
        EnDesarrollo,
        Entregado,
        None = 0,
    }

    public enum TicketPriority
    {
        High,
        Normal,
        Low
    }

    public enum TicketCategory
    {
        Incident,
        MinorChange,
        Evolutive
    }

    public class Ticket
    {
        [DisplayName("Número")]
        [Required]
        public string Number { get; set; }

        [DisplayName("Título")]
        [Required]
        public string Title { get; set; }

        [DisplayName("Descripción")]
        [Required]
        public string Description { get; set; }

        [DisplayName("Asignado A")]
        [Required]
        public Resource Resource { get; set; }

        [DisplayName("Status")]
        [Required]
        public TicketStatus Status { get; set; }

        [DisplayName("Prioridad")]
        [Required]
        public TicketPriority Priority { get; set; }

        [DisplayName("Categoría")]
        [Required]
        public TicketCategory Category { get; set; }

        [DisplayName("Cluster")]
        [Required]
        public string Cluster { get; set; }

        [DisplayName("Sistema")]
        [Required]
        public string System { get; set; }

        [DisplayName("Fecha de Inicio")]
        public DateTime? StartDate { get; set; }

        [DisplayName("Fecha estimada de Entrega")]
        public DateTime? DeliveryDate { get; set; }

        [DisplayName("Fecha real de Entrega")]
        public DateTime? RealDeliveryDate { get; set; }

        [DisplayName("Horas consumidas")]
        public decimal? ConsumedHours { get; set; }

        public IEnumerable<Task> Tasks { get; set; }

        [DisplayName("Comentarios")]
        public IEnumerable<TicketComment> Comments { get; set; }

        [DisplayName("Estimación")]
        public decimal? EstimatedHours
        {
            get
            {
                return this.Tasks.Sum(x => x.EstimatedHours);
            }
        }

        // La cantidad de horas a consumir estimada se define como
        //      "La suma del tiempo invertido hasta ahora + el estimado del porcentaje pendiente de las tareas a realizar."
        [DisplayName("Horas pendientes")]
        public decimal PendingHours
        {
            get
            {
                return this.Tasks.Sum(x => x.PendingHours);
            }
        }

        // La cantidad de horas a consumir estimada se define como
        //      "La suma del tiempo invertido hasta ahora + el estimado del porcentaje pendiente de las tareas a realizar."
        [DisplayName("Pronóstico de horas consumidas")]
        public decimal? ConsumedHoursForecast
        {
            get
            {
                return (this.ConsumedHours ?? 0) + this.PendingHours;
            }
        }

        // La fecha estimada de inicio se define como
        //      "La máxima fecha en que se puede empezar el ticket y entregarlo con un día de anticipación."
        [DisplayName("Pronóstico de fecha de inicio")]
        public DateTime? StartDateForecast
        {
            get
            {
                return this.DeliveryDate == null ? (DateTime?)null :
                    DateHelper.AddWorkingHours(DateHelper.EndWorkingDay(this.DeliveryDate.Value.AddDays(-1)), -1 * this.Tasks.Sum(x => x.EstimatedHours));
            }
        }

        // La fecha estimada de entrega se define como
        //      "La minima fecha en que se puede entregar el ticket continuandolo ahora."
        //      ¿ESTA DEFINICION NO SIRVE? --> "La minima fecha en que se puede entregar el ticket desde la fecha de inicio, sumados los desvíos en las tareas ya realizadas."
        [DisplayName("Pronóstico de fecha de entrega")]
        public DateTime DeliveryDateForecast
        {
            get
            {
                return DateHelper.AddWorkingHours(DateTime.Now, this.PendingHours);
            }
        }

        [DisplayName("Porcentaje de avance")]
        public decimal DonePercentage
        {
            get
            {
                decimal estimatedHours = this.Tasks.Sum(t => t.EstimatedHours);

                if (estimatedHours == 0)
                {
                    return 0;
                }
                else
                {
                    //No hace falta multiplicar por 100 porque el DonePercentage va de 0 a 100.
                    return this.Tasks.Sum(t => t.DonePercentage * t.EstimatedHours) / estimatedHours;
                }
            }
        }

        [DisplayName("Fecha de Creación")]
        public DateTime DateCreated { get; set; }

        [DisplayName("Usuario de Creación")]
        public User UserCreated { get; set; }

        [DisplayName("Fecha de Última Modificación")]
        public DateTime DateLastModified { get; set; }

        [DisplayName("Usuario de Última Modificación")]
        public User UserLastModified { get; set; }

        [DisplayName("Fecha de Eliminación")]
        public DateTime DateDeleted { get; set; }

        [DisplayName("Usuario de Eliminación")]
        public User UserDeleted { get; set; }
    }
}