using PayFlow.Infrastructure.Features.Address.DTOs;

namespace PayFlow.Infrastructure.Interfaces
{
    public interface IAddressService
    {
        Task<ViaCepDto> GetByPostalCodeAsync(string postalCode, CancellationToken cancellationToken);
    }
}