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
    public interface ICustomersRepository
    {
        Task<Customer> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<DataPart<Customer>> GetByNameAndLocationAsync(string? firstname, string lastname, string? street, string? city, string orderField, bool ascending, int v, int pageSize, CancellationToken cancellationToken);
        Task CreateAsync(Customer customer, CancellationToken cancellationToken);
        Task UpdateAsync(Customer customer, CancellationToken cancellationToken);
        Task DeleteAsync(Customer customer, CancellationToken cancellationToken);
    }
}
