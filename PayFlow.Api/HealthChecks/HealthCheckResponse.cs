using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace PayFlow.Api.HealthChecks
{
    public static class HealthCheckResponse
    {
        public static async Task WriteResponse(HttpContext context, HealthReport report)
        {
            context.Response.ContentType = "application/json";

            var response = new
            {
                status = report.Status.ToString(),
                timestamp = DateTime.UtcNow,
                checks = report.Entries.Select(entry => new
                {
                    name = entry.Key,
                    status = entry.Value.Status.ToString(),
                    duration = entry.Value.Duration.TotalMilliseconds + "ms",
                    error = entry.Value.Exception?.Message
                })
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}