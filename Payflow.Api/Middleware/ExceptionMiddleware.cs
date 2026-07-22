using PayFlow.Application.Common.Exceptions;
using PayFlow.Application.Common.Responses;
using System.Diagnostics;

namespace PayFlow.Api.Middleware
{
    public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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

                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = exception switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                BadRequestException => StatusCodes.Status400BadRequest,
                ConflictException => StatusCodes.Status409Conflict,
                UnauthorizedException => StatusCodes.Status401Unauthorized,
                ExternalServiceException => StatusCodes.Status502BadGateway,
                _ => StatusCodes.Status500InternalServerError
            };

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var response = ApiResponse<object>.ErrorResponse(exception.Message);

            response.TraceId = Activity.Current?.TraceId.ToString() ?? context.TraceIdentifier;

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}