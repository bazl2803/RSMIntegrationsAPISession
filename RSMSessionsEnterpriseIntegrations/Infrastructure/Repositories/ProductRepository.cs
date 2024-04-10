using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public sealed class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AdvWorksDbContext dbContext) : base(dbContext) { }
    }
}
