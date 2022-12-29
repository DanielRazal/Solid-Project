using Data.Context;
using Data.Models;
using Data.Repositories.Interfaces;

namespace Data.Repositories.Repo
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDbContext _context;
        public CategoryRepository(StoreDbContext context)
        {
            _context = context;
        }

        public IQueryable<Category> GetCategories()
        {
            return _context.Categories.OrderBy(x => x.Name);
        }
    }
}
