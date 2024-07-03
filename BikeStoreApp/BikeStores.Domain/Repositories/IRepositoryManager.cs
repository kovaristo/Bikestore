using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeStores.Domain.Repositories.Production;
using BikeStores.Domain.Repositories.Sales;

namespace BikeStores.Domain.Repositories
{
    public interface IRepositoryManager
    {
        public ICategoriesRepository CategoriesRepository { get; }
        public IBrandsRepository BrandsRepository { get; }
        public IProductsRepository ProductsRepository { get; }
        public ICustomersRepository CustomersRepository { get; }
        public IStoresRepository StoresRepository { get; }
        public IStaffsRepository StaffsRepository { get; }
        public IOrdersRepository OrdersRepository { get; }
        public IUnitOfWork UnitOfWork { get; }
    }
}
