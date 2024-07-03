using BikeStores.Domain.Entities.Production;
using BikeStores.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Domain.Repositories.Production
{
    public interface IBrandsRepository
    {
        Task<Brand> GetByIdAsync(int id, CancellationToken cancellationToken);

        Task<DataPart<Brand>> GetByNameAsync(string name, string orderBy, bool ascending, int startIndex, int count, CancellationToken cancellationToken);
        Task CreateAsync(Brand brand, CancellationToken cancellationToken);
        Task UpdateAsync(Brand brand, CancellationToken cancellationToken);
        Task DeleteAsync(Brand brand, CancellationToken cancellationToken);

    }
}
