using PayFlow.Application.Features.Address.DTOs;

namespace PayFlow.Application.Interfaces
{
    public interface IAddressService
    {
        Task<ViaCepDto> GetByPostalCodeAsync(string postalCode, CancellationToken cancellationToken);
    }
}