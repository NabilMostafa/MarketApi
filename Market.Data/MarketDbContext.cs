using Market.Core.Models;
using Market.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Market.Core.Models;
using Market.Data.Configurations;

namespace Market.Data
{
    public class MarketDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public MarketDbContext(DbContextOptions<MarketDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new ProductConfiguration());

            builder
                .ApplyConfiguration(new CategoryConfiguration());
        }
    }
}