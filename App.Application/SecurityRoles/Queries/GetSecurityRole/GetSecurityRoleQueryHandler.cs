using App.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.SecurityRoles.Queries.GetSecurityRole
{
    public class GetSecurityRoleQueryHandler : IRequestHandler<GetSecurityRoleQuery, SecurityRoleViewModel>
    {
        private readonly AppDbContext _context;

        public GetSecurityRoleQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SecurityRoleViewModel> Handle(GetSecurityRoleQuery request, CancellationToken cancellationToken)
        {
            var securityRole = await _context.SecurityRoles
                .Where(sr => sr.Id == request.SecurityRoleId)
                .Select(sr => new SecurityRoleViewModel
                {
                    Name = sr.Name,
                    Description = sr.Description
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (securityRole == null)
            {
                throw new Exception($"Security role not found with given id : {request.SecurityRoleId}");
            }

            return securityRole;
        }
    }
}
