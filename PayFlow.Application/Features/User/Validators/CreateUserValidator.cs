using FluentValidation;
using PayFlow.Application.Features.User.Requests;
using PayFlow.Infrastructure.Features.User.Validators;

namespace PayFlow.Application.Features.User.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Name).NameRule();
            RuleFor(x => x.Email).EmailRule();
            RuleFor(x => x.PasswordHash).PasswordRule();
        }
    }
}