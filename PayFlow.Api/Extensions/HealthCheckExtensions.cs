using Microsoft.Extensions.Diagnostics.HealthChecks;
using PayFlow.Api.HealthChecks;

namespace PayFlow.Api.Extensions
{
    public static class HealthCheckExtensions
    {
        public static IServiceCollection AddHealthCheckConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddHealthChecks()
                .AddCheck(
                    "api",
                    () => HealthCheckResult.Healthy(),
                    tags: ["live"])
                .AddSqlServer(
                    configuration.GetConnectionString("AppDbConnectionString")!,
                    name: "database",
                    tags: ["ready"])
                .AddCheck<CloudflareR2HealthCheck>(
                    "cloudflare-r2",
                    tags: ["ready"]);

            return services;
        }
    }
}