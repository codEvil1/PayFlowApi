using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using PayFlow.Api.Constants;
using PayFlow.Application.Common.Responses;
using PayFlow.Infrastructure.Features.Auth.Requests;
using PayFlow.Infrastructure.Interfaces;

namespace PayFlow.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthService service) : ControllerBase
    {

        [HttpPost("login")]
        [EnableRateLimiting(RateLimitPolicies.Auth)]
        public async Task<IActionResult> Login(AuthRequest request, CancellationToken cancellationToken)
        {
            var result = await service.LoginAsync(request, cancellationToken);

            return Ok(
                ApiResponse<object>.SuccessResponse(
                    result,
                    "Login realizado com sucesso."
                )
            );
        }


        [HttpPost("refresh")]
        [EnableRateLimiting(RateLimitPolicies.Auth)]
        public async Task<IActionResult> Refresh(RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            var result = await service.RefreshTokenAsync(request, cancellationToken);

            return Ok(
                ApiResponse<object>.SuccessResponse(
                    result,
                    "Token atualizado com sucesso."
                )
            );
        }

        [HttpPost("logout")]
        [EnableRateLimiting(RateLimitPolicies.Auth)]
        public async Task<IActionResult> Logout(RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            await service.RevokeTokenAsync(request, cancellationToken);

            return Ok(
                ApiResponse<object>.SuccessResponse(
                    null,
                    "Logout realizado com sucesso."
                )
            );
        }
    }
}