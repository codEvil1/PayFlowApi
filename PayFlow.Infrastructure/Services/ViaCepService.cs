using PayFlow.Application.Common.Exceptions;
using PayFlow.Application.Features.Address.DTOs;
using PayFlow.Application.Interfaces;
using PayFlow.Infrastructure.Extensions;
using System.Net.Http.Json;

namespace PayFlow.Infrastructure.Services
{
    public class ViaCepService(HttpClient client) : IAddressService
    {
        public async Task<ViaCepDto> GetByPostalCodeAsync(string postalCode, CancellationToken cancellationToken)
        {
            postalCode = postalCode.OnlyDigits();

            var response = await client.GetFromJsonAsync<ViaCepDto>($"ws/{postalCode}/json/", cancellationToken);

            if (response is null)
                throw new NotFoundException("Código postal não encontrado.");

            if (response.Error)
                throw new NotFoundException("Código postal não encontrado.");

            return response;
        }
    }
}
