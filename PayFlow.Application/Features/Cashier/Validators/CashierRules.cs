using FluentValidation;

namespace PayFlow.Infrastructure.Features.Cashier.Validators
{
    public static class CashierRules
    {
        public static IRuleBuilderOptions<T, string> CpfRule<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                .WithMessage("O CPF é obrigatório.")
                .Matches(@"^\d{11}$")
                .WithMessage("O CPF deve possuir 11 dígitos.");
        }

        public static IRuleBuilderOptions<T, string> NameRule<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                .WithMessage("O nome é obrigatório.")
                .MaximumLength(150)
                .WithMessage("O nome deve possuir no máximo 150 caracteres.");
        }

        public static IRuleBuilderOptions<T, string> EmailRule<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                .WithMessage("O e-mail é obrigatório.")
                .EmailAddress()
                .WithMessage("O e-mail informado é inválido.")
                .MaximumLength(150)
                .WithMessage("O e-mail deve possuir no máximo 150 caracteres.");
        }

        public static IRuleBuilderOptions<T, decimal> RatingRule<T>(this IRuleBuilder<T, decimal> rule)
        {
            return rule
                .InclusiveBetween(0, 5)
                .WithMessage("A avaliação deve estar entre 0 e 5.");
        }
    }
}