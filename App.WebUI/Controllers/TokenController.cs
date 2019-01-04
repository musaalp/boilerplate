using App.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace App.WebUI.Controllers
{
    public class TokenController : BaseController
    {
        [HttpPost]
        [Route("token")]
        public IActionResult GetToken([FromBody] UserInfo userInfo)
        {
            Console.WriteLine($"User name: {userInfo.Username}");
            Console.WriteLine($"Password: {userInfo.Password}");

            if (IsValidUser(userInfo.Username, userInfo.Password))
            {
                return new ObjectResult(GenerateToken(userInfo.Username));
            }

            return Unauthorized();
        }

        private object GenerateToken(string username)
        {
            var claims = new Claim[]
            {
                new Claim (JwtRegisteredClaimNames.UniqueName, username),
                new Claim (JwtRegisteredClaimNames.Email, "user@mail.com"),
                new Claim (JwtRegisteredClaimNames.NameId, Guid.NewGuid().ToString())
            };

            //todo: read it from a proper place
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("boilerplateSigningKey"));

            var token = new JwtSecurityToken(
                issuer: "issuer.boilerplate",
                audience: "audience.boilerplate",
                claims: claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool IsValidUser(string userName, string password)
        {
            //todo: implement auth with a identity server
            return true;
        }
    }
}