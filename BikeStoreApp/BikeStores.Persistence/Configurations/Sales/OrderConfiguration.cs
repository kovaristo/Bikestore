using BikeStores.Domain.Entities.Production;
using BikeStores.Domain.Entities.Sales;
using BikeStores.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Persistence.Configurations.Sales
{
    public class OrderConfiguration : BaseAuditableEntityConfiguration<Order>, IEntityTypeConfiguration<Order>
    {
        public override Order[] DefaultData => new Order[]
        {
            new Order()
            {
               Id  = 1,
               StoreId = 1, 
               StaffId = 2,
               CustomerId = 1,
               OrderStatus = OrderStatusEnum.New, 
               OrderDate = DateTime.Now.AddDays(-13).AddMinutes(-1234567), 
               RequiredDate = DateTime.Now.AddDays(13).AddMinutes(-1234567),
               ShippedDate = null
            },
            new Order()
            {
               Id  = 2,
               StoreId = 1,
               StaffId = 2,
               CustomerId = 2,
               OrderStatus = OrderStatusEnum.Shipped,
               OrderDate = DateTime.Now.AddDays(-27).AddMinutes(-1234567),
               RequiredDate = DateTime.Now.AddDays(-2).AddMinutes(-1234567),
               ShippedDate = DateTime.Now.AddDays(-1).AddMinutes(-1234)
            },
        };

        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);

            builder.HasKey(p => p.Id);

            builder.ToTable("orders").Metadata.SetSchema("sales");

            builder.Property(p => p.Id).ValueGeneratedOnAdd().HasColumnName("order_id");
            builder.Property(p => p.StoreId).HasColumnName("store_id");
            builder.Property(p => p.StaffId).HasColumnName("staff_id");
            builder.Property(p => p.CustomerId).HasColumnName("customer_id");
            builder.Property(p => p.OrderStatus).HasColumnName("order_status").HasColumnType("tinyint");
            builder.Property(p => p.OrderDate).HasColumnName("order_date");
            builder.Property(p => p.RequiredDate).HasColumnName("required_date");
            builder.Property(p => p.ShippedDate).HasColumnName("shipped_date");

            builder.HasMany(x => x.OrderItems).WithOne(x => x.Order).HasForeignKey(x => x.OrderId).HasConstraintName("FK_Orders_OrderItems").OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Store).WithMany(x=>x.Orders).HasForeignKey(x => x.StoreId).HasConstraintName("FK_Stores_Orders").OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Staff).WithMany(x => x.Orders).HasForeignKey(x => x.StaffId).HasConstraintName("FK_Staffs_Orders").OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Customer).WithMany(x => x.Orders).HasForeignKey(x => x.CustomerId).HasConstraintName("FK_Customers_Orders").OnDelete(DeleteBehavior.Restrict);
        }
    }
}
