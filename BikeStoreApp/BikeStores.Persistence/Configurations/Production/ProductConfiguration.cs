using BikeStores.Common.Constants;
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
    public class ProductConfiguration : BaseAuditableEntityConfiguration<Product>, IEntityTypeConfiguration<Product>
    {
        public override Product[] DefaultData => new Product[]
        {
            new Product()
            {
                Id = 1,
                BrandId = 1, 
                CategoryId = 1, 
                ListPrice = 123, 
                ModelYear = 2020, 
                Name = "Kross Adventure 1", 
            },
            new Product()
            {
                Id = 2,
                BrandId = 1,
                CategoryId = 1,
                ListPrice = 79,
                ModelYear = 2021,
                Name = "Kross Hardcore 2",
            },
            new Product()
            {
                Id = 3,
                BrandId = 1,
                CategoryId = 2,
                ListPrice = 37,
                ModelYear = 2023,
                Name = "Kross Family 2",
            },
            new Product()
            {
                Id = 4,
                BrandId = 1,
                CategoryId = 2,
                ListPrice = 62,
                ModelYear = 2022,
                Name = "Kross Common 1",
            },
            new Product()
            {
                Id = 5,
                BrandId = 2,
                CategoryId = 1,
                ListPrice = 231,
                ModelYear = 2021,
                Name = "Romet Gazela 2",
            },
            new Product()
            {
                Id = 6,
                BrandId = 2,
                CategoryId = 1,
                ListPrice = 193,
                ModelYear = 2022,
                Name = "Romet Alicia 3",
            }
            ,new Product()
            {
                Id = 7,
                BrandId = 2,
                CategoryId = 2,
                ListPrice = 56,
                ModelYear = 2022,
                Name = "Romet Universal 1",
            },
            new Product()
            {
                Id = 8,
                BrandId = 2,
                CategoryId = 2,
                ListPrice = 63,
                ModelYear = 2023,
                Name = "Romel Universal 2",
            }
        };

        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.HasKey(p => p.Id).HasName("PK_Products");

            builder.ToTable("products").Metadata.SetSchema("production");

            builder.Property(p => p.Id).ValueGeneratedOnAdd().HasColumnName("product_id").IsRequired(true);
            builder.Property(p => p.Name).HasColumnName("product_name").HasMaxLength(FieldsLength.PRODUCT_NAME_LENGTH).IsRequired(true);
            builder.Property(p => p.BrandId).HasColumnName("brand_id").IsRequired(true);
            builder.Property(p => p.CategoryId).HasColumnName("category_id").IsRequired(true);
            builder.Property(p => p.ModelYear).HasColumnName("model_year").IsRequired(true);
            builder.Property(p => p.ListPrice).HasColumnName("list_price").HasColumnType("decimal(10,2)").IsRequired(true);

            builder.HasOne(x => x.Brand).WithMany(x => x.Products).HasForeignKey(x => x.BrandId).HasConstraintName("FK_Products_Brands").OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x =>  x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId).HasConstraintName("FK_Products_Categories").OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x =>x.Stocks).WithOne(x => x.Product).HasForeignKey(x => x.ProductId).HasConstraintName("FK_Stocks_Products").OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.OrderItems).WithOne(x => x.Product).HasForeignKey(x => x.ProductId).HasConstraintName("FK_OrderItems_Products").OnDelete(DeleteBehavior.Restrict);
        }
    }
}
