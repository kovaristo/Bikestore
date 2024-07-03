using BikeStores.Domain.Entities.Production;
using BikeStores.Domain.Repositories.Production;
using BikeStores.Domain.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Persistence.Repositories.Production
{
    public class CategoriesRepository : BaseGenericRepository<Category, int>, ICategoriesRepository
    {

        public CategoriesRepository(RepositoryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Category> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await this.FindByKey(id, cancellationToken);
        }

        public async Task<DataPart<Category>> GetByNameAsync(string name, string orderBy, bool ascending, int startIdx, int count, CancellationToken cancellationToken)
        {
            var query = DbContext.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => x.Name.Contains(name));

            if (string.IsNullOrEmpty(orderBy))
                query = ascending ? query.OrderBy(x => x.Id) : query.OrderByDescending(x => x.Id);
            else
                query = ascending ? query.OrderBy(x => EF.Property<object>(x, orderBy)) : query.OrderByDescending(x => EF.Property<object>(x, orderBy));
            
            int totalRecords = await query.CountAsync(cancellationToken);
            return DataPart.Create<Category>(await query.Include(x => x.Products).Skip(startIdx).Take(count).ToArrayAsync(cancellationToken), totalRecords);
        }

    }
}
