using FluentValidation;
using PayFlow.Infrastructure.Extensions;
using PayFlow.Application.Features.Company.DTOs;

namespace PayFlow.Application.Features.Company.Validators
{
    public class GetCompanyByCnpjValidator : AbstractValidator<GetCompanyByCnpj>
    {
        public GetCompanyByCnpjValidator()
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