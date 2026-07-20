using FluentValidation;
using PayFlow.Application.Extensions;
using PayFlow.Application.Features.Address.DTOs;

namespace PayFlow.Application.Features.Address.Validators
{
    public class GetAddressByPostalCodeValidator : AbstractValidator<GetAddressByPostalCodeRequest>
    {
        public GetAddressByPostalCodeValidator()
        {
            RuleFor(x => x.PostalCode)
                .NotEmpty()
                .WithMessage("Código postal é obrigatório.")
                .Must(BeAValidPostalCode)
                .WithMessage("Código postal é inválido.");
        }

        private static bool BeAValidPostalCode(string postalCode)
        {
            var digits = postalCode.OnlyDigits();

            return digits.Length == 8
                   && digits != "00000000";
        }
    }
}