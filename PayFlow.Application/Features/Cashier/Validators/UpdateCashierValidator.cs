using FluentValidation;
using PayFlow.Infrastructure.Features.Cashier.Requests;

namespace PayFlow.Infrastructure.Features.Cashier.Validators
{
    public class UpdateCashierValidator : AbstractValidator<UpdateCashierRequest>
    {
        public UpdateCashierValidator()
        {
            RuleFor(x => x.Cpf).CpfRule();
            RuleFor(x => x.Name).NameRule();
            RuleFor(x => x.Email).EmailRule();
            RuleFor(x => x.Rating).RatingRule();
        }
    }
}