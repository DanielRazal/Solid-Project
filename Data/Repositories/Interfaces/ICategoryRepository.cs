using Data.Models;

namespace Data.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetCategories();
    }
}
