using BikeStores.Domain.Session;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using BikeStores.Domain.Entities;
using BikeStores.Domain.Entities.Production;
using BikeStores.Domain.Entities.Sales;

namespace BikeStores.Persistence
{
    public class RepositoryDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Store> Stores { get; set; }

        private readonly UserData _userData;
        public RepositoryDbContext(DbContextOptions options, UserData userData)
            : base(options)
        {
            _userData = userData;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryDbContext).Assembly);
        }

        private void OnBeforeSave()
        {
            ChangeTracker.DetectChanges();
            foreach (var entry in ChangeTracker.Entries().Where(x => x.Entity is BaseAuditableEntity))
            {
                if (entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                BaseAuditableEntity baseEntityInstance = (BaseAuditableEntity)entry.Entity;
                if (entry.State == EntityState.Added)
                {
                    baseEntityInstance.CreatedBy = this._userData.Username;
                    baseEntityInstance.WhenCreated = DateTime.UtcNow;
                }
                if (entry.State == EntityState.Modified)
                {
                    baseEntityInstance.ModifiedBy = this._userData.Username;
                    baseEntityInstance.WhenModified = DateTime.UtcNow;
                }
            }
        }

        public override int SaveChanges()
        {
            OnBeforeSave();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}