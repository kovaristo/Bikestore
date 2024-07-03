using BikeStores.Contracts.Sales.Customers;
using BikeStores.Domain.Entities.Sales;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Services.Mapping.Sales
{
    public class CustomerRegister : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Customer, CustomerDTO>()
                .Map(dest => dest.OrdersCount, src => src.Orders.Count());

        }
    }
}
