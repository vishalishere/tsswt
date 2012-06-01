using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HP.SW.SWT.Entities
{
    public class Holiday
    {
        [DisplayName("Fecha")]
        [Required]
        [DisplayFormatAttribute(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}", NullDisplayText = "")]
        public DateTime Date { get; set; }

        [DisplayName("Descripción")]
        [Required]
        public string Description { get; set; }
    }
}
