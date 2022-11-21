using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MediCare2._0.Models
{
    public class Schedule
    {
        [Key]
        [Required]
        [Display(Name = "Schedule ID")]
        public int scheduleID { get; set; }

        [Required]
        [Display(Name = "Schedule Number")]
        public int scheduleNumber { get; set; }

        [Required]
        [StringLength(1000)]
        [Display(Name = "Description")]
        public string scheduleDescription { get; set; }

    }
}
