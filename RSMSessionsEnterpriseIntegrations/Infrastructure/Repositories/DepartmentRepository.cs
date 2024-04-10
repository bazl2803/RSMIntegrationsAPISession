namespace Infrastructure.Repositories
{
    using Domain.Interfaces;
    using Domain.Models;
    using Infrastructure.Context;

    public sealed class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AdvWorksDbContext dbContext) : base(dbContext) { }
    }
}
