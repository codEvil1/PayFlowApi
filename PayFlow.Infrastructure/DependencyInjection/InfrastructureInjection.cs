using Amazon.S3;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PayFlow.Infrastructure.Data.Context;
using PayFlow.Infrastructure.Services.Interfaces;
using PayFlow.Infrastructure.Services.Settings;
using PayFlow.Infrastructure.Services.Storage;

namespace PayFlow.Infrastructure.DependencyInjection
{
    public static class InfrastructureInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddDatabase(configuration)
                .AddCloudflareR2(configuration);
        }

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("AppDbConnectionString")));

            return services;
        }

        private static IServiceCollection AddCloudflareR2(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration
                .GetSection("CloudflareR2")
                .Get<CloudflareR2Settings>();

            services.AddSingleton(settings!);

            services.AddSingleton<IAmazonS3>(provider =>
            {
                var config = new AmazonS3Config
                {
                    ServiceURL = $"https://{settings!.AccountId}.r2.cloudflarestorage.com",
                    ForcePathStyle = true
                };

                return new AmazonS3Client(
                    settings.AccessKey,
                    settings.SecretKey,
                    config);
            });

            services.AddScoped<IStorageService, CloudflareR2Service>();

            return services;
        }
    }
}