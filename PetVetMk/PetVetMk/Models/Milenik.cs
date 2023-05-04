using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetVetMk.Models
{
    public class Milenik
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Име")]
        public string MilenikIme { get; set; }
        [Required]
        [Display(Name = "Сопственик")]
        public string MilenikSopstvenik { get; set; }
        [Required]
        [Display(Name = "Дата раѓање")]
        public string MilenikDataRaganje { get; set; }
        [Required]
        [Display(Name = "Вид")]
        public string MilenikVid { get; set; }
        [Required]
        [Display(Name = "Раса")]
        public string MilenikRasa { get; set; }
        [Required]
        [Display(Name = "Боја")]
        public string MilenikBoja { get; set; }
        public VeterinarnaAmbulanta veterinarnaAmbulanta { get; set; }
    }
}