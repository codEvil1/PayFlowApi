using Microsoft.AspNetCore.Mvc;
using PayFlow.Application.Interfaces;

namespace PayFlow.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController(ICompanyService service) : ControllerBase
    {

        [HttpGet("{cnpj}")]
        public async Task<IActionResult> GetByCnpj(string cnpj, CancellationToken cancellationToken)
        {
            var company = await service.GetByCnpjAsync(cnpj, cancellationToken);

            return Ok(company);
        }
    }
}