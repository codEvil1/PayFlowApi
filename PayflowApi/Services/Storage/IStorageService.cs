namespace PayflowApi.Services.Storage
{
    public interface IStorageService
    {
        Task<string> UploadAsync(IFormFile file, string folder);
        Task DeleteAsync(string fileName);
    }
}
