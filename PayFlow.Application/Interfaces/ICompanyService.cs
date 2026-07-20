using PayFlow.Application.Features.Company.DTOs;

namespace PayFlow.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<CompanyDto> GetByCnpjAsync(string cnpj, CancellationToken cancellationToken);
    }
}