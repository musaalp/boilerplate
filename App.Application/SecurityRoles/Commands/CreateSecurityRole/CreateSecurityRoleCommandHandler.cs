using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.SecurityRoles.Commands.CreateSecurityRole
{
    public class CreateSecurityRoleCommandHandler : IRequestHandler<CreateSecurityRoleCommand, int>
    {
        public CreateSecurityRoleCommandHandler()
        {
            //todo: inject orm context
        }

        public Task<int> Handle(CreateSecurityRoleCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
