using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Conge.Views
{
    public class DemandeConge
    {
       
        public DateTimeOffset dateDebut { get; set; }
        public DateTimeOffset dateFin { get; set; }
        public int colabId { get; set; }
        public int typeid { get; set; }
        public int statuid { get; set; }
    }
}
