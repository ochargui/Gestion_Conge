
using Gestion_Conge.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gestion_Conge.Services
{
    public interface IUserManager
    {
        SecurityToken Login(LoginViewModel model);

  



    }
}
