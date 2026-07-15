using FluentValidation;

namespace PayFlow.Infrastructure.Features.Customer.Validators
{
    public static class CustomerRules
    {
        public static IRuleBuilderOptions<T, string> IdentifierRule<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                .WithMessage("O identificador é obrigatório.")
                .MaximumLength(30)
                .WithMessage("O identificador deve possuir no máximo 30 caracteres.");
        }

        public static IRuleBuilderOptions<T, string> NameRule<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                .WithMessage("O nome é obrigatório.")
                .MaximumLength(150)
                .WithMessage("O nome deve possuir no máximo 150 caracteres.");
        }

        public static IRuleBuilderOptions<T, string> PhoneRule<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                .WithMessage("O telefone é obrigatório.")
                .Matches(@"^\d{10,11}$")
                .WithMessage("O telefone deve possuir 10 ou 11 dígitos.");
        }

        public static IRuleBuilderOptions<T, string> EmailRule<T>(
            this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                .WithMessage("O e-mail é obrigatório.")
                .EmailAddress()
                .WithMessage("O e-mail informado é inválido.")
                .MaximumLength(150)
                .WithMessage("O e-mail deve possuir no máximo 150 caracteres.");
        }
    }
}