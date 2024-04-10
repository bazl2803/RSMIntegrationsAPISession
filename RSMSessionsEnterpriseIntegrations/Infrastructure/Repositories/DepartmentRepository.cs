namespace Infrastructure.Repositories
{
    using Domain.Interfaces;
    using Domain.Models;
    using Infrastructure.Context;
    using Microsoft.EntityFrameworkCore;

    public class DepartmentRepository : IDepartmentRepository
    {
        protected readonly AdvWorksDbContext DbContext;

        public DepartmentRepository(AdvWorksDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<Department?> GetById(int id)
        {
            return await DbContext.Set<Department>().AsNoTracking().SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            return await DbContext.Set<Department>().AsNoTracking().ToListAsync();
        }

        public async Task<int> Create(Department entity)
        {
            DbContext.Set<Department>().Add(entity);
            return await DbContext.SaveChangesAsync();
        }

        public async Task<int> Update(Department entity)
        {
            DbContext.Set<Department>().Update(entity);
            return await DbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(Department entity)
        {
            DbContext.Set<Department>().Remove(entity);
            return await DbContext.SaveChangesAsync();
        }
    }
}
