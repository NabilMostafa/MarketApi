using System.Collections.Generic;
using System.Threading.Tasks;
using Market.Core;
using Market.Core.Models;
using Market.Core.Services;

namespace Market.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Product> CreateProduct(Product newProduct)
        {
            await _unitOfWork.Product.AddAsync(newProduct);
            await _unitOfWork.CommitAsync();
            return newProduct;
        }

        public async Task DeleteProduct(Product product)
        {
            _unitOfWork.Product.Remove(product);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Product>> GetAllWithCategory()
        {
            return await _unitOfWork.Product
                .GetAllWithCategoryAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _unitOfWork.Product
                .GetWithCategoryByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId)
        {
            return await _unitOfWork.Product
                .GetAllWithCategoryByCategoryIdAsync(categoryId);
        }

        public async Task UpdateProduct(Product productToBeUpdated, Product product)
        {
            productToBeUpdated.Name = product.Name;
            productToBeUpdated.CategoryId = product.CategoryId;

            await _unitOfWork.CommitAsync();
        }
    }
}