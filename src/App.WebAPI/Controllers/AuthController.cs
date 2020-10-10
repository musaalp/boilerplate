using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace App.WebAPI.Controllers
{
    public class AuthController : BaseController
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login()
        {
            return Ok(true);
        }

        [HttpGet("access-token/{refreshToken}")]
        public async Task<IActionResult> GetAccessToken([FromQuery] string refreshToken)
        {
            return Ok(true);
        }
    }
}
