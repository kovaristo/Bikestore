using BikeStores.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Persistence.Configurations
{
    public abstract class BaseAuditableEntityConfiguration<T> : IEntityTypeConfiguration<T>
        where T: BaseAuditableEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(c => c.WhenCreated).HasColumnName("when_created").IsRequired(true);
            builder.Property(c => c.CreatedBy).HasColumnName("created_by").HasMaxLength(50).IsRequired(true);
            builder.Property(c => c.WhenModified).HasColumnName("when_modified").IsRequired(false);
            builder.Property(c => c.ModifiedBy).HasColumnName("modified_by").HasMaxLength(50).IsRequired(false);

            builder.HasData(DefaultData);
        }

        public abstract T[] DefaultData { get; }
    }
}
