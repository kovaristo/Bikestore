using BikeStores.Domain.Entities.Production;
using BikeStores.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Domain.Repositories.Production
{
    public interface IProductsRepository
    {
        Task<DataPart<Product>> GetByNameYearsAndPricesAsync(string name, short[] modelYears, decimal? minListPrice, decimal? maxListPrice, string orderBy, bool ascending, int startIndex, int count, CancellationToken cancellationToken);
        Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task CreateAsync(Product product, CancellationToken cancellationToken);
        Task UpdateAsync(Product product, CancellationToken cancellationToken);
        Task DeleteAsync(Product product, CancellationToken cancellationToken);
    }
}
