using FluentValidation;
using System.Linq.Expressions;

namespace PayFlow.Application.Features.Auth.Validators
{
    public static class AuthRules
    {
        public static IRuleBuilderOptions<T, string> EmailRule<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                    .WithMessage("O e-mail é obrigatório.")
                .MaximumLength(150)
                    .WithMessage("O e-mail deve possuir no máximo 150 caracteres.")
                .EmailAddress()
                    .WithMessage("O e-mail informado é inválido.");
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