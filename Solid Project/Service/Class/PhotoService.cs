using Data.Models;
using Solid_Project.Service.Interface;

namespace Solid_Project.Service.Class
{
    public class PhotoService : IPhotoService
    {
        private readonly IWebHostEnvironment _environment;

        public PhotoService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public async Task<string> UploadPhotos(IFormFile file, Product product)
        {
            string wwwPath = _environment.WebRootPath;
            var path = Path.Combine(wwwPath, "images", file.FileName);
            if (file.Length > 0)
            {
                using var stream = new FileStream(path, FileMode.Create);
                await file.CopyToAsync(stream);
            }
            return product.PhotoUrl = file.FileName;
        }
    }
}
