using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayFlow.Application.Features.Company.DTOs;
using PayFlow.Infrastructure.Interfaces;

namespace PayFlow.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class CompanyController(ICompanyService service) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> GetByCnpj([FromBody] GetCompanyByCnpj request, CancellationToken cancellationToken)
        {
            var company = await service.GetByCnpjAsync(request.Cnpj, cancellationToken);

            return Ok(company);
        }
    }
}