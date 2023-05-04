using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetVetMk.Models
{
    public class AmbulantaDoktor
    {
        public AmbulantaDoktor()
        {
            doktorilista = new List<VeterinarenDoktor>();
        }

        public int AmbulantaId { get; set; }

        public int DoktorId { get; set; }

        public VeterinarnaAmbulanta ambulanta { get; set; }

        public List<VeterinarenDoktor> doktorilista { get; set; }
    }
}