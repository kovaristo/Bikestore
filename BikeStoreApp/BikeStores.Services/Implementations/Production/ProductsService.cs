using BikeStores.Contracts;
using BikeStores.Contracts.Production.Products;
using BikeStores.Domain.Entities;
using BikeStores.Domain.Entities.Production;
using BikeStores.Domain.Exceptions.Production;
using BikeStores.Domain.Repositories;
using BikeStores.Services.Abstractions.Production;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Services.Implementations.Production
{
    public class ProductsService : BaseService, IProductsService
    {
        public ProductsService(IRepositoryManager repositoryManager) : base(repositoryManager)
        {
        }

        public async Task<int> CreateProductAsync(ProductForCreateOrUpdateDTO product, CancellationToken cancellationToken)
        {
            var productEntity = product.Adapt<Product>();
            await RepositoryManager.ProductsRepository.CreateAsync(productEntity, cancellationToken);
            await RepositoryManager.UnitOfWork.SaveChangesAsync();
            return productEntity.Id;
        }

        public async Task DeleteProductAsync(int productId, CancellationToken cancellationToken)
        {
            var productFound = await RepositoryManager.ProductsRepository.GetByIdAsync(productId, cancellationToken);
            if (productFound == null)
                throw new ProductNotFoundException(productId);

            await RepositoryManager.ProductsRepository.DeleteAsync(productFound, cancellationToken);
            await RepositoryManager.UnitOfWork.SaveChangesAsync();
        }

        public async Task<ProductDTO> GetByIdAsync(int productId, CancellationToken cancellationToken)
        {
            var productFound = await RepositoryManager.ProductsRepository.GetByIdAsync(productId, cancellationToken);

            if (productFound == null)
                throw new ProductNotFoundException(productId);

            return productFound.Adapt<ProductDTO>();
        }

        public async Task<PagingResponse<ProductDTO>> GetProductsPageAsync(ProductFilterRequest productPageRequest, PagingRequest<ProductDTO> pagingRequest, CancellationToken cancellationToken)
        {
            var currentPage = await RepositoryManager.ProductsRepository.GetByNameYearsAndPricesAsync(productPageRequest.Name, productPageRequest.ModelYears, productPageRequest.MinListPrice, productPageRequest.MaxListPrice, pagingRequest.OrderField, pagingRequest.Ascending, pagingRequest.StartIndex(), pagingRequest.PageSize, cancellationToken);
            return new PagingResponse<ProductDTO>(currentPage.Data.Adapt<IEnumerable<ProductDTO>>().ToArray(), currentPage.Total, pagingRequest);
        }

        public async Task UpdateProductAsync(int productId, ProductForCreateOrUpdateDTO product, CancellationToken cancellationToken)
        {
            var productFound = await RepositoryManager.ProductsRepository.GetByIdAsync(productId, cancellationToken);
            if (productFound == null)
                throw new ProductNotFoundException(productId);

            product.Adapt(productFound);

            await RepositoryManager.ProductsRepository.UpdateAsync(productFound, cancellationToken);
            await RepositoryManager.UnitOfWork.SaveChangesAsync();
        }
    }
}
