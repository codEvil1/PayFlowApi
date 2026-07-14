using Microsoft.AspNetCore.Mvc;
using PayFlow.Application.Features.Customer.Requests;
using PayFlow.Application.Interfaces;

namespace Payflow.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController(ICustomerService service) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            await service.CreateAsync(request, cancellationToken);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await service.GetAllAsync(cancellationToken);

            return Ok(result);
        }

        [HttpGet("{identifier}")]
        public async Task<IActionResult> GetCustomerById(string identifier, CancellationToken cancellationToken)
        {
            var result = await service.GetByIdentifierAsync(identifier, cancellationToken);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{identifier}")]
        public async Task<IActionResult> Update(string identifier, [FromForm] UpdateCustomerRequest request, CancellationToken cancellationToken)
        {
            await service.UpdateAsync(identifier, request, cancellationToken);

            return Ok();
        }

        [HttpDelete("{identifier}")]
        public async Task<IActionResult> Delete(string identifier, CancellationToken cancellationToken)
        {
            await service.DeleteAsync(identifier, cancellationToken);

            return Ok();
        }
    }
}