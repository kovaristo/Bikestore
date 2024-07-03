using BikeStores.Domain.Entities.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Persistence.Configurations.Sales
{
    public class OrderItemConfiguration : BaseAuditableEntityConfiguration<OrderItem>, IEntityTypeConfiguration<OrderItem>
    {
        public override OrderItem[] DefaultData => new OrderItem[]
        {
            new OrderItem()
            {

                OrderId = 1,
                ItemId  = 1,
                ProductId  = 1,
                Quantity = 1,
                ListPrice = 123,
                Discount = 10
            },
            new OrderItem()
            {
                OrderId = 1,
                ItemId  = 2,
                ProductId  = 3,
                Quantity = 2,
                ListPrice = 35,
                Discount = 5
            },
            new OrderItem()
            {

                OrderId = 2,
                ItemId  = 1,
                ProductId  = 3,
                Quantity = 3,
                ListPrice = 33,
                Discount = 2
            },
            new OrderItem()
            {

                OrderId = 2,
                ItemId  = 2,
                ProductId  = 5,
                Quantity = 5,
                ListPrice = 223,
                Discount = 17
            }
        };

        public override void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            base.Configure(builder);

            builder.HasKey(p => new { p.OrderId, p.ItemId });

            builder.ToTable("order_items").Metadata.SetSchema("sales");

            builder.Property(p => p.OrderId).HasColumnName("order_id");
            builder.Property(p => p.ItemId).HasColumnName("item_id");
            builder.Property(p => p.ProductId).HasColumnName("product_id");
            builder.Property(p => p.Quantity).HasColumnName("quantity");
            builder.Property(p => p.ListPrice).HasColumnName("list_price").HasColumnType("decimal(10,2)");
            builder.Property(p => p.Discount).HasColumnName("discount").HasColumnType("decimal(4,2)");
            
            builder.HasOne(x => x.Product).WithMany(x => x.OrderItems).HasForeignKey(x => x.ProductId).HasConstraintName("FK_Products_OrderItems").OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Order).WithMany(x => x.OrderItems).HasForeignKey(x => x.OrderId).HasConstraintName("FK_Orders_OrderItems").OnDelete(DeleteBehavior.Restrict);
        }
    }
}
