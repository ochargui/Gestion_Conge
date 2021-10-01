using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Conge.Domain
{
    public class conge
    {
        [Key]
        public int id { get; set; }

        public DateTimeOffset dateDebut { get; set; }
        public DateTimeOffset dateFin { get; set; }
        public string libelle { get; set; }
        public int Collaborateurid { get; set; }
        public int typeid { get; set; }
        public int statuid { get; set; }
        public virtual typeConge type { get; set; }
        public virtual statusConge statu { get; set; }

       


   
    }
}
