using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MediCare2._0.Models
{
    public class Phase
    {
        [Key]
        [Required]
        [Display(Name = "Phase ID")]
        public int phaseID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Phase Stage")]
        public string phaseStage { get; set; }

        [Required]
        [StringLength(1000)]
        [Display(Name = "Description")]
        public string phaseDescription { get; set; }
    }
}
