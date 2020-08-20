using System.Collections.Generic;
using System.Threading.Tasks;
using Market.Core.Models;

namespace Market.Core.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllWithCategory();
        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId);
        Task<Product> CreateProduct(Product newProduct);
        Task UpdateProduct(Product productToBeUpdated, Product product);
        Task DeleteProduct(Product product);
    }
}