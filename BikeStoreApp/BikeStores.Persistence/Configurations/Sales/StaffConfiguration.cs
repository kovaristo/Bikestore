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
    public class StaffConfiguration : BaseAuditableEntityConfiguration<Staff>, IEntityTypeConfiguration<Staff>
    {
        public override Staff[] DefaultData => new Staff[]
        {
            new Staff()
            {
                Id = 1,
                Firstname = "Adam",
                Lastname = "Manager",
                Phone = "+48654234201", 
                Email = "adam.manager@radom.bikestores.org", 
                Active = 1, 
                StoreId = 1,
                ManagerId = null
            },
            new Staff()
            {
                Id = 2,
                Firstname = "Anna",
                Lastname = "Pracownik",
                Phone = "+48654234202",
                Email = "anna.pracownik@radom.bikestores.org",
                Active = 1,
                StoreId = 2,
                ManagerId = 1
            },
            new Staff()
            {
                Id = 3,
                Firstname = "Krzysztof",
                Lastname = "Pracownik",
                Phone = "+48654234201",
                Email = "krzysztof.pracownik@radom.bikestores.org",
                Active = 1,
                StoreId = 2,
                ManagerId = 2
            },
            new Staff()
            {
                Id = 4,
                Firstname = "Janina",
                Lastname = "Manager",
                Phone = "+48654234201",
                Email = "janina.manager@kielce.bikestores.org",
                Active = 1,
                StoreId = 1,
                ManagerId = null
            },
            new Staff()
            {
                Id = 5,
                Firstname = "Julian",
                Lastname = "Pracownik",
                Phone = "+48654234202",
                Email = "julian.pracownik@kielce.bikestores.org",
                Active = 1,
                StoreId = 2,
                ManagerId = 4
            },
            new Staff()
            {
                Id = 6,
                Firstname = "Krzysztof",
                Lastname = "Pracownik",
                Phone = "+48654234201",
                Email = "krzysztof.pracownik.radom@bikestores.org",
                Active = 1,
                StoreId = 2,
                ManagerId = 5
            }
        };

        public override void Configure(EntityTypeBuilder<Staff> builder)
        {
            base.Configure(builder);

            builder.HasKey(p => p.Id);

            builder.ToTable("staffs").Metadata.SetSchema("sales");

            builder.Property(p => p.Id).ValueGeneratedOnAdd().HasColumnName("staff_id");
            builder.Property(p => p.Firstname).HasColumnName("first_name").HasMaxLength(FieldsLength.FIRST_NAME_LENGTH);
            builder.Property(p => p.Lastname).HasColumnName("last_name").HasMaxLength(FieldsLength.LAST_NAME_LENGTH);
            builder.Property(p => p.Email).HasColumnName("email").HasMaxLength(FieldsLength.EMAIL_LENGTH);
            builder.Property(p => p.Phone).HasColumnName("phone").HasMaxLength(FieldsLength.PHONE_LENGTH);
            builder.Property(p => p.Active).HasColumnName("active").HasColumnType("tinyint");
            builder.Property(p => p.StoreId).HasColumnName("store_id");
            builder.Property(p => p.ManagerId).HasColumnName("manager_id").IsRequired(false);

            builder.HasMany(x => x.Subordinate).WithOne(x => x.Manager).HasForeignKey(x => x.ManagerId).HasConstraintName("FK_Staffs_Manager").OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Orders).WithOne(x => x.Staff).HasForeignKey(x => x.StaffId).HasConstraintName("FK_Staffs_Orders").OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Store).WithMany(x => x.Staffs).HasForeignKey(x => x.StoreId).HasConstraintName("FK_Stores_Staffs").OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Manager).WithMany(x => x.Subordinate).HasForeignKey(x => x.ManagerId).HasConstraintName("FK_Staffs_Manager").OnDelete(DeleteBehavior.Restrict);
        }
    }
}
