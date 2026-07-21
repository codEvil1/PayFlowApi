using PayFlow.Application.Common.Responses;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace PayFlow.Api.Middleware
{
    public class ExceptionMiddleware (RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro não tratado");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var response = new ApiResponse<object>
                {
                    Success = false,
                    Message = "Erro interno no servidor.",
                    Data = null,
                    TraceId = Activity.Current?.TraceId.ToString() ?? context.TraceIdentifier,
                    Timestamp = DateTime.UtcNow
                };

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}