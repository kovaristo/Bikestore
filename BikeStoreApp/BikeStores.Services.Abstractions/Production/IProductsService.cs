using BikeStores.Contracts;
using BikeStores.Contracts.Production.Products;

namespace BikeStores.Services.Abstractions.Production
{
    public interface IProductsService
    {
        Task<PagingResponse<ProductDTO>> GetProductsPageAsync(ProductFilterRequest productPageRequest, PagingRequest<ProductDTO> pagingRequest, CancellationToken cancellationToken);
        Task<ProductDTO> GetByIdAsync(int productId, CancellationToken cancellationToken);

        Task<int> CreateProductAsync(ProductForCreateOrUpdateDTO product, CancellationToken cancellationToken);
        Task UpdateProductAsync(int productId, ProductForCreateOrUpdateDTO product, CancellationToken cancellationToken);
        Task DeleteProductAsync(int productId, CancellationToken cancellationToken);
    }
}
