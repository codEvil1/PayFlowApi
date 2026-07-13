using Amazon.S3;
using PayflowApi.Configuration;
using PayflowApi.Services.Storage;

namespace Payflow.Api.Extensions;

public static class CloudflareExtensions
{
    public static IServiceCollection AddCloudflareR2(this IServiceCollection services, IConfiguration configuration)
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