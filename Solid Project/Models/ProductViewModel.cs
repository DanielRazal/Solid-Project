using Data.Models;

namespace Solid_Project.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; } = null!;
        public IFormFile Photo { get; set; } = null!;
    }
}
