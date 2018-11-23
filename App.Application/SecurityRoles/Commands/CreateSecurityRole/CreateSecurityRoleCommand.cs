using MediatR;

namespace App.Application.SecurityRoles.Commands.CreateSecurityRole
{
    public class CreateSecurityRoleCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
