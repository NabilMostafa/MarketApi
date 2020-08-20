using System.Collections.Generic;
using System.Threading.Tasks;
using Market.Core.Models;

namespace Market.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetAllWithProductAsync();
        Task<Category> GetWithCategoryByIdAsync(int id);
    }
}