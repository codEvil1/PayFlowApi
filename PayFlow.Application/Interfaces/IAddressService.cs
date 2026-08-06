using PayFlow.Application.Features.Address.Responses;

namespace PayFlow.Application.Interfaces
{
    public interface IAddressService
    {
        Task<PostalCodeResponse> GetByPostalCodeAsync(string postalCode, CancellationToken cancellationToken);
    }
}