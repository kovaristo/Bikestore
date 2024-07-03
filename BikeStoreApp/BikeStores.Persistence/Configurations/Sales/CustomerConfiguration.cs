using BikeStores.Common.Constants;
using BikeStores.Domain.Entities.Production;
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
    public class CustomerConfiguration : BaseAuditableEntityConfiguration<Customer>, IEntityTypeConfiguration<Customer>
    {
        public override Customer[] DefaultData => new Customer[] 
        {
            new Customer()
            {
                Id = 1, 
                Firstname = "Jan",
                Lastname = "Nowak", 
                City = "Radom",
                Email = "jan.nowak@gmail.com",
                Phone = "+48555666777",
                State = "Mazowieckie", 
                Street = "Cisowa 7/23", 
                ZipCode = "26611"
            },
            new Customer()
            {
                Id = 2,
                Firstname = "Adam",
                Lastname = "Kowalski",
                City = "Kielce",
                Email = "adam.kowalski@gmail.com",
                Phone = "+48555999444",
                State = "Świetokrzyskie",
                Street = "Galenowa 13/2",
                ZipCode = "25705"
            }
        };

        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);

            builder.HasKey(p => p.Id);

            builder.ToTable("customers").Metadata.SetSchema("sales");

            builder.Property(p => p.Id).ValueGeneratedOnAdd().HasColumnName("customer_id");
            builder.Property(p => p.Firstname).HasColumnName("first_name").HasMaxLength(FieldsLength.FIRST_NAME_LENGTH);
            builder.Property(p => p.Lastname).HasColumnName("last_name").HasMaxLength(FieldsLength.LAST_NAME_LENGTH);
            builder.Property(p => p.Phone).HasColumnName("phone").HasMaxLength(FieldsLength.PHONE_LENGTH);
            builder.Property(p => p.Email).HasColumnName("email").HasMaxLength(FieldsLength.EMAIL_LENGTH);
            builder.Property(p => p.Street).HasColumnName("street").HasMaxLength(FieldsLength.STREET_LENGTH);
            builder.Property(p => p.City).HasColumnName("city").HasMaxLength(FieldsLength.CITY_LENGTH);
            builder.Property(p => p.State).HasColumnName("state").HasMaxLength(FieldsLength.STATE_LENGTH);
            builder.Property(p => p.ZipCode).HasColumnName("zip_code").HasMaxLength(FieldsLength.ZIP_CODE_LENGTH);

            builder.HasMany(x => x.Orders).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId).HasConstraintName("FK_Orders_Customers").OnDelete(DeleteBehavior.Restrict);
        }
    }
}
