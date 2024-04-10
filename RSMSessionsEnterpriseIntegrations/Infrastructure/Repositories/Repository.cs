namespace Infrastructure.Repositories
{
    using Domain.Primitives;
    using Infrastructure.Context;
    using Microsoft.EntityFrameworkCore;
    using System.Runtime.CompilerServices;

    public abstract class Repository<TEntity>
        where TEntity : Entity
    {
        protected readonly AdvWorksDbContext DbContext;

        protected Repository(AdvWorksDbContext dbContext)
        {
          DbContext = dbContext;
        }

        public async Task<TEntity?> GetById(int id)
        {
            return await DbContext.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<int> Create(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
            return await DbContext.SaveChangesAsync();
        }

        public async Task<int> Update(TEntity entity)
        {
            DbContext.Set<TEntity>().Update(entity);
            return await DbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
            return await DbContext.SaveChangesAsync();
        }
    }
}
