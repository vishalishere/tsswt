using System.Collections.Generic;
using System.ComponentModel;

using HP.SW.SWT.Entities;

namespace HP.SW.SWT.MVC.Models
{
    public class ResourceMonthlyHoursModel
    {
        public Resource Resource { get; set; }
        public IEnumerable<ResourceAssignmentDay> HoursByDay { get; set; }
    }

    public class MonthlyHoursModel
    {
        [DisplayName("Período")]
        public Period Period { get; set; }
        public IEnumerable<ResourceMonthlyHoursModel> MonthlyHoursEstimated { get; set; }
        public IEnumerable<ResourceMonthlyHoursModel> MonthlyHoursReal { get; set; }
    }
}