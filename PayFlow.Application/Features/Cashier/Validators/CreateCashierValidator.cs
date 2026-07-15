using FluentValidation;
using PayFlow.Application.Features.Cashier.Requests;

namespace PayFlow.Application.Features.Cashier.Validators
{
    public class CreateCashierValidator : AbstractValidator<CreateCashierRequest>
    {
        public CreateCashierValidator()
        {
            RuleFor(x => x.Cpf).CpfRule();
            RuleFor(x => x.Name).NameRule();
            RuleFor(x => x.Email).EmailRule();
            RuleFor(x => x.Rating).RatingRule();
        }
    }
}