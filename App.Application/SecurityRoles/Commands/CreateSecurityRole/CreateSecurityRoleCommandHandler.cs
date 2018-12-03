using App.Domain.Entities;
using App.Persistence.Contexts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.SecurityRoles.Commands.CreateSecurityRole
{
    public class CreateSecurityRoleCommandHandler : IRequestHandler<CreateSecurityRoleCommand, int>
    {
        private readonly AppDbContext _context;

        public CreateSecurityRoleCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateSecurityRoleCommand request, CancellationToken cancellationToken)
        {
            var securityRole = new SecurityRole
            {
                Name = request.Name,
                Description = request.Description
            };

            _context.SecurityRoles.Add(securityRole);

            await _context.SaveChangesAsync(cancellationToken);

            return securityRole.Id;
        }
    }
}
