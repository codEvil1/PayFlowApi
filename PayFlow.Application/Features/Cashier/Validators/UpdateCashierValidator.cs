using FluentValidation;
using PayFlow.Application.Features.Cashier.Requests;

namespace PayFlow.Application.Features.Cashier.Validators
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