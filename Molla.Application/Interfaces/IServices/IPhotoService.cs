using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Molla.Application.Interfaces.IServices
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string publicId);

    }
}
