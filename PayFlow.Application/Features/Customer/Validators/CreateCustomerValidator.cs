using FluentValidation;
using PayFlow.Infrastructure.Features.Customer.Requests;

namespace PayFlow.Infrastructure.Features.Customer.Validators
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.Identifier).IdentifierRule();
            RuleFor(x => x.Name).NameRule();
            RuleFor(x => x.Phone).PhoneRule();
            RuleFor(x => x.Email).EmailRule();
        }
    }
}