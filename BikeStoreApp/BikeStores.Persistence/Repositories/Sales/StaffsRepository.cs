using BikeStores.Domain.Entities.Production;
using BikeStores.Domain.Entities.Sales;
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
    public class StaffsRepository : BaseGenericRepository<Staff, int>, IStaffsRepository
    {
        public StaffsRepository(RepositoryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Staff> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await this.FindByKey(id, cancellationToken);
        }

        public async Task<IEnumerable<Staff>> GetByManagerId(int managerId, CancellationToken cancellationToken)
        {
            return await this.DbContext.Staffs.Where(x => x.ManagerId == managerId)
                .Include(x => x.Store) 
                .OrderBy(x => x.Id)
                .ToArrayAsync(cancellationToken);
        }

        public async Task<IEnumerable<Staff>> GetByStoreId(int storeId, CancellationToken cancellationToken)
        {
            return await this.DbContext.Staffs.Where(x => x.StoreId == storeId)
                .Include(x => x.Store)
                .OrderBy(x => x.Id)
                .ToArrayAsync(cancellationToken);
        }

        public async Task<DataPart<Staff>> GetByStaffDataAndStoreId(string firstname, string lastname, string email, string? phone, short active, int? storeId, string orderBy, bool ascending, int startIdx, int pageSize, CancellationToken cancellationToken)
        {
            var query = DbContext.Staffs.AsQueryable();

            if (!string.IsNullOrEmpty(firstname))
                query = query.Where(x => x.Firstname.Contains(firstname));
            if (!string.IsNullOrEmpty(lastname))
                query = query.Where(x => x.Lastname.Contains(lastname));
            if (!string.IsNullOrEmpty(email))
                query = query.Where(x => x.Email.Contains(email));
            if (!string.IsNullOrEmpty(phone))
                query = query.Where(x => x.Phone.Contains(phone));
            if (storeId.HasValue)
                query = query.Where(x => x.StoreId == storeId.Value);

            query = query.Where(x => x.Active == active);

            if (string.IsNullOrEmpty(orderBy))
                query = ascending ? query.OrderBy(x => x.Id) : query.OrderByDescending(x => x.Id);
            else
                query = ascending ? query.OrderBy(x => EF.Property<object>(x, orderBy)) : query.OrderByDescending(x => EF.Property<object>(x, orderBy));

            int totalRecords = await query.CountAsync(cancellationToken);
            return DataPart.Create<Staff>(await query.Include(x => x.StoreId).Skip(startIdx).Take(pageSize).ToArrayAsync(cancellationToken), totalRecords);
        }
    }
}
