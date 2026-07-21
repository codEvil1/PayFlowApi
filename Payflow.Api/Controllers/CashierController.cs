using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using PayFlow.Api.Constants;
using PayFlow.Application.Common.Responses;
using PayFlow.Application.Interfaces;
using PayFlow.Application.Security;
using PayFlow.Infrastructure.Features.Cashier.Requests;

namespace Payflow.Api.Controllers
{
    [ApiController]
    [Authorize(Roles = Roles.Admin)]
    [Route("api/[controller]")]
    public class CashierController(ICashierService service) : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        [EnableRateLimiting(RateLimitPolicies.Default)]
        public async Task<IActionResult> Create([FromForm] CreateCashierRequest request, CancellationToken cancellationToken)
        {
            var result = await service.CreateAsync(request, cancellationToken);

            return StatusCode(
                StatusCodes.Status201Created,
                ApiResponse<object>.SuccessResponse(
                    result,
                    "Caixa criado com sucesso."
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
                    "Caixas encontrados com sucesso."
                )
            );
        }

        [HttpGet("{id}")]
        [Authorize]
        [EnableRateLimiting(RateLimitPolicies.Default)]
        public async Task<IActionResult> GetCashierById(int id, CancellationToken cancellationToken)
        {
            var result = await service.GetByIdAsync(id, cancellationToken);

            if (result is null)
                return NotFound();

            return Ok(
                ApiResponse<object>.SuccessResponse(
                    result,
                    "Caixa encontrado com sucesso."
                )
            );
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Roles.Admin)]
        [EnableRateLimiting(RateLimitPolicies.Default)]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateCashierRequest request, CancellationToken cancellationToken)
        {
            var result = await service.UpdateAsync(id, request, cancellationToken);

            return Ok(
                ApiResponse<object>.SuccessResponse(
                    result,
                    "Caixa atualizado com sucesso."
                )
            );
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.Admin)]
        [EnableRateLimiting(RateLimitPolicies.Default)]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await service.DeleteAsync(id, cancellationToken);

            return Ok(
                ApiResponse<object>.SuccessResponse(
                    null,
                    "Caixa removido com sucesso."
                )
            );
        }
    }
}