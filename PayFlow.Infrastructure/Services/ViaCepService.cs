using PayFlow.Application.Common.Exceptions;
using PayFlow.Application.Features.Address.DTOs;
using PayFlow.Application.Features.Address.Responses;
using PayFlow.Application.Interfaces;
using PayFlow.Infrastructure.Extensions;
using System.Net.Http.Json;

namespace PayFlow.Infrastructure.Services
{
    public class ViaCepService(HttpClient client) : IAddressService
    {
        public async Task<PostalCodeResponse> GetByPostalCodeAsync(string postalCode, CancellationToken cancellationToken)
        {
            postalCode = postalCode.OnlyDigits();

            var response = await client.GetFromJsonAsync<ViaCepDto>($"ws/{postalCode}/json/", cancellationToken)
                ?? throw new NotFoundException("Código postal não encontrado.");

            if (response.Error)
                throw new NotFoundException("Código postal não encontrado.");

            return new PostalCodeResponse
            {
                Street = response.Street,
                Complement = response.Complement,
                Neighborhood = response.Neighborhood,
                City = response.City,
                Uf = response.StateCode
            };
        }
    }
}

