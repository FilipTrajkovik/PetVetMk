using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetVetMk.Models
{
    public class VeterinarnaAmbulanta
    {
        public VeterinarnaAmbulanta ()
        {
            vetdoktori = new List<VeterinarenDoktor>();
            milenici = new List<Milenik>();
        }

        public int? Id { get; set; }
        [Display(Name = "Име")]
        public string VetAmbulantaIme { get; set; }
        [Display(Name = "Лого")]
        public string VetAmbulantaLogoUrl { get; set; }
        [Display(Name = "Општина")]
        public string VetAmbulantaOpstina { get; set; }
        [Display(Name = "Адреса")]
        public string VetAmbulantaAdresa { get; set; }
        [Display(Name = "Работно време")]
        public string VetAmbulantaRabotnoVreme { get; set; }
        [Display(Name = "Емаил")]
        public string VetAmbulantaEmail { get; set; }
        [Display(Name = "Телефонски број")]
        public string VetAmbulantaTelBroj { get; set; }
        [Display(Name = "Краток опис")]
        public string VetAmbKratokOpis { get; set; }
        [Display(Name = "За амбулантата")]
        public string VetAmbDolgOpis { get; set; }
        public virtual ICollection<VeterinarenDoktor> vetdoktori { get; set; }
        public virtual ICollection<Milenik> milenici { get; set; }
        
    }
}