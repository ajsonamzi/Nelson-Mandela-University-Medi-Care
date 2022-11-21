using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MediCare2._0.Models
{
    public class Region
    {
        [Key]
        [Required]
        [Display(Name = "Region ID")]
        public int regionID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Region Name")]
        public string regionName { get; set; }
    }
}
