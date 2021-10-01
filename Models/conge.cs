using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Conge.Models
{
    public class conge
    {
        [Key]
        public string  id { get; set; }
        public typeConge type { get; set; }
        public statusConge status { get; set; }
        public DateTime dateDebut  { get; set; }
        public DateTime dateFin { get; set; }
        public conge Conge { get; set; }




    }
}
