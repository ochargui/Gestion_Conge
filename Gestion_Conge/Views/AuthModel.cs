using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Conge.Views
{
    public class AuthModel
    {


     
        public string Nom { get; set; }
        public string Prenom { get; set; }


        public string Email { get; set; }


        public string mdp { get; set; }



        public int idRole { get; set; }


        public string picture { get; set; }
       
        public int idFonction { get; set; }
      

     


    }
}