using System.Net.Http.Json;
using PayFlow.Application.Exceptions;
using PayFlow.Application.Extensions;
using PayFlow.Application.Features.Address.DTOs;
using PayFlow.Application.Interfaces;

namespace PayFlow.Application.Services
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
