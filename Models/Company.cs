using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace MediCare2._0.Models
{
    public class Company
    {

        [Key]
        [Required]
        [Display(Name = "Company ID")]
        public int companyID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Company Name")]
        public string companyName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Company Email")]
        public string companyEmail { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string companyAddress { get; set; }

        [Required]
        [Display(Name = "Employee Number")]
        public int companyCount { get; set; }


        [Required]
        [Display(Name  = "Region")]
        public virtual int regionID { get; set; }

        [ForeignKey("regionID")]
        public virtual Region Regions { get; set; }
    }
}
