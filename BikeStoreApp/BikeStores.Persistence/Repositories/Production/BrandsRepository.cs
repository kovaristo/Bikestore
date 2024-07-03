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
    public class BrandsRepository : BaseGenericRepository<Brand, int>, IBrandsRepository
    {
        public BrandsRepository(RepositoryDbContext dbContext) : base(dbContext)
        {
        }

        public Task<Brand> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return this.FindByKey(id, cancellationToken);
        }

        public async Task<DataPart<Brand>> GetByNameAsync(string name, string orderBy, bool ascending, int startIdx, int count, CancellationToken cancellationToken)
        {
            var query = DbContext.Brands.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => x.Name.Contains(name));

            if (string.IsNullOrEmpty(orderBy))
                query = ascending ? query.OrderBy(x => x.Id) : query.OrderByDescending(x => x.Id);
            else
                query = ascending ? query.OrderBy(x => EF.Property<object>(x, orderBy)) : query.OrderByDescending(x => EF.Property<object>(x, orderBy));

            int totalRecords = await query.CountAsync(cancellationToken);
            return DataPart.Create<Brand>(await query.Include(x => x.Products).Skip(startIdx).Take(count).ToArrayAsync(cancellationToken), totalRecords);
        }
    }
}
