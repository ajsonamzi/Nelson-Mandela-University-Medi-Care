using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MediCare2._0.Models
{
    public class Alternative
    {

        [Key]
        [Required]
        [Display(Name = "Alternative ID")]
        public int alternativeID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Alternative Drug")]
        public string alternativeName { get; set; }
    }
}
