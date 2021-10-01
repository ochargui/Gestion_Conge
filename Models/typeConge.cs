using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Conge.Models
{
    public class typeConge
    {
        [Key]
        public string idc { get; set; }
        public string code { get; set; }
        public string label { get; set; }
    }
}
