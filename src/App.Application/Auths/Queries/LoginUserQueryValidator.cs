using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Auths.Queries
{
    public class LoginUserQueryValidator : AbstractValidator<LoginUserQuery>
    {
        public LoginUserQueryValidator()
        {
            RuleFor(r => r.Username)
                .NotEmpty()
                .WithMessage(r => $"{r.Username}_should_not_be_null_or_empty");

            RuleFor(r => r.Password)
                .NotEmpty()
                .WithMessage(r => $"{r.Password}_should_not_be_null_or_empty");
        }        
    }
}
