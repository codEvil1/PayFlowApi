using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using PayFlow.Api.Constants;
using PayFlow.Application.Common.Responses;
using PayFlow.Application.Interfaces;
using PayFlow.Application.Security;
using PayFlow.Infrastructure.Features.Discount.Requests;

namespace Payflow.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountController(IDiscountService service) : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        [EnableRateLimiting(RateLimitPolicies.Default)]
        public async Task<IActionResult> Create([FromForm] CreateDiscountRequest request, CancellationToken cancellationToken)
        {
            var result = await service.CreateAsync(request, cancellationToken);

            return StatusCode(
                StatusCodes.Status201Created,
                ApiResponse<object?>.SuccessResponse(
                    result,
                    "Desconto criado com sucesso."
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
                    "Descontos encontrados com sucesso."
                )
            );
        }

        [HttpGet("{id}")]
        [Authorize]
        [EnableRateLimiting(RateLimitPolicies.Default)]
        public async Task<IActionResult> GetDiscountById(string id, CancellationToken cancellationToken)
        {
            var result = await service.GetByIdAsync(id, cancellationToken);

            if (result is null)
                return NotFound();

            return Ok(
                ApiResponse<object>.SuccessResponse(
                    result,
                    "Desconto encontrado com sucesso."
                )
            );
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Roles.Admin)]
        [EnableRateLimiting(RateLimitPolicies.Default)]
        public async Task<IActionResult> Update(string id, [FromForm] UpdateDiscountRequest request, CancellationToken cancellationToken)
        {
            var result = await service.UpdateAsync(id, request, cancellationToken);

            return Ok(
                ApiResponse<object?>.SuccessResponse(
                    result,
                    "Desconto atualizado com sucesso."
                )
            );
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.Admin)]
        [EnableRateLimiting(RateLimitPolicies.Default)]
        public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
        {
            await service.DeleteAsync(id, cancellationToken);

            return Ok(
                ApiResponse<object?>.SuccessResponse(
                    null,
                    "Desconto removido com sucesso."
                )
            );
        }
    }
}
