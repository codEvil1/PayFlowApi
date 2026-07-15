using PayFlow.Infrastructure.Features.Company.DTOs;

namespace PayFlow.Infrastructure.Interfaces
{
    public interface ICompanyService
    {
        Task<CompanyDto> GetByCnpjAsync(string cnpj, CancellationToken cancellationToken);
    }
}