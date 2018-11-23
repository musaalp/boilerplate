using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Permissions.Queries.GetPermissions
{
    public class GetPermissionsQueryHandler : IRequestHandler<GetPermissionsQuery, PermissionsViewModel>
    {
        public GetPermissionsQueryHandler()
        {
            //todo: inject orm context
        }

        public Task<PermissionsViewModel> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
        {
            //todo: fetch from db..
            throw new NotImplementedException();
        }
    }
}
