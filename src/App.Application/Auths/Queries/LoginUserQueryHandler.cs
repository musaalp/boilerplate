using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Auths.Queries
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, bool>
    {
        public async Task<bool> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            await Task.Delay(5000);

            return true;
        }
    }
}
