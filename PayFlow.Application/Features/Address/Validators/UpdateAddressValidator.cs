using FluentValidation;
using PayFlow.Application.Features.Address.Requests;

namespace PayFlow.Application.Features.Address.Validators
{
    public class UpdateAddressValidator : AbstractValidator<UpdateAddressRequest>
    {
        public UpdateAddressValidator()
        {
            RuleFor(x => x.Street).StreetRule();
            RuleFor(x => x.Number).NumberRule();
            RuleFor(x => x.Complement).ComplementRule();
            RuleFor(x => x.Neighborhood).NeighborhoodRule();
            RuleFor(x => x.City).CityRule();
            RuleFor(x => x.PostalCode).PostalCodeRule();
            RuleFor(x => x.State).StateRule();
            RuleFor(x => x.Uf).UfRule();
        }
    }
}