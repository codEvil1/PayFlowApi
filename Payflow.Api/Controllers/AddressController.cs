using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using PayFlow.Api.Constants;
using PayFlow.Infrastructure.Features.Address.DTOs;
using PayFlow.Infrastructure.Interfaces;

namespace PayFlow.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class AddressController(IAddressService service) : ControllerBase
    {
        [HttpPost("postal-code")]
        [EnableRateLimiting(RateLimitPolicies.Default)]
        public async Task<IActionResult> GetByPostalCode([FromBody] GetAddressByPostalCodeRequest request, CancellationToken cancellationToken)
        {
            var address = await service.GetByPostalCodeAsync(request.PostalCode, cancellationToken);
                
            return Ok(address);
        }
    }
}