using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product), "Production");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("ProductID");
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.ProductNumber).IsRequired();
            builder.Property(e => e.MakeFlag).IsRequired();
            builder.Property(e => e.FinishedGoodsFlag).IsRequired();
            builder.Property(e => e.Color);
            builder.Property(e => e.SafetyStockLevel).IsRequired();
            builder.Property(e => e.ReorderPoint).IsRequired();
            builder.Property(e => e.StandardCost).IsRequired();
            builder.Property(e => e.ListPrice).IsRequired();
            builder.Property(e => e.Size);
            builder.Property(e => e.SizeUnitMeasureCode);
            builder.Property(e => e.WeightUnitMeasureCode);
            builder.Property(e => e.Weight);
            builder.Property(e => e.DaysToManufacture).IsRequired();
            builder.Property(e => e.ProductLine);
            builder.Property(e => e.Class);
            builder.Property(e => e.Style);
            builder.Property(e => e.ProductSubcategoryID);
            builder.Property(e => e.ProductModelID);
            builder.Property(e => e.SellStartDate).IsRequired();
            builder.Property(e => e.SellEndDate);
            builder.Property(e => e.DiscontinuedDate);
        }
    }
}
