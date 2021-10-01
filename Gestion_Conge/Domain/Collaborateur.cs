using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Conge.Domain
{

    public class Collaborateur
    {
        public int id { get; set; }

        public int idSup { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }


        public string Email { get; set; }
        public string RestPassword{ get; set; }


        public string mdp { get; set; }
        public string picture { get; set; }



        public int roleid { get; set; }
        public int fonctionid { get; set; }
        public virtual role role { get; set; }
        public virtual fonctionCollaborateur fonction { get; set; }

        public virtual ICollection<conge> conge { get; set; }


    }
}



