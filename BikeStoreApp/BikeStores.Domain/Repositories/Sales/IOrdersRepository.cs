using BikeStores.Domain.Entities.Production;
using BikeStores.Domain.Entities.Sales;
using BikeStores.Domain.Enums;
using BikeStores.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Domain.Repositories.Sales
{
    public interface IOrdersRepository
    {
        Task<Order> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task CreateAsync(Order order, CancellationToken cancellationToken);
        Task UpdateAsync(Order order, CancellationToken cancellationToken);
        Task DeleteAsync(Order order, CancellationToken cancellationToken);
        Task<DataPart<Order>> GetByCustomerAndOrderParams(int? customerId, int? storeId, OrderStatusEnum? orderStatus, DateTime? orderDate, string orderBy, bool ascending, int startIndex, int count, CancellationToken cancellationToken);
    }
}
