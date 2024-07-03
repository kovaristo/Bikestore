using BikeStores.Contracts;
using BikeStores.Contracts.Production.Brands;

namespace BikeStores.Services.Abstractions.Production
{
    public interface IBrandsService
    {
        Task<BrandDTO> GetByIdAsync(int brandId, CancellationToken cancellationToken);

        Task<PagingResponse<BrandDTO>> GetBrandsPageAsync(BrandFilterRequest categoryPageRequest, PagingRequest<BrandDTO> pagingRequest, CancellationToken cancellationToken);
        Task<int> CreateBrandAsync(BrandForCreateOrUpdateDTO brand, CancellationToken cancellationToken);
        Task UpdateBrandAsync(int brandId, BrandForCreateOrUpdateDTO brand, CancellationToken cancellationToken);
        Task DeleteBrandAsync(int brandId, CancellationToken cancellationToken);
    }
}
