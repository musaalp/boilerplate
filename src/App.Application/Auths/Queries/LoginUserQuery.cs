using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Auths.Queries
{
    public class LoginUserQuery : IRequest<bool>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
