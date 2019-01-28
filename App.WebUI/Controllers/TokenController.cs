using App.WebUI.Models;
using App.WebUI.Models.TokenAuth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace App.WebUI.Controllers
{
    public class TokenController : BaseController
    {
        private readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("authenticate")]
        public AuthenticateResultModel Authenticate([FromBody] UserInfo userInfo)
        {
            Console.WriteLine($"User name: {userInfo.Username}");
            Console.WriteLine($"Password: {userInfo.Password}");

            if (IsValidUser(userInfo.Username, userInfo.Password))
            {
                return new AuthenticateResultModel
                {
                    AccessToken = GenerateToken(userInfo.Username)
                };
            }

            return null;
        }

        private string GenerateToken(string username)
        {
            var claims = new Claim[]
            {
                new Claim (JwtRegisteredClaimNames.UniqueName, username),
                new Claim (JwtRegisteredClaimNames.Email, "user@mail.com"),
                new Claim (JwtRegisteredClaimNames.NameId, Guid.NewGuid().ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:JwtBearer:SecurityKey"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["Authentication:JwtBearer:Issuer"],
                audience: _configuration["Authentication:JwtBearer:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
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