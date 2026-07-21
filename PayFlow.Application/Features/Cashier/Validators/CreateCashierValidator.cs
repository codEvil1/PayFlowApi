using FluentValidation;
using PayFlow.Infrastructure.Features.Cashier.Requests;

namespace PayFlow.Infrastructure.Features.Cashier.Validators
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