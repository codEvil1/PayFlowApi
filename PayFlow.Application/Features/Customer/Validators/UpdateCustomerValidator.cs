using FluentValidation;
using PayFlow.Application.Features.Customer.Requests;

namespace PayFlow.Application.Features.Customer.Validators
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