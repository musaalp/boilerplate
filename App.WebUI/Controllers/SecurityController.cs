using App.Application.SecurityRoles.Commands.CreateSecurityRole;
using App.Application.SecurityRoles.Queries.GetSecurityRole;
using App.Application.SecurityRoles.Queries.GetSecurityRoles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.WebUI.Controllers
{
    //api/security
    [Authorize]
    public class SecurityController : BaseController
    {
        //get : api/security
        [HttpGet]
        public Task<SecurityRolesViewModel> Get()
        {
            return Mediator.Send(new GetSecurityRolesQuery());
        }

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
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetSecurityRoleQuery { SecurityRoleId = id }));
        }
    }
}
