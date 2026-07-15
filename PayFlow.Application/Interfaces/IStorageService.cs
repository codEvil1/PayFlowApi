using Microsoft.AspNetCore.Http;

namespace PayFlow.Application.Interfaces
{
    public interface IStorageService
    {
        Task<string> UploadAsync(IFormFile file, string folder);
        Task DeleteAsync(string fileUrl);
    }
}