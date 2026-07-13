using Amazon.S3;
using Microsoft.EntityFrameworkCore;
using PayflowApi.Configuration;
using PayflowApi.Services.Storage;
using PayFlowApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("AppDbConnectionString")
    )
);

var r2Settings = builder.Configuration
    .GetSection("CloudflareR2")
    .Get<CloudflareR2Settings>();

builder.Services.AddSingleton(r2Settings!);

builder.Services.AddSingleton<IAmazonS3>(provider =>
{
    var settings = provider
        .GetRequiredService<CloudflareR2Settings>();

    var config = new AmazonS3Config
    {
        ServiceURL = $"https://{settings.AccountId}.r2.cloudflarestorage.com",
        ForcePathStyle = true
    };

    return new AmazonS3Client(
        settings.AccessKey,
        settings.SecretKey,
        config
    );
});

builder.Services.AddScoped<IStorageService, CloudflareR2Service>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseAuthorization();
app.MapControllers();
app.Run();