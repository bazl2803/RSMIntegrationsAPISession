namespace Infrastructure.Context
{
    using Microsoft.EntityFrameworkCore;
    using Domain.Models;
    using System.Reflection;

    public class AdvWorksDbContext : DbContext
    {
        public AdvWorksDbContext() { }

        public AdvWorksDbContext(DbContextOptions<AdvWorksDbContext> options) : base(options) { }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
