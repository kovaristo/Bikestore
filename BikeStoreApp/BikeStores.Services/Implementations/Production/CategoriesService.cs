using BikeStores.Contracts;
using BikeStores.Contracts.Production.Categories;
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
    public class CategoriesService : BaseService, ICategoriesService
    {
        public CategoriesService(IRepositoryManager repositoryManager) : base(repositoryManager)
        {
        }

        public async Task<int> CreateCategoryAsync(CategoryForCreateOrUpdateDTO category, CancellationToken cancellationToken)
        {
            var categoryEntity = category.Adapt<Category>();
            await RepositoryManager.CategoriesRepository.CreateAsync(categoryEntity, cancellationToken);
            await RepositoryManager.UnitOfWork.SaveChangesAsync();
            return categoryEntity.Id;
        }

        public async Task DeleteCategoryAsync(int categoryId, CancellationToken cancellationToken)
        {
            var categoryFound = await RepositoryManager.CategoriesRepository.GetByIdAsync(categoryId, cancellationToken);
            if (categoryFound == null)
                throw new CategoryNotFoundException(categoryId);

            await RepositoryManager.CategoriesRepository.DeleteAsync(categoryFound, cancellationToken);
            await RepositoryManager.UnitOfWork.SaveChangesAsync();
        }

        public async Task<CategoryDTO> GetByIdAsync(int categoryId, CancellationToken cancellationToken)
        {
            var categoryFound = await RepositoryManager.CategoriesRepository.GetByIdAsync(categoryId, cancellationToken);

            if (categoryFound == null)
                throw new CategoryNotFoundException(categoryId);

            return categoryFound.Adapt<CategoryDTO>();
        }

        public async Task<PagingResponse<CategoryDTO>> GetCategoriesPageAsync(CategoryFilterRequest categoryPageRequest, PagingRequest<CategoryDTO> pagingRequest, CancellationToken cancellationToken)
        {
            var currentPage = await RepositoryManager.CategoriesRepository.GetByNameAsync(categoryPageRequest.Name, pagingRequest.OrderField, pagingRequest.Ascending, pagingRequest.StartIndex(), pagingRequest.PageSize, cancellationToken);
            return new PagingResponse<CategoryDTO>(currentPage.Data.Adapt<IEnumerable<CategoryDTO>>().ToArray(), currentPage.Total, pagingRequest);
        }

        public async Task UpdateCategoryAsync(int categoryId, CategoryForCreateOrUpdateDTO category, CancellationToken cancellationToken)
        {
            var categoryFound = await RepositoryManager.CategoriesRepository.GetByIdAsync(categoryId, cancellationToken);
            if (categoryFound == null)
                throw new CategoryNotFoundException(categoryId);

            category.Adapt(categoryFound);

            await RepositoryManager.CategoriesRepository.UpdateAsync(categoryFound, cancellationToken);
            await RepositoryManager.UnitOfWork.SaveChangesAsync();
        }
    }
}
