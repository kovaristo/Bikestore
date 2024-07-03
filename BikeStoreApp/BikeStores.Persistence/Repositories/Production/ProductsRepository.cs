using BikeStores.Domain.Entities.Production;
using BikeStores.Domain.Repositories.Production;
using BikeStores.Domain.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Persistence.Repositories.Production
{
    public class ProductsRepository : BaseGenericRepository<Product, int>, IProductsRepository
    {
        public ProductsRepository(RepositoryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await this.FindByKey(id, cancellationToken);
        }

        public async Task<DataPart<Product>> GetByNameYearsAndPricesAsync(string name, short[] modelYears, decimal? minListPrice, decimal? maxListPrice, string orderBy, bool ascending, int startIdx, int count, CancellationToken cancellationToken)
        {
            var query = DbContext.Products.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => x.Name.Contains(name));

            if (modelYears != null && modelYears.Any())
                query = query.Where(x => modelYears.Contains(x.ModelYear));

            if (minListPrice.HasValue)
                query = query.Where(x => x.ListPrice >= minListPrice.Value);

            if (maxListPrice.HasValue)
                query = query.Where(x => x.ListPrice <= maxListPrice.Value);

            if (string.IsNullOrEmpty(orderBy))
                query = ascending ? query.OrderBy(x => x.Id) : query.OrderByDescending(x => x.Id);
            else
                query = ascending ? query.OrderBy(x => EF.Property<object>(x, orderBy)) : query.OrderByDescending(x => EF.Property<object>(x, orderBy));

            int totalRecords = await query.CountAsync(cancellationToken);
            return DataPart.Create<Product>(await query.Include(x => x.Category).Include(x => x.Brand).Skip(startIdx).Take(count).ToArrayAsync(cancellationToken), totalRecords);
        }
    }
}
