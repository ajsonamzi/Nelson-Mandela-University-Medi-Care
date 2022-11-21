using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MediCare2._0.Models
{
    public class SideEffect
    {
        [Key]
        [Required]
        [Display(Name = "Side-Effect ID")]
        public int sideEffectID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Side-Effect Name")]
        public string sideEffectName { get; set; }

        [Required]
        [StringLength(1000)]
        [Display(Name = "Description")]
        public string sideEffectDescription { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Added")]
        public DateTime sideEffectDate { get; set; }
    }
}
