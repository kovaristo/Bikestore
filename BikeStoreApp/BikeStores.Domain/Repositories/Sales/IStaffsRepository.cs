using BikeStores.Domain.Entities.Sales;
using BikeStores.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Domain.Repositories.Sales
{
    public interface IStaffsRepository
    {
        Task<Staff> GetByIdAsync(int id, CancellationToken cancellationToken);
        
        Task<IEnumerable<Staff>> GetByStoreId(int storeId, CancellationToken cancellationToken); 
        Task<IEnumerable<Staff>> GetByManagerId(int managerId, CancellationToken cancellationToken);

        Task<DataPart<Staff>> GetByStaffDataAndStoreId(string firstname, string lastname, string email, string? phone, 
            short active, int? storeId, string orderField, bool ascending, int v, int pageSize, CancellationToken cancellationToken);
        Task CreateAsync(Staff staff, CancellationToken cancellationToken);
        Task UpdateAsync(Staff staff, CancellationToken cancellationToken);
        Task DeleteAsync(Staff staff, CancellationToken cancellationToken);
    }
}
