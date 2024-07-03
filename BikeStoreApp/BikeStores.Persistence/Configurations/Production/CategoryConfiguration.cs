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
    public class CategoryConfiguration : BaseAuditableEntityConfiguration<Category>, IEntityTypeConfiguration<Category>
    {
        public override Category[] DefaultData => new Category[]
        {
            new Category()
            {

                Id = 1,
                Name = "Trekking bicycles"
            },
            new Category()
            {

                Id = 2,
                Name = "Universal bicycles"
            }
        };

        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder.HasKey(p => p.Id).HasName("PK_Categories");

            builder.ToTable("categories").Metadata.SetSchema("production");
            builder.Property(c => c.Id).ValueGeneratedOnAdd().HasColumnName("category_id").IsRequired(true);
            builder.Property(c => c.Name).HasColumnName("category_name").HasMaxLength(FieldsLength.CATEGORY_NAME_LENGTH).IsRequired(true);

            builder.HasMany(c => c.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId).HasConstraintName("FK_Products_Categories").OnDelete(DeleteBehavior.Restrict);
        }
    }
}
