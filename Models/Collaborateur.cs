using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Conge.Models
{
    public class Collaborateur
    {
        [Key]
        public string id { get; set; }
    
        public string idSup { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string mdp { get; set; }
     
        public string picture{ get; set; }
        public role role { get; set; }
       public fonctionCollaborateur fonction { get; set; }

        ICollection<conge> conge { get; set; }

     
    }
}
