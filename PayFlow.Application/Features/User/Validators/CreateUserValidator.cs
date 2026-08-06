using FluentValidation;
using PayFlow.Application.Features.User.Requests;

namespace PayFlow.Infrastructure.Features.User.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NameRule();
            RuleFor(x => x.Email).EmailRule();
            RuleFor(x => x.PasswordHash).PasswordRule();
        }
    }
}