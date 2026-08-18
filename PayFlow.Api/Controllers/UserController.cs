using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using PayFlow.Api.Constants;
using PayFlow.Application.Features.Auth.Requests;
using PayFlow.Application.Features.User.Requests;
using PayFlow.Application.Interfaces;
using PayFlow.Application.Security;
using PayFlow.Infrastructure.Features.User.Requests;

namespace PayFlow.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserService service) : ControllerBase
    {
        [HttpPost]
        [EnableRateLimiting(RateLimitPolicies.Default)]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
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

        [HttpPost("send-verification-code")]
        [EnableRateLimiting(RateLimitPolicies.Auth)]
        public async Task<IActionResult> SendVerificationCode([FromBody] SendVerificationCodeRequest request, CancellationToken cancellationToken)
        {
            await service.SendCodeAsync(request, cancellationToken);

            return Ok(new
            {
                message = "Código de verificação enviado com sucesso."
            });
        }

        [HttpPost("verify-email")]
        [EnableRateLimiting(RateLimitPolicies.Auth)]
        public async Task<IActionResult> VerifyEmail([FromBody] VerifyEmailRequest request, CancellationToken cancellationToken)
        {
            await service.VerifyEmailAsync(request, cancellationToken);

            return Ok(new
            {
                message = "E-mail verificado com sucesso."
            });
        }
    }
}