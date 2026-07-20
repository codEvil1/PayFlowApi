using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayFlow.Application.Features.Address.DTOs;
using PayFlow.Application.Interfaces;

namespace PayFlow.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class AddressController(IAddressService service) : ControllerBase
    {
        [HttpPost("postal-code")]
        public async Task<IActionResult> GetByPostalCode([FromBody] GetAddressByPostalCodeRequest request, CancellationToken cancellationToken)
        {
            var address = await service.GetByPostalCodeAsync(request.PostalCode, cancellationToken);
                
            return Ok(address);
        }
    }
}