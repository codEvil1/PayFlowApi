using Microsoft.AspNetCore.RateLimiting;
using PayFlow.Api.Constants;

namespace PayFlow.Api.Extensions
{
    public static class RateLimiterExtensions
    {
        public static IServiceCollection AddRateLimiterConfiguration(this IServiceCollection services)
        {
            services.AddRateLimiter(options =>
            {
                options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

                options.AddFixedWindowLimiter(
                    RateLimitPolicies.Auth,
                    limiter =>
                    {
                        limiter.PermitLimit = 5;
                        limiter.Window = TimeSpan.FromMinutes(1);
                        limiter.QueueLimit = 0;
                    });

                options.AddFixedWindowLimiter(
                    RateLimitPolicies.Default,
                    limiter =>
                    {
                        limiter.PermitLimit = 100;
                        limiter.Window = TimeSpan.FromMinutes(1);
                        limiter.QueueLimit = 0;
                    });
            });

            return services;
        }
    }
}