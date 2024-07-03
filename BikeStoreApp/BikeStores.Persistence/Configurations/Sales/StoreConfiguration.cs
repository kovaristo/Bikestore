using BikeStores.Common.Constants;
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
    public class StoreConfiguration : BaseAuditableEntityConfiguration<Store>, IEntityTypeConfiguration<Store>
    {
        public override Store[] DefaultData => new Store[]
        {
            new Store()
            {
                Id = 1,
                Name = "Sklep w Radomiu",
                Phone = "+48654234200",
                Email = "radom@bikestores.org",
                City = "Radom",
                State = "Mazowieckie",
                Street = "Wiejska 14",
                ZipCode = "26606"
            },
            new Store()
            {
                Id = 2,
                Name = "Sklep w Kielcach",
                Phone = "+22456543200",
                Email = "kielce@bikestores.org",
                City = "Kielce",
                State = "Swietokrzyskie",
                Street = "Kwarcowa 12/4",
                ZipCode = "25741"
            }
        };

        public override void Configure(EntityTypeBuilder<Store> builder)
        {
            base.Configure(builder);

            builder.HasKey(p => p.Id);

            builder.ToTable("stores").Metadata.SetSchema("sales");

            builder.Property(p => p.Id).ValueGeneratedOnAdd().HasColumnName("store_id");
            builder.Property(p => p.Name).HasColumnName("store_name").HasMaxLength(FieldsLength.STORE_NAME_LENGTH);
            builder.Property(p => p.Phone).HasColumnName("phone").HasMaxLength(FieldsLength.PHONE_LENGTH);
            builder.Property(p => p.Email).HasColumnName("email").HasMaxLength(FieldsLength.EMAIL_LENGTH);
            builder.Property(p => p.Street).HasColumnName("street").HasMaxLength(FieldsLength.STREET_LENGTH);
            builder.Property(p => p.City).HasColumnName("city").HasMaxLength(FieldsLength.CITY_LENGTH);
            builder.Property(p => p.State).HasColumnName("state").HasMaxLength(FieldsLength.STATE_LENGTH);
            builder.Property(p => p.ZipCode).HasColumnName("zip_code").HasMaxLength(FieldsLength.ZIP_CODE_LENGTH);

            builder.HasMany(x => x.Orders).WithOne(x => x.Store).HasForeignKey(x => x.StoreId).HasConstraintName("FK_Orders_Stores").OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Stocks).WithOne(x => x.Store).HasForeignKey(x => x.StoreId).HasConstraintName("FK_Stocks_Stores").OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Staffs).WithOne(x => x.Store).HasForeignKey(x => x.StoreId).HasConstraintName("FK_Staffs_Stores").OnDelete(DeleteBehavior.Restrict);
        }
    }
}
