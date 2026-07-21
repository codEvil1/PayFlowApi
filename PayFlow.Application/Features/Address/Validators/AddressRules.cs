using FluentValidation;

namespace PayFlow.Infrastructure.Features.Address.Validators
{
    public static class AddressRules
    {
        public static IRuleBuilderOptions<T, string> StreetRule<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                .WithMessage("A rua é obrigatória.")
                .MaximumLength(150)
                .WithMessage("A rua deve possuir no máximo 150 caracteres.");
        }

        public static IRuleBuilderOptions<T, int?> NumberRule<T>(this IRuleBuilder<T, int?> rule)
        {
            return rule
                .NotNull()
                .WithMessage("O número é obrigatório.")
                .GreaterThan(0)
                .WithMessage("O número deve ser maior que zero.");
        }

        public static IRuleBuilderOptions<T, string> CityRule<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                .WithMessage("A cidade é obrigatória.")
                .MaximumLength(100)
                .WithMessage("A cidade deve possuir no máximo 100 caracteres.");
        }

        public static IRuleBuilderOptions<T, string> PostalCodeRule<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                .WithMessage("O CEP é obrigatório.")
                .Matches(@"^\d{8}$")
                .WithMessage("O CEP deve conter exatamente 8 dígitos.");
        }

        public static IRuleBuilderOptions<T, string> StateRule<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                .WithMessage("O estado é obrigatório.")
                .MaximumLength(100)
                .WithMessage("O estado deve possuir no máximo 100 caracteres.");
        }

        public static IRuleBuilderOptions<T, string> UfRule<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                .WithMessage("A UF é obrigatória.")
                .Length(2)
                .WithMessage("A UF deve possuir exatamente 2 caracteres.");
        }

        public static IRuleBuilderOptions<T, string> CountryRule<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                .WithMessage("O país é obrigatório.")
                .MaximumLength(100)
                .WithMessage("O país deve possuir no máximo 100 caracteres.");
        }
    }
}