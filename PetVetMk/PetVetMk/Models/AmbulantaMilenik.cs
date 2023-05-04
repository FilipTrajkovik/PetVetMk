using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetVetMk.Models
{
    public class AmbulantaMilenik
    {
        public AmbulantaMilenik()
        {
            milenicilista = new List<Milenik>();
        }
        public int AmbulantaId { get; set; }

        public int MilenikId { get; set; }

        public VeterinarnaAmbulanta ambulanta { get; set; }

        public List<Milenik> milenicilista { get; set; }
    }
}