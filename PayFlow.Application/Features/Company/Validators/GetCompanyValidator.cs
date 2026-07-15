using FluentValidation;
using PayFlow.Application.Features.Company.DTOs;
using PayFlow.Application.Extensions;

namespace PayFlow.Application.Features.Company.Validators
{
    public class GetCompanyValidator : AbstractValidator<FilterCompanyDto>
    {
        public GetCompanyValidator()
        {
            RuleFor(x => x.Cnpj)
                .NotEmpty()
                .Must(BeAValidCnpj)
                .WithMessage("CNPJ inválido.");
        }

        private static bool BeAValidCnpj(string cnpj)
        {
            cnpj = cnpj.OnlyDigits();

            return cnpj.Length == 14;
        }
    }
}