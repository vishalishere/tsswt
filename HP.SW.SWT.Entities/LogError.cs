using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HP.SW.SWT.Entities
{
    public class LogError
    {
        [DisplayName("ID")]
        public int ID { get; set; }

        [DisplayName("Fecha/Hora")]
        public DateTime Date { get; set; }

        [DisplayName("Usuario")]
        public User User { get; set; }

        [DisplayName("Mensaje")]
        public string Message { get; set; }

        [DisplayName("Stack Trace")]
        public string StackTrace { get; set; }
    }
}
