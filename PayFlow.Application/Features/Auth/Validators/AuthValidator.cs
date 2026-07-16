using FluentValidation;
using PayFlow.Application.Features.Auth.Requests;

namespace PayFlow.Application.Features.Auth.Validators
{
    public class AuthValidator : AbstractValidator<AuthRequest>
    {
        public AuthValidator()
        {
            RuleFor(x => x.Email).EmailRule();
            RuleFor(x => x.Password).PasswordRule();
        }
    }
}   
 