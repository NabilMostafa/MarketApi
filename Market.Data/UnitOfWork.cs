using System.Threading.Tasks;
using Market.Core;
using Market.Core.Models;
using Market.Core.Repositories;
using Market.Data.Repositories;

namespace Market.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MarketDbContext _context;
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;

        public UnitOfWork(MarketDbContext context)
        {
            this._context = context;
        }

        public ICategoryRepository Category =>
            _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);

        public IProductRepository Product => _productRepository = _productRepository ?? new ProductRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}