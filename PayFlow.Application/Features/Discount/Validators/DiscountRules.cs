using FluentValidation;
using PayFlow.Domain.Enums;

namespace PayFlow.Infrastructure.Features.Discount.Validators
{
    public static class DiscountRules
    {
        public static IRuleBuilderOptions<T, string> CodeRule<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                .WithMessage("O código do desconto é obrigatório.")
                .MaximumLength(30)
                .WithMessage("O código do desconto deve possuir no máximo 30 caracteres.");
        }

        public static IRuleBuilderOptions<T, string> DescriptionRule<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                .WithMessage("A descrição é obrigatória.")
                .MaximumLength(150)
                .WithMessage("A descrição deve possuir no máximo 150 caracteres.");
        }

        public static IRuleBuilderOptions<T, DiscountType> TypeRule<T>(this IRuleBuilder<T, DiscountType> rule)
        {
            return rule
                .IsInEnum()
                .WithMessage("O tipo de desconto informado é inválido.");
        }

        public static IRuleBuilderOptions<T, decimal> ValueRule<T>(this IRuleBuilder<T, decimal> rule)
        {
            return rule
                .GreaterThan(0)
                .WithMessage("O valor do desconto deve ser maior que zero.");
        }

        public static IRuleBuilderOptions<T, DateOnly> StartDateRule<T>(this IRuleBuilder<T, DateOnly> rule)
        {
            return rule
                .NotEmpty()
                .WithMessage("A data inicial é obrigatória.");
        }

        public static IRuleBuilderOptions<T, DateOnly> EndDateRule<T>(this IRuleBuilder<T, DateOnly> rule)
        {
            return rule
                .NotEmpty()
                .WithMessage("A data final é obrigatória.");
        }

        public static IRuleBuilderOptions<T, decimal> MinimumValueRule<T>(this IRuleBuilder<T, decimal> rule)
        {
            return rule
                .GreaterThanOrEqualTo(0)
                .WithMessage("O valor mínimo não pode ser negativo.");
        }

        public static IRuleBuilderOptions<T, decimal> MaximumDiscountRule<T>(this IRuleBuilder<T, decimal> rule)
        {
            return rule
                .GreaterThanOrEqualTo(0)
                .WithMessage("O desconto máximo não pode ser negativo.");
        }
    }
}