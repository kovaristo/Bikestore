using BikeStores.Domain.Entities.Production;
using BikeStores.Domain.Entities.Sales;
using BikeStores.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Domain.Repositories.Sales
{
    public interface IStoresRepository
    {
        Task<Store> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<DataPart<Store>> GetByNameAndLocationAsync(string name, string? street, string? city, string orderField, bool ascending, int v, int pageSize, CancellationToken cancellationToken);
        Task CreateAsync(Store store, CancellationToken cancellationToken);
        Task UpdateAsync(Store store, CancellationToken cancellationToken);
        Task DeleteAsync(Store store, CancellationToken cancellationToken);
    }
}
