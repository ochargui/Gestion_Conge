using Gestion_Conge.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Conge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TokenController : ControllerBase
    {

        public IConfiguration _configuration;
public readonly ProjectsDbContext _context;
public TokenController(IConfiguration configuration, ProjectsDbContext context)
        {
            _configuration = configuration;
            _context = context;

        }
        [HttpPost]
        public async Task<IActionResult> Post(Collaborateur collaborateur)
        {
            if (collaborateur != null && collaborateur.Email != null && collaborateur.mdp != null)
            {
                var user = await GetUser(collaborateur.Email,collaborateur.mdp);
                if (user != null)
                {
                    var claims = new[]{
        new Claim(JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
        new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
        new Claim("id",user.id.ToString()),
        new Claim("idSup",user.idSup.ToString()),
        new Claim("Email",user.Email),
        new Claim("mdp",user.mdp)
};

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],claims,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }

            }
            else
            {
                return BadRequest();
            }

        }
        [HttpGet]
        public async Task<Collaborateur> GetUser(string Email, string mdp)
        {
            return await _context.Collaborateurs.FirstOrDefaultAsync(u => u.Email == Email && u.mdp == mdp);
        }
    }
}

  
