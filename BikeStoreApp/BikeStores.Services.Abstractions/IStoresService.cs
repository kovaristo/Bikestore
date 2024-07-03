using BikeStores.Contracts;
using BikeStores.Contracts.Sales.Stores;

namespace BikeStores.Services.Abstractions
{
    public interface IStoresService
    {
        Task<StoreDTO> GetByIdAsync(int storeId, CancellationToken cancellationToken);
        Task<PagingResponse<StoreDTO>> GetStoresPageAsync(StoreFilterRequest storePageRequest, PagingRequest<StoreDTO> pagingRequest, CancellationToken cancellationToken);
        Task<int> CreateStoreAsync(StoreForCreateOrUpdateDTO storeCreateRequest, CancellationToken cancellationToken);
        Task UpdateStoreAsync(int storeId, StoreForCreateOrUpdateDTO store, CancellationToken cancellationToken);
        Task DeleteStoreAsync(int storeId, CancellationToken cancellationToken);
    }
}
