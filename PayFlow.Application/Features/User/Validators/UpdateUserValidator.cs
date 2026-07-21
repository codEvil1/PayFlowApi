using FluentValidation;
using PayFlow.Infrastructure.Features.User.Requests;

namespace PayFlow.Infrastructure.Features.User.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Name).NameRule();
            RuleFor(x => x.Email).EmailRule();
            RuleFor(x => x.PasswordHash).PasswordRule();
        }
    }
}