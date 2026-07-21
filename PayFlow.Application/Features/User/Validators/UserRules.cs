using FluentValidation;

namespace PayFlow.Infrastructure.Features.User.Validators
{
    public static class UserRules
    {
        public static IRuleBuilderOptions<T, string> IdRule<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                .WithMessage("O identificador é obrigatório.")
                .MaximumLength(50)
                .WithMessage("O identificador deve possuir no máximo 50 caracteres.");
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

        public static IRuleBuilderOptions<T, string> PasswordRule<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                .WithMessage("A senha é obrigatória.")
                .MinimumLength(8)
                .WithMessage("A senha deve possuir no mínimo 8 caracteres.")
                .MaximumLength(100)
                .WithMessage("A senha deve possuir no máximo 100 caracteres.");
        }
    }
}