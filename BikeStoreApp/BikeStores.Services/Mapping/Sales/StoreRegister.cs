using BikeStores.Contracts.Sales.Stores;
using BikeStores.Domain.Entities.Sales;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Services.Mapping.Sales
{
    public class StoreRegister : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
           config.NewConfig<Store, StoreDTO>()
                .Map(dest => dest.StaffsCount, src => src.Staffs.Count())
                .Map(dest => dest.ProductsCount, src => src.Stocks.Select(x => x.ProductId).Distinct().Count())
                .Map(dest => dest.OrdersCount, src => src.Orders.Count());

        }
    }
}
