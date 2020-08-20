using System.Collections.Generic;
using System.Threading.Tasks;
using Market.Core;
using Market.Core.Models;
using Market.Core.Services;

namespace Market.Services
{
    public class CategroyService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategroyService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Category> CreateCategory(Category newCategory)
        {
            await _unitOfWork.Category
                .AddAsync(newCategory);
            await _unitOfWork.CommitAsync();
            
            return newCategory;
        }

        public async Task DeleteCategory(Category category)
        {
            _unitOfWork.Category.Remove(category);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _unitOfWork.Category.GetAllAsync();
        }
        
        public async Task<Category> GetCategoryById(int id)
        {
            return await _unitOfWork.Category.GetByIdAsync(id);
        }

        public async Task UpdateCategory(Category categoryToBeUpdated, Category category)
        {
            categoryToBeUpdated.Name = category.Name;

            await _unitOfWork.CommitAsync();
        }
    }
}