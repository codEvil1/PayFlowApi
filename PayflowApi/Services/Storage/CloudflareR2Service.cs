namespace PayflowApi.Services.Storage
{
    using Amazon.S3;
    using Amazon.S3.Model;
    using PayflowApi.Configuration;

    public class CloudflareR2Service(IAmazonS3 client, IConfiguration configuration) : IStorageService
    {
        private readonly IAmazonS3 client = client;

        private readonly CloudflareR2Settings settings = configuration
                .GetSection("CloudflareR2")
                .Get<CloudflareR2Settings>()!;

        public async Task<string> UploadAsync(IFormFile file, string folder)
        {
            var extension = Path.GetExtension(file.FileName);
            var fileName = $"{folder}/{Guid.NewGuid()}{extension}";

            await using var stream = file.OpenReadStream();

            var request = new PutObjectRequest
            {
                BucketName = settings.BucketName,
                Key = fileName,
                InputStream = stream,
                ContentType = file.ContentType,
                DisablePayloadSigning = true
            };

            await client.PutObjectAsync(request);

            return $"{settings.PublicUrl}/{fileName}";
        }

        public async Task DeleteAsync(string fileName)
        {
            await client.DeleteObjectAsync(new DeleteObjectRequest
            {
                BucketName = settings.BucketName,
                Key = fileName
            });
        }
    }
}
