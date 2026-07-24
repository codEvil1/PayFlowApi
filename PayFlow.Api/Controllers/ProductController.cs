using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using PayFlow.Api.Constants;
using PayFlow.Application.Interfaces;
using PayFlow.Application.Security;
using PayFlow.Domain.Common.Models;
using PayFlow.Infrastructure.Features.Product.Requests;

namespace PayFlow.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(IProductService service) : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        [EnableRateLimiting(RateLimitPolicies.Default)]
        public async Task<IActionResult> Create([FromForm] CreateProductRequest request, CancellationToken cancellationToken)
        {
            var result = await service.CreateAsync(request, cancellationToken);

            return CreatedAtAction(
                nameof(GetProductById),
                new { id = result.Id },
                result
            );
        }

        [HttpGet]
        [Authorize]
        [EnableRateLimiting(RateLimitPolicies.Default)]
        public async Task<IActionResult> GetPaged([FromQuery] PaginationParams pagination, CancellationToken cancellationToken)
        {
            var result = await service.GetPagedAsync(pagination, cancellationToken);

            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize]
        [EnableRateLimiting(RateLimitPolicies.Default)]
        public async Task<IActionResult> GetProductById(string id, CancellationToken cancellationToken)
        {
            var result = await service.GetByIdAsync(id, cancellationToken);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Roles.Admin)]
        [EnableRateLimiting(RateLimitPolicies.Default)]
        public async Task<IActionResult> Update(string id, [FromForm] UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var result = await service.UpdateAsync(id, request, cancellationToken);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.Admin)]
        [EnableRateLimiting(RateLimitPolicies.Default)]
        public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
        {
            await service.DeleteAsync(id, cancellationToken);

            return Ok();
        }
    }
}