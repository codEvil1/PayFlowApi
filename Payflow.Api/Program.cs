using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Payflow.Api.DependencyInjection;
using Payflow.Api.Extensions;
using PayFlow.Api.Extensions;
using PayFlow.Api.HealthChecks;
using PayFlow.Infrastructure.DependencyInjection;
using PayFlow.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});

builder.Services.AddSwaggerDocumentation();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApi(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddCorsConfiguration();
builder.Services.AddHealthCheckConfiguration(builder.Configuration);
builder.Services.AddRateLimiterConfiguration();

var app = builder.Build();

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