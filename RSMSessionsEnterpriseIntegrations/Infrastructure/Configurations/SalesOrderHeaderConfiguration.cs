
namespace Infrastructure.Configurations
{
    using Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SalesOrderHeaderConfiguration : IEntityTypeConfiguration<SalesOrderHeader>
    {
        public void Configure(EntityTypeBuilder<SalesOrderHeader> builder)
        {
            builder.ToTable(nameof(SalesOrderHeader), "Sales");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("SalesOrderID");
            builder.Property(e => e.RevisionNumber).IsRequired();
            builder.Property(e => e.OrderDate).IsRequired();
            builder.Property(e => e.DueDate).IsRequired();
            builder.Property(e => e.Status).IsRequired();
            builder.Property(e => e.OnlineOrderFlag).IsRequired();
            builder.Property(e => e.CustomerId).IsRequired();
            builder.Property(e => e.BillToAddressID).IsRequired();
            builder.Property(e => e.ShipToAddressID).IsRequired();
            builder.Property(e => e.Subtotal).IsRequired();
            builder.Property(e => e.TaxAmt).IsRequired();
            builder.Property(e => e.Freight).IsRequired();
        }
    }
}
