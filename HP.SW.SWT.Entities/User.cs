using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HP.SW.SWT.Entities
{
    public class User
    {
        [DisplayName("ID")]
        [Required]
        public int ID { get; set; }

        [DisplayName("Usuario")]
        [Required]
        public string Logon { get; set; }

        [DisplayName("Clave")]
        [Required]
        public string Password { get; set; }

        [DisplayName("Nombre")]
        [Required]
        public string Name { get; set; }
    }
}