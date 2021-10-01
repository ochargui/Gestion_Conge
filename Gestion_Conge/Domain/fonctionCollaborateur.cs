
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Conge.Domain
{
    public class fonctionCollaborateur
    {[Key]
     
        public int id { get; set; }
        public string code { get; set; }
        public string label { get; set; }
       
    }
}
