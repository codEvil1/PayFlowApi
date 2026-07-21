using FluentValidation;
using PayFlow.Infrastructure.Features.Auth.Requests;

namespace PayFlow.Infrastructure.Features.Auth.Validators
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
 