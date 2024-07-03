using BikeStores.Contracts;
using BikeStores.Contracts.Production.Brands;
using BikeStores.Domain.Entities.Production;
using BikeStores.Domain.Exceptions.Production;
using BikeStores.Domain.Repositories;
using BikeStores.Services.Abstractions.Production;
using Mapster;

namespace BikeStores.Services.Implementations.Production
{
    public class BrandsService : BaseService, IBrandsService
    {
        public BrandsService(IRepositoryManager repositoryManager) : base(repositoryManager)
        {
        }

        public async Task<int> CreateBrandAsync(BrandForCreateOrUpdateDTO brand, CancellationToken cancellationToken)
        {
            var brandEntity = brand.Adapt<Brand>();
            await RepositoryManager.BrandsRepository.CreateAsync(brandEntity, cancellationToken);
            await RepositoryManager.UnitOfWork.SaveChangesAsync();
            return brandEntity.Id;
        }

        public async Task DeleteBrandAsync(int brandId, CancellationToken cancellationToken)
        {
            var brandFound = await RepositoryManager.BrandsRepository.GetByIdAsync(brandId, cancellationToken);
            if (brandFound == null)
                throw new BrandNotFoundException(brandId);

            await RepositoryManager.BrandsRepository.DeleteAsync(brandFound, cancellationToken);
            await RepositoryManager.UnitOfWork.SaveChangesAsync();
        }

        public async Task<PagingResponse<BrandDTO>> GetBrandsPageAsync(BrandFilterRequest brandPageRequest, PagingRequest<BrandDTO> pagingRequest, CancellationToken cancellationToken)
        {
            var currentPage = await RepositoryManager.BrandsRepository.GetByNameAsync(brandPageRequest.Name, pagingRequest.OrderField, pagingRequest.Ascending, pagingRequest.StartIndex(), pagingRequest.PageSize, cancellationToken);
            return new PagingResponse<BrandDTO>(currentPage.Data.Adapt<IEnumerable<BrandDTO>>().ToArray(), currentPage.Total, pagingRequest);
        }

        public async Task<BrandDTO> GetByIdAsync(int brandId, CancellationToken cancellationToken)
        {
            var brandFound = await RepositoryManager.BrandsRepository.GetByIdAsync(brandId, cancellationToken);

            if (brandFound == null)
                throw new BrandNotFoundException(brandId);

            return brandFound.Adapt<BrandDTO>();
        }

        public async Task UpdateBrandAsync(int brandId, BrandForCreateOrUpdateDTO brand, CancellationToken cancellationToken)
        {
            var brandFound = await RepositoryManager.BrandsRepository.GetByIdAsync(brandId, cancellationToken);
            if (brandFound == null)
                throw new BrandNotFoundException(brandId);

            brand.Adapt(brandFound);

            await RepositoryManager.BrandsRepository.UpdateAsync(brandFound, cancellationToken);
            await RepositoryManager.UnitOfWork.SaveChangesAsync();
        }
    }
}
