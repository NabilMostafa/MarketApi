using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Market.Core.Models;
using Market.Core.Repositories;

namespace Market.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(MarketDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Category>> GetAllWithProductAsync()
        {
            return await MarketDbContext.Categories
                .Include(a => a.Product)
                .ToListAsync();
        }

     

        public Task<Category> GetWithCategoryByIdAsync(int id)
        {
            return MarketDbContext.Categories
                .Include(a => a.Product)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        private MarketDbContext MarketDbContext
        {
            get { return Context as MarketDbContext; }
        }
    }
}