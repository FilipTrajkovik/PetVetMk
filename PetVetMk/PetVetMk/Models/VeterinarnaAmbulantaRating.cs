using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetVetMk.Models
{
    public class VeterinarnaAmbulantaRating
    {
        public int Id { get; set; }
        public int ambulantaId { get; set; }
        public string korisnikId { get; set; }
        public int rating { get; set; }

    }
}