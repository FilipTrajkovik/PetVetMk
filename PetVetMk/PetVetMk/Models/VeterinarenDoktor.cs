using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetVetMk.Models
{
    public class VeterinarenDoktor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Име и презиме")]
        public string DoktorImePrezime { get; set; }
        [Required]
        [Display(Name = "Општина")]
        public string DoktorOpstina { get; set; }
        [Required]
        [Display(Name = "Телефонски број")]
        public string DoktorTelBroj { get; set; }
        [Required]
        [Display(Name = "Емаил")]
        public string DoktorEmail { get; set; }
        public virtual VeterinarnaAmbulanta veterinarnaAmbulanta { get; set; }
        
    }
}