using System.Net.Http.Json;
using PayFlow.Application.Features.Address.DTOs;
using PayFlow.Application.Interfaces;
using PayFlow.Infrastructure.Exceptions;
using PayFlow.Infrastructure.Extensions;

namespace PayFlow.Infrastructure.Services
{
    public class ViaCepService(HttpClient client) : IAddressService
    {
        public async Task<ViaCepDto> GetByPostalCodeAsync(string postalCode, CancellationToken cancellationToken)
        {
            postalCode = postalCode.OnlyDigits();

            var response = await client.GetFromJsonAsync<ViaCepDto>($"ws/{postalCode}/json/", cancellationToken);

            if (response is null || response.Error)
                throw new BusinessException("Código postal não encontrado.");

            return response;
        }
    }
}
