using BikeStores.Contracts;
using BikeStores.Contracts.Production.Categories;

namespace BikeStores.Services.Abstractions.Production
{
    public interface ICategoriesService
    {
        Task<PagingResponse<CategoryDTO>> GetCategoriesPageAsync(CategoryFilterRequest categoryPageRequest, PagingRequest<CategoryDTO> pagingRequest, CancellationToken cancellationToken);
        Task<CategoryDTO> GetByIdAsync(int categoryId, CancellationToken cancellationToken);

        Task<int> CreateCategoryAsync(CategoryForCreateOrUpdateDTO category, CancellationToken cancellationToken);
        Task UpdateCategoryAsync(int categoryId, CategoryForCreateOrUpdateDTO category, CancellationToken cancellationToken);
        Task DeleteCategoryAsync(int categoryId, CancellationToken cancellationToken);
    }
}