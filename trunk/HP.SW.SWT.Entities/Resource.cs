using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HP.SW.SWT.Entities
{
    public class Resource
    {
        [DisplayName("T")]
        [Required]
        public string T { get; set; }

        [DisplayName("Cluster")]
        [Required]
        public string Cluster { get; set; }

        [DisplayName("Nombre")]
        [Required]
        public string Name { get; set; }
    }
}