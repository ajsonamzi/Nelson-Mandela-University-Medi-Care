using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MediCare2._0.Models
{
    public class DrugAdmin
    {
        [Key]
        [Required]
        [Display(Name = "Drug Admin ID")]
        public int drugAdminID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Administration Type")]
        public string adminType { get; set; }
    }
}
