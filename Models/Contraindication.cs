using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MediCare2._0.Models
{
    public class Contraindication
    {

        [Key]
        [Required]
        [Display(Name = "Contraindication ID")]
        public int contraindicationID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Contraindication Drug")]
        public string contraindicationName { get; set; }
    }
}
