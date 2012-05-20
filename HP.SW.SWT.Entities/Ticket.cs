using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Web;

namespace HP.SW.SWT.Entities
{
    public class Ticket
    {
        public string Number { get; set; }
        public Resource Resource { get; set; }
        //public bool Working { get; set; }
        public string Cluster { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public decimal? ConsumedHours { get; set; }
        public IEnumerable<Task> Tasks { get; set; }

        public decimal? EstimatedHours
        {
            get
            {
                return this.Tasks.Sum(x => x.EstimatedHours);
            }
        }

        // La cantidad de horas a consumir estimada se define como
        //      "La suma del tiempo invertido hasta ahora + el estimado del porcentaje pendiente de las tareas a realizar."
        public decimal PendingHours
        {
            get
            {
                return this.Tasks.Sum(x => x.PendingHours);
            }
        }

        // La cantidad de horas a consumir estimada se define como
        //      "La suma del tiempo invertido hasta ahora + el estimado del porcentaje pendiente de las tareas a realizar."
        public decimal? ConsumedHoursForecast
        {
            get
            {
                return (this.ConsumedHours ?? 0) + this.PendingHours;
            }
        }

        // La fecha estimada de inicio se define como
        //      "La máxima fecha en que se puede empezar el ticket y entregarlo con un día de anticipación."
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
        public DateTime DeliveryDateForecast
        {
            get
            {
                return DateHelper.AddWorkingHours(DateTime.Now, this.PendingHours);
            }
        }

        public decimal DonePercentage
        {
            get
            {
                //No hace falta multiplicar por 100 porque el DonePercentage va de 0 a 100.
                return this.Tasks.Sum(t => t.DonePercentage * t.EstimatedHours) / this.Tasks.Sum(t => t.EstimatedHours);
            }
        }
    }
}