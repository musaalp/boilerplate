using MediatR;

namespace App.Application.SecurityRoles.Queries.GetSecurityRole
{
    public class GetSecurityRoleQuery : IRequest<SecurityRoleViewModel>
    {
        public int SecurityRoleId { get; set; }
    }
}
