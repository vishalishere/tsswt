using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HP.SW.SWT.Entities
{
    public class Holiday
    {
        [DisplayName("Fecha")]
        [Required]
        public DateTime Date { get; set; }

        [DisplayName("Descripción")]
        [Required]
        public string Description { get; set; }
    }
}
