using PayFlow.Application.Common.Exceptions;
using PayFlow.Infrastructure.Extensions;
using PayFlow.Infrastructure.Features.Company.DTOs;
using PayFlow.Infrastructure.Interfaces;
using System.Net;
using System.Text.Json;

namespace PayFlow.Infrastructure.Services;

public class ReceitaWsService(HttpClient client) : ICompanyService
{
    public async Task<CompanyDto> GetByCnpjAsync(string cnpj, CancellationToken cancellationToken)
    {
        cnpj = WebUtility.UrlDecode(cnpj).OnlyDigits();

        var httpResponse = await client.GetAsync($"v1/cnpj/{cnpj}", cancellationToken);

        var content = await httpResponse.Content.ReadAsStringAsync(cancellationToken);

        if (!httpResponse.IsSuccessStatusCode)
            throw new ExternalServiceException($"Não foi possível consultar a ReceitaWS.");

        var response = JsonSerializer.Deserialize<CompanyDto>(content);

        return response
            ?? throw new ExternalServiceException("A ReceitaWS retornou uma resposta inválida.");
    }
}