using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using PayFlow.Api.DependencyInjection;
using PayFlow.Api.Extensions;
using PayFlow.Api.Filters;
using PayFlow.Api.HealthChecks;
using PayFlow.Api.Middleware;
using PayFlow.Application.Common.Responses;
using PayFlow.Application.DependencyInjection;
using PayFlow.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers(options =>
    {
        options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
        options.Filters.Add<ApiResponseFilter>();
    })
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var errors = context.ModelState
                .Where(x => x.Value!.Errors.Count > 0)
                .SelectMany(x => x.Value!.Errors.Select(error => new ApiError
                {
                    Field = x.Key,
                    Message = error.ErrorMessage
                }));

            return new BadRequestObjectResult(
                ApiResponse<object>.ErrorResponse(
                    "Erro de validação.",
                    errors
                )
            );
        };
    });

builder.Services.AddSwaggerDocumentation();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApi(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddCorsConfiguration();
builder.Services.AddHealthCheckConfiguration(builder.Configuration);
builder.Services.AddRateLimiterConfiguration();
builder.Services.AddScoped<ApiResponseFilter>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.EnablePersistAuthorization();
    });
}

// Saúde completa
app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = HealthCheckResponse.WriteResponse
});

// Saúde somente da API
app.MapHealthChecks("/health/live", new HealthCheckOptions
{
    Predicate = check => check.Tags.Contains("live"),
    ResponseWriter = HealthCheckResponse.WriteResponse
});

// Verifica dependências (Banco, R2, etc.)
app.MapHealthChecks("/health/ready", new HealthCheckOptions
{
    Predicate = check => check.Tags.Contains("ready"),
    ResponseWriter = HealthCheckResponse.WriteResponse
});

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseRateLimiter();
app.Run();