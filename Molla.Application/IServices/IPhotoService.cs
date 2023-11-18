using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
 

namespace Molla.Application.IServices
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string publicId);

    }
}
