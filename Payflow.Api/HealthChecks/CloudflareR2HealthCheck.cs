using Microsoft.Extensions.Diagnostics.HealthChecks;
using PayFlow.Application.Interfaces;

namespace PayFlow.Api.HealthChecks
{
    public class CloudflareR2HealthCheck(IStorageService storage) : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken)
        {
            try
            {
                var connected = await storage.CheckConnectionAsync();

                return connected ? HealthCheckResult.Healthy("Cloudflare R2 disponível.")
                    : HealthCheckResult.Unhealthy("Cloudflare R2 indisponível.");
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy("Erro ao conectar no Cloudflare R2.", ex);
            }
        }
    }
}