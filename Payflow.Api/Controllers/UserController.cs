using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using PayFlow.Api.Constants;
using PayFlow.Application.Security;
using PayFlow.Infrastructure.Features.User.Requests;
using PayFlow.Infrastructure.Interfaces;

namespace Payflow.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserService service) : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        [EnableRateLimiting(RateLimitPolicies.Default)]
        public async Task<IActionResult> Create([FromForm] CreateUserRequest request, CancellationToken cancellationToken)
        {
            await service.CreateAsync(request, cancellationToken);

            return Ok();
        }

        [HttpGet("{id}")]
        [Authorize]
        [EnableRateLimiting(RateLimitPolicies.Default)]
        public async Task<IActionResult> GetUserById(int id, CancellationToken cancellationToken)
        {
            var result = await service.GetByIdAsync(id, cancellationToken);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Roles.Admin)]
        [EnableRateLimiting(RateLimitPolicies.Default)]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateUserRequest request, CancellationToken cancellationToken)
        {
            await service.UpdateAsync(id, request, cancellationToken);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.Admin)]
        [EnableRateLimiting(RateLimitPolicies.Default)]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await service.DeleteAsync(id, cancellationToken);

            return Ok();
        }
    }
}