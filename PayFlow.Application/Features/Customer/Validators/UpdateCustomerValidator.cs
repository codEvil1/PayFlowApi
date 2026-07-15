using FluentValidation;
using PayFlow.Infrastructure.Features.Customer.Requests;

namespace PayFlow.Infrastructure.Features.Customer.Validators
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(x => x.Name).NameRule();
            RuleFor(x => x.Phone).PhoneRule();
            RuleFor(x => x.Email).EmailRule();
        }
    }
}