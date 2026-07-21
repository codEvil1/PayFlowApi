using FluentValidation;
using PayFlow.Application.Features.Address.Validators;
using PayFlow.Infrastructure.Features.Address.Requests;

namespace PayFlow.Infrastructure.Features.Address.Validators
{
    public class UpdateAddressValidator : AbstractValidator<UpdateAddressRequest>
    {
        public UpdateAddressValidator()
        {
            RuleFor(x => x.Street).StreetRule();
            RuleFor(x => x.Number).NumberRule();
            RuleFor(x => x.City).CityRule();
            RuleFor(x => x.State).StateRule();
            RuleFor(x => x.Uf).UfRule();
            RuleFor(x => x.PostalCode).PostalCodeRule();
            RuleFor(x => x.Country).CountryRule();
        }
    }
}