using System;
using System.Threading.Tasks;
using Market.Core.Repositories;

namespace Market.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }
        Task<int> CommitAsync();
    }
}