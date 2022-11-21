using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MediCare2._0.Models
{
    public class Symptom
    {
        [Key]
        [Required]
        [Display(Name = "Symptom ID")]
        public int symptomID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Symptom Name")]
        public string symptomName { get; set; }

        [Required]
        [StringLength(1000)]
        [Display(Name = "Description")]
        public string symptomDescription { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Added")]
        public DateTime symptomDate { get; set; }
    }
}
