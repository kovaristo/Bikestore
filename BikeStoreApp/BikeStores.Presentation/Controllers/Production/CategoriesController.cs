using BikeStores.Contracts;
using BikeStores.Contracts.Production.Categories;
using BikeStores.Domain.Response;
using BikeStores.Services.Abstractions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Presentation.Controllers.Production
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : BaseServiceController
    {
        private readonly IValidator<PagingRequest<CategoryDTO>> categoriesPagingValidator;

        public CategoriesController(ILogger<CategoriesController> logger, IServiceManager serviceManager, IValidator<PagingRequest<CategoryDTO>> categoriesPagingValidator) : base(logger, serviceManager)
        {
            this.categoriesPagingValidator = categoriesPagingValidator;
        }

        /// <summary>
        /// Get categories with filtering and paging
        /// </summary>
        /// <param name="categoryFilterRequest">Category data to filter</param>
        /// <param name="pagingRequest">Paging parameters</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet(Name = "GetCategories")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(PagingResponse<CategoryDTO>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetCategoriesAsync([FromQuery]CategoryFilterRequest categoryFilterRequest, [FromQuery]PagingRequest<CategoryDTO> pagingRequest, CancellationToken cancellationToken)
        {
            var categoryDTOs = await ServiceManager.CategoriesService.GetCategoriesPageAsync(categoryFilterRequest, pagingRequest, cancellationToken);
            return Ok(categoryDTOs);
        }

        /// <summary>
        /// Gets category with selected id
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{categoryId:int}", Name = "GetCategoryById")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(CategoryDTO))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetCategoryByIdAsync(int categoryId, CancellationToken cancellationToken)
        {
            var categoryDTO = await ServiceManager.CategoriesService.GetByIdAsync(categoryId, cancellationToken);
            return Ok(categoryDTO);
        }

        /// <summary>
        /// Creates category
        /// </summary>
        /// <param name="categoryCreateRequest">Category data to create</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateCategory")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> CreateCategoryAsync([FromBody]CategoryForCreateOrUpdateDTO categoryCreateRequest, CancellationToken cancellationToken)
        {
            int categoryId = await ServiceManager.CategoriesService.CreateCategoryAsync(categoryCreateRequest, cancellationToken);
            return CreatedAtRoute("GetCategoryById", new { categoryId = categoryId }, value: categoryCreateRequest);
        }

        /// <summary>
        /// Updates selected category
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <param name="categoryUpdateRequest">Category data to update</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{categoryId:int}", Name = "UpdateCategory")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> UpdateCategoryAsync([FromRoute]int categoryId, [FromBody] CategoryForCreateOrUpdateDTO categoryUpdateRequest, CancellationToken cancellationToken)
        {
            await ServiceManager.CategoriesService.UpdateCategoryAsync(categoryId, categoryUpdateRequest, cancellationToken);
            return Ok();
        }

        /// <summary>
        /// Deletes selected category
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{categoryId:int}", Name = "DeleteCategory")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> DeleteCategoryAsync([FromRoute] int categoryId, CancellationToken cancellationToken)
        {
            await ServiceManager.CategoriesService.DeleteCategoryAsync(categoryId, cancellationToken);
            return Ok();
        }

    }
}
