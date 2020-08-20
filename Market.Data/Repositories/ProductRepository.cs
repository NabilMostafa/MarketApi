using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Market.Core.Models;
using Market.Core.Repositories;

namespace Market.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(MarketDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetAllWithCategoryAsync()
        {
            return await MarketDbContext.Products
                .Include(m => m.Category)
                .ToListAsync();
        }

        public async Task<Product> GetWithCategoryByIdAsync(int id)
        {
            return await MarketDbContext.Products
                .Include(m => m.Category)
                .SingleOrDefaultAsync(m => m.Id == id);
            ;
        }

        public async Task<IEnumerable<Product>> GetAllWithCategoryByCategoryIdAsync(int productId)
        {
            return await MarketDbContext.Products
                .Include(m => m.Category)
                .Where(m => m.CategoryId == productId)
                .ToListAsync();
        }
        
        private MarketDbContext MarketDbContext
        {
            get { return Context as MarketDbContext; }
        }

       
    }
}