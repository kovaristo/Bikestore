using BikeStores.Domain.Repositories;
using BikeStores.Services.Abstractions;
using BikeStores.Services.Abstractions.Production;
using BikeStores.Services.Abstractions.Sales;
using BikeStores.Services.Implementations.Production;
using BikeStores.Services.Implementations.Sales;

namespace BikeStores.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICategoriesService> _categoriesService;
        private readonly Lazy<IBrandsService> _brandsService;
        private readonly Lazy<IProductsService> _productsService;
        private readonly Lazy<ICustomersService> _customersService;
        private readonly Lazy<IStoresService> _storesService;
        private readonly Lazy<IStaffsService> _staffsService;
        private readonly Lazy<IOrdersService> _ordersService;

        private readonly IRepositoryManager _repositoryManager;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;
            this._categoriesService = new Lazy<ICategoriesService>(() => new CategoriesService(_repositoryManager));
            this._brandsService = new Lazy<IBrandsService>(() => new BrandsService(_repositoryManager));
            this._productsService = new Lazy<IProductsService>(() => new ProductsService(_repositoryManager));
            this._customersService = new Lazy<ICustomersService>(() => new CustomersService(_repositoryManager));
            this._storesService = new Lazy<IStoresService>(() => new StoresService(_repositoryManager));
            this._staffsService = new Lazy<IStaffsService>(() => new StaffsService(_repositoryManager));
            this._ordersService = new Lazy<IOrdersService>(() => new OrdersService(_repositoryManager));
        }

        public ICategoriesService CategoriesService => _categoriesService.Value;
        public IBrandsService BrandsService => _brandsService.Value;
        public IProductsService ProductsService => _productsService.Value;
        public ICustomersService CustomersService => _customersService.Value;
        public IStoresService StoresService => _storesService.Value;
        public IStaffsService StaffsService => _staffsService.Value;
        public IOrdersService OrdersService => _ordersService.Value;
    }
}