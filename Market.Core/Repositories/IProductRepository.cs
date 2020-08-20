using System.Collections.Generic;
using System.Threading.Tasks;
using Market.Core.Models;

namespace Market.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllWithCategoryAsync();
        Task<Product> GetWithCategoryByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllWithCategoryByCategoryIdAsync(int productId);
    }
}