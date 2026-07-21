using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayFlow.Infrastructure.Interfaces;
using PayFlow.Infrastructure.Features.Product.Requests;
using PayFlow.Application.Security;

namespace Payflow.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(IProductService service) : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Create([FromForm] CreateProductRequest request, CancellationToken cancellationToken)
        {
            await service.CreateAsync(request, cancellationToken);

            return Ok();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await service.GetAllAsync(cancellationToken);

            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetProductById(string id, CancellationToken cancellationToken)
        {
            var result = await service.GetByIdAsync(id, cancellationToken);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Update(string id, [FromForm] UpdateProductRequest request, CancellationToken cancellationToken)
        {
            await service.UpdateAsync(id, request, cancellationToken);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
        {
            await service.DeleteAsync(id, cancellationToken);

            return Ok();
        }
    }
}