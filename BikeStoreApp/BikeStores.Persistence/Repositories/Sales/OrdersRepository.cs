using BikeStores.Domain.Entities.Production;
using BikeStores.Domain.Entities.Sales;
using BikeStores.Domain.Enums;
using BikeStores.Domain.Repositories.Sales;
using BikeStores.Domain.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BikeStores.Persistence.Repositories.Sales
{
    public class OrdersRepository : BaseGenericRepository<Order, int>, IOrdersRepository
    {
        public OrdersRepository(RepositoryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<DataPart<Order>> GetByCustomerAndOrderParams(int? customerId, int? storeId, OrderStatusEnum? orderStatus, DateTime? orderDate, string orderBy, bool ascending, int startIndex, int count, CancellationToken cancellationToken)
        {
            var query = DbContext.Orders.AsQueryable();

            if (customerId.HasValue)
                query = query.Where(x => x.CustomerId == customerId);
            
            if (storeId.HasValue)
                query = query.Where(x => x.StoreId == storeId);

            if (orderStatus.HasValue)
                query = query.Where(x => x.OrderStatus == orderStatus);

            if (orderDate.HasValue)
                query = query.Where(x => x.OrderDate.Date == orderDate.Value.Date);

            if (string.IsNullOrEmpty(orderBy))
                query = ascending ? query.OrderBy(x => x.Id) : query.OrderByDescending(x => x.Id);
            else
                query = ascending ? query.OrderBy(x => EF.Property<object>(x, orderBy)) : query.OrderByDescending(x => EF.Property<object>(x, orderBy));

            int totalRecords = await query.CountAsync(cancellationToken);
            return DataPart.Create<Order>(await query.Include(x => x.OrderItems).Skip(startIndex).Take(count).ToArrayAsync(cancellationToken), totalRecords);
        }

        public async Task<Order> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await this.DbContext.Orders.Where(x => x.Id == id)
                .Include(x => x.OrderItems)
                .FirstOrDefaultAsync(cancellationToken);
            //return await this.FindByKey(id, cancellationToken);
        }
    }
}
