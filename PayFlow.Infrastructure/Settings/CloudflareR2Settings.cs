namespace PayFlow.Infrastructure.Services.Settings
{
    public class CloudflareR2Settings
    {
        public string AccountId { get; set; } = string.Empty;
        public string AccessKey { get; set; } = string.Empty;
        public string SecretKey { get; set; } = string.Empty;
        public string BucketName { get; set; } = string.Empty;
        public string PublicUrl { get; set; } = string.Empty;
    }
}
