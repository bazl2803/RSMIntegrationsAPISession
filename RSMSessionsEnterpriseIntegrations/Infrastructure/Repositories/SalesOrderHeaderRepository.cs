
namespace Infrastructure.Repositories
{
    using Domain.Interfaces;
    using Domain.Models;

    using Infrastructure.Context;

    public sealed class SalesOrderHeaderRepository : Repository<SalesOrderHeader>, ISalesOrderHeaderRepository
    {
        public SalesOrderHeaderRepository(AdvWorksDbContext dbContext) : base(dbContext) { }
    }
}
