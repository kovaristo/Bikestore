using BikeStores.Domain.Entities.Production;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Persistence.Configurations.Production
{
    public class StockConfiguration : BaseAuditableEntityConfiguration<Stock>, IEntityTypeConfiguration<Stock>
    {
        public override Stock[] DefaultData => new Stock[]
        {
            new Stock()
            {
                ProductId = 1, StoreId = 1, Quantity = 13
            },
            new Stock()
            {
                ProductId = 2, StoreId = 1, Quantity = 17
            },
            new Stock()
            {
                ProductId = 1, StoreId = 2, Quantity = 23
            },
            new Stock()
            {
                ProductId = 2, StoreId = 2, Quantity = 7
            }
        };

        public override void Configure(EntityTypeBuilder<Stock> builder)
        {
            base.Configure(builder);

            builder.HasKey(p => new { p.StoreId, p.ProductId }).HasName("PK_Stocks");

            builder.ToTable("stocks").Metadata.SetSchema("production");
            
            builder.Property(p => p.StoreId).HasColumnName("store_id").IsRequired(true);
            builder.Property(p => p.ProductId).HasColumnName("product_id").IsRequired(true);
            builder.Property(p => p.Quantity).HasColumnName("quantity").IsRequired(false);
            
            builder.HasOne(x => x.Product).WithMany(x => x.Stocks).HasForeignKey(x => x.ProductId).HasConstraintName("FK_Stocks_Products").OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Store).WithMany(x => x.Stocks).HasForeignKey(x => x.StoreId).HasConstraintName("FK_Stocks_Stores").OnDelete(DeleteBehavior.Restrict);
        }
    }
}
