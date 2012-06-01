using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HP.SW.SWT.Entities
{
    public class TicketComment
    {
        public string Comment { get; set; }
        public User User { get; set; }

        [DisplayFormatAttribute(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}", NullDisplayText = "")]
        public DateTime Date { get; set; }
    }
}