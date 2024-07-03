using BikeStores.Contracts;
using BikeStores.Contracts.Production.Brands;
using BikeStores.Domain.Response;
using BikeStores.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace BikeStores.Presentation.Controllers.Production
{
    [ApiController]
    [Route("[controller]")]
    public class BrandsController : BaseServiceController
    {
        public BrandsController(ILogger<BrandsController> logger, IServiceManager serviceManager) : base(logger, serviceManager)
        {
        }

        /// <summary>
        /// Get brands with filtering and paging
        /// </summary>
        /// <param name="brandFilterRequest">Brand data to filter</param>
        /// <param name="pagingRequest">Paging parameters</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet(Name = "GetBrands")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(PagingResponse<BrandDTO>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetBrandsAsync([FromQuery] BrandFilterRequest brandFilterRequest, [FromQuery] PagingRequest<BrandDTO> pagingRequest, CancellationToken cancellationToken)
        {
            var brandDTOs = await ServiceManager.BrandsService.GetBrandsPageAsync(brandFilterRequest, pagingRequest, cancellationToken);
            return Ok(brandDTOs);
        }

        /// <summary>
        /// Get brand with selected id
        /// </summary>
        /// <param name="brandId">Brand id</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{brandId:int}", Name = "GetBrandById")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(BrandDTO))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetBrandByIdAsync(int brandId, CancellationToken cancellationToken)
        {
            var brandDTO = await ServiceManager.BrandsService.GetByIdAsync(brandId, cancellationToken);
            return Ok(brandDTO);
        }

        /// <summary>
        /// Creates brand
        /// </summary>
        /// <param name="brandCreateRequest">Brand data to create</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateBrand")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> CreateBrandAsync([FromBody] BrandForCreateOrUpdateDTO brandCreateRequest, CancellationToken cancellationToken)
        {
            int brandId = await ServiceManager.BrandsService.CreateBrandAsync(brandCreateRequest, cancellationToken);
            return CreatedAtRoute("GetBrandById", new { brandId = brandId }, value: brandCreateRequest);
        }

        /// <summary>
        /// Updates selected brand
        /// </summary>
        /// <param name="brandId">Brand identifier</param>
        /// <param name="brandUpdateRequest">Brand data to update</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{brandId:int}", Name = "UpdateBrand")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> UpdateBrandAsync([FromRoute] int brandId, [FromBody] BrandForCreateOrUpdateDTO brandUpdateRequest, CancellationToken cancellationToken)
        {
            await ServiceManager.BrandsService.UpdateBrandAsync(brandId, brandUpdateRequest, cancellationToken);
            return Ok();
        }

        /// <summary>
        /// Deletes selected brand
        /// </summary>
        /// <param name="brandId">Brand identifier</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{brandId:int}", Name = "DeleteBrand")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> DeleteBrandAsync([FromRoute] int brandId, CancellationToken cancellationToken)
        {
            await ServiceManager.BrandsService.DeleteBrandAsync(brandId, cancellationToken);
            return Ok();
        }
    }
}
