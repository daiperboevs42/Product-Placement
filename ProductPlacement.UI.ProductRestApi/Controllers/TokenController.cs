using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProdductPlacement.Core.Entity;
using ProductPlacement.Infrastructure.Data.Repositories;
using ProductPlacement.UI.ProductRestApi.Helper;

namespace ProductPlacement.UI.ProductRestApi.Controllers
{
    [Route("/token")]
    public class TokenController : Controller
    {
        private readonly UserRepository _userRepo;

        public TokenController(UserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginInputModel model)
        {
            var user = _userRepo.ReadAllUsers().FirstOrDefault(u => u.Username == model.Username);

            if (user == null)
                return Unauthorized();

            if (!VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized();

            return Ok(new
            {
                username = user.Username,
                token = GenerateToken(user)
            });
        }

        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }
            return true;
        }

        private string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            if (user.IsAdmin)
                claims.Add(new Claim(ClaimTypes.Role, "Administator"));

            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    JwtSecurityKey.Key,
                    SecurityAlgorithms.HmacSha256)),
                new JwtPayload(null,  //issuer - not needed (ValidateIssuer false)
                               null,  //audience - not needed (ValidateAudience false)
                               claims.ToArray(),
                               DateTime.Now,                 //not before
                               DateTime.Now.AddMinutes(5))); // means that the login expires

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
