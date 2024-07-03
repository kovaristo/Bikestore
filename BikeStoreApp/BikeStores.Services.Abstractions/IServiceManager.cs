using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeStores.Services.Abstractions.Production;
using BikeStores.Services.Abstractions.Sales;

namespace BikeStores.Services.Abstractions
{
    public interface IServiceManager
    {
        public ICategoriesService CategoriesService { get; }
        public IBrandsService BrandsService { get; }
        public IProductsService ProductsService { get; }
        public ICustomersService CustomersService { get; }
        public IStoresService StoresService { get; }

        public IOrdersService OrdersService { get; }
        public IStaffsService StaffsService { get; }
    }
}
