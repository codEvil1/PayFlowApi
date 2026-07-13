using Microsoft.EntityFrameworkCore;
using PayFlowApi.Data;

namespace Payflow.Api.Extensions;

public static class DatabaseExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("AppDbConnectionString")));

        return services;
    }
}