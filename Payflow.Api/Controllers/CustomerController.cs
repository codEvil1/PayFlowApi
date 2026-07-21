using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using PayFlow.Api.Constants;
using PayFlow.Application.Common.Responses;
using PayFlow.Application.Interfaces;
using PayFlow.Application.Security;
using PayFlow.Infrastructure.Features.Customer.Requests;

namespace Payflow.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController(ICustomerService service) : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        [EnableRateLimiting(RateLimitPolicies.Default)]
        public async Task<IActionResult> Create([FromForm] CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            var result = await service.CreateAsync(request, cancellationToken);

            return StatusCode(
                StatusCodes.Status201Created,
                ApiResponse<object?>.SuccessResponse(
                    result,
                    "Cliente criado com sucesso."
                )
            );
        }

        [HttpGet]
        [Authorize]
        [EnableRateLimiting(RateLimitPolicies.Default)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await service.GetAllAsync(cancellationToken);

            return Ok(
                ApiResponse<object>.SuccessResponse(
                    result,
                    "Clientes encontrados com sucesso."
                )
            );
        }

        [HttpGet("{identifier}")]
        [Authorize]
        [EnableRateLimiting(RateLimitPolicies.Default)]
        public async Task<IActionResult> GetCustomerById(string identifier, CancellationToken cancellationToken)
        {
            var result = await service.GetByIdentifierAsync(identifier, cancellationToken);

            if (result is null)
                return NotFound();

            return Ok(
                ApiResponse<object>.SuccessResponse(
                    result,
                    "Cliente encontrado com sucesso."
                )
            );
        }

        [HttpPut("{identifier}")]
        [Authorize(Roles = Roles.Admin)]
        [EnableRateLimiting(RateLimitPolicies.Default)]
        public async Task<IActionResult> Update(string identifier, [FromForm] UpdateCustomerRequest request, CancellationToken cancellationToken)
        {
            var result = await service.UpdateAsync(identifier, request, cancellationToken);

            return Ok(
                ApiResponse<object?>.SuccessResponse(
                    result,
                    "Cliente atualizado com sucesso."
                )
            );
        }

        [HttpDelete("{identifier}")]
        [Authorize(Roles = Roles.Admin)]
        [EnableRateLimiting(RateLimitPolicies.Default)]
        public async Task<IActionResult> Delete(string identifier, CancellationToken cancellationToken)
        {
            await service.DeleteAsync(identifier, cancellationToken);

            return Ok(
                ApiResponse<object?>.SuccessResponse(
                    null,
                    "Cliente removido com sucesso."
                )
            );
        }
    }
}