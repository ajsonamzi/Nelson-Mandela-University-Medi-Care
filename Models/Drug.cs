using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace MediCare2._0.Models
{
    public class Drug
    {
        [Key]
        [Required]
        [Display(Name = "Drug ID")]
        public int drugID { get; set; }

        [Required]
        [Display(Name = "Drug Name")]
        [StringLength(100)]
        public string drugName { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string description { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Dosage")]
        public string dosage { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date First Manufactured")]
        public DateTime dateFirstManufactured { get; set; }

        [Required]
        [Display(Name = "Drug Admin")]
        public virtual int drugAdminID { get; set; }

        [ForeignKey("drugAdminID")]
        public virtual DrugAdmin DrugAdmins { get; set; }



        [Display(Name = "Side Effects")]
        [Required]
        public virtual int sideEffectID { get; set; }

        [ForeignKey("sideEffectID")]
        public virtual SideEffect SideEffects { get; set; }




        [Display(Name = "Symptom")]
        [Required]
        public virtual int symptomID { get; set; }

        [ForeignKey("symptomID")]
        public virtual Symptom Symptoms { get; set; }




        [Display(Name = "Company")]
        public virtual int companyID { get; set; }

        [ForeignKey("companyID")]
        public virtual Company Companies { get; set; }



        [Display(Name = "Phase")]
        public virtual int phaseID { get; set; }

        [ForeignKey("phaseID")]
        public virtual Phase Phases { get; set; }



        [Display(Name = "Alternative")]
        public virtual int alternativeID { get; set; }

        [ForeignKey("alternativeID")]
        public virtual Alternative Alternatives { get; set; }


        [Display(Name = "Contraindication")]
        public virtual int contraindicationID { get; set; }

        [ForeignKey("contraindicationID")]
        public virtual Contraindication Contraindications { get; set; }

        [Display(Name = "Schedule")]
        public virtual int scheduleID { get; set; }

        [ForeignKey("scheduleID")]
        public virtual Schedule Schedules { get; set; }

    }
}
