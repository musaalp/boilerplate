using App.Application.SecurityRoles.Commands.CreateSecurityRole;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.WebUI.Controllers
{
    //api/security
    public class SecurityController : BaseController
    {
        // post : api/security/create
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateSecurityRoleCommand command)
        {
            var securityRoleId = await Mediator.Send(command);
            return Ok(securityRoleId);
        }

        // get: api/security/3
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(5);
        }
    }
}
