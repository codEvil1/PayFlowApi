using Microsoft.AspNetCore.Http;

namespace PayFlow.Infrastructure.Interfaces
{
    public interface IStorageService
    {
        Task<string> UploadAsync(IFormFile file, string folder);
        Task DeleteAsync(string fileUrl);
    }
}