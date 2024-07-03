using BikeStores.Domain.Entities.Production;
using BikeStores.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Domain.Repositories.Production
{
    public interface ICategoriesRepository
    {
        Task<DataPart<Category>> GetByNameAsync(string name, string orderBy, bool ascending, int startIndex, int count, CancellationToken cancellationToken);
        Task<Category> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task CreateAsync(Category category, CancellationToken cancellationToken);
        Task UpdateAsync(Category category, CancellationToken cancellationToken);
        Task DeleteAsync(Category category, CancellationToken cancellationToken);
    }
}
