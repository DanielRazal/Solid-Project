using Data.Models;

namespace Solid_Project.Service.Interface
{
    public interface IPhotoService
    {
        Task<string> UploadPhotos(IFormFile file, Product product);
    }
}
