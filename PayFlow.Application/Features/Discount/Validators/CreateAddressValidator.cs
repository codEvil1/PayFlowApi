using FluentValidation;
using PayFlow.Application.Features.Discount.Requests;

namespace PayFlow.Application.Features.Discount.Validators
{
    public class CreateDiscountValidator : AbstractValidator<CreateDiscountRequest>
    {
        public CreateDiscountValidator()
        {
            RuleFor(x => x.Code).CodeRule();
            RuleFor(x => x.Description).DescriptionRule();
            RuleFor(x => x.Type).TypeRule();
            RuleFor(x => x.Value).ValueRule();
            RuleFor(x => x.StartDate).StartDateRule();
            RuleFor(x => x.EndDate).EndDateRule();
            RuleFor(x => x.MinimumValue).MinimumValueRule();
            RuleFor(x => x.MaximumDiscount).MaximumDiscountRule();
        }
    }
}