﻿using BikeStores.Domain.Entities.Production;
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
    public class CustomersRepository : BaseGenericRepository<Customer,int>, ICustomersRepository
    {
        public CustomersRepository(RepositoryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Customer> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await this.FindByKey(id, cancellationToken);
        }

        public async Task<DataPart<Customer>> GetByNameAndLocationAsync(string? firstname, string lastname, string? street, string? city, string orderBy, bool ascending, int startIdx, int count, CancellationToken cancellationToken)
        {
            var query = DbContext.Customers.AsQueryable();

            if (!string.IsNullOrEmpty(firstname))
                query = query.Where(x => x.Firstname.Contains(firstname));
            if (!string.IsNullOrEmpty(lastname))
                query = query.Where(x => x.Lastname.Contains(lastname));
            if (!string.IsNullOrEmpty(street))
                query = query.Where(x => x.Street.Contains(street));
            if (!string.IsNullOrEmpty(city))
                query = query.Where(x => x.City.Contains(city));

            if (string.IsNullOrEmpty(orderBy))
                query = ascending ? query.OrderBy(x => x.Id) : query.OrderByDescending(x => x.Id);
            else
                query = ascending ? query.OrderBy(x => EF.Property<object>(x, orderBy)) : query.OrderByDescending(x => EF.Property<object>(x, orderBy));

            int totalRecords = await query.CountAsync(cancellationToken);
            return DataPart.Create<Customer>(await query.Skip(startIdx).Take(count).ToArrayAsync(cancellationToken), totalRecords);
        }
    }
}
