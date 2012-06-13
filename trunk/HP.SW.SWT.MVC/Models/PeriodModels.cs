using System.Collections.Generic;
using System.ComponentModel;

using HP.SW.SWT.Entities;
using System.ComponentModel.DataAnnotations;

namespace HP.SW.SWT.MVC.Models
{
    public class MonthlyHoursModelEstimated
    {
        public Resource Resource { get; set; }
        public IEnumerable<ResourceAssignmentDay> HoursByDay { get; set; }
    }

    public class MonthlyHoursModelReal
    {
        public Resource Resource { get; set; }
        public IEnumerable<ResourceRealDay> HoursByDay { get; set; }
    }

    public class MonthlyHoursModel
    {
        [DisplayName("Período")]
        public Period Period { get; set; }
        public IEnumerable<MonthlyHoursModelEstimated> MonthlyHoursEstimated { get; set; }
        public IEnumerable<MonthlyHoursModelReal> MonthlyHoursReal { get; set; }
    }

    public class DashboardReportModel
    {
        [DisplayName("Carga Inicial")]
        [DisplayFormatAttribute(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:F1}", NullDisplayText = "")]
        public decimal Initial { get; set; }
        
        [DisplayName("Ausencias Programadas")]
        [DisplayFormatAttribute(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:F1}", NullDisplayText = "")]
        public decimal ScheduledAbsences { get; set; }

        [DisplayName("Ausencias no Programadas")]
        [DisplayFormatAttribute(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:F1}", NullDisplayText = "")]
        public decimal NonScheduledAbsences { get; set; }
        
        [DisplayName("Retrabajo")]
        [DisplayFormatAttribute(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:F1}", NullDisplayText = "")]
        public decimal Rework { get; set; }
        
        [DisplayName("Horas no certificables")]
        [DisplayFormatAttribute(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:F1}", NullDisplayText = "")]
        public decimal NonCertifiable { get; set; }
        
        [DisplayName("Leverage")]
        [DisplayFormatAttribute(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:F1}", NullDisplayText = "")]
        public decimal Leverage { get; set; }

        [DisplayName("Total")]
        [DisplayFormatAttribute(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:F1}", NullDisplayText = "")]
        public decimal Total
        {
            get 
            {
                return this.Initial - this.ScheduledAbsences - this.NonScheduledAbsences - this.Rework - this.NonCertifiable + this.Leverage;
            }
        }
    }
}