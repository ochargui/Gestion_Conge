using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Conge.Domain
{
    public class ResetPasswordModel

    { 
           
            public string NewPassword { get; set; }

           
            public string ConfirmPassword { get; set; }

           
            public string ResetCode { get; set; }
        }
    }

