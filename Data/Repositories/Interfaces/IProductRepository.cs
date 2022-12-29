using Data.Models;

namespace Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> AddProduct(Product product);
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProductsByCategory(int id);
    }
}
