using BikeStores.Domain.Repositories;
using BikeStores.Domain.Repositories.Production;
using BikeStores.Domain.Repositories.Sales;
using BikeStores.Persistence.Repositories.Production;
using BikeStores.Persistence.Repositories.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Persistence.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<ICategoriesRepository> _lazyCategoriesRepository;
        private readonly Lazy<IBrandsRepository> _lazyBrandsRepository;
        private readonly Lazy<IProductsRepository> _lazyProductsRepository;
        private readonly Lazy<IStoresRepository> _lazyStoresRepository;
        private readonly Lazy<ICustomersRepository> _lazyCustomersRepository;
        private readonly Lazy<IStaffsRepository> _lazyStaffsRepository;
        private readonly Lazy<IOrdersRepository> _lazyOrdersRepository;

        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(RepositoryDbContext repoDbContext)
        {
            _lazyCategoriesRepository = new Lazy<ICategoriesRepository>(() => new CategoriesRepository(repoDbContext));
            _lazyBrandsRepository = new Lazy<IBrandsRepository>(() => new BrandsRepository(repoDbContext));
            _lazyProductsRepository = new Lazy<IProductsRepository>(() => new ProductsRepository(repoDbContext));
            _lazyStoresRepository = new Lazy<IStoresRepository>(() => new StoresRepository(repoDbContext));
            _lazyCustomersRepository = new Lazy<ICustomersRepository>(() => new CustomersRepository(repoDbContext));
            _lazyStaffsRepository = new Lazy<IStaffsRepository>(() => new StaffsRepository(repoDbContext));
            _lazyOrdersRepository = new Lazy<IOrdersRepository>(() => new OrdersRepository(repoDbContext));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(repoDbContext));
        }

        public ICategoriesRepository CategoriesRepository => _lazyCategoriesRepository.Value;
        public IBrandsRepository BrandsRepository => _lazyBrandsRepository.Value;
        public IProductsRepository ProductsRepository => _lazyProductsRepository.Value;
        public ICustomersRepository CustomersRepository => _lazyCustomersRepository.Value;
        public IStoresRepository StoresRepository => _lazyStoresRepository.Value;
        public IStaffsRepository StaffsRepository => _lazyStaffsRepository.Value;
        public IOrdersRepository OrdersRepository => _lazyOrdersRepository.Value;

        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    }
}
