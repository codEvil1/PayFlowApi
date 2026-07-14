using Microsoft.AspNetCore.Http;

namespace PayFlow.Infrastructure.Services.Interfaces
{
    public interface IStorageService
    {
        Task<string> UploadAsync(IFormFile file, string folder);
        Task DeleteAsync(string fileName);
    }
}
