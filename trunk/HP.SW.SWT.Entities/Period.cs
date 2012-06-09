using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HP.SW.SWT.Entities
{
    public class Period
    {
        [DisplayName("ID")]
        [Required]
        public int ID { get; set; }

        [DisplayName("Año")]
        [Required]
        public int Year { get; set; }

        [DisplayName("Mes")]
        [Required]
        public int Month { get; set; }

        [DisplayName("Descripción")]
        [Required]
        public string Description { get; set; }

        [DisplayName("Fecha de Inicio")]
        [Required]
        [DisplayFormatAttribute(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}", NullDisplayText = "")]
        public DateTime StartDate { get; set; }

        [DisplayName("Fecha de Fin")]
        [DisplayFormatAttribute(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}", NullDisplayText = "")]
        public DateTime? EndDate { get; set; }

        [DisplayName("Días laborales")]
        [DisplayFormatAttribute(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:F1}", NullDisplayText = "")]
        public decimal BusinessDays 
        {
            get
            {
                int res = 0;
                if (this.EndDate.HasValue)
                {
                    for (DateTime d = this.StartDate.Date; d <= this.EndDate.Value.Date; d = d.AddDays(1))
                    {
                        if (DateHelper.IsWorkingDay(d))
                        {
                            res++;
                        }
                    }
                }
                return res;
            }
        }
    }
}
