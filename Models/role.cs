using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Conge.Models
{
    public class role
    {
        [Key]
        public string idr { get; set; }
        public string code { get; set; }
        public string label { get; set; }
    }
}
