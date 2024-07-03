using BikeStores.Contracts.Production.Brands;
using BikeStores.Contracts.Production.Categories;
using BikeStores.Contracts.Production.Products;
using BikeStores.Contracts.Sales.Customers;
using BikeStores.Contracts.Sales.Orders;
using BikeStores.Contracts.Sales.Stores;
using BikeStores.Domain.Entities.Production;
using BikeStores.Domain.Entities.Sales;
using BikeStores.Domain.Enums;
using Mapster;
using Microsoft.OpenApi.Extensions;

namespace BikeStores.API.Infrastructure.Configuration
{
    public static class MapsterConfiguration
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig.GlobalSettings.Scan(typeof(BikeStores.Services.AssemblyReference).Assembly);
        }
    }
}
