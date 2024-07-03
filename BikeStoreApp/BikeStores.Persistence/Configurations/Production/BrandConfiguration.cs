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
    public class BrandConfiguration : BaseAuditableEntityConfiguration<Brand>, IEntityTypeConfiguration<Brand>
    {
        public override Brand[] DefaultData => new Brand[]
        {
            new Brand()
            {
                Id = 1,
                Name = "Kross"
            },
            new Brand()
            {
                Id = 2,
                Name = "Romet"
            }
        };

        public override void Configure(EntityTypeBuilder<Brand> builder)
        {
            base.Configure(builder);

            builder.HasKey(p => p.Id).HasName("PK_Brands");

            builder.ToTable("brands").Metadata.SetSchema("production");
            builder.Property(b => b.Id).ValueGeneratedOnAdd().HasColumnName("brand_id").IsRequired(true);
            builder.Property(b => b.Name).HasColumnName("brand_name").HasMaxLength(FieldsLength.BRAND_NAME_LENGTH).IsRequired(true);

            builder.HasMany(b => b.Products).WithOne(p => p.Brand).HasForeignKey(p => p.BrandId).HasConstraintName("FK_Products_Brands").OnDelete(DeleteBehavior.Restrict);
        }
    }
}
