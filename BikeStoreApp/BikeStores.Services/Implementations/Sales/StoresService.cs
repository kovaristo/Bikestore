using BikeStores.Contracts;
using BikeStores.Contracts.Sales.Stores;
using BikeStores.Domain.Entities.Sales;
using BikeStores.Domain.Exceptions.Sales;
using BikeStores.Domain.Repositories;
using BikeStores.Services.Abstractions;
using Mapster;

namespace BikeStores.Services.Implementations.Sales
{
    public class StoresService : BaseService, IStoresService
    {
        public StoresService(IRepositoryManager repositoryManager) : base(repositoryManager)
        {
        }

        public async Task<int> CreateStoreAsync(StoreForCreateOrUpdateDTO store, CancellationToken cancellationToken)
        {
            var storeEntity = store.Adapt<Store>();
            await RepositoryManager.StoresRepository.CreateAsync(storeEntity, cancellationToken);
            await RepositoryManager.UnitOfWork.SaveChangesAsync();
            return storeEntity.Id;
        }

        public async Task DeleteStoreAsync(int storeId, CancellationToken cancellationToken)
        {
            var storeFound = await RepositoryManager.StoresRepository.GetByIdAsync(storeId, cancellationToken);
            if (storeFound == null)
                throw new StoreNotFoundException(storeId);

            await RepositoryManager.StoresRepository.DeleteAsync(storeFound, cancellationToken);
            await RepositoryManager.UnitOfWork.SaveChangesAsync();
        }

        public async Task<StoreDTO> GetByIdAsync(int storeId, CancellationToken cancellationToken)
        {
            var storeFound = await RepositoryManager.StoresRepository.GetByIdAsync(storeId, cancellationToken);
            if (storeFound == null)
                throw new StoreNotFoundException(storeId);

            return storeFound.Adapt<StoreDTO>();
        }

        public async Task<PagingResponse<StoreDTO>> GetStoresPageAsync(StoreFilterRequest storePageRequest, PagingRequest<StoreDTO> pagingRequest, CancellationToken cancellationToken)
        {
            var currentPage = await RepositoryManager.StoresRepository.GetByNameAndLocationAsync(storePageRequest.Name, storePageRequest.Street, storePageRequest.City, pagingRequest.OrderField, pagingRequest.Ascending, pagingRequest.StartIndex(), pagingRequest.PageSize, cancellationToken);
            return new PagingResponse<StoreDTO>(currentPage.Data.Adapt<IEnumerable<StoreDTO>>().ToArray(), currentPage.Total, pagingRequest);
        }

        public async Task UpdateStoreAsync(int storeId, StoreForCreateOrUpdateDTO store, CancellationToken cancellationToken)
        {
            var storeFound = await RepositoryManager.StoresRepository.GetByIdAsync(storeId, cancellationToken);
            if (storeFound == null)
                throw new StoreNotFoundException(storeId);

            store.Adapt(storeFound);

            await RepositoryManager.StoresRepository.UpdateAsync(storeFound, cancellationToken);
            await RepositoryManager.UnitOfWork.SaveChangesAsync();
        }
    }
}
