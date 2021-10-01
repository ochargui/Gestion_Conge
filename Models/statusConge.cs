using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Conge.Models
{
    public class statusConge
    {
        [Key]
        public string ids { get; set; }
        public string code { get; set; }
        public string label { get; set; }
    }
}
