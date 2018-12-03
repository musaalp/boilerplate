using App.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.SecurityRoles.Queries.GetSecurityRoles
{
    public class GetSecurityRolesQueryHandler : IRequestHandler<GetSecurityRolesQuery, SecurityRolesViewModel>
    {
        private readonly AppDbContext _context;

        public GetSecurityRolesQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SecurityRolesViewModel> Handle(GetSecurityRolesQuery request, CancellationToken cancellationToken)
        {
            var model = new SecurityRolesViewModel
            {
                SecurityRoles = await _context.SecurityRoles.Select(sr => new SecurityRoleDto
                {
                    Name = sr.Name,
                    Description = sr.Description
                })
                .OrderBy(sr => sr.Name)
                .ToListAsync(cancellationToken)
            };

            return model;
        }
    }
}
