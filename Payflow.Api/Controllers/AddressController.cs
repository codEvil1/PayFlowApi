using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using PayFlow.Api.Constants;
using PayFlow.Application.Common.Responses;
using PayFlow.Application.Features.Address.DTOs;
using PayFlow.Application.Interfaces;
using PayFlow.Domain.Entities;
using PayFlow.Infrastructure.Features.Address.DTOs;
using PayFlow.Infrastructure.Features.Product.DTOs;

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
                
            return Ok(ApiResponse<ViaCepDto>.SuccessResponse(address));
        }
    }
}