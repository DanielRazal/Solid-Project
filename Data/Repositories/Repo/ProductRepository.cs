using Data.Context;
using Data.Models;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Repo
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _context;
        public ProductRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.Include(x => x.Category).OrderBy(x => x.Name).ToList();
        }

        public IEnumerable<Product> GetProductsByCategory(int id)
        {
            List<Product> data = new();
            var product = _context.Products.Include(a => a.Category);

            if (id > 0)
            {
                data = product.Where(c => c.Category!.Id == id).ToList();
            }
            else
            {
                data = product.ToList();
            }
            return data;
        }
    }
}
